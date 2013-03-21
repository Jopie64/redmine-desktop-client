﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using Redmine.Net.Api.Types;
using Redmine.Client.Languages;
using System.Text.RegularExpressions;
using System.IO;

namespace Redmine.Client
{
    public partial class IssueForm : BgWorker
    {
        class ClientCustomField
        {
            public String Name { get; set; }
            public String Value { get; set; }
        };
        class ClientIssueRelation : IssueRelation
        {
            private Issue issueTo;
            public String IssueToSubject { get { return issueTo.Subject; } }
            public IdentifiableName IssueToTracker { get { return issueTo.Tracker; } }
            public IdentifiableName IssueToStatus { get { return issueTo.Status; } }
            public ClientIssueRelation(IssueRelation relation, Issue issueTo)
            {
                this.Id = relation.Id;
                this.IssueId = relation.IssueId;
                this.IssueToId = relation.IssueToId;
                this.Type = relation.Type;
                this.issueTo = issueTo;
            }
        };
        private Project project;
        private int issueId = 0;
        private Issue issue;
        private List<ClientIssueRelation> issueRelations;
        private int projectId;
        private DialogType type;
        private IssueFormData DataCache = null;

        private Label LabelChildren;
        private DataGridView DataGridViewChildren;
        private Label LabelParent;
        private Label LabelRelations;
        private DataGridView DataGridViewRelations;

        private const int ChildrenHeight = 119;
        private const int RelationsHeight = 119;
        private const int ParentHeight = 24;

        public IssueForm(Project project)
        {
            this.project = project;
            this.projectId = project.Id;
            this.type = DialogType.New;
            InitializeComponent();
            UpdateTitle(null);
            BtnCloseButton.Visible = false;
            linkEditInRedmine.Visible = false;
            DataGridViewCustomFields.Visible = false;
            downloadOpenToolStripMenuItem.Enabled = false;
            LangTools.UpdateControlsForLanguage(this.Controls);
            LangTools.UpdateControlsForLanguage(contextMenuStripAttachments.Items);

            // initialize new objects
            Issue issue = new Issue();
            issue.Attachments = new List<Attachment>();
        }

        public IssueForm(Issue issue)
        {
            this.issueId = issue.Id;
            this.projectId = issue.Project.Id;
            this.type = DialogType.Edit;
            InitializeComponent();

            LangTools.UpdateControlsForLanguage(this.Controls);
            LangTools.UpdateControlsForLanguage(contextMenuStripAttachments.Items);
            UpdateTitle(issue);

            BtnDeleteButton.Visible = false;

            EnableDisableAllControls(false);
        }

        private void UpdateTitle(Issue issue)
        {
            if (type == DialogType.New)
                this.Text = String.Format(Lang.DlgIssueTitleNew, project.Name);
            else
                this.Text = String.Format(Lang.DlgIssueTitleEdit, issue.Id, issue.Project.Name);
        }

        private void EnableDisableAllControls(bool enable)
        {
            //BtnCancelButton.Enabled = enable;
            BtnSaveButton.Enabled = enable;
            labelTracker.Enabled = enable;
            ComboBoxTracker.Enabled = enable;
            DateStart.Enabled = enable;
            labelSubject.Enabled = enable;
            TextBoxSubject.Enabled = enable;
            labelDescription.Enabled = enable;
            TextBoxDescription.Enabled = enable;
            labelStatus.Enabled = enable;
            ComboBoxStatus.Enabled = enable;
            labelPriority.Enabled = enable;
            ComboBoxPriority.Enabled = enable;
            DateDue.Enabled = enable;
            labelEstimatedTime.Enabled = enable;
            TextBoxEstimatedTime.Enabled = enable;
            labelAssignedTo.Enabled = enable;
            ComboBoxAssignedTo.Enabled = enable;
            labelTargetVersion.Enabled = enable;
            ComboBoxTargetVersion.Enabled = enable;
            numericUpDown1.Enabled = enable;
            labelPercentDone.Enabled = enable;
            cbStartDate.Enabled = enable;
            cbDueDate.Enabled = enable;
            BtnCloseButton.Enabled = enable;
            //linkEditInRedmine.Enabled = enable;
            DataGridViewCustomFields.Enabled = enable;
            BtnViewTimeButton.Enabled = enable;
        }

