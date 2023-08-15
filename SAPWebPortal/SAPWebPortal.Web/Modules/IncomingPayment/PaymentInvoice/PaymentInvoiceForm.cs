using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.IncomingPayment.Forms
{
    [FormScript("IncomingPayment.PaymentInvoice")]
    [BasedOnRow(typeof(PaymentInvoiceRow), CheckNames = true)]
    public class PaymentInvoiceForm
    {
        public Int32 DocEntry { get; set; }
        public Double? SumApplied { get; set; }
        public Double? AppliedFc { get; set; }
        public Double? AppliedSys { get; set; }
        public Double? DocRate { get; set; }
        public Int32 DocLine { get; set; }
        //System.Nullable`1[SAPB1.BoRcptInvTypes]
        public String InvoiceType { get; set; }
        public Double? DiscountPercent { get; set; }
        public Double? PaidSum { get; set; }
        public Int32 InstallmentId { get; set; }
        public Double? WitholdingTaxApplied { get; set; }
        public Double? WitholdingTaxAppliedFc { get; set; }
        public Double? WitholdingTaxAppliedSc { get; set; }
        public DateTime LinkDate { get; set; }
        public System.String DistributionRule { get; set; }
        public System.String DistributionRule2 { get; set; }
        public System.String DistributionRule3 { get; set; }
        public System.String DistributionRule4 { get; set; }
        public System.String DistributionRule5 { get; set; }
        public Double? TotalDiscount { get; set; }
        public Double? TotalDiscountFc { get; set; }
        public Double? TotalDiscountSc { get; set; }
        public System.String UOcrCode6 { get; set; }
        public System.String UOcrCode7 { get; set; }
        public System.String UOcrCode8 { get; set; }
        public System.String UOcrCode9 { get; set; }
        public System.String UOcrCode10 { get; set; }
        public System.String UOcrCode11 { get; set; }
    }
}