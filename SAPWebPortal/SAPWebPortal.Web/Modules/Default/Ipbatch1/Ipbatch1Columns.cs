using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Ipbatch1")]
    [BasedOnRow(typeof(Ipbatch1Row), CheckNames = true)]
    public class Ipbatch1Columns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
        [EditLink]
        public string UCardCode { get; set; }
        public string UDocSum { get; set; }
        public string UBDocNum { get; set; }
        public string UBDocEntry { get; set; }
        public string UCardName { get; set; }
        public int UBatchId { get; set; }
    }
}