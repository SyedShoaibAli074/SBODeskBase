using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using SAPWebPortal.APInvoiceLine;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace SAPWebPortal.APInvoice.Forms
{
    [FormScript("APInvoice.Document")]
    [BasedOnRow(typeof(DocumentRow), CheckNames = true)]
    public class DocumentForm
    {
        
        [HalfWidth]

        public Int32 Series { get; set; }
        [MediumHalfLargeQuarterWidth, ReadOnly(true)]


        public Int32 DocNum { get; set; }
        [MediumHalfLargeQuarterWidth, ReadOnly(true)]


        public string DocumentStatus { get; set; }
        [HalfWidth]


        public string CardCode { get; set; }
        [HalfWidth, ReadOnly(true)]


        public string CardName { get; set; }
        [HalfWidth]


        public string DocCurrency { get; set; }
        [HalfWidth, DefaultValue("Now")]


        public DateTime DocDate { get; set; }
        [HalfWidth]


        public string NumAtCard { get; set; }
        [HalfWidth, DefaultValue("Now")]


        public DateTime DocDueDate { get; set; }

        [HalfWidth]
        public string U_Cartons { get; set; }  
        [HalfWidth]
        public string U_Total_Weight{ get; set; } 
        [HalfWidth]
        public Int32 TrnspCode { get; set; } 
        [HalfWidth]
        public string TrackNo { get; set; }
        [HalfWidth]


        public string U_BAL { get; set; }
        [TextAreaEditor, HalfWidth]
        public string Comments { get; set; }
        [Tab("Contents")]
        [MediumThirdLargeQuarterWidth]
        public string DocType { get; set; }
        [DocumentLineEditor]
        public System.Collections.Generic.List<DocumentLineRow> DocumentLines { get; set; }
        //[DocumentAdditionalExpenseEditor]
        //public System.Collections.Generic.List<DocumentAdditionalExpenseRow> DocumentAdditionalExpenses { get; set; }
        [HalfWidth]


        public Int32 SalesPersonCode { get; set; }
        [HalfWidth]


        public Int32 DocumentsOwner { get; set; }
        [MediumThirdLargeQuarterWidth]


        public string DiscountPercent { get; set; }
        [MediumThirdLargeQuarterWidth]


        public string TotalDiscount { get; set; }
        [HalfWidth]


        public decimal VatSum { get; set; }
        [HalfWidth]


        public decimal DocTotal { get; set; }
        [HalfWidth, Visible(false)]
        public Int32 UserSign { get; set; }
       
        [Tab("Accounting")]


        [HalfWidth, ReadOnly(true)]
        public string PaymentGroupCode { get; set; }
        [HalfWidth]
        public string Project { get; set; }
        [Tab("Logistic")]


        public string PayToCode { get; set; }


        public string ShipToCode { get; set; }
        [HalfWidth, ReadOnly(true)]


        public Int32 U_QTY { get; set; }


        [Tab("Attachment")]
        [DisplayName("Attachment"), HalfWidth]


        public string AttachmentEntry { get; set; }
        [Hidden]
        public string FederalTaxId { get; set; }


    }
}