/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: MainForm.Designer.cs 3185 2010-10-01 00:44:06Z unknown $

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

*******************************************************************************/
namespace NLocalizer.Example
{
    partial class MainForm
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
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ExampleDialogsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BrowseFolderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExampleFontMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectColorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MessageBoxMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherFormsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TestFormMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadLanguagesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LanguageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExampleDialogsMenu,
            this.OtherFormsMenu,
            this.LanguagesMenu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(623, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // ExampleDialogsMenu
            // 
            this.ExampleDialogsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileMenu,
            this.SaveFileMenu,
            this.BrowseFolderMenu,
            this.toolStripSeparator1,
            this.ExampleFontMenu,
            this.SelectColorMenu,
            this.toolStripSeparator3,
            this.MessageBoxMenu});
            this.ExampleDialogsMenu.Name = "ExampleDialogsMenu";
            this.ExampleDialogsMenu.Size = new System.Drawing.Size(104, 20);
            this.ExampleDialogsMenu.Text = "Example dialogs";
            // 
            // OpenFileMenu
            // 
            this.OpenFileMenu.Name = "OpenFileMenu";
            this.OpenFileMenu.Size = new System.Drawing.Size(152, 22);
            this.OpenFileMenu.Text = "Open file";
            this.OpenFileMenu.Click += new System.EventHandler(this.OpenFileMenu_Click);
            // 
            // SaveFileMenu
            // 
            this.SaveFileMenu.Name = "SaveFileMenu";
            this.SaveFileMenu.Size = new System.Drawing.Size(152, 22);
            this.SaveFileMenu.Text = "Save file";
            this.SaveFileMenu.Click += new System.EventHandler(this.SaveFileMenu_Click);
            // 
            // BrowseFolderMenu
            // 
            this.BrowseFolderMenu.Name = "BrowseFolderMenu";
            this.BrowseFolderMenu.Size = new System.Drawing.Size(152, 22);
            this.BrowseFolderMenu.Text = "Browse folder";
            this.BrowseFolderMenu.Click += new System.EventHandler(this.BrowseFolderMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // ExampleFontMenu
            // 
            this.ExampleFontMenu.Name = "ExampleFontMenu";
            this.ExampleFontMenu.Size = new System.Drawing.Size(152, 22);
            this.ExampleFontMenu.Text = "Select font";
            this.ExampleFontMenu.Click += new System.EventHandler(this.ExampleFontMenu_Click);
            // 
            // SelectColorMenu
            // 
            this.SelectColorMenu.Name = "SelectColorMenu";
            this.SelectColorMenu.Size = new System.Drawing.Size(152, 22);
            this.SelectColorMenu.Text = "Select color";
            this.SelectColorMenu.Click += new System.EventHandler(this.SelectColorMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // MessageBoxMenu
            // 
            this.MessageBoxMenu.Name = "MessageBoxMenu";
            this.MessageBoxMenu.Size = new System.Drawing.Size(152, 22);
            this.MessageBoxMenu.Text = "Show message";
            this.MessageBoxMenu.Click += new System.EventHandler(this.MessageBoxMenu_Click);
            // 
            // OtherFormsMenu
            // 
            this.OtherFormsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestFormMenu});
            this.OtherFormsMenu.Name = "OtherFormsMenu";
            this.OtherFormsMenu.Size = new System.Drawing.Size(83, 20);
            this.OtherFormsMenu.Text = "Other forms";
            // 
            // TestFormMenu
            // 
            this.TestFormMenu.Name = "TestFormMenu";
            this.TestFormMenu.Size = new System.Drawing.Size(128, 22);
            this.TestFormMenu.Text = "Show Test";
            this.TestFormMenu.Click += new System.EventHandler(this.TestFormMenu_Click);
            // 
            // LanguagesMenu
            // 
            this.LanguagesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadLanguagesMenu,
            this.toolStripSeparator2});
            this.LanguagesMenu.Name = "LanguagesMenu";
            this.LanguagesMenu.Size = new System.Drawing.Size(76, 20);
            this.LanguagesMenu.Text = "Languages";
            this.LanguagesMenu.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.LanguagesMenu_DropDownItemClicked);
            // 
            // LoadLanguagesMenu
            // 
            this.LoadLanguagesMenu.Name = "LoadLanguagesMenu";
            this.LoadLanguagesMenu.Size = new System.Drawing.Size(157, 22);
            this.LoadLanguagesMenu.Text = "Load languages";
            this.LoadLanguagesMenu.Click += new System.EventHandler(this.LoadLanguagesMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 287);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(623, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(46, 17);
            this.LanguageLabel.Text = "Neutral";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 309);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "Example form for NLocalizer.codeplex.com (C) Krzysztof Arkadiusz Prusik";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.OpenFileDialog OpenFileDialog;
        public System.Windows.Forms.SaveFileDialog SaveFileDialog;
        public System.Windows.Forms.ColorDialog ColorDialog;
        public System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        public System.Windows.Forms.FontDialog FontDialog;
        public System.Windows.Forms.MenuStrip MenuStrip;
        public System.Windows.Forms.StatusStrip StatusStrip;
        public System.Windows.Forms.ToolStripStatusLabel LanguageLabel;
        public System.Windows.Forms.ToolStripMenuItem ExampleDialogsMenu;
        public System.Windows.Forms.ToolStripMenuItem OpenFileMenu;
        public System.Windows.Forms.ToolStripMenuItem SaveFileMenu;
        public System.Windows.Forms.ToolStripMenuItem BrowseFolderMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem ExampleFontMenu;
        public System.Windows.Forms.ToolStripMenuItem SelectColorMenu;
        public System.Windows.Forms.ToolStripMenuItem OtherFormsMenu;
        public System.Windows.Forms.ToolStripMenuItem LanguagesMenu;
        public System.Windows.Forms.ToolStripMenuItem TestFormMenu;
        public System.Windows.Forms.ToolStripMenuItem LoadLanguagesMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem MessageBoxMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

