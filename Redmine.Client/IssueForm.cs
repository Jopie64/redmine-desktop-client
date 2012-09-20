﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using Redmine.Net.Api.Types;
using Redmine.Client.Languages;

namespace Redmine.Client
{
    public partial class IssueForm : Form
    {
        public enum DialogType {
            New,
            Edit,
        };
        private Project project;
        private Issue issue;
        private int ProjectId { get { if (this.type == DialogType.New) return project.Id; else return issue.Project.Id; } }
        private DialogType type;
        private IssueFormData DataCache = null;

        public IssueForm(Project project)
        {
            this.project = project;
            this.type = DialogType.New;
            InitializeComponent();
            this.Text = String.Format(Lang.DlgIssueTitleNew, project.Name);
            BtnCloseButton.Visible = false;
            linkEditInRedmine.Visible = false;
            DataGridViewCustomFields.Visible = false;
            LangTools.UpdateControlsForLanguage(this.Controls);
        }

        public IssueForm(Issue issue)
        {
            this.issue = issue;
            this.type = DialogType.Edit;
            InitializeComponent();

            this.Text = String.Format(Lang.DlgIssueTitleEdit, issue.Id, issue.Project.Name);
            LangTools.UpdateControlsForLanguage(this.Controls);
        }

        private void BtnSaveButton_Click(object sender, EventArgs e)
        {
            Issue issue = new Issue();
            if (type == DialogType.Edit)
                issue.Id = this.issue.Id;
            issue.Project = new IdentifiableName { Id = ProjectId };
            issue.AssignedTo = new IdentifiableName { Id = Convert.ToInt32(ComboBoxAssignedTo.SelectedValue) };
            issue.Description = TextBoxDescription.Text;
            
            int time;
            issue.EstimatedHours = Int32.TryParse(TextBoxEstimatedTime.Text, out time) ? time : 0;
            issue.DoneRatio = Convert.ToInt32(numericUpDown1.Value);
            issue.Priority = new IdentifiableName { Id = Convert.ToInt32(ComboBoxPriority.SelectedValue) };
            if (DateStart.Enabled)
            {
                issue.StartDate = DateStart.Value;
            }
            if (DateDue.Enabled)
            {
                issue.DueDate = DateDue.Value;   
            }
            issue.Status = new IdentifiableName { Id = Convert.ToInt32(ComboBoxStatus.SelectedValue) };
            issue.Subject = TextBoxSubject.Text;
            issue.FixedVersion = new IdentifiableName { Id = Convert.ToInt32(ComboBoxTargetVersion.SelectedValue) };
            issue.Tracker = new IdentifiableName { Id = Convert.ToInt32(ComboBoxTracker.SelectedValue) };
            try
            {
                if (issue.Subject != String.Empty)
                {
                    if (type == DialogType.New)
                        RedmineClientForm.redmine.CreateObject<Issue>(issue);
                    else
                        RedmineClientForm.redmine.UpdateObject<Issue>(issue.Id.ToString(), issue);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Lang.Error_IssueSubjectMandatory,
                                Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TextBoxSubject.Focus();
                }
            }
            catch (Exception ex)
            {
                if (type == DialogType.New)
                    MessageBox.Show(String.Format(Lang.Error_CreateIssueFailed, ex.Message),
                                Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(String.Format(Lang.Error_UpdateIssueFailed, ex.Message),
                                Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void NewIssueForm_Load(object sender, EventArgs e)
        {
            cbDueDate.Checked = false;
            cbStartDate.Checked = false;
            DateStart.Enabled = false;
            DateDue.Enabled = false;
            if (this.DataCache == null)
            {
                this.Cursor = Cursors.AppStarting;
                backgroundWorker2.RunWorkerAsync(ProjectId);
                this.BtnSaveButton.Enabled = false;
            }
            else
            {
                FillForm();   
            }
        }

        private void FillForm()
        {
            if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
            {
                if (RedmineClientForm.RedmineVersion >= ApiVersion.V14x)
                {
                    this.ComboBoxAssignedTo.DataSource = this.DataCache.Assignees;
                    this.ComboBoxAssignedTo.DisplayMember = "Name";
                    this.ComboBoxAssignedTo.ValueMember = "Id";
                }
                else
                    ComboBoxAssignedTo.Enabled = false;
                this.ComboBoxStatus.DataSource = this.DataCache.Statuses;
                this.ComboBoxStatus.DisplayMember = "Name";
                this.ComboBoxStatus.ValueMember = "Id";
                this.ComboBoxTargetVersion.DataSource = this.DataCache.Versions;
                this.ComboBoxTargetVersion.DisplayMember = "Name";
                this.ComboBoxTargetVersion.ValueMember = "Id";
                this.ComboBoxTracker.DataSource = this.DataCache.Trackers;
                this.ComboBoxTracker.DisplayMember = "Name";
                this.ComboBoxTracker.ValueMember = "Id";
                //this.ListBoxWatchers.DataSource = RedmineClientForm.DataCache.Watchers;
                //this.ListBoxWatchers.DisplayMember = "Name";
                //this.ListBoxWatchers.ClearSelected();
            }
            else
            {
                ComboBoxAssignedTo.Enabled = false;
                ComboBoxStatus.Enabled = false;
                ComboBoxTargetVersion.Enabled = false;
                ComboBoxTracker.Enabled = false;
                BtnCloseButton.Visible = false;
            }
            this.ComboBoxPriority.DataSource = Enumerations.IssuePriorities;
            this.ComboBoxPriority.DisplayMember = "Name";
            this.ComboBoxPriority.ValueMember = "Id";

            if (this.type == DialogType.Edit)
            {
                if (issue.AssignedTo != null)
                {
                    if (RedmineClientForm.RedmineVersion >= ApiVersion.V14x)
                    {
                        ComboBoxAssignedTo.SelectedIndex = ComboBoxAssignedTo.FindStringExact(issue.AssignedTo.Name);
                    }
                    else
                    {
                        ComboBoxAssignedTo.Items.Add(issue.AssignedTo);
                        ComboBoxAssignedTo.DisplayMember = "Name";
                        ComboBoxAssignedTo.ValueMember = "Id";
                        ComboBoxAssignedTo.SelectedItem = issue.AssignedTo;
                    }
                }
                if (issue.Description != null)
                    TextBoxDescription.Text = issue.Description;
                TextBoxEstimatedTime.Text = issue.EstimatedHours.ToString();
                numericUpDown1.Value = Convert.ToDecimal(issue.DoneRatio);
                ComboBoxPriority.SelectedIndex = ComboBoxPriority.FindStringExact(issue.Priority.Name);
                if (issue.StartDate.HasValue)
                    DateStart.Value = issue.StartDate.Value;
                if (issue.DueDate.HasValue)
                    DateDue.Value = issue.DueDate.Value;
                if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
                {
                    ComboBoxStatus.SelectedIndex = ComboBoxStatus.FindStringExact(issue.Status.Name);
                    ComboBoxTracker.SelectedIndex = ComboBoxTracker.FindStringExact(issue.Tracker.Name);
                }
                else
                {
                    ComboBoxStatus.Items.Add(issue.Status);
                    ComboBoxStatus.DisplayMember = "Name";
                    ComboBoxStatus.ValueMember = "Id";
                    ComboBoxStatus.SelectedItem = issue.Status;
                    ComboBoxTracker.Items.Add(issue.Tracker);
                    ComboBoxTracker.DisplayMember = "Name";
                    ComboBoxTracker.ValueMember = "Id";
                    ComboBoxTracker.SelectedItem = issue.Tracker;
                }
                TextBoxSubject.Text = issue.Subject;
                if (issue.FixedVersion != null)
                {
                    if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
                    {
                        ComboBoxTargetVersion.SelectedIndex = ComboBoxTargetVersion.FindStringExact(issue.FixedVersion.Name);
                    }
                    else
                    {
                        ComboBoxTargetVersion.Items.Add(issue.FixedVersion);
                        ComboBoxTargetVersion.DisplayMember = "Name";
                        ComboBoxTargetVersion.ValueMember = "Id";
                        ComboBoxTargetVersion.SelectedItem = issue.FixedVersion;
                    }
                }
                if (issue.CustomFields.Count == 0)
                    DataGridViewCustomFields.Visible = false;
                else
                {
                    DataGridViewCustomFields.DataSource = issue.CustomFields;
                    DataGridViewCustomFields.RowHeadersVisible = false;
                    DataGridViewCustomFields.ColumnHeadersVisible = false;
                    DataGridViewCustomFields.Columns["Multiple"].Visible = false;
                    DataGridViewCustomFields.Columns["Id"].Visible = false;
                    DataGridViewCustomFields.Columns["Name"].DisplayIndex = 0;
                    DataGridViewCustomFields.Columns["Value"].DisplayIndex = 1;
                }
            }
        }

        private static Assignee MemberToAssignee(ProjectMembership projectMember)
        {
            return new Assignee(projectMember);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DataCache = new IssueFormData();
            int projectId = (int)e.Argument;
            NameValueCollection parameters = new NameValueCollection { { "project_id", projectId.ToString() } };

            try
            {
                if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
                {
                    this.DataCache.Statuses = RedmineClientForm.redmine.GetTotalObjectList<IssueStatus>(parameters);
                    this.DataCache.Trackers = RedmineClientForm.redmine.GetTotalObjectList<Tracker>(parameters);
                    this.DataCache.Versions = (List<Redmine.Net.Api.Types.Version>)RedmineClientForm.redmine.GetTotalObjectList<Redmine.Net.Api.Types.Version>(parameters);
                    this.DataCache.Versions.Insert(0, new Redmine.Net.Api.Types.Version { Id = 0, Name = "" });
                    if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
                    {
                        List<ProjectMembership> projectMembers = (List<ProjectMembership>)RedmineClientForm.redmine.GetTotalObjectList<ProjectMembership>(parameters);
                        //RedmineClientForm.DataCache.Watchers = projectMembers.ConvertAll(new Converter<ProjectMembership, Assignee>(MemberToAssignee));
                        this.DataCache.Assignees = projectMembers.ConvertAll(new Converter<ProjectMembership, Assignee>(MemberToAssignee));
                        this.DataCache.Assignees.Insert(0, new Assignee(new ProjectMembership { Id = 0, User = new IdentifiableName { Id = 0, Name = "" } }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Lang.Error_Exception, ex.Message), Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            FillForm();
            this.BtnSaveButton.Enabled = true;
        }

        private void cbStartDate_CheckedChanged(object sender, EventArgs e)
        {
            DateStart.Enabled = cbStartDate.Checked;
        }

        private void cbDueDate_CheckedChanged(object sender, EventArgs e)
        {
            DateDue.Enabled = cbDueDate.Checked;
        }

        private void BtnCloseButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ClosedStatus == 0)
            {
                MessageBox.Show(Lang.Error_ClosedStatusUnknown, Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show(String.Format(Lang.CloseIssueText, issue.Id), Lang.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ComboBoxStatus.SelectedValue = Properties.Settings.Default.ClosedStatus; // ComboBoxStatus.FindStringExact("Closed");
                BtnSaveButton_Click(null, null);
            }
        }

        private void linkEditInRedmine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkEditInRedmine.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start(RedmineClientForm.RedmineURL + "/issues/" + issue.Id.ToString());
        }


    }
}
