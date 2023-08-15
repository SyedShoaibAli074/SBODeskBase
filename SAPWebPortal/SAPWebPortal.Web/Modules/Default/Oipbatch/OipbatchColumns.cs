using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Oipbatch")]
    [BasedOnRow(typeof(OipbatchRow), CheckNames = true)]
    public class OipbatchColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
        public int UUserid { get; set; }
        [EditLink]
        public string UUserCode { get; set; }
        public string UBatchType { get; set; }
        public DateTime UDocDate { get; set; }
        public string UCashAcct { get; set; }
        public string UTrsfrAcct { get; set; }
        public int UTDocNum { get; set; }
        public string UCashierId { get; set; }
        public string UStatus { get; set; }
        public decimal UDocTotal { get; set; }
    }
}