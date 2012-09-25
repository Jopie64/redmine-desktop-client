﻿using System;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using Redmine.Client.Languages;
using Redmine.Net.Api.Types;
using System.Collections.Specialized;

namespace Redmine.Client
{
    public partial class SettingsForm : Form
    {
        private List<System.Globalization.CultureInfo> supportedLang = new List<System.Globalization.CultureInfo> {
            new System.Globalization.CultureInfo("nl-NL"),
            new System.Globalization.CultureInfo("en-US"),
            new System.Globalization.CultureInfo("cs-CZ")
        };
        /* api version lower then 1.1 does not support time-entry, so is not supported. */
        private List<IdentifiableName> apiVersions = new List<IdentifiableName> {
            /*new IdentifiableName { Id = (int)ApiVersion.V10x, Name = LangTools.GetTextForApiVersion(ApiVersion.V10x) },*/
            new IdentifiableName { Id = (int)ApiVersion.V11x, Name = LangTools.GetTextForApiVersion(ApiVersion.V11x) },
            new IdentifiableName { Id = (int)ApiVersion.V13x, Name = LangTools.GetTextForApiVersion(ApiVersion.V13x) },
            new IdentifiableName { Id = (int)ApiVersion.V14x, Name = LangTools.GetTextForApiVersion(ApiVersion.V14x) },
            new IdentifiableName { Id = (int)ApiVersion.V21x, Name = LangTools.GetTextForApiVersion(ApiVersion.V21x) }
        };

        public SettingsForm()
        {
            InitializeComponent();
            LoadLanguage();
            LanguageComboBox.DataSource = supportedLang;
            LanguageComboBox.ValueMember = "Name";
            LanguageComboBox.DisplayMember = "DisplayName";

            RedmineVersionComboBox.DataSource = apiVersions;
            RedmineVersionComboBox.ValueMember = "Id";
            RedmineVersionComboBox.DisplayMember = "Name";

            LoadConfig();
            EnableDisableAuthenticationFields();
        }

