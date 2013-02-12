﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Redmine.Net.Api.Types;
using Redmine.Client.Languages;

namespace Redmine.Client
{
    public partial class TimeEntryForm : BgWorker
    {
        public enum eFormType
        {
            New,
            Edit,
        };
        public TimeEntry CurTimeEntry { get; set; }
        private Issue issue;
        private IList<ProjectMember> projectMembers;
        private eFormType type;

        public TimeEntryForm(Issue issue, IList<ProjectMember> projectMembers)
        {
            InitializeComponent();
            this.issue = issue;
            this.projectMembers = projectMembers;
            type = eFormType.New;
            CurTimeEntry = new TimeEntry();
            LoadLanguage();
            LoadCombos();
        }
        public TimeEntryForm(Issue issue, IList<ProjectMember> projectMembers, TimeEntry timeEntry)
        {
            InitializeComponent();
            this.issue = issue;
            this.projectMembers = projectMembers;
            type = eFormType.Edit;
            CurTimeEntry = timeEntry;
            LoadLanguage();
            LoadCombos();

            if (CurTimeEntry.SpentOn.HasValue)
                datePickerSpentOn.Value = CurTimeEntry.SpentOn.Value;

            comboBoxByUser.SelectedValue = CurTimeEntry.User.Id;
            comboBoxActivity.SelectedValue = CurTimeEntry.Activity.Id;
            textBoxSpentHours.Text = CurTimeEntry.Hours.ToString();
            textBoxComment.Text = CurTimeEntry.Comments;
        }

        private void LoadCombos()
        {
            comboBoxActivity.DataSource = Enumerations.Activities;
            comboBoxActivity.DisplayMember = "Name";
            comboBoxActivity.ValueMember = "Id";
            comboBoxByUser.DataSource = projectMembers;
            comboBoxActivity.DisplayMember = "Name";
            comboBoxActivity.ValueMember = "Id";
        }

        private void LoadLanguage()
        {
            LangTools.UpdateControlsForLanguage(this.Controls);
            if (type == eFormType.New)
            {
                this.Text = String.Format(Lang.DlgTimeEntryFormTitle_New, issue.Id, issue.Subject);
                labelTimeEntryTitle.Text = String.Format(Lang.labelTimeEntryTitle_New, issue.Id, issue.Subject);
            }
            else
            {
                string fmtSpentOn = "";
                if (CurTimeEntry.SpentOn.HasValue)
                    fmtSpentOn = CurTimeEntry.SpentOn.Value.ToString("d", Lang.Culture);
                this.Text = String.Format(Lang.DlgTimeEntryFormTitle_Edit, fmtSpentOn, issue.Id, issue.Subject);
                labelTimeEntryTitle.Text = String.Format(Lang.labelTimeEntryTitle_Edit, fmtSpentOn, issue.Id, issue.Subject);
            }
        }

        private void BtnOKButton_Click(object sender, EventArgs e)
        {
            CurTimeEntry.SpentOn = datePickerSpentOn.Value;
            CurTimeEntry.User.Id = ((ProjectMember)comboBoxByUser.SelectedItem).Id;
            CurTimeEntry.Activity.Id = ((IdentifiableName)comboBoxActivity.SelectedItem).Id;
            CurTimeEntry.Hours = decimal.Parse(textBoxSpentHours.Text, Lang.Culture);
            CurTimeEntry.Comments = textBoxComment.Text;

            if (type == eFormType.New)
                RedmineClientForm.redmine.CreateObject(CurTimeEntry);
            else
                RedmineClientForm.redmine.UpdateObject(CurTimeEntry.Id.ToString(), CurTimeEntry);
        }
    }
}
