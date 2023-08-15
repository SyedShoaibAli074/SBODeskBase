using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Reports")]
    [BasedOnRow(typeof(ReportsRow), CheckNames = true)]
    public class ReportsColumns
    {
        [DisplayName("Report Id"), AlignCenter]
        public Int32 Rdocid { get; set; }

        [LabelWidth(40), Width(350)]
        public String RptName { get; set; }
        [Width(150)]
        public DateTime CreateDate { get; set; }

        public String DB_Name;

    }
}