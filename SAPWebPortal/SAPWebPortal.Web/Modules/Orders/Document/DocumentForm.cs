using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using SAPWebPortal.OrdersLine;
using SAPWebPortal.Default;
using SAPWebPortal.OrdersExpense;
using Serenity.Data.Mapping;

namespace SAPWebPortal.Orders.Forms
{
    [FormScript("Orders.Document")]
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
        [HalfWidth,Hidden]
        public string DBName { get; set; }
        [HalfWidth, ReadOnly(true)]
        public string CardName { get; set; }
        [HalfWidth]
        public string DocCurrency { get; set; }
        [HalfWidth,DefaultValue("Now")]
        public DateTime DocDate { get; set; }
        [HalfWidth]
        public string NumAtCard { get; set; }
        [HalfWidth]
        public DateTime DocDueDate { get; set; }
       
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
        public decimal DiscountPercent { get; set; }
        [MediumThirdLargeQuarterWidth]
        public decimal TotalDiscount { get; set; }
        [HalfWidth]
        public decimal VatSum { get; set; }
        [HalfWidth]
        public decimal DocTotal { get; set; }
        [HalfWidth, Visible(false)]
        public Int32 UserSign { get; set; }
        [TextAreaEditor, NotNull]
        public string Comments { get; set; }
        [Tab("Accounting")]
        [HalfWidth, ReadOnly(true)]
        public string GroupNum  { get; set; }
        [HalfWidth]
        public string Project { get; set; }
        [Tab("Logistic")]
        public string PayToCode { get; set; }
        public string ShipToCode { get; set; }
        [FullWidth]
        public string U_Address { get; set; }


        [Tab("Attachment")]
        [DisplayName("Attachment"), HalfWidth,FileUploadEditor]
        public string AttachmentEntry { get; set; }




