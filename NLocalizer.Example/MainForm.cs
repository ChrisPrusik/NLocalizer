/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: MainForm.cs 3213 2010-10-03 04:23:36Z unknown $

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
using System.Windows.Forms;
using NLocalizer;

namespace NLocalizer.Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenFileMenu_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
        }

        private void SaveFileMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog.ShowDialog();
        }

        private void BrowseFolderMenu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.ShowDialog();
        }

        private void ExampleFontMenu_Click(object sender, EventArgs e)
        {
            FontDialog.ShowDialog();
        }

        private void SelectColorMenu_Click(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
        }

        private void TestFormMenu_Click(object sender, EventArgs e)
        {
            using (TestForm form = new TestForm())
            {
                try
                {
                    Translator.Translate(form);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Messages.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                form.ShowDialog();
            }
        }

        private void FillLanguagesMenu()
        {
            foreach (KeyValuePair<string, TranslationClasses> lang in Translator.Translation)
            {
                bool found = false;
                foreach (object item in LanguagesMenu.DropDownItems)
                    if (item is ToolStripMenuItem && 
                        ((ToolStripMenuItem)item).Text == lang.Key)
                        found = true;
                if (found == false)
                    LanguagesMenu.DropDownItems.Add(lang.Key);
            }
        }

        private void LoadLanguagesMenu_Click(object sender, EventArgs e)
        {
            try
            {
                Translator.Translation.Read();
                LanguageLabel.Text = Translator.Translation.CurrentLanguage;
                FillLanguagesMenu();
                Translator.Translate(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LanguagesMenu_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (Translator.Translation.Exists(e.ClickedItem.Text))
                try
                {
                    Translator.Translation.CurrentLanguage = e.ClickedItem.Text;
                    LanguageLabel.Text = Translator.Translation.CurrentLanguage;
                    Translator.Translate(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Messages.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLanguagesMenu_Click(sender, e);
        }

        private void MessageBoxMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Messages.HelloWorld, Messages.TitleInformation, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}