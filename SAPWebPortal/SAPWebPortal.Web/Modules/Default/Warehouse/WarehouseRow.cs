using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), ServiceLayer("Warehouses")]
    [DisplayName("Warehouse"), InstanceName("Warehouse")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [NotMapped]
    public sealed class WarehouseRow : Row<WarehouseRow.RowFields>, IIdRow
    {

        [DisplayName("Warehouse Code"), NotNull,IdProperty, NameProperty]
        [NotMapped]
        public System.String? WarehouseCode
        {
            get => fields.WarehouseCode[this];
            set => fields.WarehouseCode[this] = value;
        }
        [DisplayName("Warehouse Name"), NotNull]
        [NotMapped]
        public System.String? WarehouseName
        {
            get => fields.WarehouseName[this];
            set => fields.WarehouseName[this] = value;
        }
        //[DisplayName("Street"), NotNull, ]
        //[NotMapped]
        //public System.String? Street
        //{
        //    get => fields.Street[this];
        //    set => fields.Street[this] = value;
        //}

        //[DisplayName("Stock Inflation Offset Account"), NotNull]
        //[NotMapped]
        //public System.String? StockInflationOffsetAccount
        //{
        //    get => fields.StockInflationOffsetAccount[this];
        //    set => fields.StockInflationOffsetAccount[this] = value;
        //}

        //[DisplayName("Zip Code"), NotNull]
        //[NotMapped]
        //public System.String? ZipCode
        //{
        //    get => fields.ZipCode[this];
        //    set => fields.ZipCode[this] = value;
        //}

        //[DisplayName("Decreasing Account"), NotNull]
        //[NotMapped]
        //public System.String? DecreasingAccount
        //{
        //    get => fields.DecreasingAccount[this];
        //    set => fields.DecreasingAccount[this] = value;
        //}

        //[DisplayName("Purchase Account"), NotNull]
        //[NotMapped]
        //public System.String? PurchaseAccount
        //{
        //    get => fields.PurchaseAccount[this];
        //    set => fields.PurchaseAccount[this] = value;
        //}

        //[DisplayName("Eu Revenues Account"), Column("EURevenuesAccount"), NotNull]
        //[NotMapped]
        //public System.String? EuRevenuesAccount
        //{
        //    get => fields.EuRevenuesAccount[this];
        //    set => fields.EuRevenuesAccount[this] = value;
        //}

        //[DisplayName("Returning Account"), NotNull]
        //[NotMapped]
        //public System.String? ReturningAccount
        //{
        //    get => fields.ReturningAccount[this];
        //    set => fields.ReturningAccount[this] = value;
        //}

        //[DisplayName("Shipped Goods Account"), NotNull]
        //[NotMapped]
        //public System.String? ShippedGoodsAccount
        //{
        //    get => fields.ShippedGoodsAccount[this];
        //    set => fields.ShippedGoodsAccount[this] = value;
        //}

        //[DisplayName("Stock Inflation Adjust Account"), NotNull]
        //[NotMapped]
        //public System.String? StockInflationAdjustAccount
        //{
        //    get => fields.StockInflationAdjustAccount[this];
        //    set => fields.StockInflationAdjustAccount[this] = value;
        //}

        //[DisplayName("Allow Use Tax"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? AllowUseTax
        //{
        //    get => fields.AllowUseTax[this];
        //    set => fields.AllowUseTax[this] = value;
        //}

        //[DisplayName("Cost Inflation Account"), NotNull]
        //[NotMapped]
        //public System.String? CostInflationAccount
        //{
        //    get => fields.CostInflationAccount[this];
        //    set => fields.CostInflationAccount[this] = value;
        //}

        //[DisplayName("Foreign Expenses Account"), NotNull]
        //[NotMapped]
        //public System.String? ForeignExpensesAccount
        //{
        //    get => fields.ForeignExpensesAccount[this];
        //    set => fields.ForeignExpensesAccount[this] = value;
        //}

        //[DisplayName("Eu Expenses Account"), Column("EUExpensesAccount"), NotNull]
        //[NotMapped]
        //public System.String? EuExpensesAccount
        //{
        //    get => fields.EuExpensesAccount[this];
        //    set => fields.EuExpensesAccount[this] = value;
        //}

        //[DisplayName("Cost Inflation Offset Account"), NotNull]
        //[NotMapped]
        //public System.String? CostInflationOffsetAccount
        //{
        //    get => fields.CostInflationOffsetAccount[this];
        //    set => fields.CostInflationOffsetAccount[this] = value;
        //}

        //[DisplayName("Expenses Clearing Account"), NotNull]
        //[NotMapped]
        //public System.String? ExpensesClearingAccount
        //{
        //    get => fields.ExpensesClearingAccount[this];
        //    set => fields.ExpensesClearingAccount[this] = value;
        //}

        //[DisplayName("Purchase Returning Account"), NotNull]
        //[NotMapped]
        //public System.String? PurchaseReturningAccount
        //{
        //    get => fields.PurchaseReturningAccount[this];
        //    set => fields.PurchaseReturningAccount[this] = value;
        //}

        //[DisplayName("Vat In Revenue Account"), Column("VATInRevenueAccount"), NotNull]
        //[NotMapped]
        //public System.String? VatInRevenueAccount
        //{
        //    get => fields.VatInRevenueAccount[this];
        //    set => fields.VatInRevenueAccount[this] = value;
        //}

        //[DisplayName("Federal Tax Id"), Column("FederalTaxID"), NotNull]
        //[NotMapped]
        //public System.String? FederalTaxId
        //{
        //    get => fields.FederalTaxId[this];
        //    set => fields.FederalTaxId[this] = value;
        //}

        //[DisplayName("Location"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? Location
        //{
        //    get => fields.Location[this];
        //    set => fields.Location[this] = value;
        //}

        //[DisplayName("Block"), NotNull]
        //[NotMapped]
        //public System.String? Block
        //{
        //    get => fields.Block[this];
        //    set => fields.Block[this] = value;
        //}

        //[DisplayName("Expense Account"), NotNull]
        //[NotMapped]
        //public System.String? ExpenseAccount
        //{
        //    get => fields.ExpenseAccount[this];
        //    set => fields.ExpenseAccount[this] = value;
        //}

        //[DisplayName("Decrease Gl Account"), Column("DecreaseGLAccount"), NotNull]
        //[NotMapped]
        //public System.String? DecreaseGlAccount
        //{
        //    get => fields.DecreaseGlAccount[this];
        //    set => fields.DecreaseGlAccount[this] = value;
        //}

        //[DisplayName("Revenues Account"), NotNull]
        //[NotMapped]
        //public System.String? RevenuesAccount
        //{
        //    get => fields.RevenuesAccount[this];
        //    set => fields.RevenuesAccount[this] = value;
        //}

        //[DisplayName("Tax Group"), NotNull]
        //[NotMapped]
        //public System.String? TaxGroup
        //{
        //    get => fields.TaxGroup[this];
        //    set => fields.TaxGroup[this] = value;
        //}

        //[DisplayName("Exempt Revenues Account"), NotNull]
        //[NotMapped]
        //public System.String? ExemptRevenuesAccount
        //{
        //    get => fields.ExemptRevenuesAccount[this];
        //    set => fields.ExemptRevenuesAccount[this] = value;
        //}

        //[DisplayName("Purchase Offset Account"), NotNull]
        //[NotMapped]
        //public System.String? PurchaseOffsetAccount
        //{
        //    get => fields.PurchaseOffsetAccount[this];
        //    set => fields.PurchaseOffsetAccount[this] = value;
        //}

        //[DisplayName("Cost Of Goods Sold"), NotNull]
        //[NotMapped]
        //public System.String? CostOfGoodsSold
        //{
        //    get => fields.CostOfGoodsSold[this];
        //    set => fields.CostOfGoodsSold[this] = value;
        //}

      

        //[DisplayName("State"), NotNull]
        //[NotMapped]
        //public System.String? State
        //{
        //    get => fields.State[this];
        //    set => fields.State[this] = value;
        //}

        //[DisplayName("City"), NotNull]
        //[NotMapped]
        //public System.String? City
        //{
        //    get => fields.City[this];
        //    set => fields.City[this] = value;
        //}

        //[DisplayName("Price Differences Account"), NotNull]
        //[NotMapped]
        //public System.String? PriceDifferencesAccount
        //{
        //    get => fields.PriceDifferencesAccount[this];
        //    set => fields.PriceDifferencesAccount[this] = value;
        //}

        //[DisplayName("Variance Account"), NotNull]
        //[NotMapped]
        //public System.String? VarianceAccount
        //{
        //    get => fields.VarianceAccount[this];
        //    set => fields.VarianceAccount[this] = value;
        //}

        //[DisplayName("Country"), NotNull]
        //[NotMapped]
        //public System.String? Country
        //{
        //    get => fields.Country[this];
        //    set => fields.Country[this] = value;
        //}

        //[DisplayName("Increase Gl Account"), Column("IncreaseGLAccount"), NotNull]
        //[NotMapped]
        //public System.String? IncreaseGlAccount
        //{
        //    get => fields.IncreaseGlAccount[this];
        //    set => fields.IncreaseGlAccount[this] = value;
        //}

        //[DisplayName("Exchange Rate Differences Account"), NotNull]
        //[NotMapped]
        //public System.String? ExchangeRateDifferencesAccount
        //{
        //    get => fields.ExchangeRateDifferencesAccount[this];
        //    set => fields.ExchangeRateDifferencesAccount[this] = value;
        //}

        //[DisplayName("Wip Material Account"), Column("WIPMaterialAccount"), NotNull]
        //[NotMapped]
        //public System.String? WipMaterialAccount
        //{
        //    get => fields.WipMaterialAccount[this];
        //    set => fields.WipMaterialAccount[this] = value;
        //}



        //[DisplayName("Drop Ship"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DropShip
        //{
        //    get => fields.DropShip[this];
        //    set => fields.DropShip[this] = value;
        //}

        //[DisplayName("Wip Material Variance Account"), Column("WIPMaterialVarianceAccount"), NotNull]
        //[NotMapped]
        //public System.String? WipMaterialVarianceAccount
        //{
        //    get => fields.WipMaterialVarianceAccount[this];
        //    set => fields.WipMaterialVarianceAccount[this] = value;
        //}

        //[DisplayName("Transfers Acc"), NotNull]
        //[NotMapped]
        //public System.String? TransfersAcc
        //{
        //    get => fields.TransfersAcc[this];
        //    set => fields.TransfersAcc[this] = value;
        //}

        //[DisplayName("Internal Key"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? InternalKey
        //{
        //    get => fields.InternalKey[this];
        //    set => fields.InternalKey[this] = value;
        //}

        //[DisplayName("Foreign Revenues Acc"), NotNull]
        //[NotMapped]
        //public System.String? ForeignRevenuesAcc
        //{
        //    get => fields.ForeignRevenuesAcc[this];
        //    set => fields.ForeignRevenuesAcc[this] = value;
        //}

        //[DisplayName("Building Floor Room"), NotNull]
        //[NotMapped]
        //public System.String? BuildingFloorRoom
        //{
        //    get => fields.BuildingFloorRoom[this];
        //    set => fields.BuildingFloorRoom[this] = value;
        //}

        //[DisplayName("County"), NotNull]
        //[NotMapped]
        //public System.String? County
        //{
        //    get => fields.County[this];
        //    set => fields.County[this] = value;
        //}

        //[DisplayName("Nettable"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? Nettable
        //{
        //    get => fields.Nettable[this];
        //    set => fields.Nettable[this] = value;
        //}

        //[DisplayName("Increasing Acc"), NotNull]
        //[NotMapped]
        //public System.String? IncreasingAcc
        //{
        //    get => fields.IncreasingAcc[this];
        //    set => fields.IncreasingAcc[this] = value;
        //}

        //[DisplayName("Expense Offseting Act"), NotNull]
        //[NotMapped]
        //public System.String? ExpenseOffsetingAct
        //{
        //    get => fields.ExpenseOffsetingAct[this];
        //    set => fields.ExpenseOffsetingAct[this] = value;
        //}

        //[DisplayName("Goods Clearing Acc"), NotNull]
        //[NotMapped]
        //public System.String? GoodsClearingAcc
        //{
        //    get => fields.GoodsClearingAcc[this];
        //    set => fields.GoodsClearingAcc[this] = value;
        //}

        //[DisplayName("Stock Account"), NotNull]
        //[NotMapped]
        //public System.String? StockAccount
        //{
        //    get => fields.StockAccount[this];
        //    set => fields.StockAccount[this] = value;
        //}

        //[DisplayName("Business Place Id"), Column("BusinessPlaceID"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? BusinessPlaceId
        //{
        //    get => fields.BusinessPlaceId[this];
        //    set => fields.BusinessPlaceId[this] = value;
        //}

        //[DisplayName("Purchase Credit Acc"), NotNull]
        //[NotMapped]
        //public System.String? PurchaseCreditAcc
        //{
        //    get => fields.PurchaseCreditAcc[this];
        //    set => fields.PurchaseCreditAcc[this] = value;
        //}

        //[DisplayName("Eu Purchase Credit Acc"), Column("EUPurchaseCreditAcc"), NotNull]
        //[NotMapped]
        //public System.String? EuPurchaseCreditAcc
        //{
        //    get => fields.EuPurchaseCreditAcc[this];
        //    set => fields.EuPurchaseCreditAcc[this] = value;
        //}

        //[DisplayName("Foreign Purchase Credit Acc"), NotNull]
        //[NotMapped]
        //public System.String? ForeignPurchaseCreditAcc
        //{
        //    get => fields.ForeignPurchaseCreditAcc[this];
        //    set => fields.ForeignPurchaseCreditAcc[this] = value;
        //}

        //[DisplayName("Sales Credit Acc"), NotNull]
        //[NotMapped]
        //public System.String? SalesCreditAcc
        //{
        //    get => fields.SalesCreditAcc[this];
        //    set => fields.SalesCreditAcc[this] = value;
        //}

        //[DisplayName("Sales Credit Eu Acc"), Column("SalesCreditEUAcc"), NotNull]
        //[NotMapped]
        //public System.String? SalesCreditEuAcc
        //{
        //    get => fields.SalesCreditEuAcc[this];
        //    set => fields.SalesCreditEuAcc[this] = value;
        //}

        //[DisplayName("Exempted Credits"), NotNull]
        //[NotMapped]
        //public System.String? ExemptedCredits
        //{
        //    get => fields.ExemptedCredits[this];
        //    set => fields.ExemptedCredits[this] = value;
        //}

        //[DisplayName("Sales Credit Foreign Acc"), NotNull]
        //[NotMapped]
        //public System.String? SalesCreditForeignAcc
        //{
        //    get => fields.SalesCreditForeignAcc[this];
        //    set => fields.SalesCreditForeignAcc[this] = value;
        //}

        //[DisplayName("Negative Inventory Adjustment Account"), NotNull]
        //[NotMapped]
        //public System.String? NegativeInventoryAdjustmentAccount
        //{
        //    get => fields.NegativeInventoryAdjustmentAccount[this];
        //    set => fields.NegativeInventoryAdjustmentAccount[this] = value;
        //}

        //[DisplayName("Wh Ship To Name"), Column("WHShipToName"), NotNull]
        //[NotMapped]
        //public System.String? WhShipToName
        //{
        //    get => fields.WhShipToName[this];
        //    set => fields.WhShipToName[this] = value;
        //}

        //[DisplayName("Excisable"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? Excisable
        //{
        //    get => fields.Excisable[this];
        //    set => fields.Excisable[this] = value;
        //}

        //[DisplayName("Wh Incoming Cenvat Account"), Column("WHIncomingCenvatAccount"), NotNull]
        //[NotMapped]
        //public System.String? WhIncomingCenvatAccount
        //{
        //    get => fields.WhIncomingCenvatAccount[this];
        //    set => fields.WhIncomingCenvatAccount[this] = value;
        //}

        //[DisplayName("Wh Outgoing Cenvat Account"), Column("WHOutgoingCenvatAccount"), NotNull]
        //[NotMapped]
        //public System.String? WhOutgoingCenvatAccount
        //{
        //    get => fields.WhOutgoingCenvatAccount[this];
        //    set => fields.WhOutgoingCenvatAccount[this] = value;
        //}

        //[DisplayName("Stock In Transit Account"), NotNull]
        //[NotMapped]
        //public System.String? StockInTransitAccount
        //{
        //    get => fields.StockInTransitAccount[this];
        //    set => fields.StockInTransitAccount[this] = value;
        //}

        //[DisplayName("Wip Offset Profit And Loss Account"), NotNull]
        //[NotMapped]
        //public System.String? WipOffsetProfitAndLossAccount
        //{
        //    get => fields.WipOffsetProfitAndLossAccount[this];
        //    set => fields.WipOffsetProfitAndLossAccount[this] = value;
        //}

        //[DisplayName("Inventory Offset Profit And Loss Account"), NotNull]
        //[NotMapped]
        //public System.String? InventoryOffsetProfitAndLossAccount
        //{
        //    get => fields.InventoryOffsetProfitAndLossAccount[this];
        //    set => fields.InventoryOffsetProfitAndLossAccount[this] = value;
        //}

        //[DisplayName("Address Type"), NotNull]
        //[NotMapped]
        //public System.String? AddressType
        //{
        //    get => fields.AddressType[this];
        //    set => fields.AddressType[this] = value;
        //}

        //[DisplayName("Street No"), NotNull]
        //[NotMapped]
        //public System.String? StreetNo
        //{
        //    get => fields.StreetNo[this];
        //    set => fields.StreetNo[this] = value;
        //}

        //[DisplayName("Storekeeper"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? Storekeeper
        //{
        //    get => fields.Storekeeper[this];
        //    set => fields.Storekeeper[this] = value;
        //}

        //[DisplayName("Shipper"), NotNull]
        //[NotMapped]
        //public System.String? Shipper
        //{
        //    get => fields.Shipper[this];
        //    set => fields.Shipper[this] = value;
        //}

        //[DisplayName("Manage Serial And Batch Numbers"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ManageSerialAndBatchNumbers
        //{
        //    get => fields.ManageSerialAndBatchNumbers[this];
        //    set => fields.ManageSerialAndBatchNumbers[this] = value;
        //}

        //[DisplayName("Global Location Number"), NotNull]
        //[NotMapped]
        //public System.String? GlobalLocationNumber
        //{
        //    get => fields.GlobalLocationNumber[this];
        //    set => fields.GlobalLocationNumber[this] = value;
        //}

        //[DisplayName("Enable Bin Locations"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? EnableBinLocations
        //{
        //    get => fields.EnableBinLocations[this];
        //    set => fields.EnableBinLocations[this] = value;
        //}

        //[DisplayName("Bin Loc Code Separator"), NotNull]
        //[NotMapped]
        //public System.String? BinLocCodeSeparator
        //{
        //    get => fields.BinLocCodeSeparator[this];
        //    set => fields.BinLocCodeSeparator[this] = value;
        //}

        //[DisplayName("Default Bin"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? DefaultBin
        //{
        //    get => fields.DefaultBin[this];
        //    set => fields.DefaultBin[this] = value;
        //}

        //[DisplayName("Default Bin Enforced"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DefaultBinEnforced
        //{
        //    get => fields.DefaultBinEnforced[this];
        //    set => fields.DefaultBinEnforced[this] = value;
        //}

        //[DisplayName("Auto Alloc On Issue"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoDocWhsAutoIssueMethod]? AutoAllocOnIssue
        //{
        //    get => fields.AutoAllocOnIssue[this];
        //    set => fields.AutoAllocOnIssue[this] = value;
        //}

        //[DisplayName("Enable Receiving Bin Locations"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? EnableReceivingBinLocations
        //{
        //    get => fields.EnableReceivingBinLocations[this];
        //    set => fields.EnableReceivingBinLocations[this] = value;
        //}

        //[DisplayName("Receiving Bin Locations By"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.ReceivingBinLocationsMethodEnum]? ReceivingBinLocationsBy
        //{
        //    get => fields.ReceivingBinLocationsBy[this];
        //    set => fields.ReceivingBinLocationsBy[this] = value;
        //}

        //[DisplayName("Purchase Balance Account"), NotNull]
        //[NotMapped]
        //public System.String? PurchaseBalanceAccount
        //{
        //    get => fields.PurchaseBalanceAccount[this];
        //    set => fields.PurchaseBalanceAccount[this] = value;
        //}

        //[DisplayName("Inactive"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? Inactive
        //{
        //    get => fields.Inactive[this];
        //    set => fields.Inactive[this] = value;
        //}

        //[DisplayName("Restrict Receipt To Empty Bin Location"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? RestrictReceiptToEmptyBinLocation
        //{
        //    get => fields.RestrictReceiptToEmptyBinLocation[this];
        //    set => fields.RestrictReceiptToEmptyBinLocation[this] = value;
        //}

        //[DisplayName("Receive Up To Max Quantity"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ReceiveUpToMaxQuantity
        //{
        //    get => fields.ReceiveUpToMaxQuantity[this];
        //    set => fields.ReceiveUpToMaxQuantity[this] = value;
        //}

        //[DisplayName("Auto Alloc On Receipt"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.AutoAllocOnReceiptMethodEnum]? AutoAllocOnReceipt
        //{
        //    get => fields.AutoAllocOnReceipt[this];
        //    set => fields.AutoAllocOnReceipt[this] = value;
        //}

        //[DisplayName("Receive Up To Max Weight"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ReceiveUpToMaxWeight
        //{
        //    get => fields.ReceiveUpToMaxWeight[this];
        //    set => fields.ReceiveUpToMaxWeight[this] = value;
        //}

        //[DisplayName("Receive Up To Method"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.ReceivingUpToMethodEnum]? ReceiveUpToMethod
        //{
        //    get => fields.ReceiveUpToMethod[this];
        //    set => fields.ReceiveUpToMethod[this] = value;
        //}

        //[DisplayName("Legal Text"), NotNull]
        //[NotMapped]
        //public System.String? LegalText
        //{
        //    get => fields.LegalText[this];
        //    set => fields.LegalText[this] = value;
        //}

        //[DisplayName("U Id"), Column("U_ID"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? UId
        //{
        //    get => fields.UId[this];
        //    set => fields.UId[this] = value;
        //}

        //[DisplayName("U Tri Whspwflag"), Column("U_TRI_whspwflag"), NotNull]
        //[NotMapped]
        //public System.String? UTriWhspwflag
        //{
        //    get => fields.UTriWhspwflag[this];
        //    set => fields.UTriWhspwflag[this] = value;
        //}

        //[DisplayName("User Default Groups"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.UserDefaultGroup]? UserDefaultGroups
        //{
        //    get => fields.UserDefaultGroups[this];
        //    set => fields.UserDefaultGroups[this] = value;
        //}

        //[DisplayName("Stock Transfers"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer]? StockTransfers
        //{
        //    get => fields.StockTransfers[this];
        //    set => fields.StockTransfers[this] = value;
        //}

        //[DisplayName("Chart Of Account"), NotNull]
        //[NotMapped]
        //public SAPB1.ChartOfAccount? ChartOfAccount
        //{
        //    get => fields.ChartOfAccount[this];
        //    set => fields.ChartOfAccount[this] = value;
        //}

        //[DisplayName("Warehouse Location"), NotNull]
        //[NotMapped]
        //public SAPB1.WarehouseLocation? WarehouseLocation
        //{
        //    get => fields.WarehouseLocation[this];
        //    set => fields.WarehouseLocation[this] = value;
        //}

        //[DisplayName("Sales Tax Code"), NotNull]
        //[NotMapped]
        //public SAPB1.SalesTaxCode? SalesTaxCode
        //{
        //    get => fields.SalesTaxCode[this];
        //    set => fields.SalesTaxCode[this] = value;
        //}

        //[DisplayName("Country2"), NotNull]
        //[NotMapped]
        //public SAPB1.Country? Country2
        //{
        //    get => fields.Country2[this];
        //    set => fields.Country2[this] = value;
        //}

        //[DisplayName("Employee Info"), NotNull]
        //[NotMapped]
        //public SAPB1.EmployeeInfo? EmployeeInfo
        //{
        //    get => fields.EmployeeInfo[this];
        //    set => fields.EmployeeInfo[this] = value;
        //}

        //[DisplayName("Business Partner"), NotNull]
        //[NotMapped]
        //public SAPB1.BusinessPartner? BusinessPartner
        //{
        //    get => fields.BusinessPartner[this];
        //    set => fields.BusinessPartner[this] = value;
        //}

        //[DisplayName("Bin Location"), NotNull]
        //[NotMapped]
        //public SAPB1.BinLocation? BinLocation
        //{
        //    get => fields.BinLocation[this];
        //    set => fields.BinLocation[this] = value;
        //}

        //[DisplayName("Bin Locations"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BinLocation]? BinLocations
        //{
        //    get => fields.BinLocations[this];
        //    set => fields.BinLocations[this] = value;
        //}

        //[DisplayName("Gl Account Advanced Rules"), Column("GLAccountAdvancedRules"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule]? GlAccountAdvancedRules
        //{
        //    get => fields.GlAccountAdvancedRules[this];
        //    set => fields.GlAccountAdvancedRules[this] = value;
        //}

        //[DisplayName("Inventory Transfer Requests"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer]? InventoryTransferRequests
        //{
        //    get => fields.InventoryTransferRequests[this];
        //    set => fields.InventoryTransferRequests[this] = value;
        //}

        //[DisplayName("Resource Capacities"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ResourceCapacity]? ResourceCapacities
        //{
        //    get => fields.ResourceCapacities[this];
        //    set => fields.ResourceCapacities[this] = value;
        //}

        //[DisplayName("Stock Transfer Drafts"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer]? StockTransferDrafts
        //{
        //    get => fields.StockTransferDrafts[this];
        //    set => fields.StockTransferDrafts[this] = value;
        //}

        //[DisplayName("Production Orders"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ProductionOrder]? ProductionOrders
        //{
        //    get => fields.ProductionOrders[this];
        //    set => fields.ProductionOrders[this] = value;
        //}

        //[DisplayName("Business Places"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPlace]? BusinessPlaces
        //{
        //    get => fields.BusinessPlaces[this];
        //    set => fields.BusinessPlaces[this] = value;
        //}

        //[DisplayName("Stock Takings"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTaking]? StockTakings
        //{
        //    get => fields.StockTakings[this];
        //    set => fields.StockTakings[this] = value;
        //}

        public WarehouseRow()
            : base()
        {
        }

        public WarehouseRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public StringField WarehouseCode;
            public StringField WarehouseName;

            //public StringField Street;
            //public StringField StockInflationOffsetAccount;
            //public StringField ZipCode;
            //public StringField DecreasingAccount;
            //public StringField PurchaseAccount;
            //public StringField EuRevenuesAccount;
            //public StringField ReturningAccount;
            //public StringField ShippedGoodsAccount;
            //public StringField StockInflationAdjustAccount;
            //public StringField AllowUseTax;
            //public StringField CostInflationAccount;
            //public StringField ForeignExpensesAccount;
            //public StringField EuExpensesAccount;
            //public StringField CostInflationOffsetAccount;
            //public StringField ExpensesClearingAccount;
            //public StringField PurchaseReturningAccount;
            //public StringField VatInRevenueAccount;
            //public StringField FederalTaxId;
            //public System.Nullable`1[System.Int32]Field Location;
            //public StringField Block;
            //public StringField ExpenseAccount;
            //public StringField DecreaseGlAccount;
            //public StringField RevenuesAccount;
            //public StringField TaxGroup;
            //public StringField ExemptRevenuesAccount;
            //public StringField PurchaseOffsetAccount;
            //public StringField CostOfGoodsSold;
            //public StringField State;
            //public StringField City;
            //public StringField PriceDifferencesAccount;
            //public StringField VarianceAccount;
            //public StringField Country;
            //public StringField IncreaseGlAccount;
            //public StringField ExchangeRateDifferencesAccount;
            //public StringField WipMaterialAccount;
            //public StringField DropShip;
            //public StringField WipMaterialVarianceAccount;
            //public StringField TransfersAcc;
            //public System.Nullable`1[System.Int32]Field InternalKey;
            //public StringField ForeignRevenuesAcc;
            //public StringField BuildingFloorRoom;
            //public StringField County;
            //public StringField Nettable;
            //public StringField IncreasingAcc;
            //public StringField ExpenseOffsetingAct;
            //public StringField GoodsClearingAcc;
            //public StringField StockAccount;
            //public System.Nullable`1[System.Int32]Field BusinessPlaceId;
            //public StringField PurchaseCreditAcc;
            //public StringField EuPurchaseCreditAcc;
            //public StringField ForeignPurchaseCreditAcc;
            //public StringField SalesCreditAcc;
            //public StringField SalesCreditEuAcc;
            //public StringField ExemptedCredits;
            //public StringField SalesCreditForeignAcc;
            //public StringField NegativeInventoryAdjustmentAccount;
            //public StringField WhShipToName;
            //public StringField Excisable;
            //public StringField WhIncomingCenvatAccount;
            //public StringField WhOutgoingCenvatAccount;
            //public StringField StockInTransitAccount;
            //public StringField WipOffsetProfitAndLossAccount;
            //public StringField InventoryOffsetProfitAndLossAccount;
            //public StringField AddressType;
            //public StringField StreetNo;
            //public System.Nullable`1[System.Int32]Field Storekeeper;
            //public StringField Shipper;
            //public StringField ManageSerialAndBatchNumbers;
            //public StringField GlobalLocationNumber;
            //public StringField EnableBinLocations;
            //public StringField BinLocCodeSeparator;
            //public System.Nullable`1[System.Int32]Field DefaultBin;
            //public StringField DefaultBinEnforced;
            //public System.Nullable`1[SAPB1.BoDocWhsAutoIssueMethod]Field AutoAllocOnIssue;
            //public StringField EnableReceivingBinLocations;
            //public System.Nullable`1[SAPB1.ReceivingBinLocationsMethodEnum]Field ReceivingBinLocationsBy;
            //public StringField PurchaseBalanceAccount;
            //public StringField Inactive;
            //public StringField RestrictReceiptToEmptyBinLocation;
            //public StringField ReceiveUpToMaxQuantity;
            //public System.Nullable`1[SAPB1.AutoAllocOnReceiptMethodEnum]Field AutoAllocOnReceipt;
            //public StringField ReceiveUpToMaxWeight;
            //public System.Nullable`1[SAPB1.ReceivingUpToMethodEnum]Field ReceiveUpToMethod;
            //public StringField LegalText;
            //public System.Nullable`1[System.Int32]Field UId;
            //public StringField UTriWhspwflag;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.UserDefaultGroup]Field UserDefaultGroups;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer]Field StockTransfers;
            //public SAPB1.ChartOfAccountField ChartOfAccount;
            //public SAPB1.WarehouseLocationField WarehouseLocation;
            //public SAPB1.SalesTaxCodeField SalesTaxCode;
            //public SAPB1.CountryField Country2;
            //public SAPB1.EmployeeInfoField EmployeeInfo;
            //public SAPB1.BusinessPartnerField BusinessPartner;
            //public SAPB1.BinLocationField BinLocation;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BinLocation]Field BinLocations;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule]Field GlAccountAdvancedRules;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer]Field InventoryTransferRequests;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ResourceCapacity]Field ResourceCapacities;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer]Field StockTransferDrafts;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ProductionOrder]Field ProductionOrders;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPlace]Field BusinessPlaces;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTaking]Field StockTakings;
        }
    }
}
