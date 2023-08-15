using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.InventoryTransferRequest.Forms
{
    [FormScript("InventoryTransferRequest.StockTransferLine")]
    [BasedOnRow(typeof(StockTransferLineRow), CheckNames = true)]
    public class StockTransferLineForm
    {
        [HalfWidth]
        public Int32 DocEntry { get; set; }
        [HalfWidth]
        public String ItemCode { get; set; }
        [HalfWidth]
        public String ItemDescription { get; set; }
        [HalfWidth]
        public Double Quantity { get; set; }
        [HalfWidth]
        public Double Price { get; set; }
        [HalfWidth]
        public String Currency { get; set; }
        [HalfWidth]
        public Double Rate { get; set; }
        [HalfWidth]
        public Double DiscountPercent { get; set; }
        [HalfWidth]
        public String VendorNum { get; set; }
        [HalfWidth]
        public String SerialNumber { get; set; }
        [HalfWidth]
        public String WarehouseCode { get; set; }
        [HalfWidth]
        public String FromWarehouseCode { get; set; }
        [HalfWidth]
        public String ProjectCode { get; set; }
        [HalfWidth]
        public Double Factor { get; set; }
        [HalfWidth]
        public Double Factor2 { get; set; }
        [HalfWidth]
        public Double Factor3 { get; set; }
        [HalfWidth]
        public Double Factor4 { get; set; }
        [HalfWidth]
        public String DistributionRule { get; set; }
        [HalfWidth]
        public String DistributionRule2 { get; set; }
        [HalfWidth]
        public String DistributionRule3 { get; set; }
        [HalfWidth]
        public String DistributionRule4 { get; set; }
        [HalfWidth]
        public String DistributionRule5 { get; set; }
        [HalfWidth]
        public String UseBaseUnits { get; set; }
        [HalfWidth]
        public String MeasureUnit { get; set; }
        [HalfWidth]
        public Double UnitsOfMeasurment { get; set; }
        [HalfWidth]
        public String BaseType { get; set; }
        [HalfWidth]
        public Int32 BaseLine { get; set; }
        [HalfWidth]
        public Int32 BaseEntry { get; set; }
        [HalfWidth]
        public Double UnitPrice { get; set; }
        [HalfWidth]
        public Int32 UoMEntry { get; set; }
        [HalfWidth]
        public String UoMCode { get; set; }
        [HalfWidth]
        public Double InventoryQuantity { get; set; }
        [HalfWidth]
        public Double RemainingOpenQuantity { get; set; }
        [HalfWidth]
        public Double RemainingOpenInventoryQuantity { get; set; }
        [HalfWidth]
        public String LineStatus { get; set; }
        [HalfWidth]
        public Double U_RecQty
        {
            get; set;
        }
    }
}