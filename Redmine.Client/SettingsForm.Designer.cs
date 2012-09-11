﻿namespace Redmine.Client
{
    partial class SettingsForm
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
            this.labelRedmineURL = new System.Windows.Forms.Label();
            this.BtnCancelButton = new System.Windows.Forms.Button();
            this.BtnSaveButton = new System.Windows.Forms.Button();
            this.AuthenticationCheckBox = new System.Windows.Forms.CheckBox();
            this.RedmineBaseUrlTextBox = new System.Windows.Forms.TextBox();
            this.RedmineUsernameTextBox = new System.Windows.Forms.TextBox();
            this.labelRedmineUsername = new System.Windows.Forms.Label();
            this.RedminePasswordTextBox = new System.Windows.Forms.TextBox();
            this.labelRedminePassword = new System.Windows.Forms.Label();
            this.CheckForUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.labelCacheLifetime = new System.Windows.Forms.Label();
            this.CacheLifetime = new System.Windows.Forms.NumericUpDown();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.MinimizeToSystemTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.MinimizeOnStartTimerCheckBox = new System.Windows.Forms.CheckBox();
            this.labelPopupTimout = new System.Windows.Forms.Label();
            this.PopupTimout = new System.Windows.Forms.NumericUpDown();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.labelRedmineVersion = new System.Windows.Forms.Label();
            this.RedmineVersionComboBox = new System.Windows.Forms.ComboBox();
            this.BtnEditActivitiesButton = new System.Windows.Forms.Button();
            this.BtnEditDocumentCategories = new System.Windows.Forms.Button();
            this.BtnEditIssuePriorities = new System.Windows.Forms.Button();
            this.GrpRedmineServerSettings = new System.Windows.Forms.GroupBox();
            this.BtnTestConnection = new System.Windows.Forms.Button();
            this.GrpApplicationSettings = new System.Windows.Forms.GroupBox();
            this.labelExplClosingIssueStatus = new System.Windows.Forms.Label();
            this.ComboBoxCloseStatus = new System.Windows.Forms.ComboBox();
            this.labelSelectCloseStatus = new System.Windows.Forms.Label();
            this.GrpEditEnumerations = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.CacheLifetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupTimout)).BeginInit();
            this.GrpRedmineServerSettings.SuspendLayout();
            this.GrpApplicationSettings.SuspendLayout();
            this.GrpEditEnumerations.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRedmineURL
            // 
            this.labelRedmineURL.AutoSize = true;
            this.labelRedmineURL.Location = new System.Drawing.Point(5, 16);
            this.labelRedmineURL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRedmineURL.Name = "labelRedmineURL";
            this.labelRedmineURL.Size = new System.Drawing.Size(74, 13);
            this.labelRedmineURL.TabIndex = 0;
            this.labelRedmineURL.Text = "Redmine URL";
            // 
            // BtnCancelButton
            // 
            this.BtnCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelButton.Location = new System.Drawing.Point(375, 421);
            this.BtnCancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelButton.Name = "BtnCancelButton";
            this.BtnCancelButton.Size = new System.Drawing.Size(68, 24);
            this.BtnCancelButton.TabIndex = 23;
            this.BtnCancelButton.Text = "Cancel";
            this.BtnCancelButton.UseVisualStyleBackColor = true;
            this.BtnCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BtnSaveButton
            // 
            this.BtnSaveButton.Location = new System.Drawing.Point(302, 421);
            this.BtnSaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSaveButton.Name = "BtnSaveButton";
            this.BtnSaveButton.Size = new System.Drawing.Size(68, 24);
            this.BtnSaveButton.TabIndex = 22;
            this.BtnSaveButton.Text = "Save";
            this.BtnSaveButton.UseVisualStyleBackColor = true;
            this.BtnSaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AuthenticationCheckBox
            // 
            this.AuthenticationCheckBox.AutoSize = true;
            this.AuthenticationCheckBox.Location = new System.Drawing.Point(8, 57);
            this.AuthenticationCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.AuthenticationCheckBox.Name = "AuthenticationCheckBox";
            this.AuthenticationCheckBox.Size = new System.Drawing.Size(138, 17);
            this.AuthenticationCheckBox.TabIndex = 2;
            this.AuthenticationCheckBox.Text = "Requires authentication";
            this.AuthenticationCheckBox.UseVisualStyleBackColor = true;
            this.AuthenticationCheckBox.CheckedChanged += new System.EventHandler(this.AuthenticationCheckBox_CheckedChanged);
            // 
            // RedmineBaseUrlTextBox
            // 
            this.RedmineBaseUrlTextBox.Location = new System.Drawing.Point(7, 33);
            this.RedmineBaseUrlTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RedmineBaseUrlTextBox.Name = "RedmineBaseUrlTextBox";
            this.RedmineBaseUrlTextBox.Size = new System.Drawing.Size(416, 20);
            this.RedmineBaseUrlTextBox.TabIndex = 1;
            // 
            // RedmineUsernameTextBox
            // 
            this.RedmineUsernameTextBox.Location = new System.Drawing.Point(7, 91);
            this.RedmineUsernameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RedmineUsernameTextBox.Name = "RedmineUsernameTextBox";
            this.RedmineUsernameTextBox.Size = new System.Drawing.Size(204, 20);
            this.RedmineUsernameTextBox.TabIndex = 4;
            // 
            // labelRedmineUsername
            // 
            this.labelRedmineUsername.AutoSize = true;
            this.labelRedmineUsername.Location = new System.Drawing.Point(5, 75);
            this.labelRedmineUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRedmineUsername.Name = "labelRedmineUsername";
            this.labelRedmineUsername.Size = new System.Drawing.Size(98, 13);
            this.labelRedmineUsername.TabIndex = 3;
            this.labelRedmineUsername.Text = "Redmine username";
            // 
            // RedminePasswordTextBox
            // 
            this.RedminePasswordTextBox.Location = new System.Drawing.Point(220, 91);
            this.RedminePasswordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RedminePasswordTextBox.Name = "RedminePasswordTextBox";
            this.RedminePasswordTextBox.PasswordChar = '*';
            this.RedminePasswordTextBox.Size = new System.Drawing.Size(204, 20);
            this.RedminePasswordTextBox.TabIndex = 6;
            // 
            // labelRedminePassword
            // 
            this.labelRedminePassword.AutoSize = true;
            this.labelRedminePassword.Location = new System.Drawing.Point(217, 75);
            this.labelRedminePassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRedminePassword.Name = "labelRedminePassword";
            this.labelRedminePassword.Size = new System.Drawing.Size(97, 13);
            this.labelRedminePassword.TabIndex = 5;
            this.labelRedminePassword.Text = "Redmine password";
            // 
            // CheckForUpdatesCheckBox
            // 
            this.CheckForUpdatesCheckBox.AutoSize = true;
            this.CheckForUpdatesCheckBox.Location = new System.Drawing.Point(8, 18);
            this.CheckForUpdatesCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.CheckForUpdatesCheckBox.Name = "CheckForUpdatesCheckBox";
            this.CheckForUpdatesCheckBox.Size = new System.Drawing.Size(163, 17);
            this.CheckForUpdatesCheckBox.TabIndex = 9;
            this.CheckForUpdatesCheckBox.Text = "Check for updates on startup";
            this.CheckForUpdatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // labelCacheLifetime
            // 
            this.labelCacheLifetime.AutoSize = true;
            this.labelCacheLifetime.Enabled = false;
            this.labelCacheLifetime.Location = new System.Drawing.Point(10, 427);
            this.labelCacheLifetime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCacheLifetime.Name = "labelCacheLifetime";
            this.labelCacheLifetime.Size = new System.Drawing.Size(172, 13);
            this.labelCacheLifetime.TabIndex = 7;
            this.labelCacheLifetime.Text = "Cache lifetime (minutes, 0 = infinite)";
            this.labelCacheLifetime.Visible = false;
            // 
            // CacheLifetime
            // 
            this.CacheLifetime.Enabled = false;
            this.CacheLifetime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CacheLifetime.Location = new System.Drawing.Point(186, 425);
            this.CacheLifetime.Margin = new System.Windows.Forms.Padding(2);
            this.CacheLifetime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CacheLifetime.Name = "CacheLifetime";
            this.CacheLifetime.Size = new System.Drawing.Size(70, 20);
            this.CacheLifetime.TabIndex = 8;
            this.CacheLifetime.Visible = false;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(4, 90);
            this.labelLanguage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(55, 13);
            this.labelLanguage.TabIndex = 14;
            this.labelLanguage.Text = "Language";
            // 
            // MinimizeToSystemTrayCheckBox
            // 
            this.MinimizeToSystemTrayCheckBox.AutoSize = true;
            this.MinimizeToSystemTrayCheckBox.Location = new System.Drawing.Point(8, 39);
            this.MinimizeToSystemTrayCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeToSystemTrayCheckBox.Name = "MinimizeToSystemTrayCheckBox";
            this.MinimizeToSystemTrayCheckBox.Size = new System.Drawing.Size(132, 17);
            this.MinimizeToSystemTrayCheckBox.TabIndex = 10;
            this.MinimizeToSystemTrayCheckBox.Text = "Minimize to Systemtray";
            this.MinimizeToSystemTrayCheckBox.UseVisualStyleBackColor = true;
            this.MinimizeToSystemTrayCheckBox.CheckedChanged += new System.EventHandler(this.AuthenticationCheckBox_CheckedChanged);
            // 
            // MinimizeOnStartTimerCheckBox
            // 
            this.MinimizeOnStartTimerCheckBox.AutoSize = true;
            this.MinimizeOnStartTimerCheckBox.Location = new System.Drawing.Point(8, 60);
            this.MinimizeOnStartTimerCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeOnStartTimerCheckBox.Name = "MinimizeOnStartTimerCheckBox";
            this.MinimizeOnStartTimerCheckBox.Size = new System.Drawing.Size(129, 17);
            this.MinimizeOnStartTimerCheckBox.TabIndex = 11;
            this.MinimizeOnStartTimerCheckBox.Text = "Minimize on start timer";
            this.MinimizeOnStartTimerCheckBox.UseVisualStyleBackColor = true;
            this.MinimizeOnStartTimerCheckBox.CheckedChanged += new System.EventHandler(this.AuthenticationCheckBox_CheckedChanged);
            // 
            // labelPopupTimout
            // 
            this.labelPopupTimout.AutoSize = true;
            this.labelPopupTimout.Location = new System.Drawing.Point(208, 18);
            this.labelPopupTimout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPopupTimout.Name = "labelPopupTimout";
            this.labelPopupTimout.Size = new System.Drawing.Size(154, 39);
            this.labelPopupTimout.TabIndex = 12;
            this.labelPopupTimout.Text = "Popup window when minimized\r\nor Request attention every\r\n(minutes, 0 = never)";
            // 
            // PopupTimout
            // 
            this.PopupTimout.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PopupTimout.Location = new System.Drawing.Point(211, 60);
            this.PopupTimout.Margin = new System.Windows.Forms.Padding(2);
            this.PopupTimout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PopupTimout.Name = "PopupTimout";
            this.PopupTimout.Size = new System.Drawing.Size(70, 20);
            this.PopupTimout.TabIndex = 13;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(142, 87);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(216, 21);
            this.LanguageComboBox.TabIndex = 15;
            // 
            // labelRedmineVersion
            // 
            this.labelRedmineVersion.AutoSize = true;
            this.labelRedmineVersion.Location = new System.Drawing.Point(5, 119);
            this.labelRedmineVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRedmineVersion.Name = "labelRedmineVersion";
            this.labelRedmineVersion.Size = new System.Drawing.Size(87, 13);
            this.labelRedmineVersion.TabIndex = 16;
            this.labelRedmineVersion.Text = "Redmine Version";
            // 
            // RedmineVersionComboBox
            // 
            this.RedmineVersionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RedmineVersionComboBox.FormattingEnabled = true;
            this.RedmineVersionComboBox.Location = new System.Drawing.Point(143, 116);
            this.RedmineVersionComboBox.Name = "RedmineVersionComboBox";
            this.RedmineVersionComboBox.Size = new System.Drawing.Size(68, 21);
            this.RedmineVersionComboBox.TabIndex = 17;
            // 
            // BtnEditActivitiesButton
            // 
            this.BtnEditActivitiesButton.Location = new System.Drawing.Point(7, 19);
            this.BtnEditActivitiesButton.Name = "BtnEditActivitiesButton";
            this.BtnEditActivitiesButton.Size = new System.Drawing.Size(68, 24);
            this.BtnEditActivitiesButton.TabIndex = 19;
            this.BtnEditActivitiesButton.Text = "Activities";
            this.BtnEditActivitiesButton.UseVisualStyleBackColor = true;
            this.BtnEditActivitiesButton.Click += new System.EventHandler(this.BtnEditActivitiesButton_Click);
            // 
            // BtnEditDocumentCategories
            // 
            this.BtnEditDocumentCategories.Location = new System.Drawing.Point(81, 19);
            this.BtnEditDocumentCategories.Name = "BtnEditDocumentCategories";
            this.BtnEditDocumentCategories.Size = new System.Drawing.Size(68, 24);
            this.BtnEditDocumentCategories.TabIndex = 20;
            this.BtnEditDocumentCategories.Text = "Doc. Cat.";
            this.BtnEditDocumentCategories.UseVisualStyleBackColor = true;
            this.BtnEditDocumentCategories.Click += new System.EventHandler(this.BtnEditDocumentCategories_Click);
            // 
            // BtnEditIssuePriorities
            // 
            this.BtnEditIssuePriorities.Location = new System.Drawing.Point(155, 19);
            this.BtnEditIssuePriorities.Name = "BtnEditIssuePriorities";
            this.BtnEditIssuePriorities.Size = new System.Drawing.Size(68, 24);
            this.BtnEditIssuePriorities.TabIndex = 21;
            this.BtnEditIssuePriorities.Text = "Priorities";
            this.BtnEditIssuePriorities.UseVisualStyleBackColor = true;
            this.BtnEditIssuePriorities.Click += new System.EventHandler(this.BtnEditIssuePriorities_Click);
            // 
            // GrpRedmineServerSettings
            // 
            this.GrpRedmineServerSettings.Controls.Add(this.RedminePasswordTextBox);
            this.GrpRedmineServerSettings.Controls.Add(this.BtnTestConnection);
            this.GrpRedmineServerSettings.Controls.Add(this.labelRedminePassword);
            this.GrpRedmineServerSettings.Controls.Add(this.RedmineUsernameTextBox);
            this.GrpRedmineServerSettings.Controls.Add(this.RedmineVersionComboBox);
            this.GrpRedmineServerSettings.Controls.Add(this.labelRedmineUsername);
            this.GrpRedmineServerSettings.Controls.Add(this.RedmineBaseUrlTextBox);
            this.GrpRedmineServerSettings.Controls.Add(this.AuthenticationCheckBox);
            this.GrpRedmineServerSettings.Controls.Add(this.labelRedmineURL);
            this.GrpRedmineServerSettings.Controls.Add(this.labelRedmineVersion);
            this.GrpRedmineServerSettings.Location = new System.Drawing.Point(12, 12);
            this.GrpRedmineServerSettings.Name = "GrpRedmineServerSettings";
            this.GrpRedmineServerSettings.Size = new System.Drawing.Size(431, 173);
            this.GrpRedmineServerSettings.TabIndex = 24;
            this.GrpRedmineServerSettings.TabStop = false;
            this.GrpRedmineServerSettings.Text = "Redmine Server Settings";
            // 
            // BtnTestConnection
            // 
            this.BtnTestConnection.Location = new System.Drawing.Point(8, 143);
            this.BtnTestConnection.Name = "BtnTestConnection";
            this.BtnTestConnection.Size = new System.Drawing.Size(96, 24);
            this.BtnTestConnection.TabIndex = 21;
            this.BtnTestConnection.Text = "Test Connection";
            this.BtnTestConnection.UseVisualStyleBackColor = true;
            this.BtnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);
            // 
            // GrpApplicationSettings
            // 
            this.GrpApplicationSettings.Controls.Add(this.labelExplClosingIssueStatus);
            this.GrpApplicationSettings.Controls.Add(this.ComboBoxCloseStatus);
            this.GrpApplicationSettings.Controls.Add(this.LanguageComboBox);
            this.GrpApplicationSettings.Controls.Add(this.PopupTimout);
            this.GrpApplicationSettings.Controls.Add(this.labelPopupTimout);
            this.GrpApplicationSettings.Controls.Add(this.labelSelectCloseStatus);
            this.GrpApplicationSettings.Controls.Add(this.MinimizeToSystemTrayCheckBox);
            this.GrpApplicationSettings.Controls.Add(this.labelLanguage);
            this.GrpApplicationSettings.Controls.Add(this.MinimizeOnStartTimerCheckBox);
            this.GrpApplicationSettings.Controls.Add(this.CheckForUpdatesCheckBox);
            this.GrpApplicationSettings.Location = new System.Drawing.Point(12, 196);
            this.GrpApplicationSettings.Name = "GrpApplicationSettings";
            this.GrpApplicationSettings.Size = new System.Drawing.Size(431, 165);
            this.GrpApplicationSettings.TabIndex = 25;
            this.GrpApplicationSettings.TabStop = false;
            this.GrpApplicationSettings.Text = "Application Settings";
            // 
            // labelExplClosingIssueStatus
            // 
            this.labelExplClosingIssueStatus.AutoSize = true;
            this.labelExplClosingIssueStatus.Location = new System.Drawing.Point(4, 138);
            this.labelExplClosingIssueStatus.Name = "labelExplClosingIssueStatus";
            this.labelExplClosingIssueStatus.Size = new System.Drawing.Size(304, 13);
            this.labelExplClosingIssueStatus.TabIndex = 16;
            this.labelExplClosingIssueStatus.Text = "Enable field with \'Test Connection\' and version V1.3.x or higher";
            // 
            // ComboBoxCloseStatus
            // 
            this.ComboBoxCloseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCloseStatus.Enabled = false;
            this.ComboBoxCloseStatus.FormattingEnabled = true;
            this.ComboBoxCloseStatus.Location = new System.Drawing.Point(209, 114);
            this.ComboBoxCloseStatus.Name = "ComboBoxCloseStatus";
            this.ComboBoxCloseStatus.Size = new System.Drawing.Size(149, 21);
            this.ComboBoxCloseStatus.TabIndex = 15;
            // 
            // labelSelectCloseStatus
            // 
            this.labelSelectCloseStatus.AutoSize = true;
            this.labelSelectCloseStatus.Location = new System.Drawing.Point(5, 117);
            this.labelSelectCloseStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectCloseStatus.Name = "labelSelectCloseStatus";
            this.labelSelectCloseStatus.Size = new System.Drawing.Size(152, 13);
            this.labelSelectCloseStatus.TabIndex = 14;
            this.labelSelectCloseStatus.Text = "When closing an Issue set it to";
            // 
            // GrpEditEnumerations
            // 
            this.GrpEditEnumerations.Controls.Add(this.BtnEditIssuePriorities);
            this.GrpEditEnumerations.Controls.Add(this.BtnEditDocumentCategories);
            this.GrpEditEnumerations.Controls.Add(this.BtnEditActivitiesButton);
            this.GrpEditEnumerations.Location = new System.Drawing.Point(12, 367);
            this.GrpEditEnumerations.Name = "GrpEditEnumerations";
            this.GrpEditEnumerations.Size = new System.Drawing.Size(430, 49);
            this.GrpEditEnumerations.TabIndex = 26;
            this.GrpEditEnumerations.TabStop = false;
            this.GrpEditEnumerations.Text = "Edit Enumerations";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.BtnSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelButton;
            this.ClientSize = new System.Drawing.Size(455, 456);
            this.Controls.Add(this.GrpRedmineServerSettings);
            this.Controls.Add(this.CacheLifetime);
            this.Controls.Add(this.labelCacheLifetime);
            this.Controls.Add(this.BtnSaveButton);
            this.Controls.Add(this.BtnCancelButton);
            this.Controls.Add(this.GrpApplicationSettings);
            this.Controls.Add(this.GrpEditEnumerations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.CacheLifetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopupTimout)).EndInit();
            this.GrpRedmineServerSettings.ResumeLayout(false);
            this.GrpRedmineServerSettings.PerformLayout();
            this.GrpApplicationSettings.ResumeLayout(false);
            this.GrpApplicationSettings.PerformLayout();
            this.GrpEditEnumerations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRedmineURL;
        private System.Windows.Forms.Button BtnCancelButton;
        private System.Windows.Forms.Button BtnSaveButton;
        private System.Windows.Forms.CheckBox AuthenticationCheckBox;
        private System.Windows.Forms.TextBox RedmineBaseUrlTextBox;
        private System.Windows.Forms.TextBox RedmineUsernameTextBox;
        private System.Windows.Forms.Label labelRedmineUsername;
        private System.Windows.Forms.TextBox RedminePasswordTextBox;
        private System.Windows.Forms.Label labelRedminePassword;
        private System.Windows.Forms.CheckBox CheckForUpdatesCheckBox;
        private System.Windows.Forms.Label labelCacheLifetime;
        private System.Windows.Forms.NumericUpDown CacheLifetime;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.CheckBox MinimizeToSystemTrayCheckBox;
        private System.Windows.Forms.CheckBox MinimizeOnStartTimerCheckBox;
        private System.Windows.Forms.Label labelPopupTimout;
        private System.Windows.Forms.NumericUpDown PopupTimout;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.Label labelRedmineVersion;
        private System.Windows.Forms.ComboBox RedmineVersionComboBox;
        private System.Windows.Forms.Button BtnEditActivitiesButton;
        private System.Windows.Forms.Button BtnEditDocumentCategories;
        private System.Windows.Forms.Button BtnEditIssuePriorities;
        private System.Windows.Forms.GroupBox GrpRedmineServerSettings;
        private System.Windows.Forms.Button BtnTestConnection;
        private System.Windows.Forms.GroupBox GrpApplicationSettings;
        private System.Windows.Forms.GroupBox GrpEditEnumerations;
        private System.Windows.Forms.ComboBox ComboBoxCloseStatus;
        private System.Windows.Forms.Label labelSelectCloseStatus;
        private System.Windows.Forms.Label labelExplClosingIssueStatus;
    }
}