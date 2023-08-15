using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.IncomingPayment.Columns
{
    [ColumnsScript("IncomingPayment.Payment")]
    [BasedOnRow(typeof(PaymentRow), CheckNames = true)]
    public class PaymentColumns
    {
        //DocNum
         public Int32 DocNum { get; set; }
        //CardCode
        public String CardCode { get; set; }
        //CardName
        public String CardName { get; set; }
        //DocDate
        public DateTime DocDate { get; set; }
        //DocDueDate
        public DateTime DueDate { get; set; }
        //DocType
        public String DocType { get; set; }
        //remarks
        public String Remarks { get; set; }
        //journal remarks
        public String JournalRemarks { get; set; }

    }
}