        private void LoadLanguage()
        {
            LangTools.UpdateControlsForLanguage(this.Controls);
            this.Text = Lang.DlgSettingsTitle;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Uri uri;
            if (!Uri.TryCreate(RedmineBaseUrlTextBox.Text, UriKind.Absolute, out uri))
            {
                MessageBox.Show(Lang.Error_InvalidUrl, Lang.Error, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                this.RedmineBaseUrlTextBox.Focus();
                return;
            }
            SaveConfig();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveConfig()
        {
            try
            {
                Languages.Lang.Culture = (System.Globalization.CultureInfo)LanguageComboBox.SelectedItem;
            }
            catch (Exception) { }
            try
            {
                Properties.Settings.Default.PropertyValues["RedmineURL"].PropertyValue = RedmineBaseUrlTextBox.Text;
                Properties.Settings.Default.PropertyValues["RedmineUser"].PropertyValue = RedmineUsernameTextBox.Text;
                Properties.Settings.Default.PropertyValues["RedminePassword"].PropertyValue = RedminePasswordTextBox.Text;
                Properties.Settings.Default.PropertyValues["RedmineAuthentication"].PropertyValue = AuthenticationCheckBox.Checked;
                Properties.Settings.Default.PropertyValues["CheckForUpdates"].PropertyValue = CheckForUpdatesCheckBox.Checked;
                Properties.Settings.Default.PropertyValues["MinimizeToSystemTray"].PropertyValue = MinimizeToSystemTrayCheckBox.Checked;
                Properties.Settings.Default.PropertyValues["MinimizeOnStartTimer"].PropertyValue = MinimizeOnStartTimerCheckBox.Checked;
                Properties.Settings.Default.PropertyValues["PopupInterval"].PropertyValue = PopupTimout.Value;
                Properties.Settings.Default.PropertyValues["CacheLifetime"].PropertyValue = CacheLifetime.Value;
                Properties.Settings.Default.PropertyValues["LanguageCode"].PropertyValue = Languages.Lang.Culture.Name;
                Properties.Settings.Default.PropertyValues["ApiVersion"].PropertyValue = (int)RedmineVersionComboBox.SelectedValue;
                if (ComboBoxCloseStatus.Enabled)
                    Properties.Settings.Default.PropertyValues["ClosedStatus"].PropertyValue = (int)ComboBoxCloseStatus.SelectedValue;
                Properties.Settings.Default.Save();
                String Name = Properties.Settings.Default.LanguageCode;
                Enumerations.SaveAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoadConfig()
        {
            RedmineBaseUrlTextBox.Text = Properties.Settings.Default.RedmineURL;
            AuthenticationCheckBox.Checked = Properties.Settings.Default.RedmineAuthentication;
            MinimizeToSystemTrayCheckBox.Checked = Properties.Settings.Default.MinimizeToSystemTray;
            MinimizeOnStartTimerCheckBox.Checked = Properties.Settings.Default.MinimizeOnStartTimer;
            RedmineUsernameTextBox.Text = Properties.Settings.Default.RedmineUser;
            RedminePasswordTextBox.Text = Properties.Settings.Default.RedminePassword;
            CheckForUpdatesCheckBox.Checked = Properties.Settings.Default.CheckForUpdates;
            CacheLifetime.Value = Properties.Settings.Default.CacheLifetime;
            PopupTimout.Value = Properties.Settings.Default.PopupInterval;
            RedmineVersionComboBox.SelectedIndex = RedmineVersionComboBox.FindStringExact(Languages.LangTools.GetTextForApiVersion((ApiVersion)Properties.Settings.Default.ApiVersion));
            try {
                Languages.Lang.Culture = new System.Globalization.CultureInfo(Properties.Settings.Default.LanguageCode);
            }
            catch (Exception)
            {
                Languages.Lang.Culture = System.Globalization.CultureInfo.CurrentUICulture;
            }
            LanguageComboBox.SelectedIndex = LanguageComboBox.FindStringExact(Languages.Lang.Culture.DisplayName);
        }

        private void AuthenticationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableAuthenticationFields();
        }

        private void EnableDisableAuthenticationFields()
        {
            if (AuthenticationCheckBox.Checked)
            {
                RedmineUsernameTextBox.Enabled = true;
                RedminePasswordTextBox.Enabled = true;
            }
            else
            {
                RedmineUsernameTextBox.Enabled = false;
                RedminePasswordTextBox.Enabled = false;
            }
        }

        private void BtnEditActivitiesButton_Click(object sender, EventArgs e)
        {
            EditEnumListForm dlg = new EditEnumListForm(Enumerations.Activities, Lang.EnumName_Activities);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Enumerations.Activities = dlg.enumeration;
                Enumerations.SaveActivities();
            }
        }

        private void BtnEditDocumentCategories_Click(object sender, EventArgs e)
        {
            EditEnumListForm dlg = new EditEnumListForm(Enumerations.DocumentCategories, Lang.EnumName_DocumentCategories);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Enumerations.DocumentCategories = dlg.enumeration;
                Enumerations.SaveDocumentCategories();
            }
        }

        private void BtnEditIssuePriorities_Click(object sender, EventArgs e)
        {
            EditEnumListForm dlg = new EditEnumListForm(Enumerations.IssuePriorities, Lang.EnumName_IssuePriorities);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Enumerations.IssuePriorities = dlg.enumeration;
                Enumerations.SaveIssuePriorities();
            }
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                Redmine.Net.Api.RedmineManager manager;
                if (AuthenticationCheckBox.Checked)
                    manager = new Redmine.Net.Api.RedmineManager(RedmineBaseUrlTextBox.Text, RedmineUsernameTextBox.Text, RedminePasswordTextBox.Text);
                else
                    manager = new Redmine.Net.Api.RedmineManager(RedmineBaseUrlTextBox.Text);
                User newCurrentUser = manager.GetCurrentUser();
                MessageBox.Show(Lang.ConnectionTestOK_Text, Lang.ConnectionTestOK_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Lang.ConnectionTestFailed_Text, ex.Message), Lang.ConnectionTestFailed_Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadAndEnableCloseStatus();
        }

        private List<IssueStatus> Statuses;
        private void LoadAndEnableCloseStatus()
        {
            ComboBoxCloseStatus.Enabled = false;
            if ((ApiVersion)RedmineVersionComboBox.SelectedValue < ApiVersion.V13x)
                return;
            try
            {
                Redmine.Net.Api.RedmineManager manager;
                Statuses = new List<IssueStatus>();
                if (AuthenticationCheckBox.Checked)
                    manager = new Redmine.Net.Api.RedmineManager(RedmineBaseUrlTextBox.Text, RedmineUsernameTextBox.Text, RedminePasswordTextBox.Text);
                else
                    manager = new Redmine.Net.Api.RedmineManager(RedmineBaseUrlTextBox.Text);

                NameValueCollection parameters = new NameValueCollection { { "is_closed", "true" } };
                foreach (IssueStatus status in manager.GetTotalObjectList<IssueStatus>(parameters))
                {
                    if (status.IsClosed)
                        Statuses.Add(status);
                }
                ComboBoxCloseStatus.DataSource = Statuses;
                ComboBoxCloseStatus.ValueMember = "Id";
                ComboBoxCloseStatus.DisplayMember = "Name";
                ComboBoxCloseStatus.Enabled = true;
                if (Properties.Settings.Default.ClosedStatus != 0)
                    ComboBoxCloseStatus.SelectedValue = Properties.Settings.Default.ClosedStatus;
                else
                    ComboBoxCloseStatus.SelectedIndex = ComboBoxCloseStatus.FindStringExact("Closed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Lang.Error_Exception, ex.Message), Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ComboBoxCloseStatus.Enabled = false;
                return;
            }
        }
    }
}
