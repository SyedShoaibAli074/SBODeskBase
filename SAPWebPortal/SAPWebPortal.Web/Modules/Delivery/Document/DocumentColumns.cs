using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Delivery.Columns
{
    [ColumnsScript("Delivery.Document")]
    [BasedOnRow(typeof(DocumentRow), CheckNames = true)]
    public class DocumentColumns
    {
        public Int32 DocEntry { get; set; }
        public String CardCode { get; set; }
        public String CardName { get; set; }
        public decimal VatSum { get; set; }
        public decimal DocTotal { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? DocDueDate { get; set; }
    }
}