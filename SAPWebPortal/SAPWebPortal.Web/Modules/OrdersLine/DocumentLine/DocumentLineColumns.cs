using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.OrdersLine.Columns
{
    [ColumnsScript("OrdersLine.DocumentLine")]
    [BasedOnRow(typeof(DocumentLineRow), CheckNames = true)]
    public class DocumentLineColumns
    {
        [Width(100)]
        public String ItemCode { get; set; }
        [Width(200)]
        public String ItemDescription { get; set; }
        [Width(100)]
        public decimal Quantity { get; set; }
        [Width(100)]
        public decimal InventoryQuantity { get; set; }
        [Width(100)]
        public decimal UnitsOfMeasurment { get; set; }
        [Width(100)]
        public decimal UnitPrice { get; set; }
        [Width(100)]
        public decimal DiscountPercent { get; set; }
        [Width(100)]
        public String WarehouseCode { get; set; }
        [Width(100)]
        public String VatGroup { get; set; }
        [Width(100)]
        public String UoMCode { get; set; }
        [Width(100)]
        public decimal LineTotal { get; set; }
        [Width(100)]
        public decimal GrossTotal { get; set; }
        [Visible(false),Width(100)]
        public decimal TaxTotal { get; set; }

    }
}