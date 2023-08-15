using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.FileRouting")]
    [BasedOnRow(typeof(FileRoutingRow), CheckNames = true)]
    public class FileRoutingForm
    {
        public String Name { get; set; }
        public String CompanyDB { get; set; }
        public String SlObjectType { get; set; }
        public String ReportPath { get; set; }
        public String RdocCode { get; set; }
        public String ExportExtension { get; set; }
        public String FileNameTemplate { get; set; }
        public String ExportPath { get; set; }
        
    }
}