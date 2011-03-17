/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: ImportForm.cs 3211 2010-10-03 03:35:32Z unknown $

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
using NLocalizer;

namespace NLocalizerApp
{
    public partial class ImportForm : Form
    {
        public Translation Translation = null;
        public bool FinishReadCs = false;
        public bool FinishGetTranslation = false;
        public bool FinishWriteCs = false;

        public ImportForm()
        {
            InitializeComponent();
        }

        private void ReadClassName(string fileName, string line, string prefix, ref string className)
        {
            if (className == "")
                className = line.Substring(prefix.Length).Trim();
            else
                throw new Exception(String.Format("Expected one class in file {0}", fileName));
        }

        private void ReadString(string fileName, string[] lines, ref int pos, string prefix, string className)
        {
            string line = lines[pos].Trim();
            line = line.Substring(prefix.Length).Trim();
            if (line.EndsWith("\";"))
                line = line.Substring(0, line.Length - 2).Trim();
            else if (line.EndsWith("\" +"))
            {
                line = line.Substring(0, line.Length - "\" +".Length).Trim();
                pos++;
                while (pos < lines.Length && lines[pos].Trim().EndsWith("\";") == false)
                {
                    string addLine = lines[pos].Trim();
                    if (addLine.StartsWith("\"") == false)
                        throw new Exception(String.Format(
                            "Expected start \" in file {0}, pos {0}", fileName, pos));
                    addLine = addLine.Substring(1).Trim();
                    if (addLine.EndsWith("\" +") == false)
                        throw new Exception(String.Format(
                            "Expected end \" + in file {0}, pos {0}", fileName, pos));
                    addLine = addLine.Substring(0, addLine.Length - "\" +".Length).Trim();
                    line += addLine;
                    pos++;
                }
                string lastLine = lines[pos].Trim();
                if (lastLine.StartsWith("\"") == false)
                    throw new Exception(String.Format(
                        "Expected start \" in file {0}, pos {0}", fileName, pos));
                lastLine = lastLine.Substring(1).Trim();
                if (lastLine.EndsWith("\";") == false)
                    throw new Exception(String.Format(
                        "Expected end \"; in file {0}, pos {0}", fileName, pos));
                lastLine = lastLine.Substring(0, lastLine.Length - "\";".Length).Trim();
                line += lastLine;
            }
            int equ = line.IndexOf(" = \"");
            if (equ < 0)
                throw new Exception(String.Format(
                    "Expected = \"; in file {0}, pos {0}", fileName, pos));
            line = line.Remove(equ, " = \"".Length);
            line = line.Insert(equ, " = ");

            bool isDisallow = line.StartsWith("Name = ");

            string[] item = line.Split(new string[] { ".Name = " }, StringSplitOptions.RemoveEmptyEntries);
            if (item.Length == 2 && item[0].Trim() == item[1].Trim())
                isDisallow = true;

            foreach (string disallow in DisallowSuffixesTextBox.Lines)
                if (line.IndexOf(disallow + " = \"") >= 0)
                    isDisallow = true;
            if (isDisallow == false && className != "")
                TranslationListBox.Items.Add("(" + className + ")" + line, true);
        }

        private void ReadCsFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            string className = "";
            int pos = 0;
            while (pos < lines.Length)
            {
                string line = lines[pos].Trim();
                if (line.StartsWith("partial class "))
                    ReadClassName(fileName, line, "partial class ", ref className);
                else if (line.StartsWith("class "))
                    ReadClassName(fileName, line, "class ", ref className);
                else if (line.StartsWith("public class "))
                    ReadClassName(fileName, line, "public class ", ref className);
                else if (line.StartsWith("public string ") && line.IndexOf("= \"") > 0)
                    ReadString(fileName, lines, ref pos, "public string ", className);
                else if (line.StartsWith("this.") && line.IndexOf(" = \"") > 0)
                    ReadString(fileName, lines, ref pos, "this.", className);
                pos++;
            }
        }

        private void ReadCsFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string fileName in FilesListBox.CheckedItems)
                    ReadCsFile(fileName);
                TabControl.SelectTab(TranslationTab);
                //MessageBox.Show("OK, all source files ready to get translation", "Information",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FinishReadCs = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteCsFile(string fileName, List<string> components)
        {
            string[] lines = File.ReadAllLines(fileName);
            bool changed = false;
            int pos = 0;
            while (pos < lines.Length)
            {
                string line = lines[pos].Trim();
                if (line.StartsWith("private "))
                    foreach(string component in components)
                        if (line.EndsWith(component + ";"))
                        {
                            int privatePos = lines[pos].IndexOf("private ");
                            lines[pos] = lines[pos].Remove(privatePos, "private ".Length);
                            lines[pos] = lines[pos].Insert(privatePos, "public ");
                            changed = true;
                            break;
                        }
                pos++;
            }
            if (changed)
                File.WriteAllLines(fileName, lines);
        }

        private void WriteCsFilesButton_Click(object sender, EventArgs e)
        {
            if (FinishGetTranslation == false)
                MessageBox.Show("Click Get Translation button first", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (MessageBox.Show("Correct all private components to public?", "Confirm", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                try
                {
                    List<string> components = new List<string>();
                    foreach (string item in TranslationListBox.CheckedItems)
                    {
                        int bracketPos = item.IndexOf(")");
                        if (bracketPos < 0)
                            throw new Exception(String.Format("Bad definition {0}", item));

                        string line = item.Substring(bracketPos + 1);
                        int pointPos = line.IndexOf(".");
                        if (pointPos > 0)
                        {
                            string component = line.Substring(0, pointPos);
                            if (components.Contains(component) == false)
                                components.Add(component);
                        }
                    }
                    foreach (string fileName in FilesListBox.CheckedItems)
                        WriteCsFile(fileName, components);
                    MessageBox.Show("OK, source .cs files modified\r\nAll components are public", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FinishWriteCs = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }

        private void GetTranslationButton_Click(object sender, EventArgs e)
        {
            if (FinishReadCs == false)
                MessageBox.Show("Please read cs files first", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                try
                {
                    List<string> lines = new List<string>();
                    foreach (string item in TranslationListBox.CheckedItems)
                        lines.Add(item);
                    Translation.Read("Neutral", lines.ToArray());
                    foreach (KeyValuePair<string, TranslationProperties> cl in Translation["Neutral"])
                        foreach (KeyValuePair<string, string> prop in cl.Value)
                            if (Translation.Exists("English", cl.Key, prop.Key) == false)
                                Translation.SetText("English", cl.Key, prop.Key, prop.Value);
                    MessageBox.Show("OK, translation Neutral is ready to work", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FinishGetTranslation = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
