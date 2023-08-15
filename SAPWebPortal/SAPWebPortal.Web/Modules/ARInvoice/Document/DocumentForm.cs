using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.ARInvoice.Forms
{
    [FormScript("ARInvoice.Document")]
    [BasedOnRow(typeof(DocumentRow), CheckNames = true)]
    public class DocumentForm
    {
        
        public Int32 DocEntry { get; set; }
        public Int32 DocNum { get; set; }
        public String DocType { get; set; }
        [Hidden]
        public String DBName { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public String CardCode { get; set; }
        public String CardName { get; set; }
        public String Address { get; set; }
        public String NumAtCard { get; set; }
        public Double DocTotal { get; set; }
    }
}