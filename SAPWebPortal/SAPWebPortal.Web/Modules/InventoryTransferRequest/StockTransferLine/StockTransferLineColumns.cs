using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.InventoryTransferRequest.Columns
{
    [ColumnsScript("InventoryTransferRequest.StockTransferLine")]
    [BasedOnRow(typeof(StockTransferLineRow), CheckNames = true)]
    public class StockTransferLineColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 LineNum { get; set; }
        public Int32 DocEntry { get; set; }
        [EditLink]
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        public Double Quantity { get; set; }
        public Double Price { get; set; }
        public String Currency { get; set; }
        public Double Rate { get; set; }
        public Double DiscountPercent { get; set; }
        public String VendorNum { get; set; }
        public String SerialNumber { get; set; }
        public String WarehouseCode { get; set; }
        public String FromWarehouseCode { get; set; }
        public String ProjectCode { get; set; }
        public Double Factor { get; set; }
        public Double Factor2 { get; set; }
        public Double Factor3 { get; set; }
        public Double Factor4 { get; set; }
        public String DistributionRule { get; set; }
        public String DistributionRule2 { get; set; }
        public String DistributionRule3 { get; set; }
        public String DistributionRule4 { get; set; }
        public String DistributionRule5 { get; set; }
        public String UseBaseUnits { get; set; }
        public String MeasureUnit { get; set; }
        public Double UnitsOfMeasurment { get; set; }
        public String BaseType { get; set; }
        public Int32 BaseLine { get; set; }
        public Int32 BaseEntry { get; set; }
        public Double UnitPrice { get; set; }
        public Int32 UoMEntry { get; set; }
        public String UoMCode { get; set; }
        public Double InventoryQuantity { get; set; }
        public Double RemainingOpenQuantity { get; set; }
        public Double RemainingOpenInventoryQuantity { get; set; }
        public String LineStatus { get; set; }
        public Double U_RecQty
        { get;set;
        }

    }
}