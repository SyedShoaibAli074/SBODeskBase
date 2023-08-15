using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.InventoryCounting.Columns
{
    [ColumnsScript("InventoryCounting.InventoryCounting")]
    [BasedOnRow(typeof(InventoryCountingRow), CheckNames = true)]
    public class InventoryCountingColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 DocumentEntry { get; set; }
        public Int32 DocumentNumber { get; set; }
        public Int32 Series { get; set; }  
        [EditLink]
        public String Remarks { get; set; } 
    }
}