using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Reports")]
    [BasedOnRow(typeof(ReportsRow), CheckNames = true)]
    public class ReportsForm
    {
        [Visible(false)]
        public String RptName { get; set; }
        [DisplayName("Report File"), HalfWidth, Required]
        [FileUploadEditor(CopyToHistory = true)]
        public String RptByteArray { get; set; }
        [DisplayName("Database Name"), HalfWidth, Required]
        public String DB_Name { get; set; }
        [Visible(false)]
        public DateTime CreateDate { get; set; }
        [Visible(false)]
        public DateTime UpdateDate { get; set; }
    }
}