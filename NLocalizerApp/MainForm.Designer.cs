/*******************************************************************************

  NLocalizer (C) 2010 Krzysztof Arkadiusz Prusik
  The fast, simple solution for localizing .NET applications, by text files.
  Latest version: http://NLocalizer.codeplex.com/

  $Id: MainForm.Designer.cs 3197 2010-10-01 10:40:02Z unknown $

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.EditedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.InfoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.ImportButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FormDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SearchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.TranslationGrid = new System.Windows.Forms.DataGridView();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImportFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TranslationGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditedStatusLabel,
            this.InfoStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 359);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(660, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // EditedStatusLabel
            // 
            this.EditedStatusLabel.Name = "EditedStatusLabel";
            this.EditedStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // InfoStatusLabel
            // 
            this.InfoStatusLabel.Name = "InfoStatusLabel";
            this.InfoStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.InfoStatusLabel.Text = "Ready";
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenButton,
            this.SaveButton,
            this.ImportButton,
            this.toolStripSeparator1,
            this.FormDropDownButton,
            this.SearchTextBox,
            this.SearchButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(660, 25);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(56, 22);
            this.OpenButton.Text = "&Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(51, 22);
            this.SaveButton.Text = "&Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Image = ((System.Drawing.Image)(resources.GetObject("ImportButton.Image")));
            this.ImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(63, 22);
            this.ImportButton.Text = "&Import";
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // FormDropDownButton
            // 
            this.FormDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("FormDropDownButton.Image")));
            this.FormDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormDropDownButton.Name = "FormDropDownButton";
            this.FormDropDownButton.Size = new System.Drawing.Size(64, 22);
            this.FormDropDownButton.Text = "For&m";
            this.FormDropDownButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FormDropDownButton_DropDownItemClicked);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(100, 25);
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            // 
            // SearchButton
            // 
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(50, 22);
            this.SearchButton.Text = "&Find";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TranslationGrid
            // 
            this.TranslationGrid.AllowUserToAddRows = false;
            this.TranslationGrid.AllowUserToDeleteRows = false;
            this.TranslationGrid.AllowUserToOrderColumns = true;
            this.TranslationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TranslationGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TranslationGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.TranslationGrid.Location = new System.Drawing.Point(0, 25);
            this.TranslationGrid.Name = "TranslationGrid";
            this.TranslationGrid.Size = new System.Drawing.Size(660, 334);
            this.TranslationGrid.TabIndex = 3;
            this.TranslationGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.TranslationGrid_CellEndEdit);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "*.lang";
            this.OpenFileDialog.FileName = "Polish.lang";
            this.OpenFileDialog.Filter = "Language files|*.lang";
            this.OpenFileDialog.Multiselect = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 381);
            this.Controls.Add(this.TranslationGrid);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.StatusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NLocalizerApp, NLocalizer.codeplex.com (C) Krzysztof Arkadiusz Prusik";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TranslationGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.DataGridView TranslationGrid;
        private System.Windows.Forms.ToolStripButton OpenButton;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton ImportButton;
        private System.Windows.Forms.ToolStripTextBox SearchTextBox;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ToolStripStatusLabel InfoStatusLabel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ToolStripDropDownButton FormDropDownButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.FolderBrowserDialog ImportFolderDialog;
        private System.Windows.Forms.ToolStripStatusLabel EditedStatusLabel;
    }
}

