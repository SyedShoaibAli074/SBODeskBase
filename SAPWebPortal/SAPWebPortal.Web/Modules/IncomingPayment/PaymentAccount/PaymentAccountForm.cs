using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.IncomingPayment.Forms
{
    [FormScript("IncomingPayment.PaymentAccount")]
    [BasedOnRow(typeof(PaymentAccountRow), CheckNames = true)]
    public class PaymentAccountForm
    {
        public System.String AccountCode { get; set; }
        public System.Double? SumPaid { get; set; }
        public System.Double? SumPaidFc { get; set; }
        public System.String Decription { get; set; }
        public System.String VatGroup { get; set; }
        public System.String AccountName { get; set; }
        public System.Double? GrossAmount { get; set; }
        public System.String ProfitCenter { get; set; }
        public System.String ProjectCode { get; set; }
        public System.Double? VatAmount { get; set; }
        public System.String ProfitCenter2 { get; set; }
        public System.String ProfitCenter3 { get; set; }
        public System.String ProfitCenter4 { get; set; }
        public System.String ProfitCenter5 { get; set; }
        public System.Int32? LocationCode { get; set; }
        public System.Double? EqualizationVatAmount { get; set; }
    }
}