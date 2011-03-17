/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: MainForm.cs 3211 2010-10-03 03:35:32Z unknown $

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

*******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using Microsoft.CSharp;
using System.Threading;
using System.CodeDom.Compiler;
using NLocalizer;

namespace NLocalizerApp
{
    public partial class MainForm : Form
    {
        private CompilerResults compiler = null;
        private int compileCounter = 0;
        private Translation translation = new Translation();
        private bool edited = false;
        private DataTable table = new DataTable();
        private DataColumn formColumn = new DataColumn("Form");
        private DataColumn propertyColumn = new DataColumn("Property");

        public MainForm()
        {
            InitializeComponent();
            BindingSource bs = new BindingSource(table, "");
            TranslationGrid.DataSource = bs;
            table.Columns.Add(formColumn);
            table.Columns.Add(propertyColumn);
            table.PrimaryKey = new DataColumn[] { formColumn, propertyColumn };
            TranslationGrid.Columns["Form"].DefaultCellStyle.BackColor = Color.AntiqueWhite;
            TranslationGrid.Columns["Property"].DefaultCellStyle.BackColor = Color.AntiqueWhite;
            FillTable();
            EditedStatusLabel.Text = "Empty";
            formColumn.ReadOnly = true;
            propertyColumn.ReadOnly = true;
        }

        private Type CompileAndGetType()
        {
            compiler = RuntimeCompiler.Compile(translation,
                Path.GetDirectoryName(OpenFileDialog.FileName));
            if (compiler == null)
                MessageBox.Show("Unnable to compile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (compiler.Errors.Count > 0)
            {
                string errors = "Compile error:\r\n";
                for(int i = 0; i < compiler.Errors.Count; i++)
                    errors += compiler.Errors[i].ErrorText;
            }
            Type type = RuntimeCompiler.GetCompiledClass(compiler);
            compileCounter++;
            return type;
        }

        private void FillTable()
        {
            foreach (KeyValuePair<string, TranslationClasses> item in translation)
                if (table.Columns.Contains(item.Key) == false)
                    table.Columns.Add(item.Key);

            foreach (DataColumn item in table.Columns)
                if (item.ColumnName != formColumn.ColumnName &&
                    item.ColumnName != propertyColumn.ColumnName &&
                    translation.Exists(item.Caption) == false)
                    table.Columns.Remove(item);

            if (TranslationGrid.Columns["Neutral"] != null)
            {
                TranslationGrid.Columns["Neutral"].ReadOnly = true;
                TranslationGrid.Columns["Neutral"].DefaultCellStyle.BackColor = Color.LightGray;
            }

            table.Rows.Clear();
            if (translation.Exists("English"))
                foreach(KeyValuePair<string, TranslationProperties> cl in translation["English"])
                    foreach (KeyValuePair<string, string> prop in cl.Value)
                    {
                        bool found = SearchTextBox.Text == "" || 
                            Regex.IsMatch(cl.Key, SearchTextBox.Text, RegexOptions.IgnoreCase) ||
                            Regex.IsMatch(prop.Key, SearchTextBox.Text, RegexOptions.IgnoreCase);
                        if (found == false)
                            foreach(KeyValuePair<string, TranslationClasses> lang in translation)
                                if (Regex.IsMatch(translation.GetText(lang.Key, cl.Key, prop.Key),
                                    SearchTextBox.Text, RegexOptions.IgnoreCase))
                                    found = true;
                        if (found)
                        {
                            DataRow row = table.Rows.Find(new object[] { cl.Key, prop.Key });
                            if (row == null)
                                row = table.Rows.Add(cl.Key, prop.Key);
                            row.BeginEdit();
                            foreach (KeyValuePair<string, TranslationClasses> lang in translation)
                                if (translation.Exists(lang.Key, cl.Key, prop.Key))
                                    row[lang.Key] = translation.GetText(lang.Key, cl.Key, prop.Key);
                                else
                                    row[lang.Key] = "***" + translation.GetText(lang.Key, cl.Key, prop.Key);
                            row.AcceptChanges();
                        }
                    }
        }

        private void FillClasses()
        {
            FormDropDownButton.DropDownItems.Clear();
            if (translation.Exists("English"))
                foreach (KeyValuePair<string, TranslationProperties> item in translation["English"])
                    FormDropDownButton.DropDownItems.Add(item.Key);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    translation.Clear();
                    translation.Read(Path.GetDirectoryName(OpenFileDialog.FileName));
                    FillClasses();
                    FillTable();
                    InfoStatusLabel.Text = "Language files opened";
                    ImportFolderDialog.SelectedPath = Path.GetDirectoryName(OpenFileDialog.FileName);
                    edited = false;
                    EditedStatusLabel.Text = "Saved";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                translation.Write(Path.GetDirectoryName(OpenFileDialog.FileName));
                InfoStatusLabel.Text = "Language files saved";
                edited = false;
                EditedStatusLabel.Text = "Saved";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FillTable();
            InfoStatusLabel.Text = "Found " + TranslationGrid.Rows.Count.ToString() + " rows";
        }

        private void FormDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SearchTextBox.Text = e.ClickedItem.Text;
            SearchButton_Click(sender, e);
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchButton_Click(sender, e);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (ImportFolderDialog.ShowDialog() == DialogResult.OK)
            {
                using (ImportForm form = new ImportForm())
                {
                    foreach(string fileName in Directory.GetFiles(
                        ImportFolderDialog.SelectedPath, "*.cs", SearchOption.AllDirectories))
                        if (fileName.EndsWith("Designer.cs") && (fileName.IndexOf(@"\Properties\") < 0))
                            form.FilesListBox.Items.Add(fileName, true);
                        else if (fileName.IndexOf("Messages") >= 0)
                            form.FilesListBox.Items.Add(fileName, true);
                        else if (fileName.IndexOf(@"\Properties\") < 0)
                            form.FilesListBox.Items.Add(fileName, false);
                    form.Translation = translation;
                    form.ShowDialog();
                    FillClasses();
                    FillTable();
                    SearchTextBox.Text = "Source files imported";
                }
            }
        }

        private void TranslationGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string languageName = TranslationGrid.Columns[e.ColumnIndex].HeaderText;
                string formName = (string)TranslationGrid.Rows[e.RowIndex].Cells["Form"].Value;
                string propertyName = (string)TranslationGrid.Rows[e.RowIndex].Cells["Property"].Value;
                string value = (string)TranslationGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (translation.GetText(languageName, formName, propertyName) != value)
                {
                    translation.SetText(languageName, formName, propertyName, value);
                    edited = true;
                    EditedStatusLabel.Text = "Not saved";
                }
            }
            catch
            {
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (edited &&
                MessageBox.Show("There are not saved, edited messages.\r\nAre You sure to close application?",
                    "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}