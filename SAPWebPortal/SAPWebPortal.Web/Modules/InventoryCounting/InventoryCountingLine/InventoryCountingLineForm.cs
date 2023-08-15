using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.InventoryCounting.Forms
{
    [FormScript("InventoryCounting.InventoryCountingLine")]
    [BasedOnRow(typeof(InventoryCountingLineRow), CheckNames = true)]
    public class InventoryCountingLineForm
    {
        public Int32 LineNumber { get; set; }
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        //public String Freeze { get; set; }
        public String WarehouseCode { get; set; }
        //public Int32 BinEntry { get; set; }
        public Double InWarehouseQuantity { get; set; }
        //public String Counted { get; set; }
        //public String UoMCode { get; set; }
        //public String BarCode { get; set; }
        //public Double UoMCountedQuantity { get; set; }
        //public Double ItemsPerUnit { get; set; }
        public Double CountedQuantity { get; set; }
        //public Double Variance { get; set; }
        //public Double VariancePercentage { get; set; }
        //public Int32 VisualOrder { get; set; }
        //public Int32 TargetEntry { get; set; }
        //public Int32 TargetLine { get; set; }
        //public Int32 TargetType { get; set; }
        //public String TargetReference { get; set; }
        //public String ProjectCode { get; set; }
        //public Int32 Manufacturer { get; set; }
        //public String SupplierCatalogNo { get; set; }
        //public String PreferredVendor { get; set; }
        //public String CostingCode { get; set; }
        //public String CostingCode2 { get; set; }
        //public String CostingCode3 { get; set; }
        //public String CostingCode4 { get; set; }
        //public String CostingCode5 { get; set; }
        //public String Remarks { get; set; }  
        //public Int32 CounterId { get; set; } 
    }
}