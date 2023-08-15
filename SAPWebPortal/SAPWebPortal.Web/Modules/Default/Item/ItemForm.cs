using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Item")]
    [BasedOnRow(typeof(ItemRow), CheckNames = true)]
    public class ItemForm
    {
        [HalfWidth]
        public string ItemCode { get; set; }
        [HalfWidth]
        public string ItemName { get; set; }
        [HalfWidth]
        public string ForeignName { get; set; }
        //[HalfWidth]
        //public string ItemsGroupCode { get; set; }
        //[HalfWidth]
        //public string CustomsGroupCode { get; set; }
        [HalfWidth]
        public string BarCode { get; set; }
        [HalfWidth]
        public string PurchaseItem { get; set; }
        [HalfWidth]
        public string SalesItem { get; set; }
        [HalfWidth]
        public string InventoryItem { get; set; }
        [Tab("Inventory Data")]
        [HideOnInsert]
        public System.Collections.Generic.List<ItemWarehouseInfoCollectionRow> ItemWarehouseInfoCollection { get; set; }
       
    }
}