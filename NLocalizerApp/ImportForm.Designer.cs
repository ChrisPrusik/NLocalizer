/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: ImportForm.Designer.cs 3185 2010-10-01 00:44:06Z unknown $

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

*******************************************************************************/
namespace NLocalizerApp
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.GetTranslationButton = new System.Windows.Forms.Button();
            this.ReadFilesButton = new System.Windows.Forms.Button();
            this.WriteCsFilesButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.FilesTab = new System.Windows.Forms.TabPage();
            this.FilesListBox = new System.Windows.Forms.CheckedListBox();
            this.DisallowPropertiesTab = new System.Windows.Forms.TabPage();
            this.DisallowSuffixesTextBox = new System.Windows.Forms.TextBox();
            this.TranslationTab = new System.Windows.Forms.TabPage();
            this.TranslationListBox = new System.Windows.Forms.CheckedListBox();
            this.BottomPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.FilesTab.SuspendLayout();
            this.DisallowPropertiesTab.SuspendLayout();
            this.TranslationTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.OKButton);
            this.BottomPanel.Controls.Add(this.GetTranslationButton);
            this.BottomPanel.Controls.Add(this.ReadFilesButton);
            this.BottomPanel.Controls.Add(this.WriteCsFilesButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 381);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(559, 39);
            this.BottomPanel.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(447, 6);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // GetTranslationButton
            // 
            this.GetTranslationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GetTranslationButton.Location = new System.Drawing.Point(235, 6);
            this.GetTranslationButton.Name = "GetTranslationButton";
            this.GetTranslationButton.Size = new System.Drawing.Size(100, 23);
            this.GetTranslationButton.TabIndex = 2;
            this.GetTranslationButton.Text = "Get translation";
            this.GetTranslationButton.UseVisualStyleBackColor = true;
            this.GetTranslationButton.Click += new System.EventHandler(this.GetTranslationButton_Click);
            // 
            // ReadFilesButton
            // 
            this.ReadFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadFilesButton.Location = new System.Drawing.Point(129, 6);
            this.ReadFilesButton.Name = "ReadFilesButton";
            this.ReadFilesButton.Size = new System.Drawing.Size(100, 23);
            this.ReadFilesButton.TabIndex = 1;
            this.ReadFilesButton.Text = "Read .cs files";
            this.ReadFilesButton.UseVisualStyleBackColor = true;
            this.ReadFilesButton.Click += new System.EventHandler(this.ReadCsFilesButton_Click);
            // 
            // WriteCsFilesButton
            // 
            this.WriteCsFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WriteCsFilesButton.Location = new System.Drawing.Point(341, 6);
            this.WriteCsFilesButton.Name = "WriteCsFilesButton";
            this.WriteCsFilesButton.Size = new System.Drawing.Size(100, 23);
            this.WriteCsFilesButton.TabIndex = 0;
            this.WriteCsFilesButton.Text = "Write .cs files";
            this.WriteCsFilesButton.UseVisualStyleBackColor = true;
            this.WriteCsFilesButton.Click += new System.EventHandler(this.WriteCsFilesButton_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.FilesTab);
            this.TabControl.Controls.Add(this.DisallowPropertiesTab);
            this.TabControl.Controls.Add(this.TranslationTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(559, 381);
            this.TabControl.TabIndex = 1;
            // 
            // FilesTab
            // 
            this.FilesTab.Controls.Add(this.FilesListBox);
            this.FilesTab.Location = new System.Drawing.Point(4, 22);
            this.FilesTab.Name = "FilesTab";
            this.FilesTab.Padding = new System.Windows.Forms.Padding(3);
            this.FilesTab.Size = new System.Drawing.Size(551, 355);
            this.FilesTab.TabIndex = 2;
            this.FilesTab.Text = "Files";
            this.FilesTab.UseVisualStyleBackColor = true;
            // 
            // FilesListBox
            // 
            this.FilesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.Location = new System.Drawing.Point(3, 3);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(545, 349);
            this.FilesListBox.TabIndex = 1;
            // 
            // DisallowPropertiesTab
            // 
            this.DisallowPropertiesTab.Controls.Add(this.DisallowSuffixesTextBox);
            this.DisallowPropertiesTab.Location = new System.Drawing.Point(4, 22);
            this.DisallowPropertiesTab.Name = "DisallowPropertiesTab";
            this.DisallowPropertiesTab.Padding = new System.Windows.Forms.Padding(3);
            this.DisallowPropertiesTab.Size = new System.Drawing.Size(551, 355);
            this.DisallowPropertiesTab.TabIndex = 0;
            this.DisallowPropertiesTab.Text = "Disallow properties";
            this.DisallowPropertiesTab.UseVisualStyleBackColor = true;
            // 
            // DisallowSuffixesTextBox
            // 
            this.DisallowSuffixesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisallowSuffixesTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DisallowSuffixesTextBox.Location = new System.Drawing.Point(3, 3);
            this.DisallowSuffixesTextBox.Multiline = true;
            this.DisallowSuffixesTextBox.Name = "DisallowSuffixesTextBox";
            this.DisallowSuffixesTextBox.Size = new System.Drawing.Size(545, 349);
            this.DisallowSuffixesTextBox.TabIndex = 3;
            this.DisallowSuffixesTextBox.Text = ".FileName";
            // 
            // TranslationTab
            // 
            this.TranslationTab.Controls.Add(this.TranslationListBox);
            this.TranslationTab.Location = new System.Drawing.Point(4, 22);
            this.TranslationTab.Name = "TranslationTab";
            this.TranslationTab.Padding = new System.Windows.Forms.Padding(3);
            this.TranslationTab.Size = new System.Drawing.Size(551, 355);
            this.TranslationTab.TabIndex = 1;
            this.TranslationTab.Text = "Translation result";
            this.TranslationTab.UseVisualStyleBackColor = true;
            // 
            // TranslationListBox
            // 
            this.TranslationListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TranslationListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TranslationListBox.FormattingEnabled = true;
            this.TranslationListBox.Location = new System.Drawing.Point(3, 3);
            this.TranslationListBox.Name = "TranslationListBox";
            this.TranslationListBox.Size = new System.Drawing.Size(545, 349);
            this.TranslationListBox.TabIndex = 0;
            // 
            // ImportForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 420);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.BottomPanel);
            this.Name = "ImportForm";
            this.Text = "Import *.Designer.cs files";
            this.BottomPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.FilesTab.ResumeLayout(false);
            this.DisallowPropertiesTab.ResumeLayout(false);
            this.DisallowPropertiesTab.PerformLayout();
            this.TranslationTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage DisallowPropertiesTab;
        private System.Windows.Forms.TabPage TranslationTab;
        private System.Windows.Forms.Button ReadFilesButton;
        private System.Windows.Forms.Button WriteCsFilesButton;
        private System.Windows.Forms.TextBox DisallowSuffixesTextBox;
        private System.Windows.Forms.CheckedListBox TranslationListBox;
        private System.Windows.Forms.TabPage FilesTab;
        private System.Windows.Forms.Button GetTranslationButton;
        public System.Windows.Forms.CheckedListBox FilesListBox;
        private System.Windows.Forms.Button OKButton;
    }
}