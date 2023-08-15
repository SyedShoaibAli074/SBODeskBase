using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using SAPWebPortal.VatGroups;
using SAPWebPortal.Default;

namespace SAPWebPortal.ARInvoiceLine.Columns
{
    [ColumnsScript("ARInvoiceLine.DocumentLine")]
    [BasedOnRow(typeof(DocumentLineRow), CheckNames = true)]
    public class DocumentLineColumns
    {
        [Width(100)]
        public String ItemCode { get; set; }
        [Width(200)]
        public String ItemDescription { get; set; }
        [Width(200)]
        public String AccountCode { get; set; }
        [Width(200)]
        public String AccountName { get; set; }
        [Width(100)]
        public decimal Quantity { get; set; }
        [Width(100)]
        public string UnitPrice { get; set; }
        [Width(100)]
        public decimal DiscountPercent { get; set; }
        [Width(100), _Ext.GridItemPickerEditor(typeof(WarehouseRow))]
        public String WarehouseCode { get; set; }
        [Width(100), _Ext.GridItemPickerEditor(typeof(VatGroupRow))]
        public String VatGroup { get; set; }
        [Width(100)]
        public String UoMCode { get; set; }
        [Width(100)]
        public String U_WRNT { get; set; }
        [Width(100)]
        public decimal LineTotal { get; set; }
        [Width(100)]
        public decimal GrossTotal { get; set; }
        [Visible(false),Width(100)]
        public decimal TaxTotal { get; set; }
        [Width(100)]
        public String CostingCode { get; set; }
        [Width(100)]
        public String CostingCode2 { get; set; }
        [Width(100)]
        public String ProjectCode { get; set; }
        [Width(100)]
        public decimal U_STCK { get; set; }
        [Width(100)]
        public String U_Remarks { get; set; }

    }
}