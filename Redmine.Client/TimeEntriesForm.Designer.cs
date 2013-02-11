﻿namespace Redmine.Client
{
    partial class TimeEntriesForm
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
            this.BtnOKButton = new System.Windows.Forms.Button();
            this.BtnCancelButton = new System.Windows.Forms.Button();
            this.DataGridViewTimeEntries = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTimeEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOKButton
            // 
            this.BtnOKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnOKButton.Location = new System.Drawing.Point(137, 235);
            this.BtnOKButton.Margin = new System.Windows.Forms.Padding(2);
            this.BtnOKButton.Name = "BtnOKButton";
            this.BtnOKButton.Size = new System.Drawing.Size(68, 24);
            this.BtnOKButton.TabIndex = 26;
            this.BtnOKButton.Text = "OK";
            this.BtnOKButton.UseVisualStyleBackColor = true;
            // 
            // BtnCancelButton
            // 
            this.BtnCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelButton.Location = new System.Drawing.Point(209, 235);
            this.BtnCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelButton.Name = "BtnCancelButton";
            this.BtnCancelButton.Size = new System.Drawing.Size(68, 24);
            this.BtnCancelButton.TabIndex = 27;
            this.BtnCancelButton.Text = "Cancel";
            this.BtnCancelButton.UseVisualStyleBackColor = true;
            // 
            // DataGridViewTimeEntries
            // 
            this.DataGridViewTimeEntries.AllowUserToAddRows = false;
            this.DataGridViewTimeEntries.AllowUserToDeleteRows = false;
            this.DataGridViewTimeEntries.AllowUserToResizeRows = false;
            this.DataGridViewTimeEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewTimeEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewTimeEntries.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewTimeEntries.MultiSelect = false;
            this.DataGridViewTimeEntries.Name = "DataGridViewTimeEntries";
            this.DataGridViewTimeEntries.ReadOnly = true;
            this.DataGridViewTimeEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewTimeEntries.Size = new System.Drawing.Size(390, 218);
            this.DataGridViewTimeEntries.TabIndex = 28;
            this.DataGridViewTimeEntries.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewTimeEntries_CellFormatting);
            // 
            // TimeEntriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 270);
            this.Controls.Add(this.DataGridViewTimeEntries);
            this.Controls.Add(this.BtnOKButton);
            this.Controls.Add(this.BtnCancelButton);
            this.Name = "TimeEntriesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TimeEntriesForm";
            this.Load += new System.EventHandler(this.TimeEntriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTimeEntries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOKButton;
        private System.Windows.Forms.Button BtnCancelButton;
        private System.Windows.Forms.DataGridView DataGridViewTimeEntries;
    }
}