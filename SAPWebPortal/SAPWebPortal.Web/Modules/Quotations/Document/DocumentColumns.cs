using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Quotations.Columns
{
    [ColumnsScript("Quotations.Document")]
    [BasedOnRow(typeof(DocumentRow), CheckNames = true)]
    public class DocumentColumns
    {
        [QuickFilter]
        public Int32 DocEntry { get; set; }
        [QuickFilter]
        public String CardCode { get; set; }
        [QuickFilter]
        public String CardName { get; set; }
        public decimal VatSum { get; set; }
        public decimal DocTotal { get; set; }
    }
}