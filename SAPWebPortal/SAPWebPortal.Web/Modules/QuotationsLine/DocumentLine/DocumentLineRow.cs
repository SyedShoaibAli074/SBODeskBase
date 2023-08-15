using SAPWebPortal.Default;
using SAPWebPortal.VatGroups;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.QuotationsLine
{
    [ConnectionKey("Default"), Module("QuotationsLine"), ServiceLayer("QuotationsLine")]
    [DisplayName("Document Line"), InstanceName("Document Line")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [NotMapped]
    public sealed class DocumentLineRow : Row<DocumentLineRow.RowFields>, IIdRow
    {
        [DisplayName("Doc Entry"), SAPDBFieldName("DocEntry")]
        [NotMapped]
        public Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }
        [DisplayName("Line Num"), NotNull, SAPDBFieldName("LineNum"), IdProperty]
        [NotMapped]
        public Int32? LineNum
        {
            get => fields.LineNum[this];
            set => fields.LineNum[this] = value;
        }

        [DisplayName("Item Code"), SAPDBFieldName("ItemCode"), _Ext.GridItemPickerEditor(typeof(ItemRow)) ]
        [NotMapped]
        public String ItemCode
        {
            get => fields.ItemCode[this];
            set => fields.ItemCode[this] = value;
        }
       
        [DisplayName("Account Code"), SAPDBFieldName("AcctCode"), _Ext.GridItemPickerEditor(typeof(ChartOfAccountRow))]
        [NotMapped]
        public String AccountCode
        {
            get => fields.AccountCode[this];
            set => fields.AccountCode[this] = value;
        }
        [DisplayName("Item Description"), SAPDBFieldName("Dscription"), ReadOnly(true)]
        [NotMapped]
        public String ItemDescription
        {
            get => fields.ItemDescription[this];
            set => fields.ItemDescription[this] = value;
        }

        [DisplayName("Quantity"), SAPDBFieldName("Quantity")]
        [NotMapped]
        public decimal? Quantity
        {
            get => fields.Quantity[this];
            set => fields.Quantity[this] = value;
        }
        [DisplayName("Items per Unit"), SAPDBFieldName("NumPerMsr"), ReadOnly(true)]
        [NotMapped]
        public decimal? UnitsOfMeasurment
        {
            get => fields.UnitsOfMeasurment[this];
            set => fields.UnitsOfMeasurment[this] = value;
        }

        [DisplayName("Price"), SAPDBFieldName("Price"), Visible, ReadOnly(true),Width(150)]
        [NotMapped]
        public decimal? UnitPrice
        {
            get => fields.UnitPrice[this];
            set => fields.UnitPrice[this] = value;
        }

        [DisplayName("Price After Vat"), SAPDBFieldName("TotInclTax"), Column("PriceAfterVAT") ]
        [NotMapped]
        public decimal? PriceAfterVat
        {
            get => fields.PriceAfterVat[this];
            set => fields.PriceAfterVat[this] = value;
        }
        [DisplayName("Discount %"), SAPDBFieldName("DiscPrcnt"), ReadOnly(true)]
        [NotMapped]
        public decimal? DiscountPercent
        {
            get => fields.DiscountPercent[this];
            set => fields.DiscountPercent[this] = value;
        }
        [DisplayName("Warehouse Code"), SAPDBFieldName("WhsCode"), ReadOnly(true) ]
        [NotMapped]
        public String WarehouseCode
        {
            get => fields.WarehouseCode[this];
            set => fields.WarehouseCode[this] = value;
        }
        [DisplayName("Tax Code"), SAPDBFieldName("VatGroup"), ReadOnly(true)]
        [NotMapped]
        public String VatGroup
        {
            get => fields.VatGroup[this];
            set => fields.VatGroup[this] = value;
        }
        [DisplayName("UoM"), SAPDBFieldName("UoMCode")]
        [NotMapped]
        public String UoMCode
        {
            get => fields.UoMCode[this];
            set => fields.UoMCode[this] = value;
        }
        [DisplayName("Tax Amount"), SAPDBFieldName("VatSum")]
        [NotMapped]
        public decimal? TaxTotal
        {
            get => fields.TaxTotal[this];
            set => fields.TaxTotal[this] = value;
        }
        [DisplayName("Line Total"), SAPDBFieldName("LineTotal")]
        [NotMapped]
        public decimal? LineTotal
        {
            get => fields.LineTotal[this];
            set => fields.LineTotal[this] = value;
        }
        [DisplayName("Gross Total"), SAPDBFieldName("GrossTotal")]
        [NotMapped]
        public decimal? GrossTotal
        {
            get => fields.GrossTotal[this];
            set => fields.GrossTotal[this] = value;
        }
        //[DisplayName("Currency"), NotNull]
        //[NotMapped]
        //public String Currency
        //{
        //    get => fields.Currency[this];
        //    set => fields.Currency[this] = value;
        //}

        //[DisplayName("Rate"), NotNull]
        //[NotMapped]
        //public decimal? Rate
        //{
        //    get => fields.Rate[this];
        //    set => fields.Rate[this] = value;
        //}
        //[DisplayName("Ship Date"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.DateTimeOffset]? ShipDate
        //{
        //    get => fields.ShipDate[this];
        //    set => fields.ShipDate[this] = value;
        //}
        //[DisplayName("Vendor Num"), NotNull]
        //[NotMapped]
        //public String VendorNum
        //{
        //    get => fields.VendorNum[this];
        //    set => fields.VendorNum[this] = value;
        //}

        //[DisplayName("Serial Num"), NotNull]
        //[NotMapped]
        //public String SerialNum
        //{
        //    get => fields.SerialNum[this];
        //    set => fields.SerialNum[this] = value;
        //}
        //[DisplayName("Sales Person Code"), NotNull]
        //[NotMapped]
        //public Int32? SalesPersonCode
        //{
        //    get => fields.SalesPersonCode[this];
        //    set => fields.SalesPersonCode[this] = value;
        //}

        //[DisplayName("Commision Percent"), NotNull]
        //[NotMapped]
        //public decimal? CommisionPercent
        //{
        //    get => fields.CommisionPercent[this];
        //    set => fields.CommisionPercent[this] = value;
        //}

        //[DisplayName("Tree Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoItemTreeTypes]? TreeType
        //{
        //    get => fields.TreeType[this];
        //    set => fields.TreeType[this] = value;
        //}



        //[DisplayName("Use Base Units"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? UseBaseUnits
        //{
        //    get => fields.UseBaseUnits[this];
        //    set => fields.UseBaseUnits[this] = value;
        //}

        //[DisplayName("Supplier Cat Num"), NotNull]
        //[NotMapped]
        //public String SupplierCatNum
        //{
        //    get => fields.SupplierCatNum[this];
        //    set => fields.SupplierCatNum[this] = value;
        //}

        //[DisplayName("Costing Code"), NotNull]
        //[NotMapped]
        //public String CostingCode
        //{
        //    get => fields.CostingCode[this];
        //    set => fields.CostingCode[this] = value;
        //}

        //[DisplayName("Project Code"), NotNull]
        //[NotMapped]
        //public String ProjectCode
        //{
        //    get => fields.ProjectCode[this];
        //    set => fields.ProjectCode[this] = value;
        //}

        //[DisplayName("Bar Code"), NotNull]
        //[NotMapped]
        //public String BarCode
        //{
        //    get => fields.BarCode[this];
        //    set => fields.BarCode[this] = value;
        //}



        //[DisplayName("Height1"), NotNull]
        //[NotMapped]
        //public decimal? Height1
        //{
        //    get => fields.Height1[this];
        //    set => fields.Height1[this] = value;
        //}

        //[DisplayName("Hight1 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Hight1Unit
        //{
        //    get => fields.Hight1Unit[this];
        //    set => fields.Hight1Unit[this] = value;
        //}

        //[DisplayName("Height2"), NotNull]
        //[NotMapped]
        //public decimal? Height2
        //{
        //    get => fields.Height2[this];
        //    set => fields.Height2[this] = value;
        //}

        //[DisplayName("Height2 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Height2Unit
        //{
        //    get => fields.Height2Unit[this];
        //    set => fields.Height2Unit[this] = value;
        //}

        //[DisplayName("Lengh1"), NotNull]
        //[NotMapped]
        //public decimal? Lengh1
        //{
        //    get => fields.Lengh1[this];
        //    set => fields.Lengh1[this] = value;
        //}

        //[DisplayName("Lengh1 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Lengh1Unit
        //{
        //    get => fields.Lengh1Unit[this];
        //    set => fields.Lengh1Unit[this] = value;
        //}

        //[DisplayName("Lengh2"), NotNull]
        //[NotMapped]
        //public decimal? Lengh2
        //{
        //    get => fields.Lengh2[this];
        //    set => fields.Lengh2[this] = value;
        //}

        //[DisplayName("Lengh2 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Lengh2Unit
        //{
        //    get => fields.Lengh2Unit[this];
        //    set => fields.Lengh2Unit[this] = value;
        //}

        //[DisplayName("Weight1"), NotNull]
        //[NotMapped]
        //public decimal? Weight1
        //{
        //    get => fields.Weight1[this];
        //    set => fields.Weight1[this] = value;
        //}

        //[DisplayName("Weight1 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Weight1Unit
        //{
        //    get => fields.Weight1Unit[this];
        //    set => fields.Weight1Unit[this] = value;
        //}

        //[DisplayName("Weight2"), NotNull]
        //[NotMapped]
        //public decimal? Weight2
        //{
        //    get => fields.Weight2[this];
        //    set => fields.Weight2[this] = value;
        //}

        //[DisplayName("Weight2 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Weight2Unit
        //{
        //    get => fields.Weight2Unit[this];
        //    set => fields.Weight2Unit[this] = value;
        //}

        //[DisplayName("Factor1"), NotNull]
        //[NotMapped]
        //public decimal? Factor1
        //{
        //    get => fields.Factor1[this];
        //    set => fields.Factor1[this] = value;
        //}

        //[DisplayName("Factor2"), NotNull]
        //[NotMapped]
        //public decimal? Factor2
        //{
        //    get => fields.Factor2[this];
        //    set => fields.Factor2[this] = value;
        //}

        //[DisplayName("Factor3"), NotNull]
        //[NotMapped]
        //public decimal? Factor3
        //{
        //    get => fields.Factor3[this];
        //    set => fields.Factor3[this] = value;
        //}

        //[DisplayName("Factor4"), NotNull]
        //[NotMapped]
        //public decimal? Factor4
        //{
        //    get => fields.Factor4[this];
        //    set => fields.Factor4[this] = value;
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

        //[DisplayName("Base Line"), NotNull]
        //[NotMapped]
        //public Int32? BaseLine
        //{
        //    get => fields.BaseLine[this];
        //    set => fields.BaseLine[this] = value;
        //}

        //[DisplayName("Volume"), NotNull]
        //[NotMapped]
        //public decimal? Volume
        //{
        //    get => fields.Volume[this];
        //    set => fields.Volume[this] = value;
        //}

        //[DisplayName("Volume Unit"), NotNull]
        //[NotMapped]
        //public Int32? VolumeUnit
        //{
        //    get => fields.VolumeUnit[this];
        //    set => fields.VolumeUnit[this] = value;
        //}

        //[DisplayName("Width1"), NotNull]
        //[NotMapped]
        //public decimal? Width1
        //{
        //    get => fields.Width1[this];
        //    set => fields.Width1[this] = value;
        //}

        //[DisplayName("Width1 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Width1Unit
        //{
        //    get => fields.Width1Unit[this];
        //    set => fields.Width1Unit[this] = value;
        //}

        //[DisplayName("Width2"), NotNull]
        //[NotMapped]
        //public decimal? Width2
        //{
        //    get => fields.Width2[this];
        //    set => fields.Width2[this] = value;
        //}

        //[DisplayName("Width2 Unit"), NotNull]
        //[NotMapped]
        //public Int32? Width2Unit
        //{
        //    get => fields.Width2Unit[this];
        //    set => fields.Width2Unit[this] = value;
        //}

        //[DisplayName("Address"), NotNull]
        //[NotMapped]
        //public String Address
        //{
        //    get => fields.Address[this];
        //    set => fields.Address[this] = value;
        //}

        //[DisplayName("Tax Code"), NotNull]
        //[NotMapped]
        //public String TaxCode
        //{
        //    get => fields.TaxCode[this];
        //    set => fields.TaxCode[this] = value;
        //}

        //[DisplayName("Tax Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoTaxTypes]? TaxType
        //{
        //    get => fields.TaxType[this];
        //    set => fields.TaxType[this] = value;
        //}

        //[DisplayName("Tax Liable"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? TaxLiable
        //{
        //    get => fields.TaxLiable[this];
        //    set => fields.TaxLiable[this] = value;
        //}

        //[DisplayName("Pick Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? PickStatus
        //{
        //    get => fields.PickStatus[this];
        //    set => fields.PickStatus[this] = value;
        //}

        //[DisplayName("Pick Quantity"), NotNull]
        //[NotMapped]
        //public decimal? PickQuantity
        //{
        //    get => fields.PickQuantity[this];
        //    set => fields.PickQuantity[this] = value;
        //}

        //[DisplayName("Pick List Id Number"), NotNull]
        //[NotMapped]
        //public Int32? PickListIdNumber
        //{
        //    get => fields.PickListIdNumber[this];
        //    set => fields.PickListIdNumber[this] = value;
        //}

        //[DisplayName("Original Item"), NotNull]
        //[NotMapped]
        //public String OriginalItem
        //{
        //    get => fields.OriginalItem[this];
        //    set => fields.OriginalItem[this] = value;
        //}

        //[DisplayName("Back Order"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? BackOrder
        //{
        //    get => fields.BackOrder[this];
        //    set => fields.BackOrder[this] = value;
        //}

        //[DisplayName("Free Text"), NotNull]
        //[NotMapped]
        //public String FreeText
        //{
        //    get => fields.FreeText[this];
        //    set => fields.FreeText[this] = value;
        //}

        //[DisplayName("Shipping Method"), NotNull]
        //[NotMapped]
        //public Int32? ShippingMethod
        //{
        //    get => fields.ShippingMethod[this];
        //    set => fields.ShippingMethod[this] = value;
        //}

        //[DisplayName("Po Target Num"), Column("POTargetNum"), NotNull]
        //[NotMapped]
        //public Int32? PoTargetNum
        //{
        //    get => fields.PoTargetNum[this];
        //    set => fields.PoTargetNum[this] = value;
        //}

        //[DisplayName("Po Target Entry"), Column("POTargetEntry"), NotNull]
        //[NotMapped]
        //public String PoTargetEntry
        //{
        //    get => fields.PoTargetEntry[this];
        //    set => fields.PoTargetEntry[this] = value;
        //}

        //[DisplayName("Po Target Row Num"), Column("POTargetRowNum"), NotNull]
        //[NotMapped]
        //public Int32? PoTargetRowNum
        //{
        //    get => fields.PoTargetRowNum[this];
        //    set => fields.PoTargetRowNum[this] = value;
        //}

        //[DisplayName("Correction Invoice Item"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoCorInvItemStatus]? CorrectionInvoiceItem
        //{
        //    get => fields.CorrectionInvoiceItem[this];
        //    set => fields.CorrectionInvoiceItem[this] = value;
        //}

        //[DisplayName("Corr Inv Amount To Stock"), NotNull]
        //[NotMapped]
        //public decimal? CorrInvAmountToStock
        //{
        //    get => fields.CorrInvAmountToStock[this];
        //    set => fields.CorrInvAmountToStock[this] = value;
        //}

        //[DisplayName("Corr Inv Amount To Diff Acct"), NotNull]
        //[NotMapped]
        //public decimal? CorrInvAmountToDiffAcct
        //{
        //    get => fields.CorrInvAmountToDiffAcct[this];
        //    set => fields.CorrInvAmountToDiffAcct[this] = value;
        //}

        //[DisplayName("Applied Tax"), NotNull]
        //[NotMapped]
        //public decimal? AppliedTax
        //{
        //    get => fields.AppliedTax[this];
        //    set => fields.AppliedTax[this] = value;
        //}

        //[DisplayName("Applied Tax Fc"), Column("AppliedTaxFC"), NotNull]
        //[NotMapped]
        //public decimal? AppliedTaxFc
        //{
        //    get => fields.AppliedTaxFc[this];
        //    set => fields.AppliedTaxFc[this] = value;
        //}

        //[DisplayName("Applied Tax Sc"), Column("AppliedTaxSC"), NotNull]
        //[NotMapped]
        //public decimal? AppliedTaxSc
        //{
        //    get => fields.AppliedTaxSc[this];
        //    set => fields.AppliedTaxSc[this] = value;
        //}

        //[DisplayName("Wt Liable"), Column("WTLiable"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? WtLiable
        //{
        //    get => fields.WtLiable[this];
        //    set => fields.WtLiable[this] = value;
        //}

        //[DisplayName("Deferred Tax"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DeferredTax
        //{
        //    get => fields.DeferredTax[this];
        //    set => fields.DeferredTax[this] = value;
        //}

        //[DisplayName("Equalization Tax Percent"), NotNull]
        //[NotMapped]
        //public decimal? EqualizationTaxPercent
        //{
        //    get => fields.EqualizationTaxPercent[this];
        //    set => fields.EqualizationTaxPercent[this] = value;
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

        //[DisplayName("Net Tax Amount"), NotNull]
        //[NotMapped]
        //public decimal? NetTaxAmount
        //{
        //    get => fields.NetTaxAmount[this];
        //    set => fields.NetTaxAmount[this] = value;
        //}

        //[DisplayName("Net Tax Amount Fc"), Column("NetTaxAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? NetTaxAmountFc
        //{
        //    get => fields.NetTaxAmountFc[this];
        //    set => fields.NetTaxAmountFc[this] = value;
        //}

        //[DisplayName("Net Tax Amount Sc"), Column("NetTaxAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? NetTaxAmountSc
        //{
        //    get => fields.NetTaxAmountSc[this];
        //    set => fields.NetTaxAmountSc[this] = value;
        //}

        //[DisplayName("Measure Unit"), NotNull]
        //[NotMapped]
        //public String MeasureUnit
        //{
        //    get => fields.MeasureUnit[this];
        //    set => fields.MeasureUnit[this] = value;
        //}

        //[DisplayName("Units Of Measurment"), NotNull]
        //[NotMapped]
        //public decimal? UnitsOfMeasurment
        //{
        //    get => fields.UnitsOfMeasurment[this];
        //    set => fields.UnitsOfMeasurment[this] = value;
        //}

        //[DisplayName("Tax Percentage Per Row"), NotNull]
        //[NotMapped]
        //public decimal? TaxPercentagePerRow
        //{
        //    get => fields.TaxPercentagePerRow[this];
        //    set => fields.TaxPercentagePerRow[this] = value;
        //}



        //[DisplayName("Consumer Sales Forecast"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ConsumerSalesForecast
        //{
        //    get => fields.ConsumerSalesForecast[this];
        //    set => fields.ConsumerSalesForecast[this] = value;
        //}

        //[DisplayName("Excise Amount"), NotNull]
        //[NotMapped]
        //public decimal? ExciseAmount
        //{
        //    get => fields.ExciseAmount[this];
        //    set => fields.ExciseAmount[this] = value;
        //}

        //[DisplayName("Tax Per Unit"), NotNull]
        //[NotMapped]
        //public decimal? TaxPerUnit
        //{
        //    get => fields.TaxPerUnit[this];
        //    set => fields.TaxPerUnit[this] = value;
        //}

        //[DisplayName("Total Incl Tax"), NotNull]
        //[NotMapped]
        //public decimal? TotalInclTax
        //{
        //    get => fields.TotalInclTax[this];
        //    set => fields.TotalInclTax[this] = value;
        //}

        //[DisplayName("Country Org"), NotNull]
        //[NotMapped]
        //public String CountryOrg
        //{
        //    get => fields.CountryOrg[this];
        //    set => fields.CountryOrg[this] = value;
        //}

        //[DisplayName("Sww"), Column("SWW"), NotNull]
        //[NotMapped]
        //public String Sww
        //{
        //    get => fields.Sww[this];
        //    set => fields.Sww[this] = value;
        //}

        //[DisplayName("Transaction Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoTransactionTypeEnum]? TransactionType
        //{
        //    get => fields.TransactionType[this];
        //    set => fields.TransactionType[this] = value;
        //}

        //[DisplayName("Distribute Expense"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DistributeExpense
        //{
        //    get => fields.DistributeExpense[this];
        //    set => fields.DistributeExpense[this] = value;
        //}

        //[DisplayName("Row Total Fc"), Column("RowTotalFC"), NotNull]
        //[NotMapped]
        //public decimal? RowTotalFc
        //{
        //    get => fields.RowTotalFc[this];
        //    set => fields.RowTotalFc[this] = value;
        //}

        //[DisplayName("Row Total Sc"), Column("RowTotalSC"), NotNull]
        //[NotMapped]
        //public decimal? RowTotalSc
        //{
        //    get => fields.RowTotalSc[this];
        //    set => fields.RowTotalSc[this] = value;
        //}

        //[DisplayName("Last Buy Inm Price"), NotNull]
        //[NotMapped]
        //public decimal? LastBuyInmPrice
        //{
        //    get => fields.LastBuyInmPrice[this];
        //    set => fields.LastBuyInmPrice[this] = value;
        //}

        //[DisplayName("Last Buy Distribute Sum Fc"), NotNull]
        //[NotMapped]
        //public decimal? LastBuyDistributeSumFc
        //{
        //    get => fields.LastBuyDistributeSumFc[this];
        //    set => fields.LastBuyDistributeSumFc[this] = value;
        //}

        //[DisplayName("Last Buy Distribute Sum Sc"), NotNull]
        //[NotMapped]
        //public decimal? LastBuyDistributeSumSc
        //{
        //    get => fields.LastBuyDistributeSumSc[this];
        //    set => fields.LastBuyDistributeSumSc[this] = value;
        //}

        //[DisplayName("Last Buy Distribute Sum"), NotNull]
        //[NotMapped]
        //public decimal? LastBuyDistributeSum
        //{
        //    get => fields.LastBuyDistributeSum[this];
        //    set => fields.LastBuyDistributeSum[this] = value;
        //}

        //[DisplayName("Stock Distributesum Foreign"), NotNull]
        //[NotMapped]
        //public decimal? StockDistributesumForeign
        //{
        //    get => fields.StockDistributesumForeign[this];
        //    set => fields.StockDistributesumForeign[this] = value;
        //}

        //[DisplayName("Stock Distributesum System"), NotNull]
        //[NotMapped]
        //public decimal? StockDistributesumSystem
        //{
        //    get => fields.StockDistributesumSystem[this];
        //    set => fields.StockDistributesumSystem[this] = value;
        //}

        //[DisplayName("Stock Distributesum"), NotNull]
        //[NotMapped]
        //public decimal? StockDistributesum
        //{
        //    get => fields.StockDistributesum[this];
        //    set => fields.StockDistributesum[this] = value;
        //}

        //[DisplayName("Stock Inm Price"), NotNull]
        //[NotMapped]
        //public decimal? StockInmPrice
        //{
        //    get => fields.StockInmPrice[this];
        //    set => fields.StockInmPrice[this] = value;
        //}

        //[DisplayName("Pick Status Ex"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoDocumentLinePickStatus]? PickStatusEx
        //{
        //    get => fields.PickStatusEx[this];
        //    set => fields.PickStatusEx[this] = value;
        //}

        //[DisplayName("Tax Before Dpm"), Column("TaxBeforeDPM"), NotNull]
        //[NotMapped]
        //public decimal? TaxBeforeDpm
        //{
        //    get => fields.TaxBeforeDpm[this];
        //    set => fields.TaxBeforeDpm[this] = value;
        //}

        //[DisplayName("Tax Before Dpmfc"), Column("TaxBeforeDPMFC"), NotNull]
        //[NotMapped]
        //public decimal? TaxBeforeDpmfc
        //{
        //    get => fields.TaxBeforeDpmfc[this];
        //    set => fields.TaxBeforeDpmfc[this] = value;
        //}

        //[DisplayName("Tax Before Dpmsc"), Column("TaxBeforeDPMSC"), NotNull]
        //[NotMapped]
        //public decimal? TaxBeforeDpmsc
        //{
        //    get => fields.TaxBeforeDpmsc[this];
        //    set => fields.TaxBeforeDpmsc[this] = value;
        //}

        //[DisplayName("Cfop Code"), Column("CFOPCode"), NotNull]
        //[NotMapped]
        //public String CfopCode
        //{
        //    get => fields.CfopCode[this];
        //    set => fields.CfopCode[this] = value;
        //}

        //[DisplayName("Cst Code"), Column("CSTCode"), NotNull]
        //[NotMapped]
        //public String CstCode
        //{
        //    get => fields.CstCode[this];
        //    set => fields.CstCode[this] = value;
        //}

        //[DisplayName("Usage"), NotNull]
        //[NotMapped]
        //public Int32? Usage
        //{
        //    get => fields.Usage[this];
        //    set => fields.Usage[this] = value;
        //}

        //[DisplayName("Tax Only"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? TaxOnly
        //{
        //    get => fields.TaxOnly[this];
        //    set => fields.TaxOnly[this] = value;
        //}

        //[DisplayName("Visual Order"), NotNull]
        //[NotMapped]
        //public Int32? VisualOrder
        //{
        //    get => fields.VisualOrder[this];
        //    set => fields.VisualOrder[this] = value;
        //}

        //[DisplayName("Base Open Quantity"), NotNull]
        //[NotMapped]
        //public decimal? BaseOpenQuantity
        //{
        //    get => fields.BaseOpenQuantity[this];
        //    set => fields.BaseOpenQuantity[this] = value;
        //}

        //[DisplayName("Unit Price"), NotNull]
        //[NotMapped]
        //public decimal? UnitPrice
        //{
        //    get => fields.UnitPrice[this];
        //    set => fields.UnitPrice[this] = value;
        //}

        //[DisplayName("Line Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoStatus]? LineStatus
        //{
        //    get => fields.LineStatus[this];
        //    set => fields.LineStatus[this] = value;
        //}

        //[DisplayName("Package Quantity"), NotNull]
        //[NotMapped]
        //public decimal? PackageQuantity
        //{
        //    get => fields.PackageQuantity[this];
        //    set => fields.PackageQuantity[this] = value;
        //}

        //[DisplayName("Text"), NotNull]
        //[NotMapped]
        //public String Text
        //{
        //    get => fields.Text[this];
        //    set => fields.Text[this] = value;
        //}

        //[DisplayName("Line Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoDocLineType]? LineType
        //{
        //    get => fields.LineType[this];
        //    set => fields.LineType[this] = value;
        //}

        //[DisplayName("Cogs Costing Code"), Column("COGSCostingCode"), NotNull]
        //[NotMapped]
        //public String CogsCostingCode
        //{
        //    get => fields.CogsCostingCode[this];
        //    set => fields.CogsCostingCode[this] = value;
        //}

        //[DisplayName("Cogs Account Code"), Column("COGSAccountCode"), NotNull]
        //[NotMapped]
        //public String CogsAccountCode
        //{
        //    get => fields.CogsAccountCode[this];
        //    set => fields.CogsAccountCode[this] = value;
        //}

        //[DisplayName("Change Assemly Bo M Warehouse"), NotNull]
        //[NotMapped]
        //public String ChangeAssemlyBoMWarehouse
        //{
        //    get => fields.ChangeAssemlyBoMWarehouse[this];
        //    set => fields.ChangeAssemlyBoMWarehouse[this] = value;
        //}

        //[DisplayName("Gross Buy Price"), NotNull]
        //[NotMapped]
        //public decimal? GrossBuyPrice
        //{
        //    get => fields.GrossBuyPrice[this];
        //    set => fields.GrossBuyPrice[this] = value;
        //}

        //[DisplayName("Gross Base"), NotNull]
        //[NotMapped]
        //public Int32? GrossBase
        //{
        //    get => fields.GrossBase[this];
        //    set => fields.GrossBase[this] = value;
        //}

        //[DisplayName("Gross Profit Total Base Price"), NotNull]
        //[NotMapped]
        //public decimal? GrossProfitTotalBasePrice
        //{
        //    get => fields.GrossProfitTotalBasePrice[this];
        //    set => fields.GrossProfitTotalBasePrice[this] = value;
        //}

        //[DisplayName("Costing Code2"), NotNull]
        //[NotMapped]
        //public String CostingCode2
        //{
        //    get => fields.CostingCode2[this];
        //    set => fields.CostingCode2[this] = value;
        //}

        //[DisplayName("Costing Code3"), NotNull]
        //[NotMapped]
        //public String CostingCode3
        //{
        //    get => fields.CostingCode3[this];
        //    set => fields.CostingCode3[this] = value;
        //}

        //[DisplayName("Costing Code4"), NotNull]
        //[NotMapped]
        //public String CostingCode4
        //{
        //    get => fields.CostingCode4[this];
        //    set => fields.CostingCode4[this] = value;
        //}

        //[DisplayName("Costing Code5"), NotNull]
        //[NotMapped]
        //public String CostingCode5
        //{
        //    get => fields.CostingCode5[this];
        //    set => fields.CostingCode5[this] = value;
        //}

        //[DisplayName("Item Details"), NotNull]
        //[NotMapped]
        //public String ItemDetails
        //{
        //    get => fields.ItemDetails[this];
        //    set => fields.ItemDetails[this] = value;
        //}

        //[DisplayName("Location Code"), NotNull]
        //[NotMapped]
        //public Int32? LocationCode
        //{
        //    get => fields.LocationCode[this];
        //    set => fields.LocationCode[this] = value;
        //}

        //[DisplayName("Actual Delivery Date"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.DateTimeOffset]? ActualDeliveryDate
        //{
        //    get => fields.ActualDeliveryDate[this];
        //    set => fields.ActualDeliveryDate[this] = value;
        //}

        //[DisplayName("Remaining Open Quantity"), NotNull]
        //[NotMapped]
        //public decimal? RemainingOpenQuantity
        //{
        //    get => fields.RemainingOpenQuantity[this];
        //    set => fields.RemainingOpenQuantity[this] = value;
        //}

        //[DisplayName("Open Amount"), NotNull]
        //[NotMapped]
        //public decimal? OpenAmount
        //{
        //    get => fields.OpenAmount[this];
        //    set => fields.OpenAmount[this] = value;
        //}

        //[DisplayName("Open Amount Fc"), Column("OpenAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? OpenAmountFc
        //{
        //    get => fields.OpenAmountFc[this];
        //    set => fields.OpenAmountFc[this] = value;
        //}

        //[DisplayName("Open Amount Sc"), Column("OpenAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? OpenAmountSc
        //{
        //    get => fields.OpenAmountSc[this];
        //    set => fields.OpenAmountSc[this] = value;
        //}

        //[DisplayName("Ex Line No"), NotNull]
        //[NotMapped]
        //public String ExLineNo
        //{
        //    get => fields.ExLineNo[this];
        //    set => fields.ExLineNo[this] = value;
        //}

        //[DisplayName("Required Date"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.DateTimeOffset]? RequiredDate
        //{
        //    get => fields.RequiredDate[this];
        //    set => fields.RequiredDate[this] = value;
        //}

        //[DisplayName("Required Quantity"), NotNull]
        //[NotMapped]
        //public decimal? RequiredQuantity
        //{
        //    get => fields.RequiredQuantity[this];
        //    set => fields.RequiredQuantity[this] = value;
        //}

        //[DisplayName("Cogs Costing Code2"), Column("COGSCostingCode2"), NotNull]
        //[NotMapped]
        //public String CogsCostingCode2
        //{
        //    get => fields.CogsCostingCode2[this];
        //    set => fields.CogsCostingCode2[this] = value;
        //}

        //[DisplayName("Cogs Costing Code3"), Column("COGSCostingCode3"), NotNull]
        //[NotMapped]
        //public String CogsCostingCode3
        //{
        //    get => fields.CogsCostingCode3[this];
        //    set => fields.CogsCostingCode3[this] = value;
        //}

        //[DisplayName("Cogs Costing Code4"), Column("COGSCostingCode4"), NotNull]
        //[NotMapped]
        //public String CogsCostingCode4
        //{
        //    get => fields.CogsCostingCode4[this];
        //    set => fields.CogsCostingCode4[this] = value;
        //}

        //[DisplayName("Cogs Costing Code5"), Column("COGSCostingCode5"), NotNull]
        //[NotMapped]
        //public String CogsCostingCode5
        //{
        //    get => fields.CogsCostingCode5[this];
        //    set => fields.CogsCostingCode5[this] = value;
        //}

        //[DisplayName("Cs Tfor Ipi"), Column("CSTforIPI"), NotNull]
        //[NotMapped]
        //public String CsTforIpi
        //{
        //    get => fields.CsTforIpi[this];
        //    set => fields.CsTforIpi[this] = value;
        //}

        //[DisplayName("Cs Tfor Pis"), Column("CSTforPIS"), NotNull]
        //[NotMapped]
        //public String CsTforPis
        //{
        //    get => fields.CsTforPis[this];
        //    set => fields.CsTforPis[this] = value;
        //}

        //[DisplayName("Cs Tfor Cofins"), Column("CSTforCOFINS"), NotNull]
        //[NotMapped]
        //public String CsTforCofins
        //{
        //    get => fields.CsTforCofins[this];
        //    set => fields.CsTforCofins[this] = value;
        //}

        //[DisplayName("Credit Origin Code"), NotNull]
        //[NotMapped]
        //public String CreditOriginCode
        //{
        //    get => fields.CreditOriginCode[this];
        //    set => fields.CreditOriginCode[this] = value;
        //}

        //[DisplayName("Without Inventory Movement"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? WithoutInventoryMovement
        //{
        //    get => fields.WithoutInventoryMovement[this];
        //    set => fields.WithoutInventoryMovement[this] = value;
        //}

        //[DisplayName("Agreement No"), NotNull]
        //[NotMapped]
        //public Int32? AgreementNo
        //{
        //    get => fields.AgreementNo[this];
        //    set => fields.AgreementNo[this] = value;
        //}

        //[DisplayName("Agreement Row Number"), NotNull]
        //[NotMapped]
        //public Int32? AgreementRowNumber
        //{
        //    get => fields.AgreementRowNumber[this];
        //    set => fields.AgreementRowNumber[this] = value;
        //}

        //[DisplayName("Actual Base Entry"), NotNull]
        //[NotMapped]
        //public Int32? ActualBaseEntry
        //{
        //    get => fields.ActualBaseEntry[this];
        //    set => fields.ActualBaseEntry[this] = value;
        //}

        //[DisplayName("Actual Base Line"), NotNull]
        //[NotMapped]
        //public Int32? ActualBaseLine
        //{
        //    get => fields.ActualBaseLine[this];
        //    set => fields.ActualBaseLine[this] = value;
        //}



        //[DisplayName("Surpluses"), NotNull]
        //[NotMapped]
        //public decimal? Surpluses
        //{
        //    get => fields.Surpluses[this];
        //    set => fields.Surpluses[this] = value;
        //}

        //[DisplayName("Defect And Breakup"), NotNull]
        //[NotMapped]
        //public decimal? DefectAndBreakup
        //{
        //    get => fields.DefectAndBreakup[this];
        //    set => fields.DefectAndBreakup[this] = value;
        //}

        //[DisplayName("Shortages"), NotNull]
        //[NotMapped]
        //public decimal? Shortages
        //{
        //    get => fields.Shortages[this];
        //    set => fields.Shortages[this] = value;
        //}

        //[DisplayName("Consider Quantity"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ConsiderQuantity
        //{
        //    get => fields.ConsiderQuantity[this];
        //    set => fields.ConsiderQuantity[this] = value;
        //}

        //[DisplayName("Partial Retirement"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? PartialRetirement
        //{
        //    get => fields.PartialRetirement[this];
        //    set => fields.PartialRetirement[this] = value;
        //}

        //[DisplayName("Retirement Quantity"), NotNull]
        //[NotMapped]
        //public decimal? RetirementQuantity
        //{
        //    get => fields.RetirementQuantity[this];
        //    set => fields.RetirementQuantity[this] = value;
        //}

        //[DisplayName("Retirement Apc"), Column("RetirementAPC"), NotNull]
        //[NotMapped]
        //public decimal? RetirementApc
        //{
        //    get => fields.RetirementApc[this];
        //    set => fields.RetirementApc[this] = value;
        //}

        //[DisplayName("Third Party"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ThirdParty
        //{
        //    get => fields.ThirdParty[this];
        //    set => fields.ThirdParty[this] = value;
        //}

        //[DisplayName("Po Num"), NotNull]
        //[NotMapped]
        //public String PoNum
        //{
        //    get => fields.PoNum[this];
        //    set => fields.PoNum[this] = value;
        //}

        //[DisplayName("Po Itm Num"), NotNull]
        //[NotMapped]
        //public Int32? PoItmNum
        //{
        //    get => fields.PoItmNum[this];
        //    set => fields.PoItmNum[this] = value;
        //}

        //[DisplayName("Expense Type"), NotNull]
        //[NotMapped]
        //public String ExpenseType
        //{
        //    get => fields.ExpenseType[this];
        //    set => fields.ExpenseType[this] = value;
        //}

        //[DisplayName("Receipt Number"), NotNull]
        //[NotMapped]
        //public String ReceiptNumber
        //{
        //    get => fields.ReceiptNumber[this];
        //    set => fields.ReceiptNumber[this] = value;
        //}

        //[DisplayName("Expense Operation Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoExpenseOperationTypeEnum]? ExpenseOperationType
        //{
        //    get => fields.ExpenseOperationType[this];
        //    set => fields.ExpenseOperationType[this] = value;
        //}

        //[DisplayName("Federal Tax Id"), Column("FederalTaxID"), NotNull]
        //[NotMapped]
        //public String FederalTaxId
        //{
        //    get => fields.FederalTaxId[this];
        //    set => fields.FederalTaxId[this] = value;
        //}

        //[DisplayName("Gross Profit"), NotNull]
        //[NotMapped]
        //public decimal? GrossProfit
        //{
        //    get => fields.GrossProfit[this];
        //    set => fields.GrossProfit[this] = value;
        //}

        //[DisplayName("Gross Profit Fc"), Column("GrossProfitFC"), NotNull]
        //[NotMapped]
        //public decimal? GrossProfitFc
        //{
        //    get => fields.GrossProfitFc[this];
        //    set => fields.GrossProfitFc[this] = value;
        //}

        //[DisplayName("Gross Profit Sc"), Column("GrossProfitSC"), NotNull]
        //[NotMapped]
        //public decimal? GrossProfitSc
        //{
        //    get => fields.GrossProfitSc[this];
        //    set => fields.GrossProfitSc[this] = value;
        //}

        //[DisplayName("Price Source"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.DocumentPriceSourceEnum]? PriceSource
        //{
        //    get => fields.PriceSource[this];
        //    set => fields.PriceSource[this] = value;
        //}

        //[DisplayName("Enable Return Cost"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? EnableReturnCost
        //{
        //    get => fields.EnableReturnCost[this];
        //    set => fields.EnableReturnCost[this] = value;
        //}

        //[DisplayName("Return Cost"), NotNull]
        //[NotMapped]
        //public decimal? ReturnCost
        //{
        //    get => fields.ReturnCost[this];
        //    set => fields.ReturnCost[this] = value;
        //}

        //[DisplayName("Line Vendor"), NotNull]
        //[NotMapped]
        //public String LineVendor
        //{
        //    get => fields.LineVendor[this];
        //    set => fields.LineVendor[this] = value;
        //}

        //[DisplayName("Stg Seq Num"), NotNull]
        //[NotMapped]
        //public Int32? StgSeqNum
        //{
        //    get => fields.StgSeqNum[this];
        //    set => fields.StgSeqNum[this] = value;
        //}

        //[DisplayName("Stg Entry"), NotNull]
        //[NotMapped]
        //public Int32? StgEntry
        //{
        //    get => fields.StgEntry[this];
        //    set => fields.StgEntry[this] = value;
        //}

        //[DisplayName("Stg Desc"), NotNull]
        //[NotMapped]
        //public String StgDesc
        //{
        //    get => fields.StgDesc[this];
        //    set => fields.StgDesc[this] = value;
        //}

        //[DisplayName("Uo M Entry"), NotNull]
        //[NotMapped]
        //public Int32? UoMEntry
        //{
        //    get => fields.UoMEntry[this];
        //    set => fields.UoMEntry[this] = value;
        //}



        //[DisplayName("Inventory Quantity"), NotNull]
        //[NotMapped]
        //public decimal? InventoryQuantity
        //{
        //    get => fields.InventoryQuantity[this];
        //    set => fields.InventoryQuantity[this] = value;
        //}

        //[DisplayName("Remaining Open Inventory Quantity"), NotNull]
        //[NotMapped]
        //public decimal? RemainingOpenInventoryQuantity
        //{
        //    get => fields.RemainingOpenInventoryQuantity[this];
        //    set => fields.RemainingOpenInventoryQuantity[this] = value;
        //}

        //[DisplayName("Parent Line Num"), NotNull]
        //[NotMapped]
        //public Int32? ParentLineNum
        //{
        //    get => fields.ParentLineNum[this];
        //    set => fields.ParentLineNum[this] = value;
        //}

        //[DisplayName("Incoterms"), NotNull]
        //[NotMapped]
        //public Int32? Incoterms
        //{
        //    get => fields.Incoterms[this];
        //    set => fields.Incoterms[this] = value;
        //}

        //[DisplayName("Transport Mode"), NotNull]
        //[NotMapped]
        //public Int32? TransportMode
        //{
        //    get => fields.TransportMode[this];
        //    set => fields.TransportMode[this] = value;
        //}

        //[DisplayName("Nature Of Transaction"), NotNull]
        //[NotMapped]
        //public Int32? NatureOfTransaction
        //{
        //    get => fields.NatureOfTransaction[this];
        //    set => fields.NatureOfTransaction[this] = value;
        //}

        //[DisplayName("Destination Country For Import"), NotNull]
        //[NotMapped]
        //public String DestinationCountryForImport
        //{
        //    get => fields.DestinationCountryForImport[this];
        //    set => fields.DestinationCountryForImport[this] = value;
        //}

        //[DisplayName("Destination Region For Import"), NotNull]
        //[NotMapped]
        //public Int32? DestinationRegionForImport
        //{
        //    get => fields.DestinationRegionForImport[this];
        //    set => fields.DestinationRegionForImport[this] = value;
        //}

        //[DisplayName("Origin Country For Export"), NotNull]
        //[NotMapped]
        //public String OriginCountryForExport
        //{
        //    get => fields.OriginCountryForExport[this];
        //    set => fields.OriginCountryForExport[this] = value;
        //}

        //[DisplayName("Origin Region For Export"), NotNull]
        //[NotMapped]
        //public Int32? OriginRegionForExport
        //{
        //    get => fields.OriginRegionForExport[this];
        //    set => fields.OriginRegionForExport[this] = value;
        //}

        //[DisplayName("Item Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoDocItemType]? ItemType
        //{
        //    get => fields.ItemType[this];
        //    set => fields.ItemType[this] = value;
        //}

        //[DisplayName("Change Inventory Quantity Independently"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ChangeInventoryQuantityIndependently
        //{
        //    get => fields.ChangeInventoryQuantityIndependently[this];
        //    set => fields.ChangeInventoryQuantityIndependently[this] = value;
        //}

        //[DisplayName("Free Of Charge Bp"), Column("FreeOfChargeBP"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? FreeOfChargeBp
        //{
        //    get => fields.FreeOfChargeBp[this];
        //    set => fields.FreeOfChargeBp[this] = value;
        //}

        //[DisplayName("Sac Entry"), Column("SACEntry"), NotNull]
        //[NotMapped]
        //public Int32? SacEntry
        //{
        //    get => fields.SacEntry[this];
        //    set => fields.SacEntry[this] = value;
        //}

        //[DisplayName("Hsn Entry"), Column("HSNEntry"), NotNull]
        //[NotMapped]
        //public Int32? HsnEntry
        //{
        //    get => fields.HsnEntry[this];
        //    set => fields.HsnEntry[this] = value;
        //}

        //[DisplayName("Gross Price"), NotNull]
        //[NotMapped]
        //public decimal? GrossPrice
        //{
        //    get => fields.GrossPrice[this];
        //    set => fields.GrossPrice[this] = value;
        //}



        //[DisplayName("Gross Total Fc"), Column("GrossTotalFC"), NotNull]
        //[NotMapped]
        //public decimal? GrossTotalFc
        //{
        //    get => fields.GrossTotalFc[this];
        //    set => fields.GrossTotalFc[this] = value;
        //}

        //[DisplayName("Gross Total Sc"), Column("GrossTotalSC"), NotNull]
        //[NotMapped]
        //public decimal? GrossTotalSc
        //{
        //    get => fields.GrossTotalSc[this];
        //    set => fields.GrossTotalSc[this] = value;
        //}

        //[DisplayName("Ncm Code"), Column("NCMCode"), NotNull]
        //[NotMapped]
        //public Int32? NcmCode
        //{
        //    get => fields.NcmCode[this];
        //    set => fields.NcmCode[this] = value;
        //}

        //[DisplayName("Nve Code"), Column("NVECode"), NotNull]
        //[NotMapped]
        //public String NveCode
        //{
        //    get => fields.NveCode[this];
        //    set => fields.NveCode[this] = value;
        //}

        //[DisplayName("Ind Escala"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? IndEscala
        //{
        //    get => fields.IndEscala[this];
        //    set => fields.IndEscala[this] = value;
        //}

        //[DisplayName("Ctr Seal Qty"), NotNull]
        //[NotMapped]
        //public decimal? CtrSealQty
        //{
        //    get => fields.CtrSealQty[this];
        //    set => fields.CtrSealQty[this] = value;
        //}

        //[DisplayName("Cnjp Man"), Column("CNJPMan"), NotNull]
        //[NotMapped]
        //public String CnjpMan
        //{
        //    get => fields.CnjpMan[this];
        //    set => fields.CnjpMan[this] = value;
        //}

        //[DisplayName("Cest Code"), Column("CESTCode"), NotNull]
        //[NotMapped]
        //public Int32? CestCode
        //{
        //    get => fields.CestCode[this];
        //    set => fields.CestCode[this] = value;
        //}

        //[DisplayName("Uf Fiscal Benefit Code"), Column("UFFiscalBenefitCode"), NotNull]
        //[NotMapped]
        //public String UfFiscalBenefitCode
        //{
        //    get => fields.UfFiscalBenefitCode[this];
        //    set => fields.UfFiscalBenefitCode[this] = value;
        //}

        //[DisplayName("Ship To Code"), NotNull]
        //[NotMapped]
        //public String ShipToCode
        //{
        //    get => fields.ShipToCode[this];
        //    set => fields.ShipToCode[this] = value;
        //}

        //[DisplayName("Ship To Description"), NotNull]
        //[NotMapped]
        //public String ShipToDescription
        //{
        //    get => fields.ShipToDescription[this];
        //    set => fields.ShipToDescription[this] = value;
        //}

        //[DisplayName("Ship From Code"), NotNull]
        //[NotMapped]
        //public String ShipFromCode
        //{
        //    get => fields.ShipFromCode[this];
        //    set => fields.ShipFromCode[this] = value;
        //}

        //[DisplayName("Ship From Description"), NotNull]
        //[NotMapped]
        //public String ShipFromDescription
        //{
        //    get => fields.ShipFromDescription[this];
        //    set => fields.ShipFromDescription[this] = value;
        //}

        //[DisplayName("External Calc Tax Rate"), NotNull]
        //[NotMapped]
        //public decimal? ExternalCalcTaxRate
        //{
        //    get => fields.ExternalCalcTaxRate[this];
        //    set => fields.ExternalCalcTaxRate[this] = value;
        //}

        //[DisplayName("External Calc Tax Amount"), NotNull]
        //[NotMapped]
        //public decimal? ExternalCalcTaxAmount
        //{
        //    get => fields.ExternalCalcTaxAmount[this];
        //    set => fields.ExternalCalcTaxAmount[this] = value;
        //}

        //[DisplayName("External Calc Tax Amount Fc"), Column("ExternalCalcTaxAmountFC"), NotNull]
        //[NotMapped]
        //public decimal? ExternalCalcTaxAmountFc
        //{
        //    get => fields.ExternalCalcTaxAmountFc[this];
        //    set => fields.ExternalCalcTaxAmountFc[this] = value;
        //}

        //[DisplayName("External Calc Tax Amount Sc"), Column("ExternalCalcTaxAmountSC"), NotNull]
        //[NotMapped]
        //public decimal? ExternalCalcTaxAmountSc
        //{
        //    get => fields.ExternalCalcTaxAmountSc[this];
        //    set => fields.ExternalCalcTaxAmountSc[this] = value;
        //}

        //[DisplayName("Standard Item Identification"), NotNull]
        //[NotMapped]
        //public Int32? StandardItemIdentification
        //{
        //    get => fields.StandardItemIdentification[this];
        //    set => fields.StandardItemIdentification[this] = value;
        //}

        //[DisplayName("Commodity Classification"), NotNull]
        //[NotMapped]
        //public Int32? CommodityClassification
        //{
        //    get => fields.CommodityClassification[this];
        //    set => fields.CommodityClassification[this] = value;
        //}

        //[DisplayName("Unencumbered Reason"), NotNull]
        //[NotMapped]
        //public Int32? UnencumberedReason
        //{
        //    get => fields.UnencumberedReason[this];
        //    set => fields.UnencumberedReason[this] = value;
        //}

        //[DisplayName("Cu Split"), Column("CUSplit"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? CuSplit
        //{
        //    get => fields.CuSplit[this];
        //    set => fields.CuSplit[this] = value;
        //}
        //[DisplayName("Line Tax Jurisdictions"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.LineTaxJurisdiction]? LineTaxJurisdictions
        //{
        //    get => fields.LineTaxJurisdictions[this];
        //    set => fields.LineTaxJurisdictions[this] = value;
        //}

        //[DisplayName("Generated Assets"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GeneratedAsset]? GeneratedAssets
        //{
        //    get => fields.GeneratedAssets[this];
        //    set => fields.GeneratedAssets[this] = value;
        //}

        //[DisplayName("E Books Details"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.EBooksDetail]? EBooksDetails
        //{
        //    get => fields.EBooksDetails[this];
        //    set => fields.EBooksDetails[this] = value;
        //}

        //[DisplayName("Document Line Additional Expenses"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentLineAdditionalExpense]? DocumentLineAdditionalExpenses
        //{
        //    get => fields.DocumentLineAdditionalExpenses[this];
        //    set => fields.DocumentLineAdditionalExpenses[this] = value;
        //}

        //[DisplayName("Withholding Tax Lines"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxLine]? WithholdingTaxLines
        //{
        //    get => fields.WithholdingTaxLines[this];
        //    set => fields.WithholdingTaxLines[this] = value;
        //}

        //[DisplayName("Serial Numbers"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.SerialNumber]? SerialNumbers
        //{
        //    get => fields.SerialNumbers[this];
        //    set => fields.SerialNumbers[this] = value;
        //}

        //[DisplayName("Batch Numbers"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BatchNumber]? BatchNumbers
        //{
        //    get => fields.BatchNumbers[this];
        //    set => fields.BatchNumbers[this] = value;
        //}

        //[DisplayName("Document Lines Bin Allocations"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentLinesBinAllocation]? DocumentLinesBinAllocations
        //{
        //    get => fields.DocumentLinesBinAllocations[this];
        //    set => fields.DocumentLinesBinAllocations[this] = value;
        //}

        //[DisplayName("Export Processes"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ExportProcess]? ExportProcesses
        //{
        //    get => fields.ExportProcesses[this];
        //    set => fields.ExportProcesses[this] = value;
        //}

        //[DisplayName("Ccd Numbers"), Column("CCDNumbers"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.CCDNumber]? CcdNumbers
        //{
        //    get => fields.CcdNumbers[this];
        //    set => fields.CcdNumbers[this] = value;
        //}

        //[DisplayName("Return Action"), NotNull]
        //[NotMapped]
        //public Int32? ReturnAction
        //{
        //    get => fields.ReturnAction[this];
        //    set => fields.ReturnAction[this] = value;
        //}

        //[DisplayName("Return Reason"), NotNull]
        //[NotMapped]
        //public Int32? ReturnReason
        //{
        //    get => fields.ReturnReason[this];
        //    set => fields.ReturnReason[this] = value;
        //}

        //[DisplayName("Owner Code"), NotNull]
        //[NotMapped]
        //public Int32? OwnerCode
        //{
        //    get => fields.OwnerCode[this];
        //    set => fields.OwnerCode[this] = value;
        //}

        //[DisplayName("Import Processes"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ImportProcess]? ImportProcesses
        //{
        //    get => fields.ImportProcesses[this];
        //    set => fields.ImportProcesses[this] = value;
        //}

        public DocumentLineRow()
            : base()
        {
        }

        public DocumentLineRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DocEntry;
            public Int32Field LineNum;
            public StringField ItemCode;
            public StringField ItemDescription;
            public StringField AccountCode;
            public DecimalField Quantity;
            public DecimalField UnitsOfMeasurment;
            public StringField VatGroup;
            public DecimalField UnitPrice;
            public DecimalField PriceAfterVat;
            public DecimalField DiscountPercent;
            public StringField WarehouseCode;
            public StringField UoMCode;
            public DecimalField LineTotal;
            public DecimalField GrossTotal;
            public DecimalField TaxTotal;
            //public StringField Currency;
            //public DecimalField Rate;
            //public StringField VendorNum;
            //public StringField SerialNum;
            //public DateTimeField ShipDate;
            //public Int32Field SalesPersonCode;
            //public DecimalField CommisionPercent;
            //public System.Nullable`1[SAPB1.BoItemTreeTypes]Field TreeType;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field UseBaseUnits;
            //public StringField SupplierCatNum;
            //public StringField CostingCode;
            //public StringField ProjectCode;
            //public StringField BarCode;
            //public DecimalField Height1;
            //public Int32Field Hight1Unit;
            //public DecimalField Height2;
            //public Int32Field Height2Unit;
            //public DecimalField Lengh1;
            //public Int32Field Lengh1Unit;
            //public DecimalField Lengh2;
            //public Int32Field Lengh2Unit;
            //public DecimalField Weight1;
            //public Int32Field Weight1Unit;
            //public DecimalField Weight2;
            //public Int32Field Weight2Unit;
            //public DecimalField Factor1;
            //public DecimalField Factor2;
            //public DecimalField Factor3;
            //public DecimalField Factor4;
            //public Int32Field BaseType;
            //public Int32Field BaseEntry;
            //public Int32Field BaseLine;
            //public DecimalField Volume;
            //public Int32Field VolumeUnit;
            //public DecimalField Width1;
            //public Int32Field Width1Unit;
            //public DecimalField Width2;
            //public Int32Field Width2Unit;
            //public StringField Address;
            //public StringField TaxCode;
            //public System.Nullable`1[SAPB1.BoTaxTypes]Field TaxType;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field TaxLiable;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field PickStatus;
            //public DecimalField PickQuantity;
            //public Int32Field PickListIdNumber;
            //public StringField OriginalItem;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field BackOrder;
            //public StringField FreeText;
            //public Int32Field ShippingMethod;
            //public Int32Field PoTargetNum;
            //public StringField PoTargetEntry;
            //public Int32Field PoTargetRowNum;
            //public System.Nullable`1[SAPB1.BoCorInvItemStatus]Field CorrectionInvoiceItem;
            //public DecimalField CorrInvAmountToStock;
            //public DecimalField CorrInvAmountToDiffAcct;
            //public DecimalField AppliedTax;
            //public DecimalField AppliedTaxFc;
            //public DecimalField AppliedTaxSc;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field WtLiable;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DeferredTax;
            //public DecimalField EqualizationTaxPercent;
            //public DecimalField TotalEqualizationTax;
            //public DecimalField TotalEqualizationTaxFc;
            //public DecimalField TotalEqualizationTaxSc;
            //public DecimalField NetTaxAmount;
            //public DecimalField NetTaxAmountFc;
            //public DecimalField NetTaxAmountSc;
            //public StringField MeasureUnit;
            //public DecimalField UnitsOfMeasurment;

            //public DecimalField TaxPercentagePerRow;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ConsumerSalesForecast;
            //public DecimalField ExciseAmount;
            //public DecimalField TaxPerUnit;
            //public DecimalField TotalInclTax;
            //public StringField CountryOrg;
            //public StringField Sww;
            //public System.Nullable`1[SAPB1.BoTransactionTypeEnum]Field TransactionType;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DistributeExpense;
            //public DecimalField RowTotalFc;
            //public DecimalField RowTotalSc;
            //public DecimalField LastBuyInmPrice;
            //public DecimalField LastBuyDistributeSumFc;
            //public DecimalField LastBuyDistributeSumSc;
            //public DecimalField LastBuyDistributeSum;
            //public DecimalField StockDistributesumForeign;
            //public DecimalField StockDistributesumSystem;
            //public DecimalField StockDistributesum;
            //public DecimalField StockInmPrice;
            //public System.Nullable`1[SAPB1.BoDocumentLinePickStatus]Field PickStatusEx;
            //public DecimalField TaxBeforeDpm;
            //public DecimalField TaxBeforeDpmfc;
            //public DecimalField TaxBeforeDpmsc;
            //public StringField CfopCode;
            //public StringField CstCode;
            //public Int32Field Usage;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field TaxOnly;
            //public Int32Field VisualOrder;
            //public DecimalField BaseOpenQuantity;
            //public DecimalField UnitPrice;
            //public System.Nullable`1[SAPB1.BoStatus]Field LineStatus;
            //public DecimalField PackageQuantity;
            //public StringField Text;
            //public System.Nullable`1[SAPB1.BoDocLineType]Field LineType;
            //public StringField CogsCostingCode;
            //public StringField CogsAccountCode;
            //public StringField ChangeAssemlyBoMWarehouse;
            //public DecimalField GrossBuyPrice;
            //public Int32Field GrossBase;
            //public DecimalField GrossProfitTotalBasePrice;
            //public StringField CostingCode2;
            //public StringField CostingCode3;
            //public StringField CostingCode4;
            //public StringField CostingCode5;
            //public StringField ItemDetails;
            //public Int32Field LocationCode;
            //public DateTimeField ActualDeliveryDate;
            //public DecimalField RemainingOpenQuantity;
            //public DecimalField OpenAmount;
            //public DecimalField OpenAmountFc;
            //public DecimalField OpenAmountSc;
            //public StringField ExLineNo;
            //public DateTimeField RequiredDate;
            //public DecimalField RequiredQuantity;
            //public StringField CogsCostingCode2;
            //public StringField CogsCostingCode3;
            //public StringField CogsCostingCode4;
            //public StringField CogsCostingCode5;
            //public StringField CsTforIpi;
            //public StringField CsTforPis;
            //public StringField CsTforCofins;
            //public StringField CreditOriginCode;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field WithoutInventoryMovement;
            //public Int32Field AgreementNo;
            //public Int32Field AgreementRowNumber;
            //public Int32Field ActualBaseEntry;
            //public Int32Field ActualBaseLine;
            //public DecimalField Surpluses;
            //public DecimalField DefectAndBreakup;
            //public DecimalField Shortages;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ConsiderQuantity;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field PartialRetirement;
            //public DecimalField RetiremenUnitsOfMeasurment;
            //public DecimalField RetirementApc;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ThirdParty;
            //public StringField PoNum;
            //public Int32Field PoItmNum;
            //public StringField ExpenseType;
            //public StringField ReceiptNumber;
            //public System.Nullable`1[SAPB1.BoExpenseOperationTypeEnum]Field ExpenseOperationType;
            //public StringField FederalTaxId;
            //public DecimalField GrossProfit;
            //public DecimalField GrossProfitFc;
            //public DecimalField GrossProfitSc;
            //public System.Nullable`1[SAPB1.DocumentPriceSourceEnum]Field PriceSource;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field EnableReturnCost;
            //public DecimalField ReturnCost;
            //public StringField LineVendor;
            //public Int32Field StgSeqNum;
            //public Int32Field StgEntry;
            //public StringField StgDesc;
            //public Int32Field UoMEntry;
            //public DecimalField InventoryQuantity;
            //public DecimalField RemainingOpenInventoryQuantity;
            //public Int32Field ParentLineNum;
            //public Int32Field Incoterms;
            //public Int32Field TransportMode;
            //public Int32Field NatureOfTransaction;
            //public StringField DestinationCountryForImport;
            //public Int32Field DestinationRegionForImport;
            //public StringField OriginCountryForExport;
            //public Int32Field OriginRegionForExport;
            //public System.Nullable`1[SAPB1.BoDocItemType]Field ItemType;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ChangeInventoryQuantityIndependently;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field FreeOfChargeBp;
            //public Int32Field SacEntry;
            //public Int32Field HsnEntry;
            //public DecimalField GrossPrice;
            //public DecimalField GrossTotalFc;
            //public DecimalField GrossTotalSc;
            //public Int32Field NcmCode;
            //public StringField NveCode;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field IndEscala;
            //public DecimalField CtrSealQty;
            //public StringField CnjpMan;
            //public Int32Field CestCode;
            //public StringField UfFiscalBenefitCode;
            //public StringField ShipToCode;
            //public StringField ShipToDescription;
            //public StringField ShipFromCode;
            //public StringField ShipFromDescription;
            //public DecimalField ExternalCalcTaxRate;
            //public DecimalField ExternalCalcTaxAmount;
            //public DecimalField ExternalCalcTaxAmountFc;
            //public DecimalField ExternalCalcTaxAmountSc;
            //public Int32Field StandardItemIdentification;
            //public Int32Field CommodityClassification;
            //public Int32Field UnencumberedReason;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field CuSplit;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.LineTaxJurisdiction]Field LineTaxJurisdictions;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.GeneratedAsset]Field GeneratedAssets;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.EBooksDetail]Field EBooksDetails;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentLineAdditionalExpense]Field DocumentLineAdditionalExpenses;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxLine]Field WithholdingTaxLines;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.SerialNumber]Field SerialNumbers;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BatchNumber]Field BatchNumbers;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocumentLinesBinAllocation]Field DocumentLinesBinAllocations;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ExportProcess]Field ExportProcesses;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.CCDNumber]Field CcdNumbers;
            //public Int32Field ReturnAction;
            //public Int32Field ReturnReason;
            //public Int32Field OwnerCode;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ImportProcess]Field ImportProcesses;
        }
    }
}