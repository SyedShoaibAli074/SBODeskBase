using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.SapToShopifySyncLog")]
    [BasedOnRow(typeof(SapToShopifySyncLogRow), CheckNames = true)]
    public class SapToShopifySyncLogColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public int Id { get; set; }
        [EditLink]
        public string DocEntry { get; set; }
        public string SyncStatus { get; set; }
        public string TargetStoreId { get; set; }
        public string SourceObjType { get; set; }
        public string SyncTime { get; set; }
    }
}