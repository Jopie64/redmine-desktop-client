﻿using System.Windows.Forms;

namespace Redmine.Client
{
    partial class RedmineClientForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedmineClientForm));
            this.TextBoxHours = new System.Windows.Forms.TextBox();
            this.TextBoxMinutes = new System.Windows.Forms.TextBox();
            this.TextBoxSeconds = new System.Windows.Forms.TextBox();
            this.BtnPauseButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TextBoxComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxActivity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxProject = new System.Windows.Forms.ComboBox();
            this.BtnCommitButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridViewIssues = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnRefreshButton = new System.Windows.Forms.Button();
            this.BtnExitButton = new System.Windows.Forms.Button();
            this.BtnResetButton = new System.Windows.Forms.Button();
            this.BtnAboutButton = new System.Windows.Forms.Button();
            this.BtnSettingsButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnNewIssueButton = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.NotifyIconMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewIssues)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxHours
            // 
            this.TextBoxHours.Location = new System.Drawing.Point(9, 10);
            this.TextBoxHours.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBoxHours.Name = "TextBoxHours";
            this.TextBoxHours.Size = new System.Drawing.Size(26, 20);
            this.TextBoxHours.TabIndex = 2;
            this.TextBoxHours.Text = "0";
            this.TextBoxHours.TextChanged += new System.EventHandler(this.TextBoxHours_TextChanged);
            // 
            // TextBoxMinutes
            // 
            this.TextBoxMinutes.Location = new System.Drawing.Point(39, 10);
            this.TextBoxMinutes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBoxMinutes.Name = "TextBoxMinutes";
            this.TextBoxMinutes.Size = new System.Drawing.Size(26, 20);
            this.TextBoxMinutes.TabIndex = 3;
            this.TextBoxMinutes.Text = "0";
            this.TextBoxMinutes.TextChanged += new System.EventHandler(this.TextBoxMinutes_TextChanged);
            // 
            // TextBoxSeconds
            // 
            this.TextBoxSeconds.Location = new System.Drawing.Point(69, 10);
            this.TextBoxSeconds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBoxSeconds.Name = "TextBoxSeconds";
            this.TextBoxSeconds.Size = new System.Drawing.Size(26, 20);
            this.TextBoxSeconds.TabIndex = 4;
            this.TextBoxSeconds.Text = "0";
            this.TextBoxSeconds.TextChanged += new System.EventHandler(this.TextBoxSeconds_TextChanged);
            // 
            // BtnPauseButton
            // 
            this.BtnPauseButton.Location = new System.Drawing.Point(99, 10);
            this.BtnPauseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnPauseButton.Name = "BtnPauseButton";
            this.BtnPauseButton.Size = new System.Drawing.Size(56, 19);
            this.BtnPauseButton.TabIndex = 5;
            this.BtnPauseButton.Text = "Start";
            this.BtnPauseButton.UseVisualStyleBackColor = true;
            this.BtnPauseButton.Click += new System.EventHandler(this.BtnPauseButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 33);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(86, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // TextBoxComment
            // 
            this.TextBoxComment.Location = new System.Drawing.Point(164, 33);
            this.TextBoxComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBoxComment.Name = "TextBoxComment";
            this.TextBoxComment.Size = new System.Drawing.Size(237, 20);
            this.TextBoxComment.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Comment";
            // 
            // ComboBoxActivity
            // 
            this.ComboBoxActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxActivity.FormattingEnabled = true;
            this.ComboBoxActivity.Location = new System.Drawing.Point(9, 69);
            this.ComboBoxActivity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComboBoxActivity.Name = "ComboBoxActivity";
            this.ComboBoxActivity.Size = new System.Drawing.Size(147, 21);
            this.ComboBoxActivity.TabIndex = 9;
            this.ComboBoxActivity.SelectedIndexChanged += new System.EventHandler(this.ComboBoxActivity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Activity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Project";
            // 
            // ComboBoxProject
            // 
            this.ComboBoxProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxProject.FormattingEnabled = true;
            this.ComboBoxProject.Location = new System.Drawing.Point(164, 69);
            this.ComboBoxProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ComboBoxProject.Name = "ComboBoxProject";
            this.ComboBoxProject.Size = new System.Drawing.Size(237, 21);
            this.ComboBoxProject.TabIndex = 11;
            this.ComboBoxProject.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProject_SelectedIndexChanged);
            // 
            // BtnCommitButton
            // 
            this.BtnCommitButton.Location = new System.Drawing.Point(408, 12);
            this.BtnCommitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnCommitButton.Name = "BtnCommitButton";
            this.BtnCommitButton.Size = new System.Drawing.Size(56, 19);
            this.BtnCommitButton.TabIndex = 13;
            this.BtnCommitButton.Text = "Commit";
            this.BtnCommitButton.UseVisualStyleBackColor = true;
            this.BtnCommitButton.Click += new System.EventHandler(this.BtnCommitButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.NotifyIconMenuStrip;
            this.notifyIcon1.Text = "Redmine Client";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // NotifyIconMenuStrip
            // 
            this.NotifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestoreToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.NotifyIconMenuStrip.Name = "NotifyIconMenuStrip";
            this.NotifyIconMenuStrip.Size = new System.Drawing.Size(105, 48);
            // 
            // RestoreToolStripMenuItem
            // 
            this.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
            this.RestoreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            if (this.MinimizeToSystemTray)
                this.RestoreToolStripMenuItem.Text = "&Hide";
            else
                this.RestoreToolStripMenuItem.Text = "Mi&nimize";
            this.RestoreToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.ExitToolStripMenuItem.Text = "&Close";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // DataGridViewIssues
            // 
            this.DataGridViewIssues.AllowUserToAddRows = false;
            this.DataGridViewIssues.AllowUserToDeleteRows = false;
            this.DataGridViewIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewIssues.Location = new System.Drawing.Point(9, 93);
            this.DataGridViewIssues.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DataGridViewIssues.Name = "DataGridViewIssues";
            this.DataGridViewIssues.ReadOnly = true;
            this.DataGridViewIssues.RowTemplate.Height = 24;
            this.DataGridViewIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewIssues.Size = new System.Drawing.Size(391, 304);
            this.DataGridViewIssues.TabIndex = 16;
            this.DataGridViewIssues.SelectionChanged += new System.EventHandler(this.DataGridViewIssues_SelectionChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnRefreshButton
            // 
            this.BtnRefreshButton.Location = new System.Drawing.Point(408, 70);
            this.BtnRefreshButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnRefreshButton.Name = "BtnRefreshButton";
            this.BtnRefreshButton.Size = new System.Drawing.Size(56, 19);
            this.BtnRefreshButton.TabIndex = 17;
            this.BtnRefreshButton.Text = "Refresh";
            this.BtnRefreshButton.UseVisualStyleBackColor = true;
            this.BtnRefreshButton.Click += new System.EventHandler(this.BtnRefreshButton_Click);
            // 
            // BtnExitButton
            // 
            this.BtnExitButton.Location = new System.Drawing.Point(408, 379);
            this.BtnExitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnExitButton.Name = "BtnExitButton";
            this.BtnExitButton.Size = new System.Drawing.Size(56, 19);
            this.BtnExitButton.TabIndex = 18;
            this.BtnExitButton.Text = "Exit";
            this.BtnExitButton.UseVisualStyleBackColor = true;
            this.BtnExitButton.Click += new System.EventHandler(this.BtnExitButton_Click);
            // 
            // BtnResetButton
            // 
            this.BtnResetButton.Location = new System.Drawing.Point(99, 32);
            this.BtnResetButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnResetButton.Name = "BtnResetButton";
            this.BtnResetButton.Size = new System.Drawing.Size(56, 19);
            this.BtnResetButton.TabIndex = 19;
            this.BtnResetButton.Text = "Reset";
            this.BtnResetButton.UseVisualStyleBackColor = true;
            this.BtnResetButton.Click += new System.EventHandler(this.BtnResetButton_Click);
            // 
            // BtnAboutButton
            // 
            this.BtnAboutButton.Location = new System.Drawing.Point(408, 355);
            this.BtnAboutButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnAboutButton.Name = "BtnAboutButton";
            this.BtnAboutButton.Size = new System.Drawing.Size(56, 19);
            this.BtnAboutButton.TabIndex = 20;
            this.BtnAboutButton.Text = "About";
            this.BtnAboutButton.UseVisualStyleBackColor = true;
            this.BtnAboutButton.Click += new System.EventHandler(this.BtnAboutButton_Click);
            // 
            // BtnSettingsButton
            // 
            this.BtnSettingsButton.Location = new System.Drawing.Point(408, 332);
            this.BtnSettingsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnSettingsButton.Name = "BtnSettingsButton";
            this.BtnSettingsButton.Size = new System.Drawing.Size(56, 19);
            this.BtnSettingsButton.TabIndex = 21;
            this.BtnSettingsButton.Text = "Settings";
            this.BtnSettingsButton.UseVisualStyleBackColor = true;
            this.BtnSettingsButton.Click += new System.EventHandler(this.BtnSettingsButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BtnNewIssueButton
            // 
            this.BtnNewIssueButton.Location = new System.Drawing.Point(408, 93);
            this.BtnNewIssueButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnNewIssueButton.Name = "BtnNewIssueButton";
            this.BtnNewIssueButton.Size = new System.Drawing.Size(56, 19);
            this.BtnNewIssueButton.TabIndex = 22;
            this.BtnNewIssueButton.Text = "New issue";
            this.BtnNewIssueButton.UseVisualStyleBackColor = true;
            this.BtnNewIssueButton.Click += new System.EventHandler(this.BtnNewIssueButton_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // RedmineClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 407);
            this.Controls.Add(this.BtnNewIssueButton);
            this.Controls.Add(this.BtnSettingsButton);
            this.Controls.Add(this.BtnAboutButton);
            this.Controls.Add(this.BtnResetButton);
            this.Controls.Add(this.BtnRefreshButton);
            this.Controls.Add(this.BtnExitButton);
            this.Controls.Add(this.DataGridViewIssues);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCommitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboBoxProject);
            this.Controls.Add(this.ComboBoxActivity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxComment);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BtnPauseButton);
            this.Controls.Add(this.TextBoxSeconds);
            this.Controls.Add(this.TextBoxMinutes);
            this.Controls.Add(this.TextBoxHours);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "RedmineClientForm";
            this.Text = "Redmine Client";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.NotifyIconMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewIssues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxHours;
        private System.Windows.Forms.TextBox TextBoxMinutes;
        private System.Windows.Forms.TextBox TextBoxSeconds;
        private System.Windows.Forms.Button BtnPauseButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox TextBoxComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxActivity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxProject;
        private System.Windows.Forms.Button BtnCommitButton;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip NotifyIconMenuStrip;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem RestoreToolStripMenuItem;
        private DataGridView DataGridViewIssues;
        private Timer timer1;
        private Button BtnRefreshButton;
        private Button BtnExitButton;
        private Button BtnResetButton;
        private Button BtnAboutButton;
        private Button BtnSettingsButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button BtnNewIssueButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

