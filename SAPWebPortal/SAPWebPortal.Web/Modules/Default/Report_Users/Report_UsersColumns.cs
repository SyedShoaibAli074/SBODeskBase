using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Report_Users")]
    [BasedOnRow(typeof(Report_UsersRow), CheckNames = true)]
    public class Report_UsersColumns
    {
        [EditLink, AlignRight]
        public Int32 UserId { get; set; }
        public int? Rodcid { get; set; }
    }
}