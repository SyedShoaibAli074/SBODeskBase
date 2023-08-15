using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.IncomingPayment.Forms
{
    [FormScript("IncomingPayment.PaymentCheck")]
    [BasedOnRow(typeof(PaymentCheckRow), CheckNames = true)]
    public class PaymentCheckForm
    {
        public DateTime DueDate { get; set; }
        public Int32 CheckNumber { get; set; }
        public System.String BankCode { get; set; }
        public System.String Branch { get; set; }
        public System.String AccounttNum { get; set; }
        public System.String Details { get; set; }
        public String Trnsfrable { get; set; }
        public Double? CheckSum { get; set; }
        public System.String Currency { get; set; }
        public System.String CountryCode { get; set; }
        public Int32 CheckAbsEntry { get; set; }
        public System.String CheckAccount { get; set; }
        public String ManualCheck { get; set; }
        public System.String FiscalId { get; set; }
        public System.String OriginallyIssuedBy { get; set; }
        public String Endorse { get; set; }
        public Int32 EndorsableCheckNo { get; set; } 
    }
}