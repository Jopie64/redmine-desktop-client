﻿using System;
using System.Collections.Generic;
using System.Text;
using Redmine.Net.Api.Types;

namespace Redmine.Client
{

    internal class IssueFormData
    {
        public IList<Tracker> Trackers { get; set; }
        public IList<IssueStatus> Statuses { get; set; }
//        public List<IdentifiableName> Priorities { get; set; }
        public List<Redmine.Net.Api.Types.Version> Versions { get; set; }
//        public List<Assignee> Watchers { get; set; }
        public List<Assignee> Assignees { get; set; }
        public IList<IssuePriority> IssuePriorities { get; set; }

    }
}
