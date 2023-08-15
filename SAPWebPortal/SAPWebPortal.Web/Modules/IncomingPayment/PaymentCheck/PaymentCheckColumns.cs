using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.IncomingPayment.Columns
{
    [ColumnsScript("IncomingPayment.PaymentCheck")]
    [BasedOnRow(typeof(PaymentCheckRow), CheckNames = true)]
    public class PaymentCheckColumns
    { 
        public Int32? LineNum { get; set; }
        public DateTime DueDate { get; set; }
        public System.Int32? CheckNumber { get; set; }
        public System.String BankCode { get; set; }
        public System.String Branch { get; set; }
        public System.String AccounttNum { get; set; }
        public System.String Details { get; set; }
        public System.String Trnsfrable { get; set; }
        public System.Double? CheckSum { get; set; }
        public System.String Currency { get; set; }
        public System.String CountryCode { get; set; }
        public System.Int32 CheckAbsEntry { get; set; }
        public System.String CheckAccount { get; set; }
        public System.String ManualCheck { get; set; }
        public System.String FiscalId { get; set; }
        public System.String OriginallyIssuedBy { get; set; }
        public System.String Endorse { get; set; }
        public System.Int32  EndorsableCheckNo { get; set; } 
    }
}