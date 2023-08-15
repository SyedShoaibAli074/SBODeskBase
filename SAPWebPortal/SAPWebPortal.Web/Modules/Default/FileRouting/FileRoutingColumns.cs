using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.FileRouting")]
    [BasedOnRow(typeof(FileRoutingRow), CheckNames = true)]
    public class FileRoutingColumns
    {
        [ DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 Id { get; set; }
        public String Name { get; set; } 
        public String CompanyDB { get; set; }
        public String SlObjectType { get; set; }
        public String ReportPath { get; set; }
        public String RdocCode { get; set; }
        public String ExportExtension { get; set; }
        public String ExportPath { get; set; }
    }
}