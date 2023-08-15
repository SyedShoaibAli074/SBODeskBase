using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.DeliveryLine.Forms
{
    [FormScript("DeliveryLine.DocumentLine")]
    [BasedOnRow(typeof(DocumentLineRow), CheckNames = true)]
    public class DocumentLineForm
    {
        [Visible(false)]
        public Int32 LineNum { get; set; }
        [HalfWidth, Width(100)]
        public String ItemCode { get; set; }
        [HalfWidth, Width(200)]
        public String ItemDescription { get; set; }
        [Width(200)]
        public String AccountCode { get; set; }
        [HalfWidth, Width(100)]
        public decimal Quantity { get; set; }
        [HalfWidth, Width(100)]
        public decimal UnitsOfMeasurment { get; set; }
        [HalfWidth, Width(100)]
        public decimal UnitPrice { get; set; }
        [HalfWidth, Width(100)]
        public decimal DiscountPercent { get; set; }
        [HalfWidth, Width(100)]
        public String VatGroup { get; set; }
        [HalfWidth, Width(100)]
        public String WarehouseCode { get; set; }
        [HalfWidth, Width(100)]
        public String UoMCode { get; set; }
        [HalfWidth, Width(100), Visible(false)]
        public decimal PriceAfterVat { get; set; }
        [HalfWidth, Width(100)]
        public decimal TaxTotal { get; set; }
        [HalfWidth, Width(100)]
        public decimal LineTotal { get; set; }
        [HalfWidth, Width(100), Visible(false)]
        public decimal GrossTotal { get; set; }


        //public String Currency { get; set; }
        //public decimal Rate { get; set; }
        //public String VendorNum { get; set; }
        //public String SerialNum { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] ShipDate { get; set; }
        //public System.Nullable`1[System.Int32] SalesPersonCode { get; set; }
        //public decimal CommisionPercent { get; set; }
        //public System.Nullable`1[SAPB1.BoItemTreeTypes] TreeType { get; set; }
        //public String AccountCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] UseBaseUnits { get; set; }
        //public String SupplierCatNum { get; set; }
        //public String CostingCode { get; set; }
        //public String ProjectCode { get; set; }
        //public String BarCode { get; set; }
        //public String VatGroup { get; set; }
        //public decimal Height1 { get; set; }
        //public System.Nullable`1[System.Int32] Hight1Unit { get; set; }
        //public decimal Height2 { get; set; }
        //public System.Nullable`1[System.Int32] Height2Unit { get; set; }
        //public decimal Lengh1 { get; set; }
        //public System.Nullable`1[System.Int32] Lengh1Unit { get; set; }
        //public decimal Lengh2 { get; set; }
        //public System.Nullable`1[System.Int32] Lengh2Unit { get; set; }
        //public decimal Weight1 { get; set; }
        //public System.Nullable`1[System.Int32] Weight1Unit { get; set; }
        //public decimal Weight2 { get; set; }
        //public System.Nullable`1[System.Int32] Weight2Unit { get; set; }
        //public decimal Factor1 { get; set; }
        //public decimal Factor2 { get; set; }
        //public decimal Factor3 { get; set; }
        //public decimal Factor4 { get; set; }
        //public System.Nullable`1[System.Int32] BaseType { get; set; }
        //public System.Nullable`1[System.Int32] BaseEntry { get; set; }
        //public System.Nullable`1[System.Int32] BaseLine { get; set; }
        //public decimal Volume { get; set; }
        //public System.Nullable`1[System.Int32] VolumeUnit { get; set; }
        //public decimal Width1 { get; set; }
        //public System.Nullable`1[System.Int32] Width1Unit { get; set; }
        //public decimal Width2 { get; set; }
        //public System.Nullable`1[System.Int32] Width2Unit { get; set; }
        //public String Address { get; set; }
        //public String TaxCode { get; set; }
        //public System.Nullable`1[SAPB1.BoTaxTypes] TaxType { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] TaxLiable { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] PickStatus { get; set; }
        //public decimal PickQuantity { get; set; }
        //public System.Nullable`1[System.Int32] PickListIdNumber { get; set; }
        //public String OriginalItem { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] BackOrder { get; set; }
        //public String FreeText { get; set; }
        //public System.Nullable`1[System.Int32] ShippingMethod { get; set; }
        //public System.Nullable`1[System.Int32] PoTargetNum { get; set; }
        //public String PoTargetEntry { get; set; }
        //public System.Nullable`1[System.Int32] PoTargetRowNum { get; set; }
        //public System.Nullable`1[SAPB1.BoCorInvItemStatus] CorrectionInvoiceItem { get; set; }
        //public decimal CorrInvAmountToStock { get; set; }
        //public decimal CorrInvAmountToDiffAcct { get; set; }
        //public decimal AppliedTax { get; set; }
        //public decimal AppliedTaxFc { get; set; }
        //public decimal AppliedTaxSc { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] WtLiable { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DeferredTax { get; set; }
        //public decimal EqualizationTaxPercent { get; set; }
        //public decimal TotalEqualizationTax { get; set; }
        //public decimal TotalEqualizationTaxFc { get; set; }
        //public decimal TotalEqualizationTaxSc { get; set; }
        //public decimal NetTaxAmount { get; set; }
        //public decimal NetTaxAmountFc { get; set; }
        //public decimal NetTaxAmountSc { get; set; }
        //public String MeasureUnit { get; set; }
        //public decimal UnitsOfMeasurment { get; set; }
        //public decimal LineTotal { get; set; }
        //public decimal TaxPercentagePerRow { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ConsumerSalesForecast { get; set; }
        //public decimal ExciseAmount { get; set; }
        //public decimal TaxPerUnit { get; set; }
        //public decimal TotalInclTax { get; set; }
        //public String CountryOrg { get; set; }
        //public String Sww { get; set; }
        //public System.Nullable`1[SAPB1.BoTransactionTypeEnum] TransactionType { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DistributeExpense { get; set; }
        //public decimal RowTotalFc { get; set; }
        //public decimal RowTotalSc { get; set; }
        //public decimal LastBuyInmPrice { get; set; }
        //public decimal LastBuyDistributeSumFc { get; set; }
        //public decimal LastBuyDistributeSumSc { get; set; }
        //public decimal LastBuyDistributeSum { get; set; }
        //public decimal StockDistributesumForeign { get; set; }
        //public decimal StockDistributesumSystem { get; set; }
        //public decimal StockDistributesum { get; set; }
        //public decimal StockInmPrice { get; set; }
        //public System.Nullable`1[SAPB1.BoDocumentLinePickStatus] PickStatusEx { get; set; }
        //public decimal TaxBeforeDpm { get; set; }
        //public decimal TaxBeforeDpmfc { get; set; }
        //public decimal TaxBeforeDpmsc { get; set; }
        //public String CfopCode { get; set; }
        //public String CstCode { get; set; }
        //public System.Nullable`1[System.Int32] Usage { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] TaxOnly { get; set; }
        //public System.Nullable`1[System.Int32] VisualOrder { get; set; }
        //public decimal BaseOpenQuantity { get; set; }
        //public decimal UnitPrice { get; set; }
        //public System.Nullable`1[SAPB1.BoStatus] LineStatus { get; set; }
        //public decimal PackageQuantity { get; set; }
        //public String Text { get; set; }
        //public System.Nullable`1[SAPB1.BoDocLineType] LineType { get; set; }
        //public String CogsCostingCode { get; set; }
        //public String CogsAccountCode { get; set; }
        //public String ChangeAssemlyBoMWarehouse { get; set; }
        //public decimal GrossBuyPrice { get; set; }
        //public System.Nullable`1[System.Int32] GrossBase { get; set; }
        //public decimal GrossProfitTotalBasePrice { get; set; }
        //public String CostingCode2 { get; set; }
        //public String CostingCode3 { get; set; }
        //public String CostingCode4 { get; set; }
        //public String CostingCode5 { get; set; }
        //public String ItemDetails { get; set; }
        //public System.Nullable`1[System.Int32] LocationCode { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] ActualDeliveryDate { get; set; }
        //public decimal RemainingOpenQuantity { get; set; }
        //public decimal OpenAmount { get; set; }
        //public decimal OpenAmountFc { get; set; }
        //public decimal OpenAmountSc { get; set; }
        //public String ExLineNo { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] RequiredDate { get; set; }
        //public decimal RequiredQuantity { get; set; }
        //public String CogsCostingCode2 { get; set; }
        //public String CogsCostingCode3 { get; set; }
        //public String CogsCostingCode4 { get; set; }
        //public String CogsCostingCode5 { get; set; }
        //public String CsTforIpi { get; set; }
        //public String CsTforPis { get; set; }
        //public String CsTforCofins { get; set; }
        //public String CreditOriginCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] WithoutInventoryMovement { get; set; }
        //public System.Nullable`1[System.Int32] AgreementNo { get; set; }
        //public System.Nullable`1[System.Int32] AgreementRowNumber { get; set; }
        //public System.Nullable`1[System.Int32] ActualBaseEntry { get; set; }
        //public System.Nullable`1[System.Int32] ActualBaseLine { get; set; }
        //public System.Nullable`1[System.Int32] DocEntry { get; set; }
        //public decimal Surpluses { get; set; }
        //public decimal DefectAndBreakup { get; set; }
        //public decimal Shortages { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ConsiderQuantity { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] PartialRetirement { get; set; }
        //public decimal RetirementQuantity { get; set; }
        //public decimal RetirementApc { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ThirdParty { get; set; }
        //public String PoNum { get; set; }
        //public System.Nullable`1[System.Int32] PoItmNum { get; set; }
        //public String ExpenseType { get; set; }
        //public String ReceiptNumber { get; set; }
        //public System.Nullable`1[SAPB1.BoExpenseOperationTypeEnum] ExpenseOperationType { get; set; }
        //public String FederalTaxId { get; set; }
        //public decimal GrossProfit { get; set; }
        //public decimal GrossProfitFc { get; set; }
        //public decimal GrossProfitSc { get; set; }
        //public System.Nullable`1[SAPB1.DocumentPriceSourceEnum] PriceSource { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] EnableReturnCost { get; set; }
        //public decimal ReturnCost { get; set; }
        //public String LineVendor { get; set; }
        //public System.Nullable`1[System.Int32] StgSeqNum { get; set; }
        //public System.Nullable`1[System.Int32] StgEntry { get; set; }
        //public String StgDesc { get; set; }
        //public System.Nullable`1[System.Int32] UoMEntry { get; set; }
        //public String UoMCode { get; set; }
        //public decimal InventoryQuantity { get; set; }
        //public decimal RemainingOpenInventoryQuantity { get; set; }
        //public System.Nullable`1[System.Int32] ParentLineNum { get; set; }
        //public System.Nullable`1[System.Int32] Incoterms { get; set; }
        //public System.Nullable`1[System.Int32] TransportMode { get; set; }
        //public System.Nullable`1[System.Int32] NatureOfTransaction { get; set; }
        //public String DestinationCountryForImport { get; set; }
        //public System.Nullable`1[System.Int32] DestinationRegionForImport { get; set; }
        //public String OriginCountryForExport { get; set; }
        //public System.Nullable`1[System.Int32] OriginRegionForExport { get; set; }
        //public System.Nullable`1[SAPB1.BoDocItemType] ItemType { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ChangeInventoryQuantityIndependently { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] FreeOfChargeBp { get; set; }
        //public System.Nullable`1[System.Int32] SacEntry { get; set; }
        //public System.Nullable`1[System.Int32] HsnEntry { get; set; }
        //public decimal GrossPrice { get; set; }
        //public decimal GrossTotal { get; set; }
        //public decimal GrossTotalFc { get; set; }
        //public decimal GrossTotalSc { get; set; }
        //public System.Nullable`1[System.Int32] NcmCode { get; set; }
        //public String NveCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] IndEscala { get; set; }
        //public decimal CtrSealQty { get; set; }
        //public String CnjpMan { get; set; }
        //public System.Nullable`1[System.Int32] CestCode { get; set; }
        //public String UfFiscalBenefitCode { get; set; }
        //public String ShipToCode { get; set; }
        //public String ShipToDescription { get; set; }
        //public String ShipFromCode { get; set; }
        //public String ShipFromDescription { get; set; }
        //public decimal ExternalCalcTaxRate { get; set; }
        //public decimal ExternalCalcTaxAmount { get; set; }
        //public decimal ExternalCalcTaxAmountFc { get; set; }
        //public decimal ExternalCalcTaxAmountSc { get; set; }
        //public System.Nullable`1[System.Int32] StandardItemIdentification { get; set; }
        //public System.Nullable`1[System.Int32] CommodityClassification { get; set; }
        //public System.Nullable`1[System.Int32] UnencumberedReason { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] CuSplit { get; set; }
        //public System.Nullable`1[System.Int32] UItemClassId { get; set; }
        //public System.Nullable`1[System.Int32] UItemTypeId { get; set; }
        //public String UItemCode { get; set; }
        //public System.Nullable`1[System.Int32] UOctrId { get; set; }
        //public String UReason { get; set; }
        //public String UItemStatus { get; set; }
        //public String UFoc { get; set; }
        //public String UOcrCode6 { get; set; }
        //public String UOcrCode7 { get; set; }
        //public String UOcrCode8 { get; set; }
        //public String UOcrCode9 { get; set; }
        //public String UOcrCode10 { get; set; }
        //public String UOcrCode11 { get; set; }
        //public System.Nullable`1[System.Int32] ULineNo { get; set; }
        //public System.Nullable`1[System.Int32] UDocEntry { get; set; }
        //public String UComments { get; set; }
        //public decimal UTriRetAm { get; set; }
        //public String UTriBudgetkey { get; set; }
        //public String UTriOrigitem { get; set; }
        //public String UTriProjnum { get; set; }
        //public String UTriPlankey { get; set; }
        //public String UTriLinekey { get; set; }
        //public String UTriPartkey { get; set; }
        //public String UTriScartkey { get; set; }
        //public String UTriScartrem { get; set; }
        //public String UTriExtpos { get; set; }
        //public String UTriIscombined { get; set; }
        //public String UTriTimesheetkey { get; set; }
        //public decimal UTriToBook { get; set; }
        //public String UTriDocType { get; set; }
        //public System.Nullable`1[System.Int32] UTriDocEntry { get; set; }
        //public System.Nullable`1[System.Int32] UTriDocLine { get; set; }
        //public String UServiceCallNo { get; set; }
        //public String UServiceFlag { get; set; }
        //public String UIsCovered { get; set; }
        //public String UContractId { get; set; }
        //public String UInvoiceType { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] UFromDate { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] UToDate { get; set; }
        //public String UPoolCode { get; set; }
        //public String UUsedMeter { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.LineTaxJurisdiction] LineTaxJurisdictions { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GeneratedAsset] GeneratedAssets { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.EBooksDetail] EBooksDetails { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentLineAdditionalExpense] DocumentLineAdditionalExpenses { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxLine] WithholdingTaxLines { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.SerialNumber] SerialNumbers { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BatchNumber] BatchNumbers { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentLinesBinAllocation] DocumentLinesBinAllocations { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ExportProcess] ExportProcesses { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.CCDNumber] CcdNumbers { get; set; }
        //public System.Nullable`1[System.Int32] ReturnAction { get; set; }
        //public System.Nullable`1[System.Int32] ReturnReason { get; set; }
        //public System.Nullable`1[System.Int32] OwnerCode { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ImportProcess] ImportProcesses { get; set; }
    }
}