        private void BtnSaveButton_Click(object sender, EventArgs e)
        {
            if (type == DialogType.Edit)
                issue.Id = this.issue.Id;
            // first check subject as it is mandatory
            issue.Subject = TextBoxSubject.Text;
            if (String.IsNullOrEmpty(issue.Subject))
            {
                MessageBox.Show(Lang.Error_IssueSubjectMandatory,
                            Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TextBoxSubject.Focus();
            }

            issue.Project = new IdentifiableName { Id = projectId };
            issue.AssignedTo = new IdentifiableName { Id = Convert.ToInt32(ComboBoxAssignedTo.SelectedValue) };
            issue.Description = TextBoxDescription.Text;

            int time;
            issue.EstimatedHours = Int32.TryParse(TextBoxEstimatedTime.Text, out time) ? time : 0;
            issue.DoneRatio = Convert.ToInt32(numericUpDown1.Value);
            issue.Priority = new IdentifiableName { Id = Convert.ToInt32(ComboBoxPriority.SelectedValue) };
            if (DateStart.Enabled && cbStartDate.Checked)
                issue.StartDate = DateStart.Value;
            else
                issue.StartDate = null;
            if (DateDue.Enabled && cbDueDate.Checked)
                issue.DueDate = DateDue.Value;
            else
                issue.DueDate = null;
            issue.Status = new IdentifiableName { Id = Convert.ToInt32(ComboBoxStatus.SelectedValue) };
            issue.FixedVersion = new IdentifiableName { Id = Convert.ToInt32(ComboBoxTargetVersion.SelectedValue) };
            issue.Tracker = new IdentifiableName { Id = Convert.ToInt32(ComboBoxTracker.SelectedValue) };
            try
            {
                if (type == DialogType.New)
                {
                    if (issue.Attachments.Count >= 0)
                    {
                        // first upload all attachment
                        issue.Uploads = new List<Upload>();
                        foreach (var a in issue.Attachments)
                        {
                            byte[] file = File.ReadAllBytes(a.ContentUrl);
                            Upload uploadedFile = RedmineClientForm.redmine.UploadData(file);
                            uploadedFile.FileName = a.FileName;
                            uploadedFile.Description = a.Description;
                            uploadedFile.ContentType = a.ContentType;
                            issue.Uploads.Add(uploadedFile);
                        }
                    }
                    RedmineClientForm.redmine.CreateObject<Issue>(issue);
                }
                else
                    RedmineClientForm.redmine.UpdateObject<Issue>(issue.Id.ToString(), issue);

                // resize to screen without children and parents...
                SetOriginalSize();

                this.DialogResult = DialogResult.OK;
                if (type == DialogType.Edit)
                    RedmineClientForm.Instance.Invoke(new AsyncCloseForm(RedmineClientForm.Instance.IssueFormClosed), new Object[] { this.DialogResult, Size });
                this.Close();
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
            // resize to screen without children and parents...
            if (issue != null)
            {
                SetOriginalSize();
            }
            this.DialogResult = DialogResult.Cancel;
            if (type == DialogType.Edit)
                RedmineClientForm.Instance.Invoke(new AsyncCloseForm(RedmineClientForm.Instance.IssueFormClosed), new Object[] { this.DialogResult, Size });
            this.Close();
        }

        private void SetOriginalSize()
        {
            if (DataGridViewChildren != null)
            {
                MinimumSize = new System.Drawing.Size(MinimumSize.Width, MinimumSize.Height - ChildrenHeight);
                Size = new System.Drawing.Size(Size.Width, Size.Height - ChildrenHeight);
            }
            if (LabelParent != null)
            {
                MinimumSize = new System.Drawing.Size(MinimumSize.Width, MinimumSize.Height - ParentHeight);
                Size = new System.Drawing.Size(Size.Width, Size.Height - ParentHeight);
            }
            if (DataGridViewRelations != null)
            {
                MinimumSize = new System.Drawing.Size(MinimumSize.Width, MinimumSize.Height - RelationsHeight);
                Size = new System.Drawing.Size(Size.Width, Size.Height - RelationsHeight);
            }
        }

        private void NewIssueForm_Load(object sender, EventArgs e)
        {
            cbDueDate.Checked = false;
            cbStartDate.Checked = false;
            DateStart.Enabled = false;
            DateDue.Enabled = false;
            if (this.DataCache == null)
            {
                UpdateDataFromRedmine();
            }
            else
            {
                FillForm();
            }
        }

        private void UpdateDataFromRedmine()
        {
            EnableDisableAllControls(false);
            this.Cursor = Cursors.AppStarting;
            RunWorkerAsync(projectId);
            this.BtnSaveButton.Enabled = false;
        }

        private void FillForm()
        {
            EnableDisableAllControls(true);
            // update title again
            UpdateTitle(issue);
            if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
            {
                if (RedmineClientForm.RedmineVersion >= ApiVersion.V14x)
                {
                    this.ComboBoxAssignedTo.DataSource = this.DataCache.ProjectMembers;
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
                    TextBoxDescription.Text = Regex.Replace(issue.Description, "(?<!\r)\n", "\r\n");
                TextBoxEstimatedTime.Text = issue.EstimatedHours.ToString();
                numericUpDown1.Value = Convert.ToDecimal(issue.DoneRatio);
                ComboBoxPriority.SelectedIndex = ComboBoxPriority.FindStringExact(issue.Priority.Name);

                cbStartDate.Checked = issue.StartDate.HasValue;
                DateStart.Enabled = cbStartDate.Checked;
                if (issue.StartDate.HasValue)
                    DateStart.Value = issue.StartDate.Value;

                cbDueDate.Checked = issue.DueDate.HasValue;
                DateDue.Enabled = cbDueDate.Checked;
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
                if (issue.CustomFields != null && issue.CustomFields.Count != 0)
                {
                    List<ClientCustomField> customFields = new List<ClientCustomField>();
                    foreach (CustomField cf in issue.CustomFields)
                    {
                        ClientCustomField field = new ClientCustomField();
                        field.Name = cf.Name;
                        foreach (CustomFieldValue cfv in cf.Values)
                        {
                            if (field.Value == null)
                                field.Value = cfv.Info;
                            else
                                field.Value += ", " + cfv.Info;
                        }
                        customFields.Add(field);
                    }
                    DataGridViewCustomFields.DataSource = customFields;
                    DataGridViewCustomFields.RowHeadersVisible = false;
                    DataGridViewCustomFields.ColumnHeadersVisible = false;
                    try // Very ugly trick to fix the mono crash reported in the SF.net forum
                    {
                        DataGridViewCustomFields.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    catch (Exception) { }
                    DataGridViewCustomFields.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                    DataGridViewCustomFields.Visible = false;

                if (issue.Attachments != null)
                {
                    dataGridViewAttachments.RowHeadersVisible = false;
                    dataGridViewAttachments.ColumnHeadersVisible = false;
                    AttachAttachements(issue.Attachments);
                }
                // if the issue has children, show them.
                if (issue.Children != null && issue.Children.Count > 0)
                {
                    LabelChildren = new Label();
                    LabelChildren.AutoSize = true;
                    LabelChildren.Location = new System.Drawing.Point(TextBoxDescription.Location.X, linkEditInRedmine.Location.Y);
                    LabelChildren.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                    LabelChildren.Name = "LabelChildren";
                    LabelChildren.Size = new System.Drawing.Size(44, 13);
                    LabelChildren.TabIndex = 4;
                    LabelChildren.Text = Lang.LabelChildren;
                    LabelChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                    Controls.Add(LabelChildren);

                    DataGridViewChildren = new DataGridView();
                    DataGridViewChildren.AllowUserToAddRows = false;
                    DataGridViewChildren.AllowUserToDeleteRows = false;
                    DataGridViewChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    DataGridViewChildren.Location = new System.Drawing.Point(TextBoxDescription.Location.X, linkEditInRedmine.Location.Y + 19);
                    DataGridViewChildren.MultiSelect = false;
                    DataGridViewChildren.Name = "DataGridViewChildren";
                    DataGridViewChildren.ReadOnly = true;
                    DataGridViewChildren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                    DataGridViewChildren.Size = new System.Drawing.Size(TextBoxDescription.Width, 88);
                    DataGridViewChildren.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewChildren_CellFormatting);
                    DataGridViewChildren.TabIndex = 26;
                    DataGridViewChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    DataGridViewChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    Controls.Add(DataGridViewChildren);
                    DataGridViewChildren.DataSource = issue.Children;
                    try // Very ugly trick to fix the mono crash reported in the SF.net forum
                    {
                        DataGridViewChildren.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    catch (Exception) { }
                    if (DataGridViewChildren.Columns.Count > 0)
                    {
                        DataGridViewChildren.Columns["Subject"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    DataGridViewChildren.RowHeadersWidth = 20;
                    foreach (DataGridViewColumn column in DataGridViewChildren.Columns)
                    {
                        if (column.Name != "Id" && column.Name != "Subject")
                        {
                            column.Visible = false;
                        }
                    }
                    DataGridViewChildren.Columns["Id"].DisplayIndex = 0;
                    DataGridViewChildren.Columns["Subject"].DisplayIndex = 1;
                    SuspendLayout();
                    // first set size, then alter minimum size; otherwise dialog is expanded twice.
                    Size = new System.Drawing.Size(Size.Width, Size.Height + ChildrenHeight);
                    MinimumSize = new System.Drawing.Size(MinimumSize.Width, MinimumSize.Height + ChildrenHeight);
                    MoveControl(linkEditInRedmine, 0, ChildrenHeight);
                    MoveControl(BtnCancelButton, 0, ChildrenHeight);
                    MoveControl(BtnCloseButton, 0, ChildrenHeight);
                    MoveControl(BtnSaveButton, 0, ChildrenHeight);
                    ResumeLayout(false);
                }
                if (issue.ParentIssue != null && issue.ParentIssue.Id != 0)
                {
                    LabelParent = new Label();
                    LabelParent.AutoSize = true;
                    System.Drawing.Font defaultFont = (System.Drawing.Font)labelDescription.Font.Clone();
                    LabelParent.Font = new System.Drawing.Font(defaultFont.FontFamily, defaultFont.Size, System.Drawing.FontStyle.Italic, defaultFont.Unit, defaultFont.GdiCharSet);
                    LabelParent.Location = new System.Drawing.Point(TextBoxDescription.Location.X, linkEditInRedmine.Location.Y);
                    LabelParent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                    LabelParent.Name = "LabelParent";
                    LabelParent.Size = new System.Drawing.Size(44, 13);
                    LabelParent.TabIndex = 4;
                    LabelParent.Text = String.Format(Lang.LabelParent, issue.ParentIssue.Id, issue.ParentIssue.Name);
                    LabelParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                    Controls.Add(LabelParent);
                    SuspendLayout();
                    // first set size, then alter minimum size; otherwise dialog is expanded twice.
                    Size = new System.Drawing.Size(Size.Width, Size.Height + ParentHeight);
                    MinimumSize = new System.Drawing.Size(MinimumSize.Width, MinimumSize.Height + ParentHeight);
                    MoveControl(linkEditInRedmine, 0, ParentHeight);
                    MoveControl(BtnCancelButton, 0, ParentHeight);
                    MoveControl(BtnCloseButton, 0, ParentHeight);
                    MoveControl(BtnSaveButton, 0, ParentHeight);
                    ResumeLayout(false);
                    if (Size.Width < LabelParent.Width + 30)
                        Size = new System.Drawing.Size(LabelParent.Width + 30, Size.Height);
                    if (MinimumSize.Width < LabelParent.Width + 30)
                        MinimumSize = new System.Drawing.Size(LabelParent.Width + 30, MinimumSize.Height);
                }
                // if the issue has children, show them.
                if (issue.Relations != null && issue.Relations.Count > 0)
                {
                    LabelRelations = new Label();
                    LabelRelations.AutoSize = true;
                    LabelRelations.Location = new System.Drawing.Point(TextBoxDescription.Location.X, linkEditInRedmine.Location.Y);
                    LabelRelations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                    LabelRelations.Name = "LabelRelations";
                    LabelRelations.Size = new System.Drawing.Size(44, 13);
                    LabelRelations.TabIndex = 4;
                    LabelRelations.Text = Lang.LabelRelations;
                    LabelRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                    Controls.Add(LabelRelations);

                    DataGridViewRelations = new DataGridView();
                    DataGridViewRelations.AllowUserToAddRows = false;
                    DataGridViewRelations.AllowUserToDeleteRows = false;
                    DataGridViewRelations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    DataGridViewRelations.Location = new System.Drawing.Point(TextBoxDescription.Location.X, linkEditInRedmine.Location.Y + 19);
                    DataGridViewRelations.MultiSelect = false;
                    DataGridViewRelations.Name = "DataGridViewRelations";
                    DataGridViewRelations.ReadOnly = true;
                    DataGridViewRelations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                    DataGridViewRelations.Size = new System.Drawing.Size(TextBoxDescription.Width, 88);
                    DataGridViewRelations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewRelations_CellFormatting);
                    DataGridViewRelations.TabIndex = 26;
                    DataGridViewRelations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    DataGridViewRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                    Controls.Add(DataGridViewRelations);
                    DataGridViewRelations.DataSource = issueRelations;
                    try // Very ugly trick to fix the mono crash reported in the SF.net forum
                    {
                        DataGridViewRelations.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    }
                    catch (Exception) { }
                    if (DataGridViewRelations.Columns.Count > 0)
                    {
                        DataGridViewRelations.Columns["IssueToSubject"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    DataGridViewRelations.RowHeadersWidth = 20;
                    foreach (DataGridViewColumn column in DataGridViewRelations.Columns)
                    {
                        if (column.Name != "Id"
                            && column.Name != "IssueToSubject"
                            && column.Name != "Type"
                            && column.Name != "IssueToStatus")
                        {
                            column.Visible = false;
                        }
                    }
                    DataGridViewRelations.Columns["Type"].DisplayIndex = 0;
                    DataGridViewRelations.Columns["Type"].HeaderText = "Relation";
                    DataGridViewRelations.Columns["Id"].DisplayIndex = 1;
                    DataGridViewRelations.Columns["IssueToSubject"].DisplayIndex = 2;
                    DataGridViewRelations.Columns["IssueToSubject"].HeaderText = "Subject";
                    DataGridViewRelations.Columns["IssueToStatus"].DisplayIndex = 3;
                    DataGridViewRelations.Columns["IssueToStatus"].HeaderText = "Status";

                    SuspendLayout();
                    // first set size, then alter minimum size; otherwise dialog is expanded twice.
                    Size = new System.Drawing.Size(Size.Width, Size.Height + RelationsHeight);
                    MinimumSize = new System.Drawing.Size(MinimumSize.Width, MinimumSize.Height + RelationsHeight);
                    MoveControl(linkEditInRedmine, 0, RelationsHeight);
                    MoveControl(BtnCancelButton, 0, RelationsHeight);
                    MoveControl(BtnCloseButton, 0, RelationsHeight);
                    MoveControl(BtnSaveButton, 0, RelationsHeight);
                    ResumeLayout(false);
                }
            }
            else // type new
            {
                cbStartDate.Checked = true;
                DateStart.Enabled = cbStartDate.Checked;
                DateDue.Enabled = cbDueDate.Checked;
            }
        }

        private void AttachAttachements(IList<Attachment> attachments)
        {
            dataGridViewAttachments.DataSource = null;
            dataGridViewAttachments.DataSource = attachments;
            foreach (DataGridViewColumn column in dataGridViewAttachments.Columns)
            {
                if (column.Name != "FileName"
                    && column.Name != "Description"
                    && column.Name != "Author")
                {
                    column.Visible = false;
                }
            }
            try // Very ugly trick to fix the mono crash reported in the SF.net forum
            {
                dataGridViewAttachments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception) { }
            dataGridViewAttachments.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewAttachments.Columns["FileName"].DisplayIndex = 0;
            dataGridViewAttachments.Columns["Description"].DisplayIndex = 1;
            dataGridViewAttachments.Columns["Author"].DisplayIndex = 2;
        }

        private void MoveControl(Control control, int diffx, int diffy)
        {
            System.Drawing.Point loc = control.Location;
            loc.X += diffx;
            loc.Y += diffy;
            control.Location = loc;
        }

        private static ProjectMember MembershipToMember(ProjectMembership projectMember)
        {
            return new ProjectMember(projectMember);
        }

        private void RunWorkerAsync(int projectId)
        {
            NameValueCollection parameters = new NameValueCollection { { "project_id", projectId.ToString() } };

            AddBgWork(Lang.BgWork_GetIssue, () =>
                {
                    try
                    {
                        IssueFormData dataCache = new IssueFormData();
                        List<ClientIssueRelation> currentIssueRelations = new List<ClientIssueRelation>();
                        Issue currentIssue = null;
                        if (type == DialogType.Edit)
                        {
                            NameValueCollection issueParameters = new NameValueCollection { { "include", "journals,relations,children,attachments" } };
                            currentIssue = RedmineClientForm.redmine.GetObject<Issue>(issueId.ToString(), issueParameters);
                            if (currentIssue.ParentIssue != null && currentIssue.ParentIssue.Id != 0)
                            {
                                Issue parentIssue = RedmineClientForm.redmine.GetObject<Issue>(currentIssue.ParentIssue.Id.ToString(), null);
                                currentIssue.ParentIssue.Name = parentIssue.Subject;
                            }
                        }
                        else
                        {
                            // initialize new objects
                            currentIssue = new Issue();
                            currentIssue.Id = 0;
                            currentIssue.Subject = Lang.NewIssue;
                            currentIssue.Attachments = new List<Attachment>();
                        }
                        if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
                        {
                            dataCache.Statuses = RedmineClientForm.redmine.GetTotalObjectList<IssueStatus>(parameters);
                            dataCache.Trackers = RedmineClientForm.redmine.GetTotalObjectList<Tracker>(parameters);
                            dataCache.Versions = (List<Redmine.Net.Api.Types.Version>)RedmineClientForm.redmine.GetTotalObjectList<Redmine.Net.Api.Types.Version>(parameters);
                            dataCache.Versions.Insert(0, new Redmine.Net.Api.Types.Version { Id = 0, Name = "" });
                            if (RedmineClientForm.RedmineVersion >= ApiVersion.V13x)
                            {
                                List<ProjectMembership> projectMembers = (List<ProjectMembership>)RedmineClientForm.redmine.GetTotalObjectList<ProjectMembership>(parameters);
                                //RedmineClientForm.DataCache.Watchers = projectMembers.ConvertAll(new Converter<ProjectMembership, Assignee>(MemberToAssignee));
                                dataCache.ProjectMembers = projectMembers.ConvertAll(new Converter<ProjectMembership, ProjectMember>(MembershipToMember));
                                dataCache.ProjectMembers.Insert(0, new ProjectMember(new ProjectMembership { Id = 0, User = new IdentifiableName { Id = 0, Name = "" } }));
                                if (RedmineClientForm.RedmineVersion >= ApiVersion.V22x)
                                {
                                    Enumerations.UpdateIssuePriorities(RedmineClientForm.redmine.GetTotalObjectList<IssuePriority>(null));
                                    Enumerations.SaveIssuePriorities();
                                }
                            }
                            if (currentIssue.Relations != null)
                            {
                                foreach (var r in currentIssue.Relations)
                                {
                                    Issue relatedIssue = RedmineClientForm.redmine.GetObject<Issue>(r.IssueToId.ToString(), null);
                                    currentIssueRelations.Add(new ClientIssueRelation(r, relatedIssue));
                                }
                            }
                        }
                        return () =>
                            {
                                this.issue = currentIssue;
                                this.issueRelations = currentIssueRelations;
                                this.DataCache = dataCache;
                                FillForm();
                                this.BtnSaveButton.Enabled = true;
                                this.Cursor = Cursors.Default;
                            };
                    }
                    catch (Exception ex)
                    {
                        return () =>
                            {
                                MessageBox.Show(String.Format(Lang.Error_Exception, ex.Message), Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                                this.Cursor = Cursors.Default;
                            };
                    }
                });
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
            System.Diagnostics.Process.Start(RedmineClientForm.RedmineURL + "/issues/" + issueId.ToString());
        }

        private void BtnViewTimeButton_Click(object sender, EventArgs e)
        {
            try
            {
                TimeEntriesForm dlg = new TimeEntriesForm(issue, DataCache.ProjectMembers);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    //BtnRefreshButton_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Lang.Error_Exception, ex.Message), Lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DataGridViewChildren_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DataGridViewChildren.Columns["Id"].Index) // Id column
            {
                IssueChild currentIssueChild = (IssueChild)DataGridViewChildren.Rows[e.RowIndex].DataBoundItem;
                e.Value = currentIssueChild.Tracker.Name + " " + currentIssueChild.Id.ToString();
            }
        }

        private void DataGridViewRelations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DataGridViewRelations.Columns["Id"].Index) // Id column
            {
                ClientIssueRelation currentIssueRelation = (ClientIssueRelation)DataGridViewRelations.Rows[e.RowIndex].DataBoundItem;
                e.Value = currentIssueRelation.IssueToTracker.Name + " " + currentIssueRelation.IssueToId.ToString();
            }
            if (e.ColumnIndex == DataGridViewRelations.Columns["IssueToStatus"].Index) // Id column
            {
                ClientIssueRelation currentIssueRelation = (ClientIssueRelation)DataGridViewRelations.Rows[e.RowIndex].DataBoundItem;
                e.Value = currentIssueRelation.IssueToStatus.Name;
            }
        }

        private void dataGridViewAttachments_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (type == DialogType.New)
                return;
            Attachment attachment = (Attachment)dataGridViewAttachments.Rows[e.RowIndex].DataBoundItem;
            System.Diagnostics.Process.Start(attachment.ContentUrl);
        }

        private void dataGridViewAttachments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewAttachments.Columns["FileName"].Index) // Filename
            {
                Attachment attachment = (Attachment)dataGridViewAttachments.Rows[e.RowIndex].DataBoundItem;
                e.Value = attachment.FileName + " (" + attachment.FileSize.ToByteString() + ")";
            }
            if (e.ColumnIndex == dataGridViewAttachments.Columns["Author"].Index) // Author
            {
                Attachment attachment = (Attachment)dataGridViewAttachments.Rows[e.RowIndex].DataBoundItem;
                e.Value = attachment.Author.Name;
            }
        }

        private void BtnAddButton_Click(object sender, EventArgs e)
        {
            AttachmentForm dlg = new AttachmentForm(issue, type, "");
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                if (type == DialogType.Edit)
                    UpdateDataFromRedmine();
                else
                {
                    issue.Attachments.Add(dlg.NewAttachment);
                    AttachAttachements(issue.Attachments);
                }
            }
        }

        private void dataGridViewAttachments_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void dataGridViewAttachments_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool addedAttachment = false;
                foreach (var file in files)
                {
                    AttachmentForm dlg = new AttachmentForm(issue, type, file);
                    if (dlg.ShowDialog(this) == DialogResult.Cancel)
                        break;
                    else
                    {
                        if (type == DialogType.New)
                            issue.Attachments.Add(dlg.NewAttachment);
                    }
                    addedAttachment = true;
                }
                if (addedAttachment)
                {
                    if (type == DialogType.Edit)
                        UpdateDataFromRedmine();
                    else
                        AttachAttachements(issue.Attachments);
                }
            }
        }

        private void dataGridViewAttachments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewAttachments.ClearSelection();
                dataGridViewAttachments.Rows[e.RowIndex].Selected = true;
            }
        }

        private void downloadOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (type == DialogType.New)
                return;

            if (dataGridViewAttachments.SelectedRows.Count <= 0)
                return;

            Attachment attachment = (Attachment)dataGridViewAttachments.SelectedRows[0].DataBoundItem;
            System.Diagnostics.Process.Start(attachment.ContentUrl);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnAddButton_Click(sender, e);
        }

        private void BtnDeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewAttachments.SelectedRows.Count <= 0)
                return;

            Attachment attachment = (Attachment)dataGridViewAttachments.SelectedRows[0].DataBoundItem;
            issue.Attachments.Remove(attachment);
            AttachAttachements(issue.Attachments);
        }
    }
}
