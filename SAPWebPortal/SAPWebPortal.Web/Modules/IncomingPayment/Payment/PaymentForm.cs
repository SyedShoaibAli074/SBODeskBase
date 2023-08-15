using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.IncomingPayment.Forms
{
    [FormScript("IncomingPayment.Payment")]
    [BasedOnRow(typeof(PaymentRow), CheckNames = true)]
    public class PaymentForm
    { 
        // DocType 

        public String? DocType { get; set; }
        //Series
        public Int32 Series { get; set; }
        //DocNum
        public Int32? DocNum { get; set; }
        //CardCode
        
        public String? CardCode { get; set; }
        //CardName
        public String? CardName { get; set; }
        //DocDate
        [DefaultValue("Now")]
        public DateTime? DocDate { get; set; }
        //DocDueDate
        [DefaultValue("Now")]
        public DateTime? DueDate { get; set; }
        //TaxDate
        [DefaultValue("Now")]
        public DateTime? TaxDate { get; set; }

        //DocEntry
        public Int32? DocEntry { get; set; }
        //Remarks
        public String? Remarks { get; set; }
        //JornalRemarks
        public String? JournalRemarks { get; set; }
        [Tab("Payment Invoices"),PaymentInvoiceEditor] 
        //PaymentInvoices
        public System.Collections.Generic.List<PaymentInvoiceRow> PaymentInvoices { get; set; }
        //add a new tab
        [Tab("Payment Checks"),PaymentCheckEditor]
        //PaymentChecksRow
        public System.Collections.Generic.List<PaymentCheckRow> PaymentChecks { get; set; }
        //add a new tab
        [Tab("Payment Credit Cards"),PaymentCreditCardEditor]
        //PaymentCreditCardsRow
        public System.Collections.Generic.List<PaymentCreditCardRow> PaymentCreditCards { get; set; }
        //add a new tab
        [Tab("Payment Accounts"),PaymentAccountEditor]
        //PaymentAccountsRow
        public System.Collections.Generic.List<PaymentAccountRow> PaymentAccounts { get; set; }
        
    }
}