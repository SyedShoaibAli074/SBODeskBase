using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Warehouse")]
    [BasedOnRow(typeof(WarehouseRow), CheckNames = true)]
    public class WarehouseForm
    {
        public String WarehouseCode { get; set; }
        public String WarehouseName { get; set; }
        //public String StockInflationOffsetAccount { get; set; }
        //public String ZipCode { get; set; }
        //public String DecreasingAccount { get; set; }
        //public String PurchaseAccount { get; set; }
        //public String EuRevenuesAccount { get; set; }
        //public String ReturningAccount { get; set; }
        //public String ShippedGoodsAccount { get; set; }
        //public String StockInflationAdjustAccount { get; set; }
        //public String AllowUseTax { get; set; }
        //public String CostInflationAccount { get; set; }
        //public String ForeignExpensesAccount { get; set; }
        //public String EuExpensesAccount { get; set; }
        //public String CostInflationOffsetAccount { get; set; }
        //public String ExpensesClearingAccount { get; set; }
        //public String PurchaseReturningAccount { get; set; }
        //public String VatInRevenueAccount { get; set; }
        //public String FederalTaxId { get; set; }
        //public System.Nullable`1[System.Int32] Location { get; set; }
        //public String Block { get; set; }
        //public String ExpenseAccount { get; set; }
        //public String DecreaseGlAccount { get; set; }
        //public String RevenuesAccount { get; set; }
        //public String TaxGroup { get; set; }
        //public String ExemptRevenuesAccount { get; set; }
        //public String PurchaseOffsetAccount { get; set; }
        //public String CostOfGoodsSold { get; set; }
       
        //public String State { get; set; }
        //public String City { get; set; }
        //public String PriceDifferencesAccount { get; set; }
        //public String VarianceAccount { get; set; }
        //public String Country { get; set; }
        //public String IncreaseGlAccount { get; set; }
        //public String ExchangeRateDifferencesAccount { get; set; }
        //public String WipMaterialAccount { get; set; }
        //public String DropShip { get; set; }
        //public String WipMaterialVarianceAccount { get; set; }
        //public String TransfersAcc { get; set; }
        //public System.Nullable`1[System.Int32] InternalKey { get; set; }
        //public String ForeignRevenuesAcc { get; set; }
        //public String BuildingFloorRoom { get; set; }
        //public String County { get; set; }
        //public String Nettable { get; set; }
        //public String IncreasingAcc { get; set; }
        //public String ExpenseOffsetingAct { get; set; }
        //public String GoodsClearingAcc { get; set; }
        //public String StockAccount { get; set; }
        //public System.Nullable`1[System.Int32] BusinessPlaceId { get; set; }
        //public String PurchaseCreditAcc { get; set; }
        //public String EuPurchaseCreditAcc { get; set; }
        //public String ForeignPurchaseCreditAcc { get; set; }
        //public String SalesCreditAcc { get; set; }
        //public String SalesCreditEuAcc { get; set; }
        //public String ExemptedCredits { get; set; }
        //public String SalesCreditForeignAcc { get; set; }
        //public String NegativeInventoryAdjustmentAccount { get; set; }
        //public String WhShipToName { get; set; }
        //public String Excisable { get; set; }
        //public String WhIncomingCenvatAccount { get; set; }
        //public String WhOutgoingCenvatAccount { get; set; }
        //public String StockInTransitAccount { get; set; }
        //public String WipOffsetProfitAndLossAccount { get; set; }
        //public String InventoryOffsetProfitAndLossAccount { get; set; }
        //public String AddressType { get; set; }
        //public String StreetNo { get; set; }
        //public System.Nullable`1[System.Int32] Storekeeper { get; set; }
        //public String Shipper { get; set; }
        //public String ManageSerialAndBatchNumbers { get; set; }
        //public String GlobalLocationNumber { get; set; }
        //public String EnableBinLocations { get; set; }
        //public String BinLocCodeSeparator { get; set; }
        //public System.Nullable`1[System.Int32] DefaultBin { get; set; }
        //public String DefaultBinEnforced { get; set; }
        //public System.Nullable`1[SAPB1.BoDocWhsAutoIssueMethod] AutoAllocOnIssue { get; set; }
        //public String EnableReceivingBinLocations { get; set; }
        //public System.Nullable`1[SAPB1.ReceivingBinLocationsMethodEnum] ReceivingBinLocationsBy { get; set; }
        //public String PurchaseBalanceAccount { get; set; }
        //public String Inactive { get; set; }
        //public String RestrictReceiptToEmptyBinLocation { get; set; }
        //public String ReceiveUpToMaxQuantity { get; set; }
        //public System.Nullable`1[SAPB1.AutoAllocOnReceiptMethodEnum] AutoAllocOnReceipt { get; set; }
        //public String ReceiveUpToMaxWeight { get; set; }
        //public System.Nullable`1[SAPB1.ReceivingUpToMethodEnum] ReceiveUpToMethod { get; set; }
        //public String LegalText { get; set; }
        //public System.Nullable`1[System.Int32] UId { get; set; }
        //public String UTriWhspwflag { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.UserDefaultGroup] UserDefaultGroups { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer] StockTransfers { get; set; }
        //public SAPB1.ChartOfAccount ChartOfAccount { get; set; }
        //public SAPB1.WarehouseLocation WarehouseLocation { get; set; }
        //public SAPB1.SalesTaxCode SalesTaxCode { get; set; }
        //public SAPB1.Country Country2 { get; set; }
        //public SAPB1.EmployeeInfo EmployeeInfo { get; set; }
        //public SAPB1.BusinessPartner BusinessPartner { get; set; }
        //public SAPB1.BinLocation BinLocation { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BinLocation] BinLocations { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule] GlAccountAdvancedRules { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer] InventoryTransferRequests { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ResourceCapacity] ResourceCapacities { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTransfer] StockTransferDrafts { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ProductionOrder] ProductionOrders { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPlace] BusinessPlaces { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.StockTaking] StockTakings { get; set; }
    }
}