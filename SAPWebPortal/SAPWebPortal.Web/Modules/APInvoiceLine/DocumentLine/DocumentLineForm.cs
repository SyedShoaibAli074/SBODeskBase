using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.APInvoiceLine.Forms
{
    [FormScript("OrdersLine.DocumentLine")]
    [BasedOnRow(typeof(DocumentLineRow), CheckNames = true)]
    public class DocumentLineForm
    {
        [Visible (false)]
        public Int32 LineNum { get; set; }
        [HalfWidth,Width(100)]
        public String ItemCode { get; set; }
        [HalfWidth, Width(200)]
        public String ItemDescription { get; set; }
        [HalfWidth, Width(100)]
        public decimal Quantity { get; set; }   
         
        [HalfWidth, Width(100)]
        public string UnitPrice { get; set; }
        [HalfWidth, Width(100)]
        public decimal DiscountPercent { get; set; } 
 
        [HalfWidth, Width(100)]
        public String VatGroup { get; set; }
        [HalfWidth, Width(100)]
        public String U_WRNT { get; set; }
        [HalfWidth, Width(100)]
        public String WarehouseCode { get; set; }
        [HalfWidth, Width(100)]
        public String UoMCode { get; set; }
        [HalfWidth, Width(100), Visible(false)]
        public decimal PriceAfterVat { get; set; }
        [HalfWidth, Width(100)]
        public decimal TaxTotal { get; set; }
        [HalfWidth, Width(100)]
        public decimal LineTotal { get; set; }
        [Hidden]
        public Int32 BaseEntry { get; set; }
        [Hidden]
        public Int32 BaseType { get; set; }
        [Hidden]
        public Int32 BaseLine { get; set; }

    }
}