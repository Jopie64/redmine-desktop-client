﻿namespace Redmine.Client
{
    partial class IssueForm
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
            this.BtnSaveButton = new System.Windows.Forms.Button();
            this.BtnCancelButton = new System.Windows.Forms.Button();
            this.labelTracker = new System.Windows.Forms.Label();
            this.ComboBoxTracker = new System.Windows.Forms.ComboBox();
            this.DateStart = new System.Windows.Forms.DateTimePicker();
            this.labelSubject = new System.Windows.Forms.Label();
            this.TextBoxSubject = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.ComboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelPriority = new System.Windows.Forms.Label();
            this.ComboBoxPriority = new System.Windows.Forms.ComboBox();
            this.DateDue = new System.Windows.Forms.DateTimePicker();
            this.labelEstimatedTime = new System.Windows.Forms.Label();
            this.TextBoxEstimatedTime = new System.Windows.Forms.TextBox();
            this.labelAssignedTo = new System.Windows.Forms.Label();
            this.ComboBoxAssignedTo = new System.Windows.Forms.ComboBox();
            this.labelTargetVersion = new System.Windows.Forms.Label();
            this.ComboBoxTargetVersion = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelPercentDone = new System.Windows.Forms.Label();
            this.ListBoxWatchers = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.cbStartDate = new System.Windows.Forms.CheckBox();
            this.cbDueDate = new System.Windows.Forms.CheckBox();
            this.BtnCloseButton = new System.Windows.Forms.Button();
            this.linkEditInRedmine = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSaveButton
            // 
            this.BtnSaveButton.Location = new System.Drawing.Point(308, 253);
            this.BtnSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSaveButton.Name = "BtnSaveButton";
            this.BtnSaveButton.Size = new System.Drawing.Size(56, 19);
            this.BtnSaveButton.TabIndex = 4;
            this.BtnSaveButton.Text = "Save";
            this.BtnSaveButton.UseVisualStyleBackColor = true;
            this.BtnSaveButton.Click += new System.EventHandler(this.BtnSaveButton_Click);
            // 
            // BtnCancelButton
            // 
            this.BtnCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelButton.Location = new System.Drawing.Point(368, 253);
            this.BtnCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelButton.Name = "BtnCancelButton";
            this.BtnCancelButton.Size = new System.Drawing.Size(56, 19);
            this.BtnCancelButton.TabIndex = 3;
            this.BtnCancelButton.Text = "Cancel";
            this.BtnCancelButton.UseVisualStyleBackColor = true;
            this.BtnCancelButton.Click += new System.EventHandler(this.BtnCancelButton_Click);
            // 
            // labelTracker
            // 
            this.labelTracker.AutoSize = true;
            this.labelTracker.Location = new System.Drawing.Point(9, 7);
            this.labelTracker.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTracker.Name = "labelTracker";
            this.labelTracker.Size = new System.Drawing.Size(44, 13);
            this.labelTracker.TabIndex = 12;
            this.labelTracker.Text = "Tracker";
            // 
            // ComboBoxTracker
            // 
            this.ComboBoxTracker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTracker.FormattingEnabled = true;
            this.ComboBoxTracker.Location = new System.Drawing.Point(9, 23);
            this.ComboBoxTracker.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxTracker.Name = "ComboBoxTracker";
            this.ComboBoxTracker.Size = new System.Drawing.Size(136, 21);
            this.ComboBoxTracker.TabIndex = 11;
            // 
            // DateStart
            // 
            this.DateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateStart.Location = new System.Drawing.Point(11, 179);
            this.DateStart.Margin = new System.Windows.Forms.Padding(2);
            this.DateStart.Name = "DateStart";
            this.DateStart.Size = new System.Drawing.Size(86, 20);
            this.DateStart.TabIndex = 13;
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(9, 45);
            this.labelSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(43, 13);
            this.labelSubject.TabIndex = 15;
            this.labelSubject.Text = "Subject";
            // 
            // TextBoxSubject
            // 
            this.TextBoxSubject.Location = new System.Drawing.Point(11, 61);
            this.TextBoxSubject.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxSubject.Name = "TextBoxSubject";
            this.TextBoxSubject.Size = new System.Drawing.Size(414, 20);
            this.TextBoxSubject.TabIndex = 14;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(9, 81);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 17;
            this.labelDescription.Text = "Description";
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.AcceptsReturn = true;
            this.TextBoxDescription.AcceptsTab = true;
            this.TextBoxDescription.Location = new System.Drawing.Point(11, 98);
            this.TextBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxDescription.Multiline = true;
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBoxDescription.Size = new System.Drawing.Size(414, 63);
            this.TextBoxDescription.TabIndex = 16;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(148, 7);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 19;
            this.labelStatus.Text = "Status";
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.Location = new System.Drawing.Point(148, 23);
            this.ComboBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(136, 21);
            this.ComboBoxStatus.TabIndex = 18;
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Location = new System.Drawing.Point(287, 6);
            this.labelPriority.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(38, 13);
            this.labelPriority.TabIndex = 21;
            this.labelPriority.Text = "Priority";
            // 
            // ComboBoxPriority
            // 
            this.ComboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPriority.FormattingEnabled = true;
            this.ComboBoxPriority.Location = new System.Drawing.Point(290, 23);
            this.ComboBoxPriority.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxPriority.Name = "ComboBoxPriority";
            this.ComboBoxPriority.Size = new System.Drawing.Size(136, 21);
            this.ComboBoxPriority.TabIndex = 20;
            // 
            // DateDue
            // 
            this.DateDue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateDue.Location = new System.Drawing.Point(101, 179);
            this.DateDue.Margin = new System.Windows.Forms.Padding(2);
            this.DateDue.Name = "DateDue";
            this.DateDue.Size = new System.Drawing.Size(86, 20);
            this.DateDue.TabIndex = 23;
            // 
            // labelEstimatedTime
            // 
            this.labelEstimatedTime.AutoSize = true;
            this.labelEstimatedTime.Location = new System.Drawing.Point(191, 162);
            this.labelEstimatedTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEstimatedTime.Name = "labelEstimatedTime";
            this.labelEstimatedTime.Size = new System.Drawing.Size(75, 13);
            this.labelEstimatedTime.TabIndex = 26;
            this.labelEstimatedTime.Text = "Estimated time";
            // 
            // TextBoxEstimatedTime
            // 
            this.TextBoxEstimatedTime.Location = new System.Drawing.Point(194, 179);
            this.TextBoxEstimatedTime.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxEstimatedTime.Name = "TextBoxEstimatedTime";
            this.TextBoxEstimatedTime.Size = new System.Drawing.Size(89, 20);
            this.TextBoxEstimatedTime.TabIndex = 25;
            // 
            // labelAssignedTo
            // 
            this.labelAssignedTo.AutoSize = true;
            this.labelAssignedTo.Location = new System.Drawing.Point(287, 162);
            this.labelAssignedTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAssignedTo.Name = "labelAssignedTo";
            this.labelAssignedTo.Size = new System.Drawing.Size(62, 13);
            this.labelAssignedTo.TabIndex = 28;
            this.labelAssignedTo.Text = "Assigned to";
            // 
            // ComboBoxAssignedTo
            // 
            this.ComboBoxAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAssignedTo.FormattingEnabled = true;
            this.ComboBoxAssignedTo.Location = new System.Drawing.Point(290, 179);
            this.ComboBoxAssignedTo.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxAssignedTo.Name = "ComboBoxAssignedTo";
            this.ComboBoxAssignedTo.Size = new System.Drawing.Size(136, 21);
            this.ComboBoxAssignedTo.TabIndex = 27;
            // 
            // labelTargetVersion
            // 
            this.labelTargetVersion.AutoSize = true;
            this.labelTargetVersion.Location = new System.Drawing.Point(287, 201);
            this.labelTargetVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTargetVersion.Name = "labelTargetVersion";
            this.labelTargetVersion.Size = new System.Drawing.Size(75, 13);
            this.labelTargetVersion.TabIndex = 30;
            this.labelTargetVersion.Text = "Target version";
            // 
            // ComboBoxTargetVersion
            // 
            this.ComboBoxTargetVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTargetVersion.FormattingEnabled = true;
            this.ComboBoxTargetVersion.Location = new System.Drawing.Point(290, 217);
            this.ComboBoxTargetVersion.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxTargetVersion.Name = "ComboBoxTargetVersion";
            this.ComboBoxTargetVersion.Size = new System.Drawing.Size(136, 21);
            this.ComboBoxTargetVersion.TabIndex = 29;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(194, 218);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown1.TabIndex = 31;
            // 
            // labelPercentDone
            // 
            this.labelPercentDone.AutoSize = true;
            this.labelPercentDone.Location = new System.Drawing.Point(191, 201);
            this.labelPercentDone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPercentDone.Name = "labelPercentDone";
            this.labelPercentDone.Size = new System.Drawing.Size(42, 13);
            this.labelPercentDone.TabIndex = 32;
            this.labelPercentDone.Text = "% done";
            // 
            // ListBoxWatchers
            // 
            this.ListBoxWatchers.FormattingEnabled = true;
            this.ListBoxWatchers.Location = new System.Drawing.Point(11, 244);
            this.ListBoxWatchers.Margin = new System.Windows.Forms.Padding(2);
            this.ListBoxWatchers.Name = "ListBoxWatchers";
            this.ListBoxWatchers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxWatchers.Size = new System.Drawing.Size(176, 30);
            this.ListBoxWatchers.TabIndex = 33;
            this.ListBoxWatchers.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 201);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Watchers";
            this.label12.Visible = false;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // cbStartDate
            // 
            this.cbStartDate.AutoSize = true;
            this.cbStartDate.Location = new System.Drawing.Point(11, 162);
            this.cbStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.cbStartDate.Name = "cbStartDate";
            this.cbStartDate.Size = new System.Drawing.Size(72, 17);
            this.cbStartDate.TabIndex = 35;
            this.cbStartDate.Text = "Start date";
            this.cbStartDate.UseVisualStyleBackColor = true;
            this.cbStartDate.CheckedChanged += new System.EventHandler(this.cbStartDate_CheckedChanged);
            // 
            // cbDueDate
            // 
            this.cbDueDate.AutoSize = true;
            this.cbDueDate.Location = new System.Drawing.Point(101, 162);
            this.cbDueDate.Margin = new System.Windows.Forms.Padding(2);
            this.cbDueDate.Name = "cbDueDate";
            this.cbDueDate.Size = new System.Drawing.Size(70, 17);
            this.cbDueDate.TabIndex = 36;
            this.cbDueDate.Text = "Due date";
            this.cbDueDate.UseVisualStyleBackColor = true;
            this.cbDueDate.CheckedChanged += new System.EventHandler(this.cbDueDate_CheckedChanged);
            // 
            // BtnCloseButton
            // 
            this.BtnCloseButton.Location = new System.Drawing.Point(194, 253);
            this.BtnCloseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCloseButton.Name = "BtnCloseButton";
            this.BtnCloseButton.Size = new System.Drawing.Size(72, 19);
            this.BtnCloseButton.TabIndex = 4;
            this.BtnCloseButton.Text = "Close Issue";
            this.BtnCloseButton.UseVisualStyleBackColor = true;
            this.BtnCloseButton.Click += new System.EventHandler(this.BtnCloseButton_Click);
            // 
            // linkEditInRedmine
            // 
            this.linkEditInRedmine.AutoSize = true;
            this.linkEditInRedmine.Location = new System.Drawing.Point(8, 220);
            this.linkEditInRedmine.Name = "linkEditInRedmine";
            this.linkEditInRedmine.Size = new System.Drawing.Size(127, 13);
            this.linkEditInRedmine.TabIndex = 37;
            this.linkEditInRedmine.TabStop = true;
            this.linkEditInRedmine.Text = "Edit this issue in Redmine";
            this.linkEditInRedmine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditInRedmine_LinkClicked);
            // 
            // IssueForm
            // 
            this.AcceptButton = this.BtnSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelButton;
            this.ClientSize = new System.Drawing.Size(434, 281);
            this.Controls.Add(this.linkEditInRedmine);
            this.Controls.Add(this.DateDue);
            this.Controls.Add(this.DateStart);
            this.Controls.Add(this.cbDueDate);
            this.Controls.Add(this.cbStartDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ListBoxWatchers);
            this.Controls.Add(this.labelPercentDone);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelTargetVersion);
            this.Controls.Add(this.ComboBoxTargetVersion);
            this.Controls.Add(this.labelAssignedTo);
            this.Controls.Add(this.ComboBoxAssignedTo);
            this.Controls.Add(this.labelEstimatedTime);
            this.Controls.Add(this.TextBoxEstimatedTime);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.ComboBoxPriority);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.ComboBoxStatus);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.TextBoxSubject);
            this.Controls.Add(this.labelTracker);
            this.Controls.Add(this.ComboBoxTracker);
            this.Controls.Add(this.BtnCloseButton);
            this.Controls.Add(this.BtnSaveButton);
            this.Controls.Add(this.BtnCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IssueForm";
            this.Text = "Create new issue";
            this.Load += new System.EventHandler(this.NewIssueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSaveButton;
        private System.Windows.Forms.Button BtnCancelButton;
        private System.Windows.Forms.Label labelTracker;
        private System.Windows.Forms.ComboBox ComboBoxTracker;
        private System.Windows.Forms.DateTimePicker DateStart;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox TextBoxSubject;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox ComboBoxStatus;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.ComboBox ComboBoxPriority;
        private System.Windows.Forms.DateTimePicker DateDue;
        private System.Windows.Forms.Label labelEstimatedTime;
        private System.Windows.Forms.TextBox TextBoxEstimatedTime;
        private System.Windows.Forms.Label labelAssignedTo;
        private System.Windows.Forms.ComboBox ComboBoxAssignedTo;
        private System.Windows.Forms.Label labelTargetVersion;
        private System.Windows.Forms.ComboBox ComboBoxTargetVersion;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelPercentDone;
        private System.Windows.Forms.ListBox ListBoxWatchers;
        private System.Windows.Forms.Label label12;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.CheckBox cbStartDate;
        private System.Windows.Forms.CheckBox cbDueDate;
        private System.Windows.Forms.Button BtnCloseButton;
        private System.Windows.Forms.LinkLabel linkEditInRedmine;
    }
}