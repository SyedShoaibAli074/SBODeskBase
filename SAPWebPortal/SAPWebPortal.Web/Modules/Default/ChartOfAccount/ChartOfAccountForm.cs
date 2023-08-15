using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ChartOfAccount")]
    [BasedOnRow(typeof(ChartOfAccountRow), CheckNames = true)]
    public class ChartOfAccountForm
    {
        [ReadOnly(true)]
        public String Name { get; set; }
        //public System.Nullable`1[System.Double] Balance { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] CashAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] BudgetAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ActiveAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] PrimaryAccount { get; set; }
        //public System.Nullable`1[System.Int32] AccountLevel { get; set; }
        //public System.String DataExportCode { get; set; }
        //public System.String FatherAccountKey { get; set; }
        //public System.String ExternalCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] RateConversion { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] TaxLiableAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] TaxExemptAccount { get; set; }
        //public System.Nullable`1[System.Int32] ExternalReconNo { get; set; }
        //public System.Nullable`1[System.Int32] InternalReconNo { get; set; }
        //public System.Nullable`1[SAPB1.BoAccountTypes] AccountType { get; set; }
        //public System.String AcctCurrency { get; set; }
        //public System.Nullable`1[System.Double] BalanceSyscurr { get; set; }
        //public System.Nullable`1[System.Double] BalanceFrgnCurr { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] Protected { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ReconciledAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] LiableForAdvances { get; set; }
        //public System.String ForeignName { get; set; }
        //public System.String Details { get; set; }
        //public System.String ProjectCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] RevaluationCoordinated { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] LockManualTransaction { get; set; }
        //public System.String FormatCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] AllowChangeVatGroup { get; set; }
        //public System.String DefaultVatGroup { get; set; }
        //public System.Nullable`1[System.Int32] Category { get; set; }
        //public System.String TransactionCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] LoadingType { get; set; }
        //public System.String LoadingFactorCode { get; set; }
        //public System.String LoadingFactorCode2 { get; set; }
        //public System.String LoadingFactorCode3 { get; set; }
        //public System.String LoadingFactorCode4 { get; set; }
        //public System.String LoadingFactorCode5 { get; set; }
        //public System.String PlanningLevel { get; set; }
        //public System.String DatevAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DatevAutoAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DatevFirstDataEntry { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] AllowMultipleLinking { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ProjectRelevant { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DistributionRuleRelevant { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DistributionRule2Relevant { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DistributionRule3Relevant { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DistributionRule4Relevant { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] DistributionRule5Relevant { get; set; }
        //public System.Nullable`1[System.Int32] Bplid { get; set; }
        //public System.String BplName { get; set; }
        //public System.String VatRegNum { get; set; }
        //public System.Nullable`1[SAPB1.SPEDContabilAccountPurposeCode] AccountPurposeCode { get; set; }
        //public System.String ReferentialAccountCode { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] ValidFor { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] ValidFrom { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] ValidTo { get; set; }
        //public System.String ValidRemarks { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] FrozenFor { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] FrozenFrom { get; set; }
        //public System.Nullable`1[System.DateTimeOffset] FrozenTo { get; set; }
        //public System.String FrozenRemarks { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] BlockManualPosting { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] CashFlowRelevant { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] Pcn874ReportRelevant { get; set; }
        //public System.String PrimaryClosingAccount { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] CostAccountingOnly { get; set; }
        //public System.Nullable`1[SAPB1.BoYesNoEnum] CostElementRelevant { get; set; }
        //public System.String CostElementCode { get; set; }
        //public System.String StandardAccountCode { get; set; }
        //public System.String TaxonomyCode { get; set; }
        //public System.Nullable`1[System.Int32] IncomeClassificationCategory { get; set; }
        //public System.Nullable`1[System.Int32] IncomeClassificationType { get; set; }
        //public System.Nullable`1[System.Int32] ExpenseClassificationCategory { get; set; }
        //public System.Nullable`1[System.Int32] ExpenseClassificationType { get; set; }
        //public System.String UZPostType { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Warehouse] Warehouses { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.AccrualType] AccrualTypes { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxCode] WithholdingTaxCodes { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseDeliveryNotes { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] CorrectionPurchaseInvoice { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.VatGroup] VatGroups { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Item] Items { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] CorrectionInvoiceReversal { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] CorrectionInvoice { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] InventoryGenEntries { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] Orders { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.FAAccountDetermination] FaAccountDeterminations { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WizardPaymentMethod] WizardPaymentMethods { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule] GlAccountAdvancedRules { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] InventoryGenExits { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] Drafts { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.AdditionalExpense] AdditionalExpenses { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.CustomsGroup] CustomsGroups { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseCreditNotes { get; set; }
        //public SAPB1.Currency Currency { get; set; }
        //public SAPB1.Project Project { get; set; }
        //public SAPB1.AccountCategory AccountCategory { get; set; }
        //public SAPB1.TransactionCode TransactionCode2 { get; set; }
        //public SAPB1.DistributionRule DistributionRule { get; set; }
        //public SAPB1.CostElement CostElement { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] ReturnRequest { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] DeliveryNotes { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseInvoices { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.SalesTaxAuthority] SalesTaxAuthorities { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] Invoices { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] CreditNotes { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment] PaymentDrafts { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DunningTerm] DunningTerms { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPartner] BusinessPartners { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] DownPayments { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseDownPayments { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseReturns { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseOrders { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] Quotations { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] Returns { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.HouseBankAccount] HouseBankAccounts { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] GoodsReturnRequest { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment] IncomingPayments { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ExpenseTypeData] ExpenseTypes { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseRequests { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BankPage] BankPages { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] CorrectionPurchaseInvoiceReversal { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPlace] BusinessPlaces { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.CreditCard] CreditCards { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment] VendorPayments { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ItemGroups] ItemGroups { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document] PurchaseQuotations { get; set; }
    }
}