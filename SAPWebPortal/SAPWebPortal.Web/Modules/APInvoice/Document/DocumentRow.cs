using SAPWebPortal.Common.PermissionsKeys;
using SAPWebPortal.Default;
using SAPWebPortal.APInvoiceLine;
using SAPWebPortal.Modules.DropDownEnums;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.APInvoice
{
    [ConnectionKey("Default"), Module("APInvoice"), ServiceLayer("PurchaseInvoices")]
    [DisplayName("A/P Invoice"), InstanceName("A/P Invoice")]
    [InsertPermission(MarketingDocsPermissionKeys.APInvoice.Insert)]
    [ModifyPermission(MarketingDocsPermissionKeys.APInvoice.Modify)]
    [DeletePermission(MarketingDocsPermissionKeys.APInvoice.Delete)]
    [ReadPermission(MarketingDocsPermissionKeys.APInvoice.View)]
    [NotMapped]
    public sealed class DocumentRow : Row<DocumentRow.RowFields>, IIdRow
    {

        [DisplayName("Doc Entry"), NotNull, IdProperty, SortOrder(1, descending: true), SAPPrimaryKey, QuickSearch]
        [SAPDBFieldName("DocEntry")]
        [NotMapped]
        public Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }
        [DisplayName("Series"), SAPDBFieldName("Series"), NotNull, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$" SELECT ""Series"", ""SeriesName""  FROM NNM1 WHERE NNM1.""ObjectCode"" = '18'")]
        [NotMapped]
        public Int32? Series
        {
            get => fields.Series[this];
            set => fields.Series[this] = value;
        }
        [DisplayName("Doc Num"), SAPDBFieldName("DocNum"), QuickSearch]
        [NotMapped]
        public Int32? DocNum
        {
            get => fields.DocNum[this];
            set => fields.DocNum[this] = value;
        }

        [DisplayName("Item/Service Type"), DocTypeEditor, SAPDBFieldName("DocType"), DefaultValue("dDocument_Items")]
        [NotMapped]
        public String DocType
        {
            get => fields.DocType[this];
            set => fields.DocType[this] = value;
        }

        [DisplayName("Posting Date"), NotNull, SAPDBFieldName("DocDate")]
        [NotMapped]
        public DateTime? DocDate
        {
            get => fields.DocDate[this];
            set => fields.DocDate[this] = value;
        }

        [DisplayName("Delivery Date"), NotNull, SAPDBFieldName("DocDueDate")]
        [NotMapped]
        public DateTime? DocDueDate
        {
            get => fields.DocDueDate[this];
            set => fields.DocDueDate[this] = value;
        }

        [DisplayName("Vendor"), NotNull, SAPDBFieldName("CardCode"), _Ext.GridItemPickerEditor(typeof(BusinessPartnerRow)), QuickSearch]
        [NotMapped]
        public String CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }

        [DisplayName("Customer Name"), SAPDBFieldName("CardName"), QuickSearch]
        [NotMapped]
        public String CardName
        {
            get => fields.CardName[this];
            set => fields.CardName[this] = value;
        }
        [DisplayName("Doc Total"), NotNull, SAPDBFieldName("DocTotal"), ReadOnly(true), QuickSearch]
        [NotMapped]
        public double? DocTotal
        {
            get => fields.DocTotal[this];
            set => fields.DocTotal[this] = value;
        }
        [DisplayName("Documents Owner"), SAPDBFieldName("OwnerCode"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""empID"" AS ""Code"",CONCAT(""firstName"",CONCAT(' ',""lastName"") ) AS ""Name"" FROM OHEM")]
        [NotMapped]
        public Int32? DocumentsOwner
        {
            get => fields.DocumentsOwner[this];
            set => fields.DocumentsOwner[this] = value;
        }
        [DisplayName("Status"), DocStatusEditor, SAPDBFieldName("DocEntry"), DefaultValue("bost_Open"),QuickFilter]
        [NotMapped]
        public string DocumentStatus
        {
            get => fields.DocumentStatus[this];
            set => fields.DocumentStatus[this] = value;
        }
        [DisplayName("Attachment"), SAPDBFieldName("Attachment")]//AtcEntry 
        [NotMapped]
        public string AttachmentEntry
        {
            get => fields.AttachmentEntry[this];
            set => fields.AttachmentEntry[this] = value;
        }
        [DisplayName("Sales Employee"), NotNull, SAPDBFieldName("SlpCode"), DefaultValue("-1"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT T0.""SlpCode"", T0.""SlpName"" FROM OSLP T0 inner join OCRD t1 on t1.""SlpCode"" = t0.""SlpCode""  WHERE ""Active"" ='Y'")]
        //SELECT T0."SlpCode",T1."SlpName" FROM OCRD T0 
        //Inner Join OSLP T1 on T0."SlpCode"= T1."SlpCode"

        [NotMapped]
        public Int32? SalesPersonCode
        {
            get => fields.SalesPersonCode[this];
            set => fields.SalesPersonCode[this] = value;
        }
        [DisplayName("Total Discount"), SAPDBFieldName("DiscSum")]
        [NotMapped]
        public String TotalDiscount
        {
            get => fields.TotalDiscount[this];
            set => fields.TotalDiscount[this] = value;
        }
        [DisplayName("Discount %"), SAPDBFieldName("DiscPrcnt")]
        [NotMapped]
        public String DiscountPercent
        {
            get => fields.DiscountPercent[this];
            set => fields.DiscountPercent[this] = value;
        }
        [DisplayName("Remarks"), SAPDBFieldName("Comments"), QuickSearch]
        [NotMapped]
        public String Comments
        {
            get => fields.Comments[this];
            set => fields.Comments[this] = value;
        }
        [DisplayName("User Sign"), SAPDBFieldName("UserSign")]
        [NotMapped]
        public Int32? UserSign
        {
            get => fields.UserSign[this];
            set => fields.UserSign[this] = value;
        }
        [DisplayName("BPL_IDAssignedToInvoice")]
        [NotMapped]
        public string BPL_IDAssignedToInvoice
        {
            get => fields.BPL_IDAssignedToInvoice[this];
            set => fields.BPL_IDAssignedToInvoice[this] = value;
        }
        [DisplayName("U_ARInvoiceNo")]
        [NotMapped]
        public string U_ARInvoiceNo
        {
            get => fields.U_ARInvoiceNo[this];
            set => fields.U_ARInvoiceNo[this] = value;
        }

        [DisplayName("Tax"), ReadOnly(true), SAPDBFieldName("VatSum")]
        [NotMapped]
        public decimal? VatSum
        {
            get => fields.VatSum[this];
            set => fields.VatSum[this] = value;
        }
        [DisplayName("Doc Currency"), SAPDBFieldName("DocCur"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""CurrCode"", CONCAT(CONCAT(""CurrCode"", ' - '),""CurrName"") AS ""CurrName"" FROM OCRN")]
        [NotMapped]
        public String DocCurrency
        {
            get => fields.DocCurrency[this];
            set => fields.DocCurrency[this] = value;
        }
        //[DisplayName("Address"), TextAreaEditor]
        //[NotMapped]
        //public String U_Address
        //{
        //    get => fields.U_Address[this];
        //    set => fields.U_Address[this] = value;
        //}

        [DisplayName("Document Lines"), NotNull, MasterDetailRelation(foreignKey: "DocEntry")]
        [NotMapped]
        public System.Collections.Generic.List<DocumentLineRow> DocumentLines
        {
            get => fields.DocumentLines[this];
            set => fields.DocumentLines[this] = value;
        }
        //[DisplayName("Expenses"), MasterDetailRelation(foreignKey: "DocEntry")]
        //[NotMapped]
        //public System.Collections.Generic.List<DocumentAdditionalExpenseRow> DocumentAdditionalExpenses
        //{
        //    get => fields.DocumentAdditionalExpenses[this];
        //    set => fields.DocumentAdditionalExpenses[this] = value;
        //}
        [DisplayName("Payment Terms"), ReadOnly(true)]
        [NotMapped]
        public String PaymentGroupCode
        {
            get => fields.PaymentGroupCode[this];
            set => fields.PaymentGroupCode[this] = value;
        }

        [DisplayName("BP Project"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""PrjCode"" , CONCAT(CONCAT(""PrjCode"", ' - '), ""PrjName"") AS ""PrjName"" FROM OPRJ WHERE ""Active"" = 'Y'")]
        [NotMapped]
        public String Project
        {
            get => fields.Project[this];
            set => fields.Project[this] = value;
        }
        [DisplayName("Bill To Address"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""Address"" AS ""Code"", CONCAT(""Street"",CONCAT(' ',""City"")) AS ""Address"" FROM CRD1 WHERE ""AdresType"" ='B' AND ""CardCode"" ='@CardCode'")]
        [NotMapped]
        public String PayToCode
        {
            get => fields.PayToCode[this];
            set => fields.PayToCode[this] = value;
        }
        [DisplayName("Ship To Address"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""Address"" AS ""Code"", CONCAT(""Street"",CONCAT(' ',""City"")) AS ""Address"" FROM CRD1 WHERE ""AdresType"" ='S' AND ""CardCode"" ='@CardCode'")]
        [NotMapped]
        public String ShipToCode
        {
            get => fields.ShipToCode[this];
            set => fields.ShipToCode[this] = value;
        }
        [DisplayName("Customer Ref. No")]
        [NotMapped]
        public String NumAtCard
        {
            get => fields.NumAtCard[this];
            set => fields.NumAtCard[this] = value;
        }

        [DisplayName("Approval GUID")]
        [NotMapped]
        public String U_ApprovalGUID
        {
            get => fields.U_ApprovalGUID[this];
            set => fields.U_ApprovalGUID[this] = value;
        }
        
        [DisplayName("Paid To Date")]
        [NotMapped]
         public double? PaidToDate
        {
            get => fields.PaidToDate[this];
            set => fields.PaidToDate[this] = value;
        }
        [DisplayName("Warranty Qty")]
        [NotMapped]
        public decimal? U_QTY
        {
            get => fields.U_QTY[this];
            set => fields.U_QTY[this] = value;
        }
        [DisplayName("Cartons"), SAPDBFieldName("U_Cartons"), ReadOnly(true)]
        [NotMapped]
        public String U_Cartons
        {
            get => fields.U_Cartons[this];
            set => fields.U_Cartons[this] = value;
        }
        [DisplayName("Total Weight"), SAPDBFieldName("U_Total_Weight"), ReadOnly(true)]
        [NotMapped]
        public String U_Total_Weight
        {
            get => fields.U_Total_Weight[this];
            set => fields.U_Total_Weight[this] = value;
        }
        [DisplayName("Shipping Type"), SAPDBFieldName("TrnspCode"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""TrnspCode"",""TrnspName"" FROM OSHP" )]
        public Int32? TrnspCode
        {
            get => fields.TrnspCode[this];
            set => fields.TrnspCode[this] = value;
        }
        [DisplayName("Tracking No"), SAPDBFieldName("TrackNo")]
        [NotMapped]
        public String TrackNo
        {
            get => fields.TrackNo[this];
            set => fields.TrackNo[this] = value;
        }
        [DisplayName("FederalTaxId")]
        [NotMapped]
        public String FederalTaxId
        {
            get => fields.FederalTaxId[this];
            set => fields.FederalTaxId[this] = value;
        }
        [DisplayName("DocObjectCode")]
        [NotMapped]
        public String DocObjectCode
        {
            get => fields.DocObjectCode[this];
            set => fields.DocObjectCode[this] = value;
        }
        [DisplayName("Balance"), SAPDBFieldName("U_BAL")]
        [NotMapped]
        public String U_BAL
        {
            get => fields.U_BAL[this];
            set => fields.U_BAL[this] = value;
        }

        
        public DocumentRow()
          : base()
        {
        }
        public DocumentRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DocEntry;
            public Int32Field Series;
            public Int32Field DocNum;
            public StringField DocType;
            public StringField DocObjectCode;
            public DateTimeField DocDate;
            public DateTimeField DocDueDate;
            public StringField CardCode;
            public StringField CardName;
            public DoubleField DocTotal;
            public DecimalField VatSum;
            public Int32Field SalesPersonCode;
            public StringField AttachmentEntry;
            public StringField DiscountPercent;
            public Int32Field DocumentsOwner;
            public StringField DocumentStatus;
            public StringField DocCurrency;
            public StringField TotalDiscount;
            public Int32Field UserSign;
            public StringField Comments;
            public StringField Project;
            public StringField PaymentGroupCode;
            public StringField PayToCode;
            public StringField BPL_IDAssignedToInvoice;
            public StringField TrackNo;
            public StringField U_ARInvoiceNo;
            public StringField ShipToCode;
            public StringField U_Cartons;
            public StringField U_Total_Weight;
            public Int32Field TrnspCode;
            public DecimalField U_QTY;
            public StringField FederalTaxId;
            public StringField U_BAL;
            public StringField U_ApprovalGUID;
            public StringField NumAtCard;
            public RowListField<DocumentLineRow> DocumentLines;
            public DoubleField PaidToDate;


        }
    }
}
