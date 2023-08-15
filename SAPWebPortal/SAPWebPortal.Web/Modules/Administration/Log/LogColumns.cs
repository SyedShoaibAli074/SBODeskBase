using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Columns
{
    [ColumnsScript("Administration.Log")]
    [BasedOnRow(typeof(LogRow), CheckNames = true)]
    public class LogColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 Id { get; set; }
        public DateTime UDateTime { get; set; }
        [EditLink]
        public String UDirection { get; set; }
        public String UError { get; set; }
        public String UXml { get; set; }
        public String UResponse { get; set; }
        //public String UObjType { get; set; }
        //public String UVersion { get; set; }
        //public String UKey { get; set; }
        //public String UDocNum { get; set; }
        //public Int16 Updated { get; set; }
    }
}