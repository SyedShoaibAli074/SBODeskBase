using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ItemWarehouseInfoCollection")]
    [BasedOnRow(typeof(ItemWarehouseInfoCollectionRow), CheckNames = true)]
    public class ItemWarehouseInfoCollectionForm
    {
        [HalfWidth]
        public string ItemCode { get; set; }
        [HalfWidth]
        public string WarehouseCode { get; set; }
        [HalfWidth]
        public DecimalField InStock { get; set; }
        [HalfWidth]
        public DecimalField Committed { get; set; }
        [HalfWidth]
        public DecimalField Ordered { get; set; }
        [HalfWidth]
        public DecimalField CountedQuantity { get; set; }
    }
}