        //public decimal DocRate { get; set; }
        //public string HandWritten { get; set; }
        //public System.Nullable`1[SAPB1.PrintStatusEnum] Printed { get; set; }
        //public string Reference1 { get; set; }
        //public string Reference2 { get; set; }
        //public string JournalMemo { get; set; }
        //public Int32 PaymentGroupCode { get; set; }
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay] DocTime { get; set; }
        //public Int32 TransportationCode { get; set; }
        //public String Confirmed { get; set; }
        //public Int32 ImportFileNum { get; set; }
        //public System.Nullable`1[SAPB1.BoDocSummaryTypes] SummeryType { get; set; }
        //public Int32 ContactPersonCode { get; set; }
        //public String ShowScn { get; set; }
        //public DateTime TaxDate { get; set; }
        //public String PartialSupply { get; set; }
        //public System.Nullable`1[SAPB1.BoObjectTypes] DocObjectCode { get; set; }
        //public string Indicator { get; set; }
        //public string FederalTaxId { get; set; }
        //public string PaymentReference { get; set; }
        //public DateTime CreationDate { get; set; }
        //public DateTime UpdateDate { get; set; }
        //public Int32 FinancialPeriod { get; set; }
        //public Int32 TransNum { get; set; }
        //public decimal VatSumSys { get; set; }
        //public decimal VatSumFc { get; set; }
        //public String NetProcedure { get; set; }
        //public decimal DocTotalFc { get; set; }
        //public decimal DocTotalSys { get; set; }
        //public Int32 Form1099 { get; set; }
        //public string Box1099 { get; set; }
        //public String RevisionPo { get; set; }
        //public DateTime RequriedDate { get; set; }
        //public DateTime CancelDate { get; set; }
        //public String BlockDunning { get; set; }
        //public String Submitted { get; set; }
        //public Int32 Segment { get; set; }
        //public String PickStatus { get; set; }
        //public String Pick { get; set; }
        //public string PaymentMethod { get; set; }
        //public String PaymentBlock { get; set; }
        //public Int32 PaymentBlockEntry { get; set; }
        //public string CentralBankIndicator { get; set; }
        //public String MaximumCashDiscount { get; set; }
        //public String Reserve { get; set; }

        //public DateTime ExemptionValidityDateFrom { get; set; }
        //public DateTime ExemptionValidityDateTo { get; set; }
        //public System.Nullable`1[SAPB1.BoDocWhsUpdateTypes] WareHouseUpdateType { get; set; }
        //public String Rounding { get; set; }
        //public string ExternalCorrectedDocNum { get; set; }
        //public Int32 InternalCorrectedDocNum { get; set; }
        //public Int32 NextCorrectingDocument { get; set; }
        //public String DeferredTax { get; set; }
        //public string TaxExemptionLetterNum { get; set; }
        //public decimal WtApplied { get; set; }
        //public decimal WtAppliedFc { get; set; }
        //public String BillOfExchangeReserved { get; set; }
        //public string AgentCode { get; set; }
        //public decimal WtAppliedSc { get; set; }
        //public decimal TotalEqualizationTax { get; set; }
        //public decimal TotalEqualizationTaxFc { get; set; }
        //public decimal TotalEqualizationTaxSc { get; set; }
        //public Int32 NumberOfInstallments { get; set; }
        //public String ApplyTaxOnFirstInstallment { get; set; }
        //public decimal WtNonSubjectAmount { get; set; }
        //public decimal WtNonSubjectAmountSc { get; set; }
        //public decimal WtNonSubjectAmountFc { get; set; }
        //public decimal WtExemptedAmount { get; set; }
        //public decimal WtExemptedAmountSc { get; set; }
        //public decimal WtExemptedAmountFc { get; set; }
        //public decimal BaseAmount { get; set; }
        //public decimal BaseAmountSc { get; set; }
        //public decimal BaseAmountFc { get; set; }
        //public decimal WtAmount { get; set; }
        //public decimal WtAmountSc { get; set; }
        //public decimal WtAmountFc { get; set; }
        //public DateTime VatDate { get; set; }
        //public Int32 DocumentsOwner { get; set; }
        //public string FolioPrefixString { get; set; }
        //public Int32 FolioNumber { get; set; }
        //public System.Nullable`1[SAPB1.BoDocumentSubType] DocumentSubType { get; set; }
        //public string BpChannelCode { get; set; }
        //public Int32 BpChannelContact { get; set; }
        //public string Address2 { get; set; }

        //public string PeriodIndicator { get; set; }
        //public string ManualNumber { get; set; }
        //public String UseShpdGoodsAct { get; set; }
        //public String IsPayToBank { get; set; }
        //public string PayToBankCountry { get; set; }
        //public string PayToBankCode { get; set; }
        //public string PayToBankAccountNo { get; set; }
        //public string PayToBankBranch { get; set; }
        //public Int32 BplIdAssignedToInvoice { get; set; }
        //public decimal DownPayment { get; set; }
        //public String ReserveInvoice { get; set; }
        //public Int32 LanguageCode { get; set; }
        //public string TrackingNumber { get; set; }
        //public string PickRemark { get; set; }
        //public DateTime ClosingDate { get; set; }
        //public Int32 SequenceCode { get; set; }
        //public Int32 SequenceSerial { get; set; }
        //public string SeriesString { get; set; }
        //public string SubSeriesString { get; set; }
        //public string SequenceModel { get; set; }
        //public String UseCorrectionVatGroup { get; set; }

        //public decimal DownPaymentAmount { get; set; }
        //public decimal DownPaymentPercentage { get; set; }
        //public System.Nullable`1[SAPB1.DownPaymentTypeEnum] DownPaymentType { get; set; }
        //public decimal DownPaymentAmountSc { get; set; }
        //public decimal DownPaymentAmountFc { get; set; }
        //public decimal VatPercent { get; set; }
        //public decimal ServiceGrossProfitPercent { get; set; }
        //public string OpeningRemarks { get; set; }
        //public string ClosingRemarks { get; set; }
        //public decimal RoundingDiffAmount { get; set; }
        //public decimal RoundingDiffAmountFc { get; set; }
        //public decimal RoundingDiffAmountSc { get; set; }
        //public String Cancelled { get; set; }
        //public string SignatureInputMessage { get; set; }
        //public string SignatureDigest { get; set; }
        //public string CertificationNumber { get; set; }
        //public Int32 PrivateKeyVersion { get; set; }
        //public string ControlAccount { get; set; }
        //public String InsuranceOperation347 { get; set; }
        //public String ArchiveNonremovableSalesQuotation { get; set; }
        //public Int32 GtsChecker { get; set; }
        //public Int32 GtsPayee { get; set; }
        //public Int32 ExtraMonth { get; set; }
        //public Int32 ExtraDays { get; set; }
        //public Int32 CashDiscountDateOffset { get; set; }
        //public System.Nullable`1[SAPB1.BoPayTermDueTypes] StartFrom { get; set; }
        //public String NtsApproved { get; set; }
        //public Int32 ETaxWebSite { get; set; }
        //public string ETaxNumber { get; set; }
        //public string NtsApprovedNumber { get; set; }
        //public System.Nullable`1[SAPB1.EDocGenerationTypeEnum] EDocGenerationType { get; set; }
        //public Int32 EDocSeries { get; set; }
        //public string EDocNum { get; set; }
        //public Int32 EDocExportFormat { get; set; }
        //public System.Nullable`1[SAPB1.EDocStatusEnum] EDocStatus { get; set; }
        //public string EDocErrorCode { get; set; }
        //public string EDocErrorMessage { get; set; }
        //public System.Nullable`1[SAPB1.BoSoStatus] DownPaymentStatus { get; set; }
        //public Int32 GroupSeries { get; set; }
        //public String GroupHandWritten { get; set; }
        //public String ReopenOriginalDocument { get; set; }
        //public String ReopenManuallyClosedOrCanceledDocument { get; set; }
        //public String CreateOnlineQuotation { get; set; }
        //public string PosEquipmentNumber { get; set; }
        //public string PosManufacturerSerialNumber { get; set; }
        //public Int32 PosCashierNumber { get; set; }
        //public String ApplyCurrentVatRatesForDownPaymentsToDraw { get; set; }
        //public System.Nullable`1[SAPB1.ClosingOptionEnum] ClosingOption { get; set; }
        //public DateTime SpecifiedClosingDate { get; set; }
        //public String OpenForLandedCosts { get; set; }
        //public System.Nullable`1[SAPB1.DocumentAuthorizationStatusEnum] AuthorizationStatus { get; set; }
        //public decimal TotalDiscountFc { get; set; }
        //public decimal TotalDiscountSc { get; set; }
        //public String RelevantToGts { get; set; }
        //public string BplName { get; set; }
        //public string VatRegNum { get; set; }
        //public Int32 AnnualInvoiceDeclarationReference { get; set; }
        //public string Supplier { get; set; }
        //public Int32 Releaser { get; set; }
        //public Int32 Receiver { get; set; }
        //public Int32 BlanketAgreementNumber { get; set; }
        //public String IsAlteration { get; set; }
        //public System.Nullable`1[SAPB1.CancelStatusEnum] CancelStatus { get; set; }
        //public DateTime AssetValueDate { get; set; }
        //public string Requester { get; set; }
        //public string RequesterName { get; set; }
        //public Int32 RequesterBranch { get; set; }
        //public Int32 RequesterDepartment { get; set; }
        //public string RequesterEmail { get; set; }
        //public String SendNotification { get; set; }
        //public Int32 ReqType { get; set; }
        //public String InvoicePayment { get; set; }
        //public System.Nullable`1[SAPB1.DocumentDeliveryTypeEnum] DocumentDelivery { get; set; }
        //public string AuthorizationCode { get; set; }
        //public DateTime StartDeliveryDate { get; set; }
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay] StartDeliveryTime { get; set; }
        //public DateTime EndDeliveryDate { get; set; }
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay] EndDeliveryTime { get; set; }
        //public string VehiclePlate { get; set; }
        //public string AtDocumentType { get; set; }
        //public System.Nullable`1[SAPB1.ElecCommStatusEnum] ElecCommStatus { get; set; }
        //public string ElecCommMessage { get; set; }
        //public String ReuseDocumentNum { get; set; }
        //public String ReuseNotaFiscalNum { get; set; }
        //public String PrintSepaDirect { get; set; }
        //public string FiscalDocNum { get; set; }
        //public Int32 PosDailySummaryNo { get; set; }
        //public Int32 PosReceiptNo { get; set; }
        //public string PointOfIssueCode { get; set; }
        //public System.Nullable`1[SAPB1.FolioLetterEnum] Letter { get; set; }
        //public Int32 FolioNumberFrom { get; set; }
        //public Int32 FolioNumberTo { get; set; }
        //public System.Nullable`1[SAPB1.BoInterimDocTypes] InterimType { get; set; }
        //public Int32 RelatedType { get; set; }
        //public Int32 RelatedEntry { get; set; }
        //public string SapPassport { get; set; }
        //public string DocumentTaxId { get; set; }
        //public DateTime DateOfReportingControlStatementVat { get; set; }
        //public string ReportingSectionControlStatementVat { get; set; }
        //public String ExcludeFromTaxReportControlStatementVat { get; set; }
        //public Int32 PosCashRegister { get; set; }
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay] UpdateTime { get; set; }
        //public string CreateQrCodeFrom { get; set; }
        //public System.Nullable`1[SAPB1.PriceModeDocumentEnum] PriceMode { get; set; }
        //public string DownPaymentTrasactionId { get; set; }
        //public String Revision { get; set; }
        //public string OriginalRefNo { get; set; }
        //public DateTime OriginalRefDate { get; set; }
        //public System.Nullable`1[SAPB1.GSTTransactionTypeEnum] GstTransactionType { get; set; }
        //public string OriginalCreditOrDebitNo { get; set; }
        //public DateTime OriginalCreditOrDebitDate { get; set; }
        //public string ECommerceOperator { get; set; }
        //public string ECommerceGstin { get; set; }
        //public string TaxInvoiceNo { get; set; }
        //public DateTime TaxInvoiceDate { get; set; }
        //public string ShipFrom { get; set; }
        //public System.Nullable`1[SAPB1.CommissionTradeTypeEnum] CommissionTrade { get; set; }
        //public String CommissionTradeReturn { get; set; }
        //public String UseBillToAddrToDetermineTax { get; set; }
        //public Int32 IssuingReason { get; set; }
        //public Int32 Cig { get; set; }
        //public Int32 Cup { get; set; }
        //public System.Nullable`1[SAPB1.EDocTypeEnum] EDocType { get; set; }
        //public decimal PaidToDate { get; set; }
        //public decimal PaidToDateFc { get; set; }
        //public decimal PaidToDateSys { get; set; }
        //public string FatherCard { get; set; }
        //public System.Nullable`1[SAPB1.BoFatherCardTypes] FatherType { get; set; }
        //public string ShipState { get; set; }
        //public string ShipPlace { get; set; }
        //public string CustOffice { get; set; }
        //public string Fci { get; set; }
        //public string AddLegIn { get; set; }
        //public Int32 LegTextF { get; set; }
        //public string DanfeLgTxt { get; set; }
        //public Int32 DataVersion { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document_ApprovalRequest] DocumentApprovalRequests { get; set; }

        //public SAPB1.EWayBillDetails EWayBillDetails { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ElectronicProtocol] ElectronicProtocols { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentAdditionalExpense] DocumentAdditionalExpenses { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentDistributedExpense] DocumentDistributedExpenses { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxDataWTX] WithholdingTaxDataWtxCollection { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxData] WithholdingTaxDataCollection { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentPackage] DocumentPackages { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentSpecialLine] DocumentSpecialLines { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentInstallment] DocumentInstallments { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DownPaymentToDraw] DownPaymentsToDraw { get; set; }
        //public SAPB1.TaxExtension TaxExtension { get; set; }
        //public SAPB1.AddressExtension AddressExtension { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentReference] DocumentReferences { get; set; }
        //public Int32 BaseType { get; set; }
        //public Int32 BaseEntry { get; set; }
        //public String IndFinal { get; set; }
        //public Int32 SoiWizardId { get; set; }
        //public SAPB1.BusinessPartner BusinessPartner { get; set; }
        //public SAPB1.Currency Currency { get; set; }
        //public SAPB1.PaymentTermsType PaymentTermsType { get; set; }
        //public SAPB1.SalesPerson SalesPerson { get; set; }
        //public SAPB1.ShippingType ShippingType { get; set; }
        //public SAPB1.LandedCost LandedCost { get; set; }
        //public SAPB1.FactoringIndicator FactoringIndicator { get; set; }
        //public SAPB1.User User { get; set; }
        //public SAPB1.JournalEntry JournalEntry { get; set; }
        //public SAPB1.Forms1099 Forms1099 { get; set; }
        //public SAPB1.WizardPaymentMethod WizardPaymentMethod { get; set; }
        //public SAPB1.PaymentBlock PaymentBlock2 { get; set; }
        //public SAPB1.Project Project2 { get; set; }
        //public SAPB1.EmployeeInfo EmployeeInfo { get; set; }
        //public SAPB1.Country Country { get; set; }
        //public SAPB1.BusinessPlace BusinessPlace { get; set; }
        //public SAPB1.UserLanguage UserLanguage { get; set; }
        //public SAPB1.NFModel NfModel { get; set; }
        //public SAPB1.ChartOfAccount ChartOfAccount { get; set; }
        //public SAPB1.TaxWebSite TaxWebSite { get; set; }
        //public SAPB1.Branch Branch { get; set; }
        //public SAPB1.Department Department { get; set; }
        //public SAPB1.POSDailySummary PosDailySummary { get; set; }
    }
}