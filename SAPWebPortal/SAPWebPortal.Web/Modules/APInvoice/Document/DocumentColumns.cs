using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Serenity.Data.Mapping;

namespace SAPWebPortal.APInvoice.Columns
{
    [ColumnsScript("APInvoice.Document")]
    [BasedOnRow(typeof(DocumentRow), CheckNames = true)]
    public class DocumentColumns
    {
        [EditLink, QuickSearch]
        public Int32 DocEntry { get; set; }
        [EditLink, QuickSearch]
        public Int32 DocNum { get; set; }
        [QuickSearch,QuickFilter]
        public String CardCode { get; set; }
        [QuickSearch, QuickFilter]
        public String CardName { get; set; }
        [QuickSearch]
        public String Comments { get; set; }

        public decimal VatSum { get; set; }
        [QuickSearch]
        public decimal DocTotal { get; set; }
    }
}