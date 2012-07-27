﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace Redmine.Client.Languages
{
    internal static class LangTools
    {
//        public static CultureInfo language = System.Globalization.CultureInfo.CurrentUICulture;

        public static void UpdateControlsForLanguage(Control.ControlCollection formControls)
        {
            foreach (Control c in formControls)
            {
                if (!String.IsNullOrEmpty(Lang.ResourceManager.GetString(c.Name, Lang.Culture)))
                    c.Text = Lang.ResourceManager.GetString(c.Name, Lang.Culture);
            }
        }
    }
}
