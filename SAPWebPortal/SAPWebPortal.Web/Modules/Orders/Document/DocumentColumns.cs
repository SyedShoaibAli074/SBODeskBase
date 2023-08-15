using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Serenity.Data.Mapping;

namespace SAPWebPortal.Orders.Columns
{
    [ColumnsScript("Orders.Document")]
    [BasedOnRow(typeof(DocumentRow), CheckNames = true)]
    public class DocumentColumns
    {
        [QuickFilter,QuickSearch]
        public Int32 DocEntry { get; set; }
        [QuickFilter, QuickSearch]
        public String CardCode { get; set; }
        [QuickFilter]
        public String CardName { get; set; }
        
        public decimal VatSum { get; set; }
        public decimal DocTotal { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
    }
}