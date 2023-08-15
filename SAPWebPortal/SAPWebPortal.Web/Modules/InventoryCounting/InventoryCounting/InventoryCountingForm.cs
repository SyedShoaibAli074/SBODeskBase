using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.InventoryCounting.Forms
{
    [FormScript("InventoryCounting.InventoryCounting")]
    [BasedOnRow(typeof(InventoryCountingRow), CheckNames = true)]
    public class InventoryCountingForm
    {
        public Int32 DocumentNumber { get; set; }
        public Int32 Series { get; set; }
          public Int32 SingleCounterId { get; set; }
         public String Remarks { get; set; }     
        public System.Collections.Generic.List<InventoryCountingLineRow> InventoryCountingLines { get; set; }
     }
}