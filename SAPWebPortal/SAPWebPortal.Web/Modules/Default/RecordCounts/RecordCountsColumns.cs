using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.RecordCounts")]
    [BasedOnRow(typeof(RecordCountsRow), CheckNames = true)]
    public class RecordCountsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
        [EditLink]
        public string ModuleName { get; set; }
        public int ObjectType { get; set; }
        public string Company { get; set; }
        public int Counts { get; set; }
        public DateTime DateTimeStamp { get; set; }
    }
}