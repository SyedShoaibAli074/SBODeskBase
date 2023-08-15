using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.IncomingPayment.Forms
{
    [FormScript("IncomingPayment.PaymentCreditCard")]
    [BasedOnRow(typeof(PaymentCreditCardRow), CheckNames = true)]
    public class PaymentCreditCardForm
    {
        public Int32 CreditCard { get; set; }
        public System.String CreditAcct { get; set; }
        public System.String CreditCardNumber { get; set; }
        public DateTime CardValidUntil { get; set; }
        public System.String VoucherNum { get; set; }
        public System.String OwnerIdNum { get; set; }
        public System.String OwnerPhone { get; set; }
        public Int32 PaymentMethodCode { get; set; }
        public Int32 NumOfPayments { get; set; }
        public DateTime FirstPaymentDue { get; set; }
        public Double? FirstPaymentSum { get; set; }
        public Double? AdditionalPaymentSum { get; set; }
        public Double? CreditSum { get; set; }
        public System.String CreditCur { get; set; }
        public Double? CreditRate { get; set; }
        public System.String ConfirmationNum { get; set; }
        public Int32 NumOfCreditPayments { get; set; }
        public String CreditType { get; set; }
        public String SplitPayments { get; set; }
    }
}