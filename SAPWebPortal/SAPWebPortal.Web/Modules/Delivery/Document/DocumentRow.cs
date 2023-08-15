using SAPWebPortal.Common.PermissionsKeys;
using SAPWebPortal.Default;
 using SAPWebPortal.DeliveryLine;
using SAPWebPortal.Modules.DropDownEnums;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Delivery
{
    [ConnectionKey("Default"), Module("Delivery"), ServiceLayer("DeliveryNotes")]
    [DisplayName("Delivery"), InstanceName("Delivery")]
    [InsertPermission(MarketingDocsPermissionKeys.Delivery.Insert)]
    [ModifyPermission(MarketingDocsPermissionKeys.Delivery.Modify)]
    [DeletePermission(MarketingDocsPermissionKeys.Delivery.Delete)]
    [ReadPermission(MarketingDocsPermissionKeys.Delivery.View)]
    [NotMapped]
    public sealed class DocumentRow : Row<DocumentRow.RowFields>, IIdRow
    {

        [DisplayName("DBName"), Size(255), NotMapped, RemoveFromEntity]
        public string DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }
        [DisplayName("U_TID")]
        [NotMapped]
        public String U_TID
        {
            get => fields.U_TID[this];
            set => fields.U_TID[this] = value;
        }
        [DisplayName("U_dosource")]
        [NotMapped]
        public String U_dosource
        {
            get => fields.U_dosource[this];
            set => fields.U_dosource[this] = value;
        }
        [DisplayName("U_CanceledAt")]
        [NotMapped]
        public String U_CanceledAt
        {
            get => fields.U_CanceledAt[this];
            set => fields.U_CanceledAt[this] = value;
        }
        [DisplayName("U_PaymentMethod")]
        [NotMapped]
        public String U_PaymentMethod
        {
            get => fields.U_PaymentMethod[this];
            set => fields.U_PaymentMethod[this] = value;
        }
        [DisplayName("U_OrderNumber")]
        [NotMapped]
        public String U_OrderNumber
        {
            get => fields.U_OrderNumber[this];
            set => fields.U_OrderNumber[this] = value;
        }
        [DisplayName("U_ShopifyOrderId")]
        [NotMapped]
        public String U_ShopifyOrderId
        {
            get => fields.U_ShopifyOrderId[this];
            set => fields.U_ShopifyOrderId[this] = value;
        }
        [DisplayName("Doc Entry"), NotNull, IdProperty, SortOrder(1, descending: true), SAPPrimaryKey,NameProperty, QuickSearch]
        [NotMapped]
        [SAPDBFieldName("DocEntry")]
        public Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }
        [DisplayName("Series")]
        [NotMapped]
        [SAPDBFieldName("Series")]
        public Int32? Series
        {
            get => fields.Series[this];
            set => fields.Series[this] = value;
        }
        [DisplayName("Doc Num")]
        [NotMapped]
        [SAPDBFieldName("DocNum")]
        public Int32? DocNum
        {
            get => fields.DocNum[this];
            set => fields.DocNum[this] = value;
        }

        [DisplayName("Item/Service Type"), DocTypeEditor, DefaultValue("dDocument_Items")]
        [NotMapped]
        [SAPDBFieldName("DocType")]
        public String DocType
        {
            get => fields.DocType[this];
            set => fields.DocType[this] = value;
        }

        [DisplayName("Posting Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocDate")]
        public DateTime? DocDate
        {
            get => fields.DocDate[this];
            set => fields.DocDate[this] = value;
        }

        [DisplayName("Delivery Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocDueDate")]
        public DateTime? DocDueDate
        {
            get => fields.DocDueDate[this];
            set => fields.DocDueDate[this] = value;
        }

        [DisplayName("Customer"), NotNull, _Ext.GridItemPickerEditor(typeof(BusinessPartnerRow)), QuickSearch]
        [NotMapped]
        [SAPDBFieldName("CardCode")]
        public String CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }

        [DisplayName("Customer Name"), QuickSearch]
        [NotMapped]
        [SAPDBFieldName("CardName")]
        public String CardName
        {
            get => fields.CardName[this];
            set => fields.CardName[this] = value;
        }
        [DisplayName("Doc Total"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocTotal")]
        public decimal? DocTotal
        {
            get => fields.DocTotal[this];
            set => fields.DocTotal[this] = value;
        }
        [DisplayName("Documents Owner"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""empID"" AS ""Code"",CONCAT(""firstName"",CONCAT(' ',""lastName"") ) AS ""Name"" FROM OHEM")]
        [NotMapped] 
        public Int32? DocumentsOwner
        {
            get => fields.DocumentsOwner[this];
            set => fields.DocumentsOwner[this] = value;
        }
        [DisplayName("Status"), DocStatusEditor, DefaultValue("bost_Open")]
        [NotMapped]
        [SAPDBFieldName("DocStatus")]
        public string DocumentStatus
        {
            get => fields.DocumentStatus[this];
            set => fields.DocumentStatus[this] = value;
        }
        [DisplayName("Attachment")]
        [NotMapped]
        public string AttachmentEntry
        {
            get => fields.AttachmentEntry[this];
            set => fields.AttachmentEntry[this] = value;
        }
        [DisplayName("Sales Employee"), NotNull, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""SlpCode"", ""SlpName"" FROM OSLP WHERE ""Active"" ='Y'")]
        [NotMapped]
        
        public Int32? SalesPersonCode
        {
            get => fields.SalesPersonCode[this];
            set => fields.SalesPersonCode[this] = value;
        }
        [DisplayName("Total Discount"), ReadOnly(true)]
        [NotMapped]
        
        public decimal? TotalDiscount
        {
            get => fields.TotalDiscount[this];
            set => fields.TotalDiscount[this] = value;
        }
        [DisplayName("Discount %")]
        [NotMapped]
        public decimal? DiscountPercent
        {
            get => fields.DiscountPercent[this];
            set => fields.DiscountPercent[this] = value;
        }
        [DisplayName("Remarks")]
        [NotMapped]
        [SAPDBFieldName("Comments")]
        public String Comments
        {
            get => fields.Comments[this];
            set => fields.Comments[this] = value;
        }
        [DisplayName("User Sign")]
        [NotMapped]
        public Int32? UserSign
        {
            get => fields.UserSign[this];
            set => fields.UserSign[this] = value;
        }

        [DisplayName("Tax"), ReadOnly(true),SAPDBFieldName("VatSum")]
        [NotMapped]
        public decimal? VatSum
        {
            get => fields.VatSum[this];
            set => fields.VatSum[this] = value;
        }
        [DisplayName("Doc Currency"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""CurrCode"", CONCAT(CONCAT(""CurrCode"", ' - '),""CurrName"") AS ""CurrName"" FROM OCRN")]
        [NotMapped]
        public String DocCurrency
        {
            get => fields.DocCurrency[this];
            set => fields.DocCurrency[this] = value;
        }

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

        [DisplayName("Payment Terms"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""GroupNum"" AS ""Code"",""PymntGroup"" AS ""Name"" FROM OCTG ")]
        [NotMapped]
        public Int32? GroupNumber
        {
            get => fields.GroupNumber[this];
            set => fields.GroupNumber[this] = value;
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
        [DisplayName("Customer Ref. No.")]
        [NotMapped]
        public String NumAtCard
        {
            get => fields.NumAtCard[this];
            set => fields.NumAtCard[this] = value;
        }
        [DisplayName("Address"), TextAreaEditor]
        [NotMapped]
        public String U_Address
        {
            get => fields.U_Address[this];
            set => fields.U_Address[this] = value;
        }
        [DisplayName("Document"), DraftDocsEditor, ReadOnly(true)]
        [NotMapped]
        public String DocObjectCode
        {
            get => fields.DocObjectCode[this];
            set => fields.DocObjectCode[this] = value;
        }
        [DisplayName("Approval GUID")]
        [NotMapped]
        public String U_ApprovalGUID
        {
            get => fields.U_ApprovalGUID[this];
            set => fields.U_ApprovalGUID[this] = value;
        }
        [DisplayName("U_FullfilmentId"), NotNull]
        [NotMapped]
        public String U_FullfilmentId
        {
            get => fields.U_FullfilmentId[this];
            set => fields.U_FullfilmentId[this] = value;
        }
        //[DisplayName("Hand Written"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String HandWritten
        //{
        //    get => fields.HandWritten[this];
        //    set => fields.HandWritten[this] = value;
        //}

        //[DisplayName("Printed"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.PrintStatusEnum]? Printed
        //{
        //    get => fields.Printed[this];
        //    set => fields.Printed[this] = value;
        //}




        //[DisplayName("Doc Rate"), NotNull]
        //[NotMapped]
        //public decimal? DocRate
        //{
        //    get => fields.DocRate[this];
        //    set => fields.DocRate[this] = value;
        //}

        //[DisplayName("Reference1"), NotNull]
        //[NotMapped]
        //public String Reference1
        //{
        //    get => fields.Reference1[this];
        //    set => fields.Reference1[this] = value;
        //}

        //[DisplayName("Reference2"), NotNull]
        //[NotMapped]
        //public String Reference2
        //{
        //    get => fields.Reference2[this];
        //    set => fields.Reference2[this] = value;
        //}



        //[DisplayName("Journal Memo"), NotNull]
        //[NotMapped]
        //public String JournalMemo
        //{
        //    get => fields.JournalMemo[this];
        //    set => fields.JournalMemo[this] = value;
        //}

        //[DisplayName("Payment Group Code"), NotNull]
        //[NotMapped]
        //public Int32? PaymentGroupCode
        //{
        //    get => fields.PaymentGroupCode[this];
        //    set => fields.PaymentGroupCode[this] = value;
        //}

        //[DisplayName("Doc Time"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]? DocTime
        //{
        //    get => fields.DocTime[this];
        //    set => fields.DocTime[this] = value;
        //}


        //[DisplayName("Transportation Code"), NotNull]
        //[NotMapped]
        //public Int32? TransportationCode
        //{
        //    get => fields.TransportationCode[this];
        //    set => fields.TransportationCode[this] = value;
        //}

        //[DisplayName("Confirmed"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String Confirmed
        //{
        //    get => fields.Confirmed[this];
        //    set => fields.Confirmed[this] = value;
        //}

        //[DisplayName("Import File Num"), NotNull]
        //[NotMapped]
        //public Int32? ImportFileNum
        //{
        //    get => fields.ImportFileNum[this];
        //    set => fields.ImportFileNum[this] = value;
        //}

        //[DisplayName("Summery Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoDocSummaryTypes]? SummeryType
        //{
        //    get => fields.SummeryType[this];
        //    set => fields.SummeryType[this] = value;
        //}

        //[DisplayName("Contact Person Code"), NotNull]
        //[NotMapped]
        //public Int32? ContactPersonCode
        //{
        //    get => fields.ContactPersonCode[this];
        //    set => fields.ContactPersonCode[this] = value;
        //}

        //[DisplayName("Show Scn"), Column("ShowSCN"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ShowScn
        //{
        //    get => fields.ShowScn[this];
        //    set => fields.ShowScn[this] = value;
        //}

        //[DisplayName("Series"), NotNull]
        //[NotMapped]
        //public Int32? Series
        //{
        //    get => fields.Series[this];
        //    set => fields.Series[this] = value;
        //}

        //[DisplayName("Tax Date"), NotNull]
        //[NotMapped]
        //public DateTime TaxDate
        //{
        //    get => fields.TaxDate[this];
        //    set => fields.TaxDate[this] = value;
        //}

        //[DisplayName("Partial Supply"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String PartialSupply
        //{
        //    get => fields.PartialSupply[this];
        //    set => fields.PartialSupply[this] = value;
        //}



        //[DisplayName("Indicator"), NotNull]
        //[NotMapped]
        //public String Indicator
        //{
        //    get => fields.Indicator[this];
        //    set => fields.Indicator[this] = value;
        //}

        //[DisplayName("Federal Tax Id"), Column("FederalTaxID"), NotNull]
        //[NotMapped]
        //public String FederalTaxId
        //{
        //    get => fields.FederalTaxId[this];
        //    set => fields.FederalTaxId[this] = value;
        //}

        //[DisplayName("Payment Reference"), NotNull]
        //[NotMapped]
        //public String PaymentReference
        //{
        //    get => fields.PaymentReference[this];
        //    set => fields.PaymentReference[this] = value;
        //}

        //[DisplayName("Creation Date"), NotNull]
        //[NotMapped]
        //public DateTime CreationDate
        //{
        //    get => fields.CreationDate[this];
        //    set => fields.CreationDate[this] = value;
        //}

        //[DisplayName("Update Date"), NotNull]
        //[NotMapped]
        //public DateTime UpdateDate
        //{
        //    get => fields.UpdateDate[this];
        //    set => fields.UpdateDate[this] = value;
        //}

        //[DisplayName("Financial Period"), NotNull]
        //[NotMapped]
        //public Int32? FinancialPeriod
        //{
        //    get => fields.FinancialPeriod[this];
        //    set => fields.FinancialPeriod[this] = value;
        //}

        //[DisplayName("Trans Num"), NotNull]
        //[NotMapped]
        //public Int32? TransNum
        //{
        //    get => fields.TransNum[this];
        //    set => fields.TransNum[this] = value;
        //}

        //[DisplayName("Vat Sum Sys"), NotNull]
        //[NotMapped]
        //public decimal? VatSumSys
        //{
        //    get => fields.VatSumSys[this];
        //    set => fields.VatSumSys[this] = value;
        //}

        //[DisplayName("Vat Sum Fc"), NotNull]
        //[NotMapped]
        //public decimal? VatSumFc
        //{
        //    get => fields.VatSumFc[this];
        //    set => fields.VatSumFc[this] = value;
        //}

        //[DisplayName("Net Procedure"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String NetProcedure
        //{
        //    get => fields.NetProcedure[this];
        //    set => fields.NetProcedure[this] = value;
        //}

        //[DisplayName("Doc Total"), NotNull]
        //[NotMapped]
        //public decimal? DocTotalFc
        //{
        //    get => fields.DocTotalFc[this];
        //    set => fields.DocTotalFc[this] = value;
        //}

        //[DisplayName("Doc Total Sys"), NotNull]
        //[NotMapped]
        //public decimal? DocTotalSys
        //{
        //    get => fields.DocTotalSys[this];
        //    set => fields.DocTotalSys[this] = value;
        //}

        //[DisplayName("Form1099"), NotNull]
        //[NotMapped]
        //public Int32? Form1099
        //{
        //    get => fields.Form1099[this];
        //    set => fields.Form1099[this] = value;
        //}

        //[DisplayName("Box1099"), NotNull]
        //[NotMapped]
        //public String Box1099
        //{
        //    get => fields.Box1099[this];
        //    set => fields.Box1099[this] = value;
        //}

        //[DisplayName("Revision Po"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String RevisionPo
        //{
        //    get => fields.RevisionPo[this];
        //    set => fields.RevisionPo[this] = value;
        //}

        //[DisplayName("Requried Date"), NotNull]
        //[NotMapped]
        //public DateTime RequriedDate
        //{
        //    get => fields.RequriedDate[this];
        //    set => fields.RequriedDate[this] = value;
        //}

        //[DisplayName("Cancel Date"), NotNull]
        //[NotMapped]
        //public DateTime CancelDate
        //{
        //    get => fields.CancelDate[this];
        //    set => fields.CancelDate[this] = value;
        //}

        //[DisplayName("Block Dunning"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String BlockDunning
        //{
        //    get => fields.BlockDunning[this];
        //    set => fields.BlockDunning[this] = value;
        //}

        //[DisplayName("Submitted"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String Submitted
        //{
        //    get => fields.Submitted[this];
        //    set => fields.Submitted[this] = value;
        //}

        //[DisplayName("Segment"), NotNull]
        //[NotMapped]
        //public Int32? Segment
        //{
        //    get => fields.Segment[this];
        //    set => fields.Segment[this] = value;
        //}

        //[DisplayName("Pick Status"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String PickStatus
        //{
        //    get => fields.PickStatus[this];
        //    set => fields.PickStatus[this] = value;
        //}

        //[DisplayName("Pick"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String Pick
        //{
        //    get => fields.Pick[this];
        //    set => fields.Pick[this] = value;
        //}

        //[DisplayName("Payment Method"), NotNull]
        //[NotMapped]
        //public String PaymentMethod
        //{
        //    get => fields.PaymentMethod[this];
        //    set => fields.PaymentMethod[this] = value;
        //}

        //[DisplayName("Payment Block"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String PaymentBlock
        //{
        //    get => fields.PaymentBlock[this];
        //    set => fields.PaymentBlock[this] = value;
        //}

        //[DisplayName("Payment Block Entry"), NotNull]
        //[NotMapped]
        //public Int32? PaymentBlockEntry
        //{
        //    get => fields.PaymentBlockEntry[this];
        //    set => fields.PaymentBlockEntry[this] = value;
        //}

        //[DisplayName("Central Bank Indicator"), NotNull]
        //[NotMapped]
        //public String CentralBankIndicator
        //{
        //    get => fields.CentralBankIndicator[this];
        //    set => fields.CentralBankIndicator[this] = value;
        //}

        //[DisplayName("Maximum Cash Discount"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String MaximumCashDiscount
        //{
        //    get => fields.MaximumCashDiscount[this];
        //    set => fields.MaximumCashDiscount[this] = value;
        //}

        //[DisplayName("Reserve"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String Reserve
        //{
        //    get => fields.Reserve[this];
        //    set => fields.Reserve[this] = value;
        //}



        //[DisplayName("Exemption Validity Date From"), NotNull]
        //[NotMapped]
        //public DateTime ExemptionValidityDateFrom
        //{
        //    get => fields.ExemptionValidityDateFrom[this];
        //    set => fields.ExemptionValidityDateFrom[this] = value;
        //}

        //[DisplayName("Exemption Validity Date To"), NotNull]
        //[NotMapped]
        //public DateTime ExemptionValidityDateTo
        //{
        //    get => fields.ExemptionValidityDateTo[this];
        //    set => fields.ExemptionValidityDateTo[this] = value;
        //}

        //[DisplayName("Ware House Update Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoDocWhsUpdateTypes]? WareHouseUpdateType
        //{
        //    get => fields.WareHouseUpdateType[this];
        //    set => fields.WareHouseUpdateType[this] = value;
        //}

        //[DisplayName("Rounding"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String Rounding
        //{
        //    get => fields.Rounding[this];
        //    set => fields.Rounding[this] = value;
        //}

        //[DisplayName("External Corrected Doc Num"), NotNull]
        //[NotMapped]
        //public String ExternalCorrectedDocNum
        //{
        //    get => fields.ExternalCorrectedDocNum[this];
        //    set => fields.ExternalCorrectedDocNum[this] = value;
        //}

        //[DisplayName("Internal Corrected Doc Num"), NotNull]
        //[NotMapped]
        //public Int32? InternalCorrectedDocNum
        //{
        //    get => fields.InternalCorrectedDocNum[this];
        //    set => fields.InternalCorrectedDocNum[this] = value;
        //}

        //[DisplayName("Next Correcting Document"), NotNull]
        //[NotMapped]
        //public Int32? NextCorrectingDocument
        //{
        //    get => fields.NextCorrectingDocument[this];
        //    set => fields.NextCorrectingDocument[this] = value;
        //}

        //[DisplayName("Deferred Tax"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String DeferredTax
        //{
        //    get => fields.DeferredTax[this];
        //    set => fields.DeferredTax[this] = value;
        //}

        //[DisplayName("Tax Exemption Letter Num"), NotNull]
        //[NotMapped]
        //public String TaxExemptionLetterNum
        //{
        //    get => fields.TaxExemptionLetterNum[this];
        //    set => fields.TaxExemptionLetterNum[this] = value;
        //}

        //[DisplayName("Wt Applied"), Column("WTApplied"), NotNull]
        //[NotMapped]
        //public decimal? WtApplied
        //{
        //    get => fields.WtApplied[this];
        //    set => fields.WtApplied[this] = value;
        //}

        //[DisplayName("Wt Applied Fc"), Column("WTAppliedFC"), NotNull]
        //[NotMapped]
        //public decimal? WtAppliedFc
        //{
        //    get => fields.WtAppliedFc[this];
        //    set => fields.WtAppliedFc[this] = value;
        //}

        //[DisplayName("Bill Of Exchange Reserved"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String BillOfExchangeReserved
        //{
        //    get => fields.BillOfExchangeReserved[this];
        //    set => fields.BillOfExchangeReserved[this] = value;
        //}

        //[DisplayName("Agent Code"), NotNull]
        //[NotMapped]
        //public String AgentCode
        //{
        //    get => fields.AgentCode[this];
        //    set => fields.AgentCode[this] = value;
        //}

        //[DisplayName("Wt Applied Sc"), Column("WTAppliedSC"), NotNull]
        //[NotMapped]
        //public decimal? WtAppliedSc
        //{
        //    get => fields.WtAppliedSc[this];
        //    set => fields.WtAppliedSc[this] = value;
        //}

        //[DisplayName("Total Equalization Tax"), NotNull]
        //[NotMapped]
        //public decimal? TotalEqualizationTax
        //{
        //    get => fields.TotalEqualizationTax[this];
        //    set => fields.TotalEqualizationTax[this] = value;
        //}

        //[DisplayName("Total Equalization Tax Fc"), Column("TotalEqualizationTaxFC"), NotNull]
        //[NotMapped]
        //public decimal? TotalEqualizationTaxFc
        //{
        //    get => fields.TotalEqualizationTaxFc[this];
        //    set => fields.TotalEqualizationTaxFc[this] = value;
        //}

        //[DisplayName("Total Equalization Tax Sc"), Column("TotalEqualizationTaxSC"), NotNull]
        //[NotMapped]
        //public decimal? TotalEqualizationTaxSc
        //{
        //    get => fields.TotalEqualizationTaxSc[this];
        //    set => fields.TotalEqualizationTaxSc[this] = value;
        //}

        //[DisplayName("Number Of Installments"), NotNull]
        //[NotMapped]
        //public Int32? NumberOfInstallments
        //{
        //    get => fields.NumberOfInstallments[this];
        //    set => fields.NumberOfInstallments[this] = value;
        //}

        //[DisplayName("Apply Tax On First Installment"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ApplyTaxOnFirstInstallment
        //{
        //    get => fields.ApplyTaxOnFirstInstallment[this];
        //    set => fields.ApplyTaxOnFirstInstallment[this] = value;
        //}

        //[DisplayName("Wt Non Subject Amount"), Column("WTNonSubjectAmount"), NotNull]
        //[NotMapped]
        //public decimal? WtNonSubjectAmount
        //{
        //    get => fields.WtNonSubjectAmount[this];
        //    set => fields.WtNonSubjectAmount[this] = value;
        //}

        //[DisplayName("Wt Non Subject Amount Sc"), Column("WTNonSubjectAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? WtNonSubjectAmountSc
        //{
        //    get => fields.WtNonSubjectAmountSc[this];
        //    set => fields.WtNonSubjectAmountSc[this] = value;
        //}

        //[DisplayName("Wt Non Subject Amount Fc"), Column("WTNonSubjectAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? WtNonSubjectAmountFc
        //{
        //    get => fields.WtNonSubjectAmountFc[this];
        //    set => fields.WtNonSubjectAmountFc[this] = value;
        //}

        //[DisplayName("Wt Exempted Amount"), Column("WTExemptedAmount"), NotNull]
        //[NotMapped]
        //public decimal? WtExemptedAmount
        //{
        //    get => fields.WtExemptedAmount[this];
        //    set => fields.WtExemptedAmount[this] = value;
        //}

        //[DisplayName("Wt Exempted Amount Sc"), Column("WTExemptedAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? WtExemptedAmountSc
        //{
        //    get => fields.WtExemptedAmountSc[this];
        //    set => fields.WtExemptedAmountSc[this] = value;
        //}

        //[DisplayName("Wt Exempted Amount Fc"), Column("WTExemptedAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? WtExemptedAmountFc
        //{
        //    get => fields.WtExemptedAmountFc[this];
        //    set => fields.WtExemptedAmountFc[this] = value;
        //}

        //[DisplayName("Base Amount"), NotNull]
        //[NotMapped]
        //public decimal? BaseAmount
        //{
        //    get => fields.BaseAmount[this];
        //    set => fields.BaseAmount[this] = value;
        //}

        //[DisplayName("Base Amount Sc"), Column("BaseAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? BaseAmountSc
        //{
        //    get => fields.BaseAmountSc[this];
        //    set => fields.BaseAmountSc[this] = value;
        //}

        //[DisplayName("Base Amount Fc"), Column("BaseAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? BaseAmountFc
        //{
        //    get => fields.BaseAmountFc[this];
        //    set => fields.BaseAmountFc[this] = value;
        //}

        //[DisplayName("Wt Amount"), Column("WTAmount"), NotNull]
        //[NotMapped]
        //public decimal? WtAmount
        //{
        //    get => fields.WtAmount[this];
        //    set => fields.WtAmount[this] = value;
        //}

        //[DisplayName("Wt Amount Sc"), Column("WTAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? WtAmountSc
        //{
        //    get => fields.WtAmountSc[this];
        //    set => fields.WtAmountSc[this] = value;
        //}

        //[DisplayName("Wt Amount Fc"), Column("WTAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? WtAmountFc
        //{
        //    get => fields.WtAmountFc[this];
        //    set => fields.WtAmountFc[this] = value;
        //}

        //[DisplayName("Vat Date"), NotNull]
        //[NotMapped]
        //public DateTime VatDate
        //{
        //    get => fields.VatDate[this];
        //    set => fields.VatDate[this] = value;
        //}


        //[DisplayName("Folio Prefix String"), NotNull]
        //[NotMapped]
        //public String FolioPrefixString
        //{
        //    get => fields.FolioPrefixString[this];
        //    set => fields.FolioPrefixString[this] = value;
        //}

        //[DisplayName("Folio Number"), NotNull]
        //[NotMapped]
        //public Int32? FolioNumber
        //{
        //    get => fields.FolioNumber[this];
        //    set => fields.FolioNumber[this] = value;
        //}

        //[DisplayName("Document Sub Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoDocumentSubType]? DocumentSubType
        //{
        //    get => fields.DocumentSubType[this];
        //    set => fields.DocumentSubType[this] = value;
        //}

        //[DisplayName("Bp Channel Code"), Column("BPChannelCode"), NotNull]
        //[NotMapped]
        //public String BpChannelCode
        //{
        //    get => fields.BpChannelCode[this];
        //    set => fields.BpChannelCode[this] = value;
        //}

        //[DisplayName("Bp Channel Contact"), Column("BPChannelContact"), NotNull]
        //[NotMapped]
        //public Int32? BpChannelContact
        //{
        //    get => fields.BpChannelContact[this];
        //    set => fields.BpChannelContact[this] = value;
        //}

        //[DisplayName("Address2"), NotNull]
        //[NotMapped]
        //public String Address2
        //{
        //    get => fields.Address2[this];
        //    set => fields.Address2[this] = value;
        //}



        //[DisplayName("Period Indicator"), NotNull]
        //[NotMapped]
        //public String PeriodIndicator
        //{
        //    get => fields.PeriodIndicator[this];
        //    set => fields.PeriodIndicator[this] = value;
        //}



        //[DisplayName("Manual Number"), NotNull]
        //[NotMapped]
        //public String ManualNumber
        //{
        //    get => fields.ManualNumber[this];
        //    set => fields.ManualNumber[this] = value;
        //}

        //[DisplayName("Use Shpd Goods Act"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String UseShpdGoodsAct
        //{
        //    get => fields.UseShpdGoodsAct[this];
        //    set => fields.UseShpdGoodsAct[this] = value;
        //}

        //[DisplayName("Is Pay To Bank"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String IsPayToBank
        //{
        //    get => fields.IsPayToBank[this];
        //    set => fields.IsPayToBank[this] = value;
        //}

        //[DisplayName("Pay To Bank Country"), NotNull]
        //[NotMapped]
        //public String PayToBankCountry
        //{
        //    get => fields.PayToBankCountry[this];
        //    set => fields.PayToBankCountry[this] = value;
        //}

        //[DisplayName("Pay To Bank Code"), NotNull]
        //[NotMapped]
        //public String PayToBankCode
        //{
        //    get => fields.PayToBankCode[this];
        //    set => fields.PayToBankCode[this] = value;
        //}

        //[DisplayName("Pay To Bank Account No"), NotNull]
        //[NotMapped]
        //public String PayToBankAccountNo
        //{
        //    get => fields.PayToBankAccountNo[this];
        //    set => fields.PayToBankAccountNo[this] = value;
        //}

        //[DisplayName("Pay To Bank Branch"), NotNull]
        //[NotMapped]
        //public String PayToBankBranch
        //{
        //    get => fields.PayToBankBranch[this];
        //    set => fields.PayToBankBranch[this] = value;
        //}

        //[DisplayName("Bpl Id Assigned To Invoice"), Column("BPL_IDAssignedToInvoice"), NotNull]
        //[NotMapped]
        //public Int32? BplIdAssignedToInvoice
        //{
        //    get => fields.BplIdAssignedToInvoice[this];
        //    set => fields.BplIdAssignedToInvoice[this] = value;
        //}

        //[DisplayName("Down Payment"), NotNull]
        //[NotMapped]
        //public decimal? DownPayment
        //{
        //    get => fields.DownPayment[this];
        //    set => fields.DownPayment[this] = value;
        //}

        //[DisplayName("Reserve Invoice"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ReserveInvoice
        //{
        //    get => fields.ReserveInvoice[this];
        //    set => fields.ReserveInvoice[this] = value;
        //}

        //[DisplayName("Language Code"), NotNull]
        //[NotMapped]
        //public Int32? LanguageCode
        //{
        //    get => fields.LanguageCode[this];
        //    set => fields.LanguageCode[this] = value;
        //}

        //[DisplayName("Tracking Number"), NotNull]
        //[NotMapped]
        //public String TrackingNumber
        //{
        //    get => fields.TrackingNumber[this];
        //    set => fields.TrackingNumber[this] = value;
        //}

        //[DisplayName("Pick Remark"), NotNull]
        //[NotMapped]
        //public String PickRemark
        //{
        //    get => fields.PickRemark[this];
        //    set => fields.PickRemark[this] = value;
        //}

        //[DisplayName("Closing Date"), NotNull]
        //[NotMapped]
        //public DateTime ClosingDate
        //{
        //    get => fields.ClosingDate[this];
        //    set => fields.ClosingDate[this] = value;
        //}

        //[DisplayName("Sequence Code"), NotNull]
        //[NotMapped]
        //public Int32? SequenceCode
        //{
        //    get => fields.SequenceCode[this];
        //    set => fields.SequenceCode[this] = value;
        //}

        //[DisplayName("Sequence Serial"), NotNull]
        //[NotMapped]
        //public Int32? SequenceSerial
        //{
        //    get => fields.SequenceSerial[this];
        //    set => fields.SequenceSerial[this] = value;
        //}

        //[DisplayName("Series String"), NotNull]
        //[NotMapped]
        //public String SeriesString
        //{
        //    get => fields.SeriesString[this];
        //    set => fields.SeriesString[this] = value;
        //}

        //[DisplayName("Sub Series String"), NotNull]
        //[NotMapped]
        //public String SubSeriesString
        //{
        //    get => fields.SubSeriesString[this];
        //    set => fields.SubSeriesString[this] = value;
        //}

        //[DisplayName("Sequence Model"), NotNull]
        //[NotMapped]
        //public String SequenceModel
        //{
        //    get => fields.SequenceModel[this];
        //    set => fields.SequenceModel[this] = value;
        //}

        //[DisplayName("Use Correction Vat Group"), Column("UseCorrectionVATGroup"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String UseCorrectionVatGroup
        //{
        //    get => fields.UseCorrectionVatGroup[this];
        //    set => fields.UseCorrectionVatGroup[this] = value;
        //}



        //[DisplayName("Down Payment Amount"), NotNull]
        //[NotMapped]
        //public decimal? DownPaymentAmount
        //{
        //    get => fields.DownPaymentAmount[this];
        //    set => fields.DownPaymentAmount[this] = value;
        //}

        //[DisplayName("Down Payment Percentage"), NotNull]
        //[NotMapped]
        //public decimal? DownPaymentPercentage
        //{
        //    get => fields.DownPaymentPercentage[this];
        //    set => fields.DownPaymentPercentage[this] = value;
        //}

        //[DisplayName("Down Payment Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.DownPaymentTypeEnum]? DownPaymentType
        //{
        //    get => fields.DownPaymentType[this];
        //    set => fields.DownPaymentType[this] = value;
        //}

        //[DisplayName("Down Payment Amount Sc"), Column("DownPaymentAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? DownPaymentAmountSc
        //{
        //    get => fields.DownPaymentAmountSc[this];
        //    set => fields.DownPaymentAmountSc[this] = value;
        //}

        //[DisplayName("Down Payment Amount Fc"), Column("DownPaymentAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? DownPaymentAmountFc
        //{
        //    get => fields.DownPaymentAmountFc[this];
        //    set => fields.DownPaymentAmountFc[this] = value;
        //}

        //[DisplayName("Vat Percent"), NotNull]
        //[NotMapped]
        //public decimal? VatPercent
        //{
        //    get => fields.VatPercent[this];
        //    set => fields.VatPercent[this] = value;
        //}

        //[DisplayName("Service Gross Profit Percent"), NotNull]
        //[NotMapped]
        //public decimal? ServiceGrossProfitPercent
        //{
        //    get => fields.ServiceGrossProfitPercent[this];
        //    set => fields.ServiceGrossProfitPercent[this] = value;
        //}

        //[DisplayName("Opening Remarks"), NotNull]
        //[NotMapped]
        //public String OpeningRemarks
        //{
        //    get => fields.OpeningRemarks[this];
        //    set => fields.OpeningRemarks[this] = value;
        //}

        //[DisplayName("Closing Remarks"), NotNull]
        //[NotMapped]
        //public String ClosingRemarks
        //{
        //    get => fields.ClosingRemarks[this];
        //    set => fields.ClosingRemarks[this] = value;
        //}

        //[DisplayName("Rounding Diff Amount"), NotNull]
        //[NotMapped]
        //public decimal? RoundingDiffAmount
        //{
        //    get => fields.RoundingDiffAmount[this];
        //    set => fields.RoundingDiffAmount[this] = value;
        //}

        //[DisplayName("Rounding Diff Amount Fc"), Column("RoundingDiffAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? RoundingDiffAmountFc
        //{
        //    get => fields.RoundingDiffAmountFc[this];
        //    set => fields.RoundingDiffAmountFc[this] = value;
        //}

        //[DisplayName("Rounding Diff Amount Sc"), Column("RoundingDiffAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? RoundingDiffAmountSc
        //{
        //    get => fields.RoundingDiffAmountSc[this];
        //    set => fields.RoundingDiffAmountSc[this] = value;
        //}

        //[DisplayName("Cancelled"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String Cancelled
        //{
        //    get => fields.Cancelled[this];
        //    set => fields.Cancelled[this] = value;
        //}

        //[DisplayName("Signature Input Message"), NotNull]
        //[NotMapped]
        //public String SignatureInputMessage
        //{
        //    get => fields.SignatureInputMessage[this];
        //    set => fields.SignatureInputMessage[this] = value;
        //}

        //[DisplayName("Signature Digest"), NotNull]
        //[NotMapped]
        //public String SignatureDigest
        //{
        //    get => fields.SignatureDigest[this];
        //    set => fields.SignatureDigest[this] = value;
        //}

        //[DisplayName("Certification Number"), NotNull]
        //[NotMapped]
        //public String CertificationNumber
        //{
        //    get => fields.CertificationNumber[this];
        //    set => fields.CertificationNumber[this] = value;
        //}

        //[DisplayName("Private Key Version"), NotNull]
        //[NotMapped]
        //public Int32? PrivateKeyVersion
        //{
        //    get => fields.PrivateKeyVersion[this];
        //    set => fields.PrivateKeyVersion[this] = value;
        //}

        //[DisplayName("Control Account"), NotNull]
        //[NotMapped]
        //public String ControlAccount
        //{
        //    get => fields.ControlAccount[this];
        //    set => fields.ControlAccount[this] = value;
        //}

        //[DisplayName("Insurance Operation347"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String InsuranceOperation347
        //{
        //    get => fields.InsuranceOperation347[this];
        //    set => fields.InsuranceOperation347[this] = value;
        //}

        //[DisplayName("Archive Nonremovable Sales Quotation"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ArchiveNonremovableSalesQuotation
        //{
        //    get => fields.ArchiveNonremovableSalesQuotation[this];
        //    set => fields.ArchiveNonremovableSalesQuotation[this] = value;
        //}

        //[DisplayName("Gts Checker"), Column("GTSChecker"), NotNull]
        //[NotMapped]
        //public Int32? GtsChecker
        //{
        //    get => fields.GtsChecker[this];
        //    set => fields.GtsChecker[this] = value;
        //}

        //[DisplayName("Gts Payee"), Column("GTSPayee"), NotNull]
        //[NotMapped]
        //public Int32? GtsPayee
        //{
        //    get => fields.GtsPayee[this];
        //    set => fields.GtsPayee[this] = value;
        //}

        //[DisplayName("Extra Month"), NotNull]
        //[NotMapped]
        //public Int32? ExtraMonth
        //{
        //    get => fields.ExtraMonth[this];
        //    set => fields.ExtraMonth[this] = value;
        //}

        //[DisplayName("Extra Days"), NotNull]
        //[NotMapped]
        //public Int32? ExtraDays
        //{
        //    get => fields.ExtraDays[this];
        //    set => fields.ExtraDays[this] = value;
        //}

        //[DisplayName("Cash Discount Date Offset"), NotNull]
        //[NotMapped]
        //public Int32? CashDiscountDateOffset
        //{
        //    get => fields.CashDiscountDateOffset[this];
        //    set => fields.CashDiscountDateOffset[this] = value;
        //}

        //[DisplayName("Start From"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoPayTermDueTypes]? StartFrom
        //{
        //    get => fields.StartFrom[this];
        //    set => fields.StartFrom[this] = value;
        //}

        //[DisplayName("Nts Approved"), Column("NTSApproved"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String NtsApproved
        //{
        //    get => fields.NtsApproved[this];
        //    set => fields.NtsApproved[this] = value;
        //}

        //[DisplayName("E Tax Web Site"), NotNull]
        //[NotMapped]
        //public Int32? ETaxWebSite
        //{
        //    get => fields.ETaxWebSite[this];
        //    set => fields.ETaxWebSite[this] = value;
        //}

        //[DisplayName("E Tax Number"), NotNull]
        //[NotMapped]
        //public String ETaxNumber
        //{
        //    get => fields.ETaxNumber[this];
        //    set => fields.ETaxNumber[this] = value;
        //}

        //[DisplayName("Nts Approved Number"), Column("NTSApprovedNumber"), NotNull]
        //[NotMapped]
        //public String NtsApprovedNumber
        //{
        //    get => fields.NtsApprovedNumber[this];
        //    set => fields.NtsApprovedNumber[this] = value;
        //}

        //[DisplayName("E Doc Generation Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.EDocGenerationTypeEnum]? EDocGenerationType
        //{
        //    get => fields.EDocGenerationType[this];
        //    set => fields.EDocGenerationType[this] = value;
        //}

        //[DisplayName("E Doc Series"), NotNull]
        //[NotMapped]
        //public Int32? EDocSeries
        //{
        //    get => fields.EDocSeries[this];
        //    set => fields.EDocSeries[this] = value;
        //}

        //[DisplayName("E Doc Num"), NotNull]
        //[NotMapped]
        //public String EDocNum
        //{
        //    get => fields.EDocNum[this];
        //    set => fields.EDocNum[this] = value;
        //}

        //[DisplayName("E Doc Export Format"), NotNull]
        //[NotMapped]
        //public Int32? EDocExportFormat
        //{
        //    get => fields.EDocExportFormat[this];
        //    set => fields.EDocExportFormat[this] = value;
        //}

        //[DisplayName("E Doc Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.EDocStatusEnum]? EDocStatus
        //{
        //    get => fields.EDocStatus[this];
        //    set => fields.EDocStatus[this] = value;
        //}

        //[DisplayName("E Doc Error Code"), NotNull]
        //[NotMapped]
        //public String EDocErrorCode
        //{
        //    get => fields.EDocErrorCode[this];
        //    set => fields.EDocErrorCode[this] = value;
        //}

        //[DisplayName("E Doc Error Message"), NotNull]
        //[NotMapped]
        //public String EDocErrorMessage
        //{
        //    get => fields.EDocErrorMessage[this];
        //    set => fields.EDocErrorMessage[this] = value;
        //}

        //[DisplayName("Down Payment Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoSoStatus]? DownPaymentStatus
        //{
        //    get => fields.DownPaymentStatus[this];
        //    set => fields.DownPaymentStatus[this] = value;
        //}

        //[DisplayName("Group Series"), NotNull]
        //[NotMapped]
        //public Int32? GroupSeries
        //{
        //    get => fields.GroupSeries[this];
        //    set => fields.GroupSeries[this] = value;
        //}


        //[DisplayName("Group Hand Written"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String GroupHandWritten
        //{
        //    get => fields.GroupHandWritten[this];
        //    set => fields.GroupHandWritten[this] = value;
        //}

        //[DisplayName("Reopen Original Document"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ReopenOriginalDocument
        //{
        //    get => fields.ReopenOriginalDocument[this];
        //    set => fields.ReopenOriginalDocument[this] = value;
        //}

        //[DisplayName("Reopen Manually Closed Or Canceled Document"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ReopenManuallyClosedOrCanceledDocument
        //{
        //    get => fields.ReopenManuallyClosedOrCanceledDocument[this];
        //    set => fields.ReopenManuallyClosedOrCanceledDocument[this] = value;
        //}

        //[DisplayName("Create Online Quotation"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String CreateOnlineQuotation
        //{
        //    get => fields.CreateOnlineQuotation[this];
        //    set => fields.CreateOnlineQuotation[this] = value;
        //}

        //[DisplayName("Pos Equipment Number"), Column("POSEquipmentNumber"), NotNull]
        //[NotMapped]
        //public String PosEquipmentNumber
        //{
        //    get => fields.PosEquipmentNumber[this];
        //    set => fields.PosEquipmentNumber[this] = value;
        //}

        //[DisplayName("Pos Manufacturer Serial Number"), Column("POSManufacturerSerialNumber"), NotNull]
        //[NotMapped]
        //public String PosManufacturerSerialNumber
        //{
        //    get => fields.PosManufacturerSerialNumber[this];
        //    set => fields.PosManufacturerSerialNumber[this] = value;
        //}

        //[DisplayName("Pos Cashier Number"), Column("POSCashierNumber"), NotNull]
        //[NotMapped]
        //public Int32? PosCashierNumber
        //{
        //    get => fields.PosCashierNumber[this];
        //    set => fields.PosCashierNumber[this] = value;
        //}

        //[DisplayName("Apply Current Vat Rates For Down Payments To Draw"), Column("ApplyCurrentVATRatesForDownPaymentsToDraw"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ApplyCurrentVatRatesForDownPaymentsToDraw
        //{
        //    get => fields.ApplyCurrentVatRatesForDownPaymentsToDraw[this];
        //    set => fields.ApplyCurrentVatRatesForDownPaymentsToDraw[this] = value;
        //}

        //[DisplayName("Closing Option"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.ClosingOptionEnum]? ClosingOption
        //{
        //    get => fields.ClosingOption[this];
        //    set => fields.ClosingOption[this] = value;
        //}

        //[DisplayName("Specified Closing Date"), NotNull]
        //[NotMapped]
        //public DateTime SpecifiedClosingDate
        //{
        //    get => fields.SpecifiedClosingDate[this];
        //    set => fields.SpecifiedClosingDate[this] = value;
        //}

        //[DisplayName("Open For Landed Costs"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String OpenForLandedCosts
        //{
        //    get => fields.OpenForLandedCosts[this];
        //    set => fields.OpenForLandedCosts[this] = value;
        //}

        //[DisplayName("Authorization Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.DocumentAuthorizationStatusEnum]? AuthorizationStatus
        //{
        //    get => fields.AuthorizationStatus[this];
        //    set => fields.AuthorizationStatus[this] = value;
        //}

        //[DisplayName("Total Discount Fc"), Column("TotalDiscountFC"), NotNull]
        //[NotMapped]
        //public decimal? TotalDiscountFc
        //{
        //    get => fields.TotalDiscountFc[this];
        //    set => fields.TotalDiscountFc[this] = value;
        //}

        //[DisplayName("Total Discount Sc"), Column("TotalDiscountSC"), NotNull]
        //[NotMapped]
        //public decimal? TotalDiscountSc
        //{
        //    get => fields.TotalDiscountSc[this];
        //    set => fields.TotalDiscountSc[this] = value;
        //}

        //[DisplayName("Relevant To Gts"), Column("RelevantToGTS"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String RelevantToGts
        //{
        //    get => fields.RelevantToGts[this];
        //    set => fields.RelevantToGts[this] = value;
        //}

        //[DisplayName("Bpl Name"), Column("BPLName"), NotNull]
        //[NotMapped]
        //public String BplName
        //{
        //    get => fields.BplName[this];
        //    set => fields.BplName[this] = value;
        //}

        //[DisplayName("Vat Reg Num"), Column("VATRegNum"), NotNull]
        //[NotMapped]
        //public String VatRegNum
        //{
        //    get => fields.VatRegNum[this];
        //    set => fields.VatRegNum[this] = value;
        //}

        //[DisplayName("Annual Invoice Declaration Reference"), NotNull]
        //[NotMapped]
        //public Int32? AnnualInvoiceDeclarationReference
        //{
        //    get => fields.AnnualInvoiceDeclarationReference[this];
        //    set => fields.AnnualInvoiceDeclarationReference[this] = value;
        //}

        //[DisplayName("Supplier"), NotNull]
        //[NotMapped]
        //public String Supplier
        //{
        //    get => fields.Supplier[this];
        //    set => fields.Supplier[this] = value;
        //}

        //[DisplayName("Releaser"), NotNull]
        //[NotMapped]
        //public Int32? Releaser
        //{
        //    get => fields.Releaser[this];
        //    set => fields.Releaser[this] = value;
        //}

        //[DisplayName("Receiver"), NotNull]
        //[NotMapped]
        //public Int32? Receiver
        //{
        //    get => fields.Receiver[this];
        //    set => fields.Receiver[this] = value;
        //}

        //[DisplayName("Blanket Agreement Number"), NotNull]
        //[NotMapped]
        //public Int32? BlanketAgreementNumber
        //{
        //    get => fields.BlanketAgreementNumber[this];
        //    set => fields.BlanketAgreementNumber[this] = value;
        //}

        //[DisplayName("Is Alteration"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String IsAlteration
        //{
        //    get => fields.IsAlteration[this];
        //    set => fields.IsAlteration[this] = value;
        //}

        //[DisplayName("Cancel Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.CancelStatusEnum]? CancelStatus
        //{
        //    get => fields.CancelStatus[this];
        //    set => fields.CancelStatus[this] = value;
        //}

        //[DisplayName("Asset Value Date"), NotNull]
        //[NotMapped]
        //public DateTime AssetValueDate
        //{
        //    get => fields.AssetValueDate[this];
        //    set => fields.AssetValueDate[this] = value;
        //}

        //[DisplayName("Requester"), NotNull]
        //[NotMapped]
        //public String Requester
        //{
        //    get => fields.Requester[this];
        //    set => fields.Requester[this] = value;
        //}

        //[DisplayName("Requester Name"), NotNull]
        //[NotMapped]
        //public String RequesterName
        //{
        //    get => fields.RequesterName[this];
        //    set => fields.RequesterName[this] = value;
        //}

        //[DisplayName("Requester Branch"), NotNull]
        //[NotMapped]
        //public Int32? RequesterBranch
        //{
        //    get => fields.RequesterBranch[this];
        //    set => fields.RequesterBranch[this] = value;
        //}

        //[DisplayName("Requester Department"), NotNull]
        //[NotMapped]
        //public Int32? RequesterDepartment
        //{
        //    get => fields.RequesterDepartment[this];
        //    set => fields.RequesterDepartment[this] = value;
        //}

        //[DisplayName("Requester Email"), NotNull]
        //[NotMapped]
        //public String RequesterEmail
        //{
        //    get => fields.RequesterEmail[this];
        //    set => fields.RequesterEmail[this] = value;
        //}

        //[DisplayName("Send Notification"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String SendNotification
        //{
        //    get => fields.SendNotification[this];
        //    set => fields.SendNotification[this] = value;
        //}

        //[DisplayName("Req Type"), NotNull]
        //[NotMapped]
        //public Int32? ReqType
        //{
        //    get => fields.ReqType[this];
        //    set => fields.ReqType[this] = value;
        //}

        //[DisplayName("Invoice Payment"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String InvoicePayment
        //{
        //    get => fields.InvoicePayment[this];
        //    set => fields.InvoicePayment[this] = value;
        //}

        //[DisplayName("Document Delivery"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.DocumentDeliveryTypeEnum]? DocumentDelivery
        //{
        //    get => fields.DocumentDelivery[this];
        //    set => fields.DocumentDelivery[this] = value;
        //}

        //[DisplayName("Authorization Code"), NotNull]
        //[NotMapped]
        //public String AuthorizationCode
        //{
        //    get => fields.AuthorizationCode[this];
        //    set => fields.AuthorizationCode[this] = value;
        //}

        //[DisplayName("Start Delivery Date"), NotNull]
        //[NotMapped]
        //public DateTime StartDeliveryDate
        //{
        //    get => fields.StartDeliveryDate[this];
        //    set => fields.StartDeliveryDate[this] = value;
        //}

        //[DisplayName("Start Delivery Time"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]? StartDeliveryTime
        //{
        //    get => fields.StartDeliveryTime[this];
        //    set => fields.StartDeliveryTime[this] = value;
        //}

        //[DisplayName("End Delivery Date"), NotNull]
        //[NotMapped]
        //public DateTime EndDeliveryDate
        //{
        //    get => fields.EndDeliveryDate[this];
        //    set => fields.EndDeliveryDate[this] = value;
        //}

        //[DisplayName("End Delivery Time"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]? EndDeliveryTime
        //{
        //    get => fields.EndDeliveryTime[this];
        //    set => fields.EndDeliveryTime[this] = value;
        //}

        //[DisplayName("Vehicle Plate"), NotNull]
        //[NotMapped]
        //public String VehiclePlate
        //{
        //    get => fields.VehiclePlate[this];
        //    set => fields.VehiclePlate[this] = value;
        //}

        //[DisplayName("At Document Type"), Column("ATDocumentType"), NotNull]
        //[NotMapped]
        //public String AtDocumentType
        //{
        //    get => fields.AtDocumentType[this];
        //    set => fields.AtDocumentType[this] = value;
        //}

        //[DisplayName("Elec Comm Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.ElecCommStatusEnum]? ElecCommStatus
        //{
        //    get => fields.ElecCommStatus[this];
        //    set => fields.ElecCommStatus[this] = value;
        //}

        //[DisplayName("Elec Comm Message"), NotNull]
        //[NotMapped]
        //public String ElecCommMessage
        //{
        //    get => fields.ElecCommMessage[this];
        //    set => fields.ElecCommMessage[this] = value;
        //}

        //[DisplayName("Reuse Document Num"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ReuseDocumentNum
        //{
        //    get => fields.ReuseDocumentNum[this];
        //    set => fields.ReuseDocumentNum[this] = value;
        //}

        //[DisplayName("Reuse Nota Fiscal Num"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ReuseNotaFiscalNum
        //{
        //    get => fields.ReuseNotaFiscalNum[this];
        //    set => fields.ReuseNotaFiscalNum[this] = value;
        //}

        //[DisplayName("Print Sepa Direct"), Column("PrintSEPADirect"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String PrintSepaDirect
        //{
        //    get => fields.PrintSepaDirect[this];
        //    set => fields.PrintSepaDirect[this] = value;
        //}

        //[DisplayName("Fiscal Doc Num"), NotNull]
        //[NotMapped]
        //public String FiscalDocNum
        //{
        //    get => fields.FiscalDocNum[this];
        //    set => fields.FiscalDocNum[this] = value;
        //}

        //[DisplayName("Pos Daily Summary No"), Column("POSDailySummaryNo"), NotNull]
        //[NotMapped]
        //public Int32? PosDailySummaryNo
        //{
        //    get => fields.PosDailySummaryNo[this];
        //    set => fields.PosDailySummaryNo[this] = value;
        //}

        //[DisplayName("Pos Receipt No"), Column("POSReceiptNo"), NotNull]
        //[NotMapped]
        //public Int32? PosReceiptNo
        //{
        //    get => fields.PosReceiptNo[this];
        //    set => fields.PosReceiptNo[this] = value;
        //}

        //[DisplayName("Point Of Issue Code"), NotNull]
        //[NotMapped]
        //public String PointOfIssueCode
        //{
        //    get => fields.PointOfIssueCode[this];
        //    set => fields.PointOfIssueCode[this] = value;
        //}

        //[DisplayName("Letter"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.FolioLetterEnum]? Letter
        //{
        //    get => fields.Letter[this];
        //    set => fields.Letter[this] = value;
        //}

        //[DisplayName("Folio Number From"), NotNull]
        //[NotMapped]
        //public Int32? FolioNumberFrom
        //{
        //    get => fields.FolioNumberFrom[this];
        //    set => fields.FolioNumberFrom[this] = value;
        //}

        //[DisplayName("Folio Number To"), NotNull]
        //[NotMapped]
        //public Int32? FolioNumberTo
        //{
        //    get => fields.FolioNumberTo[this];
        //    set => fields.FolioNumberTo[this] = value;
        //}

        //[DisplayName("Interim Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoInterimDocTypes]? InterimType
        //{
        //    get => fields.InterimType[this];
        //    set => fields.InterimType[this] = value;
        //}

        //[DisplayName("Related Type"), NotNull]
        //[NotMapped]
        //public Int32? RelatedType
        //{
        //    get => fields.RelatedType[this];
        //    set => fields.RelatedType[this] = value;
        //}

        //[DisplayName("Related Entry"), NotNull]
        //[NotMapped]
        //public Int32? RelatedEntry
        //{
        //    get => fields.RelatedEntry[this];
        //    set => fields.RelatedEntry[this] = value;
        //}

        //[DisplayName("Sap Passport"), Column("SAPPassport"), NotNull]
        //[NotMapped]
        //public String SapPassport
        //{
        //    get => fields.SapPassport[this];
        //    set => fields.SapPassport[this] = value;
        //}

        //[DisplayName("Document Tax Id"), Column("DocumentTaxID"), NotNull]
        //[NotMapped]
        //public String DocumentTaxId
        //{
        //    get => fields.DocumentTaxId[this];
        //    set => fields.DocumentTaxId[this] = value;
        //}

        //[DisplayName("Date Of Reporting Control Statement Vat"), Column("DateOfReportingControlStatementVAT"), NotNull]
        //[NotMapped]
        //public DateTime DateOfReportingControlStatementVat
        //{
        //    get => fields.DateOfReportingControlStatementVat[this];
        //    set => fields.DateOfReportingControlStatementVat[this] = value;
        //}

        //[DisplayName("Reporting Section Control Statement Vat"), Column("ReportingSectionControlStatementVAT"), NotNull]
        //[NotMapped]
        //public String ReportingSectionControlStatementVat
        //{
        //    get => fields.ReportingSectionControlStatementVat[this];
        //    set => fields.ReportingSectionControlStatementVat[this] = value;
        //}

        //[DisplayName("Exclude From Tax Report Control Statement Vat"), Column("ExcludeFromTaxReportControlStatementVAT"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String ExcludeFromTaxReportControlStatementVat
        //{
        //    get => fields.ExcludeFromTaxReportControlStatementVat[this];
        //    set => fields.ExcludeFromTaxReportControlStatementVat[this] = value;
        //}

        //[DisplayName("Pos Cash Register"), Column("POS_CashRegister"), NotNull]
        //[NotMapped]
        //public Int32? PosCashRegister
        //{
        //    get => fields.PosCashRegister[this];
        //    set => fields.PosCashRegister[this] = value;
        //}

        //[DisplayName("Update Time"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]? UpdateTime
        //{
        //    get => fields.UpdateTime[this];
        //    set => fields.UpdateTime[this] = value;
        //}

        //[DisplayName("Create Qr Code From"), Column("CreateQRCodeFrom"), NotNull]
        //[NotMapped]
        //public String CreateQrCodeFrom
        //{
        //    get => fields.CreateQrCodeFrom[this];
        //    set => fields.CreateQrCodeFrom[this] = value;
        //}

        //[DisplayName("Price Mode"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.PriceModeDocumentEnum]? PriceMode
        //{
        //    get => fields.PriceMode[this];
        //    set => fields.PriceMode[this] = value;
        //}

        //[DisplayName("Down Payment Trasaction Id"), Column("DownPaymentTrasactionID"), NotNull]
        //[NotMapped]
        //public String DownPaymentTrasactionId
        //{
        //    get => fields.DownPaymentTrasactionId[this];
        //    set => fields.DownPaymentTrasactionId[this] = value;
        //}

        //[DisplayName("Revision"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String Revision
        //{
        //    get => fields.Revision[this];
        //    set => fields.Revision[this] = value;
        //}

        //[DisplayName("Original Ref No"), NotNull]
        //[NotMapped]
        //public String OriginalRefNo
        //{
        //    get => fields.OriginalRefNo[this];
        //    set => fields.OriginalRefNo[this] = value;
        //}

        //[DisplayName("Original Ref Date"), NotNull]
        //[NotMapped]
        //public DateTime OriginalRefDate
        //{
        //    get => fields.OriginalRefDate[this];
        //    set => fields.OriginalRefDate[this] = value;
        //}

        //[DisplayName("Gst Transaction Type"), Column("GSTTransactionType"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.GSTTransactionTypeEnum]? GstTransactionType
        //{
        //    get => fields.GstTransactionType[this];
        //    set => fields.GstTransactionType[this] = value;
        //}

        //[DisplayName("Original Credit Or Debit No"), NotNull]
        //[NotMapped]
        //public String OriginalCreditOrDebitNo
        //{
        //    get => fields.OriginalCreditOrDebitNo[this];
        //    set => fields.OriginalCreditOrDebitNo[this] = value;
        //}

        //[DisplayName("Original Credit Or Debit Date"), NotNull]
        //[NotMapped]
        //public DateTime OriginalCreditOrDebitDate
        //{
        //    get => fields.OriginalCreditOrDebitDate[this];
        //    set => fields.OriginalCreditOrDebitDate[this] = value;
        //}

        //[DisplayName("E Commerce Operator"), NotNull]
        //[NotMapped]
        //public String ECommerceOperator
        //{
        //    get => fields.ECommerceOperator[this];
        //    set => fields.ECommerceOperator[this] = value;
        //}

        //[DisplayName("E Commerce Gstin"), Column("ECommerceGSTIN"), NotNull]
        //[NotMapped]
        //public String ECommerceGstin
        //{
        //    get => fields.ECommerceGstin[this];
        //    set => fields.ECommerceGstin[this] = value;
        //}

        //[DisplayName("Tax Invoice No"), NotNull]
        //[NotMapped]
        //public String TaxInvoiceNo
        //{
        //    get => fields.TaxInvoiceNo[this];
        //    set => fields.TaxInvoiceNo[this] = value;
        //}

        //[DisplayName("Tax Invoice Date"), NotNull]
        //[NotMapped]
        //public DateTime TaxInvoiceDate
        //{
        //    get => fields.TaxInvoiceDate[this];
        //    set => fields.TaxInvoiceDate[this] = value;
        //}

        //[DisplayName("Ship From"), NotNull]
        //[NotMapped]
        //public String ShipFrom
        //{
        //    get => fields.ShipFrom[this];
        //    set => fields.ShipFrom[this] = value;
        //}

        //[DisplayName("Commission Trade"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.CommissionTradeTypeEnum]? CommissionTrade
        //{
        //    get => fields.CommissionTrade[this];
        //    set => fields.CommissionTrade[this] = value;
        //}

        //[DisplayName("Commission Trade Return"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String CommissionTradeReturn
        //{
        //    get => fields.CommissionTradeReturn[this];
        //    set => fields.CommissionTradeReturn[this] = value;
        //}

        //[DisplayName("Use Bill To Addr To Determine Tax"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String UseBillToAddrToDetermineTax
        //{
        //    get => fields.UseBillToAddrToDetermineTax[this];
        //    set => fields.UseBillToAddrToDetermineTax[this] = value;
        //}

        //[DisplayName("Issuing Reason"), NotNull]
        //[NotMapped]
        //public Int32? IssuingReason
        //{
        //    get => fields.IssuingReason[this];
        //    set => fields.IssuingReason[this] = value;
        //}

        //[DisplayName("Cig"), NotNull]
        //[NotMapped]
        //public Int32? Cig
        //{
        //    get => fields.Cig[this];
        //    set => fields.Cig[this] = value;
        //}

        //[DisplayName("Cup"), NotNull]
        //[NotMapped]
        //public Int32? Cup
        //{
        //    get => fields.Cup[this];
        //    set => fields.Cup[this] = value;
        //}

        //[DisplayName("E Doc Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.EDocTypeEnum]? EDocType
        //{
        //    get => fields.EDocType[this];
        //    set => fields.EDocType[this] = value;
        //}

        //[DisplayName("Paid To Date"), NotNull]
        //[NotMapped]
        //public decimal? PaidToDate
        //{
        //    get => fields.PaidToDate[this];
        //    set => fields.PaidToDate[this] = value;
        //}

        //[DisplayName("Paid To Date Fc"), Column("PaidToDateFC"), NotNull]
        //[NotMapped]
        //public decimal? PaidToDateFc
        //{
        //    get => fields.PaidToDateFc[this];
        //    set => fields.PaidToDateFc[this] = value;
        //}

        //[DisplayName("Paid To Date Sys"), NotNull]
        //[NotMapped]
        //public decimal? PaidToDateSys
        //{
        //    get => fields.PaidToDateSys[this];
        //    set => fields.PaidToDateSys[this] = value;
        //}

        //[DisplayName("Father Card"), NotNull]
        //[NotMapped]
        //public String FatherCard
        //{
        //    get => fields.FatherCard[this];
        //    set => fields.FatherCard[this] = value;
        //}

        //[DisplayName("Father Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoFatherCardTypes]? FatherType
        //{
        //    get => fields.FatherType[this];
        //    set => fields.FatherType[this] = value;
        //}

        //[DisplayName("Ship State"), NotNull]
        //[NotMapped]
        //public String ShipState
        //{
        //    get => fields.ShipState[this];
        //    set => fields.ShipState[this] = value;
        //}

        //[DisplayName("Ship Place"), NotNull]
        //[NotMapped]
        //public String ShipPlace
        //{
        //    get => fields.ShipPlace[this];
        //    set => fields.ShipPlace[this] = value;
        //}

        //[DisplayName("Cust Office"), NotNull]
        //[NotMapped]
        //public String CustOffice
        //{
        //    get => fields.CustOffice[this];
        //    set => fields.CustOffice[this] = value;
        //}

        //[DisplayName("Fci"), Column("FCI"), NotNull]
        //[NotMapped]
        //public String Fci
        //{
        //    get => fields.Fci[this];
        //    set => fields.Fci[this] = value;
        //}

        //[DisplayName("Add Leg In"), NotNull]
        //[NotMapped]
        //public String AddLegIn
        //{
        //    get => fields.AddLegIn[this];
        //    set => fields.AddLegIn[this] = value;
        //}

        //[DisplayName("Leg Text F"), NotNull]
        //[NotMapped]
        //public Int32? LegTextF
        //{
        //    get => fields.LegTextF[this];
        //    set => fields.LegTextF[this] = value;
        //}

        //[DisplayName("Danfe Lg Txt"), Column("DANFELgTxt"), NotNull]
        //[NotMapped]
        //public String DanfeLgTxt
        //{
        //    get => fields.DanfeLgTxt[this];
        //    set => fields.DanfeLgTxt[this] = value;
        //}

        //[DisplayName("Data Version"), NotNull]
        //[NotMapped]
        //public Int32? DataVersion
        //{
        //    get => fields.DataVersion[this];
        //    set => fields.DataVersion[this] = value;
        //}
        //[DisplayName("Document Approval Requests"), Column("Document_ApprovalRequests"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document_ApprovalRequest]? DocumentApprovalRequests
        //{
        //    get => fields.DocumentApprovalRequests[this];
        //    set => fields.DocumentApprovalRequests[this] = value;
        //}


        //[DisplayName("E Way Bill Details"), NotNull]
        //[NotMapped]
        //public SAPB1.EWayBillDetails? EWayBillDetails
        //{
        //    get => fields.EWayBillDetails[this];
        //    set => fields.EWayBillDetails[this] = value;
        //}

        //[DisplayName("Electronic Protocols"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ElectronicProtocol]? ElectronicProtocols
        //{
        //    get => fields.ElectronicProtocols[this];
        //    set => fields.ElectronicProtocols[this] = value;
        //}

        //[DisplayName("Document Distributed Expenses"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentDistributedExpense]? DocumentDistributedExpenses
        //{
        //    get => fields.DocumentDistributedExpenses[this];
        //    set => fields.DocumentDistributedExpenses[this] = value;
        //}

        //[DisplayName("Withholding Tax Data Wtx Collection"), Column("WithholdingTaxDataWTXCollection"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxDataWTX]? WithholdingTaxDataWtxCollection
        //{
        //    get => fields.WithholdingTaxDataWtxCollection[this];
        //    set => fields.WithholdingTaxDataWtxCollection[this] = value;
        //}

        //[DisplayName("Withholding Tax Data Collection"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxData]? WithholdingTaxDataCollection
        //{
        //    get => fields.WithholdingTaxDataCollection[this];
        //    set => fields.WithholdingTaxDataCollection[this] = value;
        //}

        //[DisplayName("Document Packages"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentPackage]? DocumentPackages
        //{
        //    get => fields.DocumentPackages[this];
        //    set => fields.DocumentPackages[this] = value;
        //}

        //[DisplayName("Document Special Lines"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentSpecialLine]? DocumentSpecialLines
        //{
        //    get => fields.DocumentSpecialLines[this];
        //    set => fields.DocumentSpecialLines[this] = value;
        //}

        //[DisplayName("Document Installments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentInstallment]? DocumentInstallments
        //{
        //    get => fields.DocumentInstallments[this];
        //    set => fields.DocumentInstallments[this] = value;
        //}

        //[DisplayName("Down Payments To Draw"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DownPaymentToDraw]? DownPaymentsToDraw
        //{
        //    get => fields.DownPaymentsToDraw[this];
        //    set => fields.DownPaymentsToDraw[this] = value;
        //}

        //[DisplayName("Tax Extension"), NotNull]
        //[NotMapped]
        //public SAPB1.TaxExtension? TaxExtension
        //{
        //    get => fields.TaxExtension[this];
        //    set => fields.TaxExtension[this] = value;
        //}

        //[DisplayName("Address Extension"), NotNull]
        //[NotMapped]
        //public SAPB1.AddressExtension? AddressExtension
        //{
        //    get => fields.AddressExtension[this];
        //    set => fields.AddressExtension[this] = value;
        //}

        //[DisplayName("Document References"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentReference]? DocumentReferences
        //{
        //    get => fields.DocumentReferences[this];
        //    set => fields.DocumentReferences[this] = value;
        //}

        //[DisplayName("Base Type"), NotNull]
        //[NotMapped]
        //public Int32? BaseType
        //{
        //    get => fields.BaseType[this];
        //    set => fields.BaseType[this] = value;
        //}

        //[DisplayName("Base Entry"), NotNull]
        //[NotMapped]
        //public Int32? BaseEntry
        //{
        //    get => fields.BaseEntry[this];
        //    set => fields.BaseEntry[this] = value;
        //}

        //[DisplayName("Ind Final"), NotNull, YesOrNoEditor]
        //[NotMapped]
        //public String IndFinal
        //{
        //    get => fields.IndFinal[this];
        //    set => fields.IndFinal[this] = value;
        //}

        //[DisplayName("Soi Wizard Id"), Column("SOIWizardId"), NotNull]
        //[NotMapped]
        //public Int32? SoiWizardId
        //{
        //    get => fields.SoiWizardId[this];
        //    set => fields.SoiWizardId[this] = value;
        //}

        //[DisplayName("Business Partner"), NotNull]
        //[NotMapped]
        //public SAPB1.BusinessPartner? BusinessPartner
        //{
        //    get => fields.BusinessPartner[this];
        //    set => fields.BusinessPartner[this] = value;
        //}

        //[DisplayName("Currency"), NotNull]
        //[NotMapped]
        //public SAPB1.Currency? Currency
        //{
        //    get => fields.Currency[this];
        //    set => fields.Currency[this] = value;
        //}

        //[DisplayName("Payment Terms Type"), NotNull]
        //[NotMapped]
        //public SAPB1.PaymentTermsType? PaymentTermsType
        //{
        //    get => fields.PaymentTermsType[this];
        //    set => fields.PaymentTermsType[this] = value;
        //}

        //[DisplayName("Sales Person"), NotNull]
        //[NotMapped]
        //public SAPB1.SalesPerson? SalesPerson
        //{
        //    get => fields.SalesPerson[this];
        //    set => fields.SalesPerson[this] = value;
        //}

        //[DisplayName("Shipping Type"), NotNull]
        //[NotMapped]
        //public SAPB1.ShippingType? ShippingType
        //{
        //    get => fields.ShippingType[this];
        //    set => fields.ShippingType[this] = value;
        //}

        //[DisplayName("Landed Cost"), NotNull]
        //[NotMapped]
        //public System.Collections.Generic.List<LandedCost> LandedCost
        //{
        //    get => fields.LandedCost[this];
        //    set => fields.LandedCost[this] = value;
        //}

        //[DisplayName("Factoring Indicator"), NotNull]
        //[NotMapped]
        //public SAPB1.FactoringIndicator? FactoringIndicator
        //{
        //    get => fields.FactoringIndicator[this];
        //    set => fields.FactoringIndicator[this] = value;
        //}

        //[DisplayName("User"), NotNull]
        //[NotMapped]
        //public SAPB1.User? User
        //{
        //    get => fields.User[this];
        //    set => fields.User[this] = value;
        //}

        //[DisplayName("Journal Entry"), NotNull]
        //[NotMapped]
        //public SAPB1.JournalEntry? JournalEntry
        //{
        //    get => fields.JournalEntry[this];
        //    set => fields.JournalEntry[this] = value;
        //}

        //[DisplayName("Forms1099"), NotNull]
        //[NotMapped]
        //public SAPB1.Forms1099? Forms1099
        //{
        //    get => fields.Forms1099[this];
        //    set => fields.Forms1099[this] = value;
        //}

        //[DisplayName("Wizard Payment Method"), NotNull]
        //[NotMapped]
        //public SAPB1.WizardPaymentMethod? WizardPaymentMethod
        //{
        //    get => fields.WizardPaymentMethod[this];
        //    set => fields.WizardPaymentMethod[this] = value;
        //}

        //[DisplayName("Payment Block2"), NotNull]
        //[NotMapped]
        //public SAPB1.PaymentBlock? PaymentBlock2
        //{
        //    get => fields.PaymentBlock2[this];
        //    set => fields.PaymentBlock2[this] = value;
        //}

        //[DisplayName("Project2"), NotNull]
        //[NotMapped]
        //public SAPB1.Project? Project2
        //{
        //    get => fields.Project2[this];
        //    set => fields.Project2[this] = value;
        //}

        //[DisplayName("Employee Info"), NotNull]
        //[NotMapped]
        //public SAPB1.EmployeeInfo? EmployeeInfo
        //{
        //    get => fields.EmployeeInfo[this];
        //    set => fields.EmployeeInfo[this] = value;
        //}

        //[DisplayName("Country"), NotNull]
        //[NotMapped]
        //public SAPB1.Country? Country
        //{
        //    get => fields.Country[this];
        //    set => fields.Country[this] = value;
        //}

        //[DisplayName("Business Place"), NotNull]
        //[NotMapped]
        //public SAPB1.BusinessPlace? BusinessPlace
        //{
        //    get => fields.BusinessPlace[this];
        //    set => fields.BusinessPlace[this] = value;
        //}

        //[DisplayName("User Language"), NotNull]
        //[NotMapped]
        //public SAPB1.UserLanguage? UserLanguage
        //{
        //    get => fields.UserLanguage[this];
        //    set => fields.UserLanguage[this] = value;
        //}

        //[DisplayName("Nf Model"), Column("NFModel"), NotNull]
        //[NotMapped]
        //public SAPB1.NFModel? NfModel
        //{
        //    get => fields.NfModel[this];
        //    set => fields.NfModel[this] = value;
        //}

        //[DisplayName("Chart Of Account"), NotNull]
        //[NotMapped]
        //public SAPB1.ChartOfAccount? ChartOfAccount
        //{
        //    get => fields.ChartOfAccount[this];
        //    set => fields.ChartOfAccount[this] = value;
        //}

        //[DisplayName("Tax Web Site"), NotNull]
        //[NotMapped]
        //public SAPB1.TaxWebSite? TaxWebSite
        //{
        //    get => fields.TaxWebSite[this];
        //    set => fields.TaxWebSite[this] = value;
        //}

        //[DisplayName("Branch"), NotNull]
        //[NotMapped]
        //public SAPB1.Branch? Branch
        //{
        //    get => fields.Branch[this];
        //    set => fields.Branch[this] = value;
        //}

        //[DisplayName("Department"), NotNull]
        //[NotMapped]
        //public SAPB1.Department? Department
        //{
        //    get => fields.Department[this];
        //    set => fields.Department[this] = value;
        //}

        //[DisplayName("Pos Daily Summary"), Column("POSDailySummary"), NotNull]
        //[NotMapped]
        //public SAPB1.POSDailySummary? PosDailySummary
        //{
        //    get => fields.PosDailySummary[this];
        //    set => fields.PosDailySummary[this] = value;
        //}

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
            public DateTimeField DocDate;
            public DateTimeField DocDueDate;
            public StringField CardCode;
            public StringField CardName;
            public StringField U_FullfilmentId;
            public DecimalField DocTotal;
            public DecimalField VatSum;
            public Int32Field SalesPersonCode;
            public StringField AttachmentEntry;
            public DecimalField DiscountPercent;
            public Int32Field DocumentsOwner;
            public StringField DocumentStatus;
            public StringField DocCurrency;
            public DecimalField TotalDiscount;
            public Int32Field UserSign;
            public StringField Comments;
            public StringField Project;
            public Int32Field GroupNumber;
            public StringField PayToCode;
            public StringField ShipToCode;
            public StringField U_Address;
            public StringField NumAtCard;
            public StringField DocObjectCode;
            public StringField DBName;
            public RowListField<DocumentLineRow> DocumentLines;
            public StringField U_OrderNumber;
            public StringField U_CanceledAt;
            public StringField U_PaymentMethod;
            public StringField U_ShopifyOrderId;
            public StringField U_dosource;
            public StringField U_TID;
            public StringField U_ApprovalGUID;
            //public RowListField<DocumentAdditionalExpenseRow> DocumentAdditionalExpenses;
            //public DecimalField DocTotalFc;
            //public StringField HandWritten;
            //public StringField Printed;
            //public DecimalField DocRate;
            //public StringField Reference1;
            //public StringField Reference2;
            //public StringField JournalMemo;
            //public Int32Field PaymentGroupCode;
            //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]Field DocTime;
            //public Int32Field TransportationCode;
            //public StringField Confirmed;
            //public Int32Field ImportFileNum;
            //public System.Nullable`1[SAPB1.BoDocSummaryTypes]Field SummeryType;
            //public Int32Field ContactPersonCode;
            //public StringField ShowScn;
            //public DateTimeField TaxDate;
            //public StringField PartialSupply;
            //public StringField Indicator;
            //public StringField FederalTaxId;
            //public StringField PaymentReference;
            //public DateTimeField CreationDate;
            //public DateTimeField UpdateDate;
            //public Int32Field FinancialPeriod;
            //public Int32Field TransNum;
            //public DecimalField VatSumSys;
            //public DecimalField VatSumFc;
            //public StringField NetProcedure;
            //public DecimalField DocTotalSys;
            //public Int32Field Form1099;
            //public StringField Box1099;
            //public StringField RevisionPo;
            //public DateTimeField RequriedDate;
            //public DateTimeField CancelDate;
            //public StringField BlockDunning;
            //public StringField Submitted;
            //public Int32Field Segment;
            //public StringField PickStatus;
            //public StringField Pick;
            //public StringField PaymentMethod;
            //public StringField PaymentBlock;
            //public Int32Field PaymentBlockEntry;
            //public StringField CentralBankIndicator;
            //public StringField MaximumCashDiscount;
            //public StringField Reserve;
            //public DateTimeField ExemptionValidityDateFrom;
            //public DateTimeField ExemptionValidityDateTo;
            //public System.Nullable`1[SAPB1.BoDocWhsUpdateTypes]Field WareHouseUpdateType;
            //public StringField Rounding;
            //public StringField ExternalCorrectedDocNum;
            //public Int32Field InternalCorrectedDocNum;
            //public Int32Field NextCorrectingDocument;
            //public StringField DeferredTax;
            //public StringField TaxExemptionLetterNum;
            //public DecimalField WtApplied;
            //public DecimalField WtAppliedFc;
            //public StringField BillOfExchangeReserved;
            //public StringField AgentCode;
            //public DecimalField WtAppliedSc;
            //public DecimalField TotalEqualizationTax;
            //public DecimalField TotalEqualizationTaxFc;
            //public DecimalField TotalEqualizationTaxSc;
            //public Int32Field NumberOfInstallments;
            //public StringField ApplyTaxOnFirstInstallment;
            //public DecimalField WtNonSubjectAmount;
            //public DecimalField WtNonSubjectAmountSc;
            //public DecimalField WtNonSubjectAmountFc;
            //public DecimalField WtExemptedAmount;
            //public DecimalField WtExemptedAmountSc;
            //public DecimalField WtExemptedAmountFc;
            //public DecimalField BaseAmount;
            //public DecimalField BaseAmountSc;
            //public DecimalField BaseAmountFc;
            //public DecimalField WtAmount;
            //public DecimalField WtAmountSc;
            //public DecimalField WtAmountFc;
            //public DateTimeField VatDate;
            //public StringField FolioPrefixString;
            //public Int32Field FolioNumber;
            //public System.Nullable`1[SAPB1.BoDocumentSubType]Field DocumentSubType;
            //public StringField BpChannelCode;
            //public Int32Field BpChannelContact;
            //public StringField Address2;
            //public StringField PeriodIndicator;
            //public StringField ManualNumber;
            //public StringField UseShpdGoodsAct;
            //public StringField IsPayToBank;
            //public StringField PayToBankCountry;
            //public StringField PayToBankCode;
            //public StringField PayToBankAccountNo;
            //public StringField PayToBankBranch;
            //public Int32Field BplIdAssignedToInvoice;
            //public DecimalField DownPayment;
            //public StringField ReserveInvoice;
            //public Int32Field LanguageCode;
            //public StringField TrackingNumber;
            //public StringField PickRemark;
            //public DateTimeField ClosingDate;
            //public Int32Field SequenceCode;
            //public Int32Field SequenceSerial;
            //public StringField SeriesString;
            //public StringField SubSeriesString;
            //public StringField SequenceModel;
            //public StringField UseCorrectionVatGroup;
            ////public DecimalField DownPaymentAmount;
            ////public DecimalField DownPaymentPercentage;
            ////public System.Nullable`1[SAPB1.DownPaymentTypeEnum]Field DownPaymentType;
            ////public DecimalField DownPaymentAmountSc;
            ////public DecimalField DownPaymentAmountFc;
            //public DecimalField VatPercent;
            ////public DecimalField ServiceGrossProfitPercent;
            //public StringField OpeningRemarks;
            //public StringField ClosingRemarks;
            //public DecimalField RoundingDiffAmount;
            //public DecimalField RoundingDiffAmountFc;
            //public DecimalField RoundingDiffAmountSc;
            //public StringField Cancelled;
            //public StringField SignatureInputMessage;
            //public StringField SignatureDigest;
            //public StringField CertificationNumber;
            //public Int32Field PrivateKeyVersion;
            //public StringField ControlAccount;
            //public StringField InsuranceOperation347;
            //public StringField ArchiveNonremovableSalesQuotation;
            //public Int32Field GtsChecker;
            //public Int32Field GtsPayee;
            //public Int32Field ExtraMonth;
            //public Int32Field ExtraDays;
            //public Int32Field CashDiscountDateOffset;
            //public System.Nullable`1[SAPB1.BoPayTermDueTypes]Field StartFrom;
            //public StringField NtsApproved;
            //public Int32Field ETaxWebSite;
            //public StringField ETaxNumber;
            //public StringField NtsApprovedNumber;
            //public System.Nullable`1[SAPB1.EDocGenerationTypeEnum]Field EDocGenerationType;
            //public Int32Field EDocSeries;
            //public StringField EDocNum;
            //public Int32Field EDocExportFormat;
            //public System.Nullable`1[SAPB1.EDocStatusEnum]Field EDocStatus;
            //public StringField EDocErrorCode;
            //public StringField EDocErrorMessage;
            //public System.Nullable`1[SAPB1.BoSoStatus]Field DownPaymentStatus;
            //public Int32Field GroupSeries;
            //public StringField GroupHandWritten;
            //public StringField ReopenOriginalDocument;
            //public StringField ReopenManuallyClosedOrCanceledDocument;
            //public StringField CreateOnlineQuotation;
            //public StringField PosEquipmentNumber;
            //public StringField PosManufacturerSerialNumber;
            //public Int32Field PosCashierNumber;
            //public StringField ApplyCurrentVatRatesForDownPaymentsToDraw;
            //public System.Nullable`1[SAPB1.ClosingOptionEnum]Field ClosingOption;
            //public DateTimeField SpecifiedClosingDate;
            //public StringField OpenForLandedCosts;
            //public System.Nullable`1[SAPB1.DocumentAuthorizationStatusEnum]Field AuthorizationStatus;
            //public DecimalField TotalDiscountFc;
            //public DecimalField TotalDiscountSc;
            //public StringField RelevantToGts;
            //public StringField BplName;
            //public StringField VatRegNum;
            //public Int32Field AnnualInvoiceDeclarationReference;
            //public StringField Supplier;
            //public Int32Field Releaser;
            //public Int32Field Receiver;
            //public Int32Field BlanketAgreementNumber;
            //public StringField IsAlteration;
            //public System.Nullable`1[SAPB1.CancelStatusEnum]Field CancelStatus;
            //public DateTimeField AssetValueDate;
            //public StringField Requester;
            //public StringField RequesterName;
            //public Int32Field RequesterBranch;
            //public Int32Field RequesterDepartment;
            //public StringField RequesterEmail;
            //public StringField SendNotification;
            //public Int32Field ReqType;
            //public StringField InvoicePayment;
            //public System.Nullable`1[SAPB1.DocumentDeliveryTypeEnum]Field DocumentDelivery;
            //public StringField AuthorizationCode;
            //public DateTimeField StartDeliveryDate;
            //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]Field StartDeliveryTime;
            //public DateTimeField EndDeliveryDate;
            //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]Field EndDeliveryTime;
            //public StringField VehiclePlate;
            //public StringField AtDocumentType;
            //public System.Nullable`1[SAPB1.ElecCommStatusEnum]Field ElecCommStatus;
            //public StringField ElecCommMessage;
            //public StringField ReuseDocumentNum;
            //public StringField ReuseNotaFiscalNum;
            //public StringField PrintSepaDirect;
            //public StringField FiscalDocNum;
            //public Int32Field PosDailySummaryNo;
            //public Int32Field PosReceiptNo;
            //public StringField PointOfIssueCode;
            //public System.Nullable`1[SAPB1.FolioLetterEnum]Field Letter;
            //public Int32Field FolioNumberFrom;
            //public Int32Field FolioNumberTo;
            //public System.Nullable`1[SAPB1.BoInterimDocTypes]Field InterimType;
            //public Int32Field RelatedType;
            //public Int32Field RelatedEntry;
            //public StringField SapPassport;
            //public StringField DocumentTaxId;
            //public DateTimeField DateOfReportingControlStatementVat;
            //public StringField ReportingSectionControlStatementVat;
            //public StringField ExcludeFromTaxReportControlStatementVat;
            //public Int32Field PosCashRegister;
            //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]Field UpdateTime;
            //public StringField CreateQrCodeFrom;
            //public System.Nullable`1[SAPB1.PriceModeDocumentEnum]Field PriceMode;
            //public StringField DownPaymentTrasactionId;
            //public StringField Revision;
            //public StringField OriginalRefNo;
            //public DateTimeField OriginalRefDate;
            //public System.Nullable`1[SAPB1.GSTTransactionTypeEnum]Field GstTransactionType;
            //public StringField OriginalCreditOrDebitNo;
            //public DateTimeField OriginalCreditOrDebitDate;
            //public StringField ECommerceOperator;
            //public StringField ECommerceGstin;
            //public StringField TaxInvoiceNo;
            //public DateTimeField TaxInvoiceDate;
            //public StringField ShipFrom;
            //public System.Nullable`1[SAPB1.CommissionTradeTypeEnum]Field CommissionTrade;
            //public StringField CommissionTradeReturn;
            //public StringField UseBillToAddrToDetermineTax;
            //public Int32Field IssuingReason;
            //public Int32Field Cig;
            //public Int32Field Cup;
            //public System.Nullable`1[SAPB1.EDocTypeEnum]Field EDocType;
            //public DecimalField PaidToDate;
            //public DecimalField PaidToDateFc;
            //public DecimalField PaidToDateSys;
            //public StringField FatherCard;
            //public System.Nullable`1[SAPB1.BoFatherCardTypes]Field FatherType;
            //public StringField ShipState;
            //public StringField ShipPlace;
            //public StringField CustOffice;
            //public StringField Fci;
            //public StringField AddLegIn;
            //public Int32Field LegTextF;
            //public StringField DanfeLgTxt;
            //public Int32Field DataVersion;

            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document_ApprovalRequest]Field DocumentApprovalRequests;

            //public SAPB1.EWayBillDetailsField EWayBillDetails;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ElectronicProtocol]Field ElectronicProtocols;

            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentDistributedExpense]Field DocumentDistributedExpenses;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxDataWTX]Field WithholdingTaxDataWtxCollection;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxData]Field WithholdingTaxDataCollection;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentPackage]Field DocumentPackages;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentSpecialLine]Field DocumentSpecialLines;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentInstallment]Field DocumentInstallments;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DownPaymentToDraw]Field DownPaymentsToDraw;
            //public SAPB1.TaxExtensionField TaxExtension;
            //public SAPB1.AddressExtensionField AddressExtension;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentReference]Field DocumentReferences;
            //public Int32Field BaseType;
            //public Int32Field BaseEntry;
            //public StringField IndFinal;
            //public Int32Field SoiWizardId;
            //public SAPB1.BusinessPartnerField BusinessPartner;
            //public SAPB1.CurrencyField Currency;
            //public SAPB1.PaymentTermsTypeField PaymentTermsType;
            //public SAPB1.SalesPersonField SalesPerson;
            //public SAPB1.ShippingTypeField ShippingType;
            //public SAPB1.LandedCostField LandedCost;
            //public SAPB1.FactoringIndicatorField FactoringIndicator;
            //public SAPB1.UserField User;
            //public SAPB1.JournalEntryField JournalEntry;
            //public SAPB1.Forms1099Field Forms1099;
            //public SAPB1.WizardPaymentMethodField WizardPaymentMethod;
            //public SAPB1.PaymentBlockField PaymentBlock2;
            //public SAPB1.ProjectField Project2;
            //public SAPB1.EmployeeInfoField EmployeeInfo;
            //public SAPB1.CountryField Country;
            //public SAPB1.BusinessPlaceField BusinessPlace;
            //public SAPB1.UserLanguageField UserLanguage;
            //public SAPB1.NFModelField NfModel;
            //public SAPB1.ChartOfAccountField ChartOfAccount;
            //public SAPB1.TaxWebSiteField TaxWebSite;
            //public SAPB1.BranchField Branch;
            //public SAPB1.DepartmentField Department;
            //public SAPB1.POSDailySummaryField PosDailySummary;
        }
    }
}