using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Report_Users")]
    [BasedOnRow(typeof(Report_UsersRow), CheckNames = true)]
    public class Report_UsersForm
    {
        [ReadOnly(true),HalfWidth]
        public Int32 UserId { get; set; }
        [Visible(false)]
        public String RptName { get; set; }
        [DisplayName("Database Name"), HalfWidth]
        public String DB_Name { get; set; }

        [FullWidth]
        public Int32 Rodcid { get; set; }
    }
}