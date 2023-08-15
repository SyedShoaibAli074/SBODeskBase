using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ItemWarehouseInfoCollection")]
    [BasedOnRow(typeof(ItemWarehouseInfoCollectionRow), CheckNames = true)]
    public class ItemWarehouseInfoCollectionColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public DecimalField InStock { get; set; }
        public DecimalField Committed { get; set; }
        public DecimalField Ordered { get; set; }
        public DecimalField CountedQuantity { get; set; }
    }
}