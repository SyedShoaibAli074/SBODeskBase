﻿namespace HelpersWebSL.Models
{

    public class DocumentLine
    {
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public string ShipDate { get; set; }
        public double Price { get; set; }
        public double PriceAfterVAT { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public double DiscountPercent { get; set; }
        public object VendorNum { get; set; }
        public object SerialNum { get; set; }
        public string WarehouseCode { get; set; }
        public int SalesPersonCode { get; set; }
        public double CommisionPercent { get; set; }
        public string TreeType { get; set; }
        public string AccountCode { get; set; }
        public string UseBaseUnits { get; set; }
        public object SupplierCatNum { get; set; }
        public string CostingCode { get; set; }
        public string ProjectCode { get; set; }
        public object BarCode { get; set; }
        public string VatGroup { get; set; }
        public double Height1 { get; set; }
        public int? Hight1Unit { get; set; }
        public double Height2 { get; set; }
        public object Height2Unit { get; set; }
        public double Lengh1 { get; set; }
        public int? Lengh1Unit { get; set; }
        public double Lengh2 { get; set; }
        public object Lengh2Unit { get; set; }
        public double Weight1 { get; set; }
        public int? Weight1Unit { get; set; }
        public double Weight2 { get; set; }
        public object Weight2Unit { get; set; }
        public double Factor1 { get; set; }
        public double Factor2 { get; set; }
        public double Factor3 { get; set; }
        public double Factor4 { get; set; }
        public int BaseType { get; set; }
        public int BaseEntry { get; set; }
        public int BaseLine { get; set; }
        public double Volume { get; set; }
        public int VolumeUnit { get; set; }
        public double Width1 { get; set; }
        public int? Width1Unit { get; set; }
        public double Width2 { get; set; }
        public object Width2Unit { get; set; }
        public object Address { get; set; }
        public object TaxCode { get; set; }
        public string TaxType { get; set; }
        public string TaxLiable { get; set; }
        public string PickStatus { get; set; }
        public double PickQuantity { get; set; }
        public object PickListIdNumber { get; set; }
        public object OriginalItem { get; set; }
        public string BackOrder { get; set; }
        public object FreeText { get; set; }
        public int ShippingMethod { get; set; }
        public object POTargetNum { get; set; }
        public object POTargetEntry { get; set; }
        public object POTargetRowNum { get; set; }
        public string CorrectionInvoiceItem { get; set; }
        public double CorrInvAmountToStock { get; set; }
        public double CorrInvAmountToDiffAcct { get; set; }
        public double AppliedTax { get; set; }
        public double AppliedTaxFC { get; set; }
        public double AppliedTaxSC { get; set; }
        public string WTLiable { get; set; }
        public string DeferredTax { get; set; }
        public double EqualizationTaxPercent { get; set; }
        public double TotalEqualizationTax { get; set; }
        public double TotalEqualizationTaxFC { get; set; }
        public double TotalEqualizationTaxSC { get; set; }
        public double NetTaxAmount { get; set; }
        public double NetTaxAmountFC { get; set; }
        public double NetTaxAmountSC { get; set; }
        public string MeasureUnit { get; set; }
        public double UnitsOfMeasurment { get; set; }
        public double LineTotal { get; set; }
        public double TaxPercentagePerRow { get; set; }
        public double TaxTotal { get; set; }
        public string ConsumerSalesForecast { get; set; }
        public double ExciseAmount { get; set; }
        public double TaxPerUnit { get; set; }
        public double TotalInclTax { get; set; }
        public object CountryOrg { get; set; }
        public object SWW { get; set; }
        public object TransactionType { get; set; }
        public string DistributeExpense { get; set; }
        public double RowTotalFC { get; set; }
        public double RowTotalSC { get; set; }
        public double LastBuyInmPrice { get; set; }
        public double LastBuyDistributeSumFc { get; set; }
        public double LastBuyDistributeSumSc { get; set; }
        public double LastBuyDistributeSum { get; set; }
        public double StockDistributesumForeign { get; set; }
        public double StockDistributesumSystem { get; set; }
        public double StockDistributesum { get; set; }
        public double StockInmPrice { get; set; }
        public string PickStatusEx { get; set; }
        public double TaxBeforeDPM { get; set; }
        public double TaxBeforeDPMFC { get; set; }
        public double TaxBeforeDPMSC { get; set; }
        public object CFOPCode { get; set; }
        public object CSTCode { get; set; }
        public object Usage { get; set; }
        public string TaxOnly { get; set; }
        public int VisualOrder { get; set; }
        public double BaseOpenQuantity { get; set; }
        public double UnitPrice { get; set; }
        public string LineStatus { get; set; }
        public double PackageQuantity { get; set; }
        public object Text { get; set; }
        public string LineType { get; set; }
        public object COGSCostingCode { get; set; }
        public string COGSAccountCode { get; set; }
        public string ChangeAssemlyBoMWarehouse { get; set; }
        public double GrossBuyPrice { get; set; }
        public int GrossBase { get; set; }
        public double GrossProfitTotalBasePrice { get; set; }
        public object CostingCode2 { get; set; }
        public object CostingCode3 { get; set; }
        public object CostingCode4 { get; set; }
        public object CostingCode5 { get; set; }
        public string ItemDetails { get; set; }
        public object LocationCode { get; set; }
        public string ActualDeliveryDate { get; set; }
        public double RemainingOpenQuantity { get; set; }
        public double OpenAmount { get; set; }
        public double OpenAmountFC { get; set; }
        public double OpenAmountSC { get; set; }
        public object ExLineNo { get; set; }
        public object RequiredDate { get; set; }
        public double RequiredQuantity { get; set; }
        public object COGSCostingCode2 { get; set; }
        public object COGSCostingCode3 { get; set; }
        public object COGSCostingCode4 { get; set; }
        public object COGSCostingCode5 { get; set; }
        public object CSTforIPI { get; set; }
        public object CSTforPIS { get; set; }
        public object CSTforCOFINS { get; set; }
        public object CreditOriginCode { get; set; }
        public string WithoutInventoryMovement { get; set; }
        public object AgreementNo { get; set; }
        public object AgreementRowNumber { get; set; }
        public object ActualBaseEntry { get; set; }
        public object ActualBaseLine { get; set; }
        public int DocEntry { get; set; }
        public double Surpluses { get; set; }
        public double DefectAndBreakup { get; set; }
        public double Shortages { get; set; }
        public string ConsiderQuantity { get; set; }
        public string PartialRetirement { get; set; }
        public double RetirementQuantity { get; set; }
        public double RetirementAPC { get; set; }
        public string ThirdParty { get; set; }
        public object PoNum { get; set; }
        public object PoItmNum { get; set; }
        public object ExpenseType { get; set; }
        public object ReceiptNumber { get; set; }
        public object ExpenseOperationType { get; set; }
        public object FederalTaxID { get; set; }
        public double GrossProfit { get; set; }
        public double GrossProfitFC { get; set; }
        public double GrossProfitSC { get; set; }
        public string PriceSource { get; set; }
        public object StgSeqNum { get; set; }
        public object StgEntry { get; set; }
        public object StgDesc { get; set; }
        public int UoMEntry { get; set; }
        public string UoMCode { get; set; }
        public double InventoryQuantity { get; set; }
        public double RemainingOpenInventoryQuantity { get; set; }
        public object ParentLineNum { get; set; }
        public int Incoterms { get; set; }
        public int TransportMode { get; set; }
        public object NatureOfTransaction { get; set; }
        public object DestinationCountryForImport { get; set; }
        public object DestinationRegionForImport { get; set; }
        public object OriginCountryForExport { get; set; }
        public object OriginRegionForExport { get; set; }
        public string ItemType { get; set; }
        public string ChangeInventoryQuantityIndependently { get; set; }
        public object FreeOfChargeBP { get; set; }
        public object SACEntry { get; set; }
        public object HSNEntry { get; set; }
        public double GrossPrice { get; set; }
        public double GrossTotal { get; set; }
        public double GrossTotalFC { get; set; }
        public double GrossTotalSC { get; set; }
        public int NCMCode { get; set; }
        public object NVECode { get; set; }
        public string IndEscala { get; set; }
        public object CtrSealQty { get; set; }
        public object CNJPMan { get; set; }
        public object CESTCode { get; set; }
        public object UFFiscalBenefitCode { get; set; }
        public string ShipToCode { get; set; }
        public string ShipToDescription { get; set; }
        public object ExternalCalcTaxRate { get; set; }
        public object ExternalCalcTaxAmount { get; set; }
        public object ExternalCalcTaxAmountFC { get; set; }
        public object ExternalCalcTaxAmountSC { get; set; }
        public object StandardItemIdentification { get; set; }
        public object CommodityClassification { get; set; }
        public object UnencumberedReason { get; set; }
        public string CUSplit { get; set; }
    }

}