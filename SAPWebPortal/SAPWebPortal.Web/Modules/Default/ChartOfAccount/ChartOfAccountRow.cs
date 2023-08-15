using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), ServiceLayer("ChartOfAccounts")]
    [DisplayName("Chart Of Account"), InstanceName("Chart Of Account")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [NotMapped]
    public sealed class ChartOfAccountRow : Row<ChartOfAccountRow.RowFields>, IIdRow
    {
        [DisplayName("Code"), NotNull, SAPPrimaryKey, IdProperty, NameProperty]
        [NotMapped]
        public String Code
        {
            get => fields.Code[this];
            set => fields.Code[this] = value;
        }

        [DisplayName("Name"), NotNull]
        [NotMapped]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        //[DisplayName("Balance"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Double]? Balance
        //{
        //    get => fields.Balance[this];
        //    set => fields.Balance[this] = value;
        //}

        //[DisplayName("Cash Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? CashAccount
        //{
        //    get => fields.CashAccount[this];
        //    set => fields.CashAccount[this] = value;
        //}

        //[DisplayName("Budget Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? BudgetAccount
        //{
        //    get => fields.BudgetAccount[this];
        //    set => fields.BudgetAccount[this] = value;
        //}

        //[DisplayName("Active Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ActiveAccount
        //{
        //    get => fields.ActiveAccount[this];
        //    set => fields.ActiveAccount[this] = value;
        //}

        //[DisplayName("Primary Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? PrimaryAccount
        //{
        //    get => fields.PrimaryAccount[this];
        //    set => fields.PrimaryAccount[this] = value;
        //}

        //[DisplayName("Account Level"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? AccountLevel
        //{
        //    get => fields.AccountLevel[this];
        //    set => fields.AccountLevel[this] = value;
        //}

        //[DisplayName("Data Export Code"), NotNull]
        //[NotMapped]
        //public String DataExportCode
        //{
        //    get => fields.DataExportCode[this];
        //    set => fields.DataExportCode[this] = value;
        //}

        //[DisplayName("Father Account Key"), NotNull]
        //[NotMapped]
        //public String FatherAccountKey
        //{
        //    get => fields.FatherAccountKey[this];
        //    set => fields.FatherAccountKey[this] = value;
        //}

        //[DisplayName("External Code"), NotNull]
        //[NotMapped]
        //public String ExternalCode
        //{
        //    get => fields.ExternalCode[this];
        //    set => fields.ExternalCode[this] = value;
        //}

        //[DisplayName("Rate Conversion"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? RateConversion
        //{
        //    get => fields.RateConversion[this];
        //    set => fields.RateConversion[this] = value;
        //}

        //[DisplayName("Tax Liable Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? TaxLiableAccount
        //{
        //    get => fields.TaxLiableAccount[this];
        //    set => fields.TaxLiableAccount[this] = value;
        //}

        //[DisplayName("Tax Exempt Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? TaxExemptAccount
        //{
        //    get => fields.TaxExemptAccount[this];
        //    set => fields.TaxExemptAccount[this] = value;
        //}

        //[DisplayName("External Recon No"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? ExternalReconNo
        //{
        //    get => fields.ExternalReconNo[this];
        //    set => fields.ExternalReconNo[this] = value;
        //}

        //[DisplayName("Internal Recon No"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? InternalReconNo
        //{
        //    get => fields.InternalReconNo[this];
        //    set => fields.InternalReconNo[this] = value;
        //}

        //[DisplayName("Account Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoAccountTypes]? AccountType
        //{
        //    get => fields.AccountType[this];
        //    set => fields.AccountType[this] = value;
        //}

        //[DisplayName("Acct Currency"), NotNull]
        //[NotMapped]
        //public String AcctCurrency
        //{
        //    get => fields.AcctCurrency[this];
        //    set => fields.AcctCurrency[this] = value;
        //}

        //[DisplayName("Balance Syscurr"), Column("Balance_syscurr"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Double]? BalanceSyscurr
        //{
        //    get => fields.BalanceSyscurr[this];
        //    set => fields.BalanceSyscurr[this] = value;
        //}

        //[DisplayName("Balance Frgn Curr"), Column("Balance_FrgnCurr"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Double]? BalanceFrgnCurr
        //{
        //    get => fields.BalanceFrgnCurr[this];
        //    set => fields.BalanceFrgnCurr[this] = value;
        //}

        //[DisplayName("Protected"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? Protected
        //{
        //    get => fields.Protected[this];
        //    set => fields.Protected[this] = value;
        //}

        //[DisplayName("Reconciled Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ReconciledAccount
        //{
        //    get => fields.ReconciledAccount[this];
        //    set => fields.ReconciledAccount[this] = value;
        //}

        //[DisplayName("Liable For Advances"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? LiableForAdvances
        //{
        //    get => fields.LiableForAdvances[this];
        //    set => fields.LiableForAdvances[this] = value;
        //}

        //[DisplayName("Foreign Name"), NotNull]
        //[NotMapped]
        //public String ForeignName
        //{
        //    get => fields.ForeignName[this];
        //    set => fields.ForeignName[this] = value;
        //}

        //[DisplayName("Details"), NotNull]
        //[NotMapped]
        //public String Details
        //{
        //    get => fields.Details[this];
        //    set => fields.Details[this] = value;
        //}

        //[DisplayName("Project Code"), NotNull]
        //[NotMapped]
        //public String ProjectCode
        //{
        //    get => fields.ProjectCode[this];
        //    set => fields.ProjectCode[this] = value;
        //}

        //[DisplayName("Revaluation Coordinated"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? RevaluationCoordinated
        //{
        //    get => fields.RevaluationCoordinated[this];
        //    set => fields.RevaluationCoordinated[this] = value;
        //}

        //[DisplayName("Lock Manual Transaction"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? LockManualTransaction
        //{
        //    get => fields.LockManualTransaction[this];
        //    set => fields.LockManualTransaction[this] = value;
        //}

        //[DisplayName("Format Code"), NotNull]
        //[NotMapped]
        //public String FormatCode
        //{
        //    get => fields.FormatCode[this];
        //    set => fields.FormatCode[this] = value;
        //}

        //[DisplayName("Allow Change Vat Group"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? AllowChangeVatGroup
        //{
        //    get => fields.AllowChangeVatGroup[this];
        //    set => fields.AllowChangeVatGroup[this] = value;
        //}

        //[DisplayName("Default Vat Group"), NotNull]
        //[NotMapped]
        //public String DefaultVatGroup
        //{
        //    get => fields.DefaultVatGroup[this];
        //    set => fields.DefaultVatGroup[this] = value;
        //}

        //[DisplayName("Category"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? Category
        //{
        //    get => fields.Category[this];
        //    set => fields.Category[this] = value;
        //}

        //[DisplayName("Transaction Code"), NotNull]
        //[NotMapped]
        //public String TransactionCode
        //{
        //    get => fields.TransactionCode[this];
        //    set => fields.TransactionCode[this] = value;
        //}

        //[DisplayName("Loading Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? LoadingType
        //{
        //    get => fields.LoadingType[this];
        //    set => fields.LoadingType[this] = value;
        //}

        //[DisplayName("Loading Factor Code"), NotNull]
        //[NotMapped]
        //public String LoadingFactorCode
        //{
        //    get => fields.LoadingFactorCode[this];
        //    set => fields.LoadingFactorCode[this] = value;
        //}

        //[DisplayName("Loading Factor Code2"), NotNull]
        //[NotMapped]
        //public String LoadingFactorCode2
        //{
        //    get => fields.LoadingFactorCode2[this];
        //    set => fields.LoadingFactorCode2[this] = value;
        //}

        //[DisplayName("Loading Factor Code3"), NotNull]
        //[NotMapped]
        //public String LoadingFactorCode3
        //{
        //    get => fields.LoadingFactorCode3[this];
        //    set => fields.LoadingFactorCode3[this] = value;
        //}

        //[DisplayName("Loading Factor Code4"), NotNull]
        //[NotMapped]
        //public String LoadingFactorCode4
        //{
        //    get => fields.LoadingFactorCode4[this];
        //    set => fields.LoadingFactorCode4[this] = value;
        //}

        //[DisplayName("Loading Factor Code5"), NotNull]
        //[NotMapped]
        //public String LoadingFactorCode5
        //{
        //    get => fields.LoadingFactorCode5[this];
        //    set => fields.LoadingFactorCode5[this] = value;
        //}

        //[DisplayName("Planning Level"), NotNull]
        //[NotMapped]
        //public String PlanningLevel
        //{
        //    get => fields.PlanningLevel[this];
        //    set => fields.PlanningLevel[this] = value;
        //}

        //[DisplayName("Datev Account"), NotNull]
        //[NotMapped]
        //public String DatevAccount
        //{
        //    get => fields.DatevAccount[this];
        //    set => fields.DatevAccount[this] = value;
        //}

        //[DisplayName("Datev Auto Account"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DatevAutoAccount
        //{
        //    get => fields.DatevAutoAccount[this];
        //    set => fields.DatevAutoAccount[this] = value;
        //}

        //[DisplayName("Datev First Data Entry"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DatevFirstDataEntry
        //{
        //    get => fields.DatevFirstDataEntry[this];
        //    set => fields.DatevFirstDataEntry[this] = value;
        //}

        //[DisplayName("Allow Multiple Linking"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? AllowMultipleLinking
        //{
        //    get => fields.AllowMultipleLinking[this];
        //    set => fields.AllowMultipleLinking[this] = value;
        //}

        //[DisplayName("Project Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ProjectRelevant
        //{
        //    get => fields.ProjectRelevant[this];
        //    set => fields.ProjectRelevant[this] = value;
        //}

        //[DisplayName("Distribution Rule Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DistributionRuleRelevant
        //{
        //    get => fields.DistributionRuleRelevant[this];
        //    set => fields.DistributionRuleRelevant[this] = value;
        //}

        //[DisplayName("Distribution Rule2 Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DistributionRule2Relevant
        //{
        //    get => fields.DistributionRule2Relevant[this];
        //    set => fields.DistributionRule2Relevant[this] = value;
        //}

        //[DisplayName("Distribution Rule3 Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DistributionRule3Relevant
        //{
        //    get => fields.DistributionRule3Relevant[this];
        //    set => fields.DistributionRule3Relevant[this] = value;
        //}

        //[DisplayName("Distribution Rule4 Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DistributionRule4Relevant
        //{
        //    get => fields.DistributionRule4Relevant[this];
        //    set => fields.DistributionRule4Relevant[this] = value;
        //}

        //[DisplayName("Distribution Rule5 Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? DistributionRule5Relevant
        //{
        //    get => fields.DistributionRule5Relevant[this];
        //    set => fields.DistributionRule5Relevant[this] = value;
        //}

        //[DisplayName("Bplid"), Column("BPLID"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? Bplid
        //{
        //    get => fields.Bplid[this];
        //    set => fields.Bplid[this] = value;
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

        //[DisplayName("Account Purpose Code"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.SPEDContabilAccountPurposeCode]? AccountPurposeCode
        //{
        //    get => fields.AccountPurposeCode[this];
        //    set => fields.AccountPurposeCode[this] = value;
        //}

        //[DisplayName("Referential Account Code"), NotNull]
        //[NotMapped]
        //public String ReferentialAccountCode
        //{
        //    get => fields.ReferentialAccountCode[this];
        //    set => fields.ReferentialAccountCode[this] = value;
        //}

        //[DisplayName("Valid For"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? ValidFor
        //{
        //    get => fields.ValidFor[this];
        //    set => fields.ValidFor[this] = value;
        //}

        //[DisplayName("Valid From"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.DateTimeOffset]? ValidFrom
        //{
        //    get => fields.ValidFrom[this];
        //    set => fields.ValidFrom[this] = value;
        //}

        //[DisplayName("Valid To"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.DateTimeOffset]? ValidTo
        //{
        //    get => fields.ValidTo[this];
        //    set => fields.ValidTo[this] = value;
        //}

        //[DisplayName("Valid Remarks"), NotNull]
        //[NotMapped]
        //public String ValidRemarks
        //{
        //    get => fields.ValidRemarks[this];
        //    set => fields.ValidRemarks[this] = value;
        //}

        //[DisplayName("Frozen For"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? FrozenFor
        //{
        //    get => fields.FrozenFor[this];
        //    set => fields.FrozenFor[this] = value;
        //}

        //[DisplayName("Frozen From"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.DateTimeOffset]? FrozenFrom
        //{
        //    get => fields.FrozenFrom[this];
        //    set => fields.FrozenFrom[this] = value;
        //}

        //[DisplayName("Frozen To"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.DateTimeOffset]? FrozenTo
        //{
        //    get => fields.FrozenTo[this];
        //    set => fields.FrozenTo[this] = value;
        //}

        //[DisplayName("Frozen Remarks"), NotNull]
        //[NotMapped]
        //public String FrozenRemarks
        //{
        //    get => fields.FrozenRemarks[this];
        //    set => fields.FrozenRemarks[this] = value;
        //}

        //[DisplayName("Block Manual Posting"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? BlockManualPosting
        //{
        //    get => fields.BlockManualPosting[this];
        //    set => fields.BlockManualPosting[this] = value;
        //}

        //[DisplayName("Cash Flow Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? CashFlowRelevant
        //{
        //    get => fields.CashFlowRelevant[this];
        //    set => fields.CashFlowRelevant[this] = value;
        //}

        //[DisplayName("Pcn874 Report Relevant"), Column("PCN874ReportRelevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? Pcn874ReportRelevant
        //{
        //    get => fields.Pcn874ReportRelevant[this];
        //    set => fields.Pcn874ReportRelevant[this] = value;
        //}

        //[DisplayName("Primary Closing Account"), NotNull]
        //[NotMapped]
        //public String PrimaryClosingAccount
        //{
        //    get => fields.PrimaryClosingAccount[this];
        //    set => fields.PrimaryClosingAccount[this] = value;
        //}

        //[DisplayName("Cost Accounting Only"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? CostAccountingOnly
        //{
        //    get => fields.CostAccountingOnly[this];
        //    set => fields.CostAccountingOnly[this] = value;
        //}

        //[DisplayName("Cost Element Relevant"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoYesNoEnum]? CostElementRelevant
        //{
        //    get => fields.CostElementRelevant[this];
        //    set => fields.CostElementRelevant[this] = value;
        //}

        //[DisplayName("Cost Element Code"), NotNull]
        //[NotMapped]
        //public String CostElementCode
        //{
        //    get => fields.CostElementCode[this];
        //    set => fields.CostElementCode[this] = value;
        //}

        //[DisplayName("Standard Account Code"), NotNull]
        //[NotMapped]
        //public String StandardAccountCode
        //{
        //    get => fields.StandardAccountCode[this];
        //    set => fields.StandardAccountCode[this] = value;
        //}

        //[DisplayName("Taxonomy Code"), NotNull]
        //[NotMapped]
        //public String TaxonomyCode
        //{
        //    get => fields.TaxonomyCode[this];
        //    set => fields.TaxonomyCode[this] = value;
        //}

        //[DisplayName("Income Classification Category"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? IncomeClassificationCategory
        //{
        //    get => fields.IncomeClassificationCategory[this];
        //    set => fields.IncomeClassificationCategory[this] = value;
        //}

        //[DisplayName("Income Classification Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? IncomeClassificationType
        //{
        //    get => fields.IncomeClassificationType[this];
        //    set => fields.IncomeClassificationType[this] = value;
        //}

        //[DisplayName("Expense Classification Category"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? ExpenseClassificationCategory
        //{
        //    get => fields.ExpenseClassificationCategory[this];
        //    set => fields.ExpenseClassificationCategory[this] = value;
        //}

        //[DisplayName("Expense Classification Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? ExpenseClassificationType
        //{
        //    get => fields.ExpenseClassificationType[this];
        //    set => fields.ExpenseClassificationType[this] = value;
        //}

        //[DisplayName("U Z Post Type"), Column("U_Z_PostType"), NotNull]
        //[NotMapped]
        //public String UZPostType
        //{
        //    get => fields.UZPostType[this];
        //    set => fields.UZPostType[this] = value;
        //}

        //[DisplayName("Warehouses"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Warehouse]? Warehouses
        //{
        //    get => fields.Warehouses[this];
        //    set => fields.Warehouses[this] = value;
        //}

        //[DisplayName("Accrual Types"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.AccrualType]? AccrualTypes
        //{
        //    get => fields.AccrualTypes[this];
        //    set => fields.AccrualTypes[this] = value;
        //}

        //[DisplayName("Withholding Tax Codes"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxCode]? WithholdingTaxCodes
        //{
        //    get => fields.WithholdingTaxCodes[this];
        //    set => fields.WithholdingTaxCodes[this] = value;
        //}

        //[DisplayName("Purchase Delivery Notes"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseDeliveryNotes
        //{
        //    get => fields.PurchaseDeliveryNotes[this];
        //    set => fields.PurchaseDeliveryNotes[this] = value;
        //}

        //[DisplayName("Correction Purchase Invoice"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? CorrectionPurchaseInvoice
        //{
        //    get => fields.CorrectionPurchaseInvoice[this];
        //    set => fields.CorrectionPurchaseInvoice[this] = value;
        //}

        //[DisplayName("Vat Groups"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.VatGroup]? VatGroups
        //{
        //    get => fields.VatGroups[this];
        //    set => fields.VatGroups[this] = value;
        //}

        //[DisplayName("Items"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Item]? Items
        //{
        //    get => fields.Items[this];
        //    set => fields.Items[this] = value;
        //}

        //[DisplayName("Correction Invoice Reversal"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? CorrectionInvoiceReversal
        //{
        //    get => fields.CorrectionInvoiceReversal[this];
        //    set => fields.CorrectionInvoiceReversal[this] = value;
        //}

        //[DisplayName("Correction Invoice"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? CorrectionInvoice
        //{
        //    get => fields.CorrectionInvoice[this];
        //    set => fields.CorrectionInvoice[this] = value;
        //}

        //[DisplayName("Inventory Gen Entries"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? InventoryGenEntries
        //{
        //    get => fields.InventoryGenEntries[this];
        //    set => fields.InventoryGenEntries[this] = value;
        //}

        //[DisplayName("Orders"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? Orders
        //{
        //    get => fields.Orders[this];
        //    set => fields.Orders[this] = value;
        //}

        //[DisplayName("Fa Account Determinations"), Column("FAAccountDeterminations"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.FAAccountDetermination]? FaAccountDeterminations
        //{
        //    get => fields.FaAccountDeterminations[this];
        //    set => fields.FaAccountDeterminations[this] = value;
        //}

        //[DisplayName("Wizard Payment Methods"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WizardPaymentMethod]? WizardPaymentMethods
        //{
        //    get => fields.WizardPaymentMethods[this];
        //    set => fields.WizardPaymentMethods[this] = value;
        //}

        //[DisplayName("Gl Account Advanced Rules"), Column("GLAccountAdvancedRules"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule]? GlAccountAdvancedRules
        //{
        //    get => fields.GlAccountAdvancedRules[this];
        //    set => fields.GlAccountAdvancedRules[this] = value;
        //}

        //[DisplayName("Inventory Gen Exits"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? InventoryGenExits
        //{
        //    get => fields.InventoryGenExits[this];
        //    set => fields.InventoryGenExits[this] = value;
        //}

        //[DisplayName("Drafts"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? Drafts
        //{
        //    get => fields.Drafts[this];
        //    set => fields.Drafts[this] = value;
        //}

        //[DisplayName("Additional Expenses"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.AdditionalExpense]? AdditionalExpenses
        //{
        //    get => fields.AdditionalExpenses[this];
        //    set => fields.AdditionalExpenses[this] = value;
        //}

        //[DisplayName("Customs Groups"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.CustomsGroup]? CustomsGroups
        //{
        //    get => fields.CustomsGroups[this];
        //    set => fields.CustomsGroups[this] = value;
        //}

        //[DisplayName("Purchase Credit Notes"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseCreditNotes
        //{
        //    get => fields.PurchaseCreditNotes[this];
        //    set => fields.PurchaseCreditNotes[this] = value;
        //}

        //[DisplayName("Currency"), NotNull]
        //[NotMapped]
        //public SAPB1.Currency? Currency
        //{
        //    get => fields.Currency[this];
        //    set => fields.Currency[this] = value;
        //}

        //[DisplayName("Project"), NotNull]
        //[NotMapped]
        //public SAPB1.Project? Project
        //{
        //    get => fields.Project[this];
        //    set => fields.Project[this] = value;
        //}

        //[DisplayName("Account Category"), NotNull]
        //[NotMapped]
        //public SAPB1.AccountCategory? AccountCategory
        //{
        //    get => fields.AccountCategory[this];
        //    set => fields.AccountCategory[this] = value;
        //}

        //[DisplayName("Transaction Code2"), NotNull]
        //[NotMapped]
        //public SAPB1.TransactionCode? TransactionCode2
        //{
        //    get => fields.TransactionCode2[this];
        //    set => fields.TransactionCode2[this] = value;
        //}

        //[DisplayName("Distribution Rule"), NotNull]
        //[NotMapped]
        //public SAPB1.DistributionRule? DistributionRule
        //{
        //    get => fields.DistributionRule[this];
        //    set => fields.DistributionRule[this] = value;
        //}

        //[DisplayName("Cost Element"), NotNull]
        //[NotMapped]
        //public SAPB1.CostElement? CostElement
        //{
        //    get => fields.CostElement[this];
        //    set => fields.CostElement[this] = value;
        //}

        //[DisplayName("Return Request"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? ReturnRequest
        //{
        //    get => fields.ReturnRequest[this];
        //    set => fields.ReturnRequest[this] = value;
        //}

        //[DisplayName("Delivery Notes"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? DeliveryNotes
        //{
        //    get => fields.DeliveryNotes[this];
        //    set => fields.DeliveryNotes[this] = value;
        //}

        //[DisplayName("Purchase Invoices"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseInvoices
        //{
        //    get => fields.PurchaseInvoices[this];
        //    set => fields.PurchaseInvoices[this] = value;
        //}

        //[DisplayName("Sales Tax Authorities"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.SalesTaxAuthority]? SalesTaxAuthorities
        //{
        //    get => fields.SalesTaxAuthorities[this];
        //    set => fields.SalesTaxAuthorities[this] = value;
        //}

        //[DisplayName("Invoices"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? Invoices
        //{
        //    get => fields.Invoices[this];
        //    set => fields.Invoices[this] = value;
        //}

        //[DisplayName("Credit Notes"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? CreditNotes
        //{
        //    get => fields.CreditNotes[this];
        //    set => fields.CreditNotes[this] = value;
        //}

        //[DisplayName("Payment Drafts"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]? PaymentDrafts
        //{
        //    get => fields.PaymentDrafts[this];
        //    set => fields.PaymentDrafts[this] = value;
        //}

        //[DisplayName("Dunning Terms"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DunningTerm]? DunningTerms
        //{
        //    get => fields.DunningTerms[this];
        //    set => fields.DunningTerms[this] = value;
        //}

        //[DisplayName("Business Partners"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPartner]? BusinessPartners
        //{
        //    get => fields.BusinessPartners[this];
        //    set => fields.BusinessPartners[this] = value;
        //}

        //[DisplayName("Down Payments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? DownPayments
        //{
        //    get => fields.DownPayments[this];
        //    set => fields.DownPayments[this] = value;
        //}

        //[DisplayName("Purchase Down Payments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseDownPayments
        //{
        //    get => fields.PurchaseDownPayments[this];
        //    set => fields.PurchaseDownPayments[this] = value;
        //}

        //[DisplayName("Purchase Returns"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseReturns
        //{
        //    get => fields.PurchaseReturns[this];
        //    set => fields.PurchaseReturns[this] = value;
        //}

        //[DisplayName("Purchase Orders"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseOrders
        //{
        //    get => fields.PurchaseOrders[this];
        //    set => fields.PurchaseOrders[this] = value;
        //}

        //[DisplayName("Quotations"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? Quotations
        //{
        //    get => fields.Quotations[this];
        //    set => fields.Quotations[this] = value;
        //}

        //[DisplayName("Returns"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? Returns
        //{
        //    get => fields.Returns[this];
        //    set => fields.Returns[this] = value;
        //}

        //[DisplayName("House Bank Accounts"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.HouseBankAccount]? HouseBankAccounts
        //{
        //    get => fields.HouseBankAccounts[this];
        //    set => fields.HouseBankAccounts[this] = value;
        //}

        //[DisplayName("Goods Return Request"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? GoodsReturnRequest
        //{
        //    get => fields.GoodsReturnRequest[this];
        //    set => fields.GoodsReturnRequest[this] = value;
        //}

        //[DisplayName("Incoming Payments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]? IncomingPayments
        //{
        //    get => fields.IncomingPayments[this];
        //    set => fields.IncomingPayments[this] = value;
        //}

        //[DisplayName("Expense Types"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ExpenseTypeData]? ExpenseTypes
        //{
        //    get => fields.ExpenseTypes[this];
        //    set => fields.ExpenseTypes[this] = value;
        //}

        //[DisplayName("Purchase Requests"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseRequests
        //{
        //    get => fields.PurchaseRequests[this];
        //    set => fields.PurchaseRequests[this] = value;
        //}

        //[DisplayName("Bank Pages"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BankPage]? BankPages
        //{
        //    get => fields.BankPages[this];
        //    set => fields.BankPages[this] = value;
        //}

        //[DisplayName("Correction Purchase Invoice Reversal"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? CorrectionPurchaseInvoiceReversal
        //{
        //    get => fields.CorrectionPurchaseInvoiceReversal[this];
        //    set => fields.CorrectionPurchaseInvoiceReversal[this] = value;
        //}

        //[DisplayName("Business Places"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPlace]? BusinessPlaces
        //{
        //    get => fields.BusinessPlaces[this];
        //    set => fields.BusinessPlaces[this] = value;
        //}

        //[DisplayName("Credit Cards"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.CreditCard]? CreditCards
        //{
        //    get => fields.CreditCards[this];
        //    set => fields.CreditCards[this] = value;
        //}

        //[DisplayName("Vendor Payments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]? VendorPayments
        //{
        //    get => fields.VendorPayments[this];
        //    set => fields.VendorPayments[this] = value;
        //}

        //[DisplayName("Item Groups"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ItemGroups]? ItemGroups
        //{
        //    get => fields.ItemGroups[this];
        //    set => fields.ItemGroups[this] = value;
        //}

        //[DisplayName("Purchase Quotations"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]? PurchaseQuotations
        //{
        //    get => fields.PurchaseQuotations[this];
        //    set => fields.PurchaseQuotations[this] = value;
        //}

        public ChartOfAccountRow()
            : base()
        {
        }

        public ChartOfAccountRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField Code;
            public StringField Name;
            //public System.Nullable`1[System.Double]Field Balance;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field CashAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field BudgetAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ActiveAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field PrimaryAccount;
            //public System.Nullable`1[System.Int32]Field AccountLevel;
            //public System.StringField DataExportCode;
            //public System.StringField FatherAccountKey;
            //public System.StringField ExternalCode;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field RateConversion;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field TaxLiableAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field TaxExemptAccount;
            //public System.Nullable`1[System.Int32]Field ExternalReconNo;
            //public System.Nullable`1[System.Int32]Field InternalReconNo;
            //public System.Nullable`1[SAPB1.BoAccountTypes]Field AccountType;
            //public System.StringField AcctCurrency;
            //public System.Nullable`1[System.Double]Field BalanceSyscurr;
            //public System.Nullable`1[System.Double]Field BalanceFrgnCurr;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field Protected;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ReconciledAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field LiableForAdvances;
            //public System.StringField ForeignName;
            //public System.StringField Details;
            //public System.StringField ProjectCode;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field RevaluationCoordinated;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field LockManualTransaction;
            //public System.StringField FormatCode;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field AllowChangeVatGroup;
            //public System.StringField DefaultVatGroup;
            //public System.Nullable`1[System.Int32]Field Category;
            //public System.StringField TransactionCode;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field LoadingType;
            //public System.StringField LoadingFactorCode;
            //public System.StringField LoadingFactorCode2;
            //public System.StringField LoadingFactorCode3;
            //public System.StringField LoadingFactorCode4;
            //public System.StringField LoadingFactorCode5;
            //public System.StringField PlanningLevel;
            //public System.StringField DatevAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DatevAutoAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DatevFirstDataEntry;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field AllowMultipleLinking;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ProjectRelevant;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DistributionRuleRelevant;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DistributionRule2Relevant;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DistributionRule3Relevant;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DistributionRule4Relevant;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field DistributionRule5Relevant;
            //public System.Nullable`1[System.Int32]Field Bplid;
            //public System.StringField BplName;
            //public System.StringField VatRegNum;
            //public System.Nullable`1[SAPB1.SPEDContabilAccountPurposeCode]Field AccountPurposeCode;
            //public System.StringField ReferentialAccountCode;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field ValidFor;
            //public System.Nullable`1[System.DateTimeOffset]Field ValidFrom;
            //public System.Nullable`1[System.DateTimeOffset]Field ValidTo;
            //public System.StringField ValidRemarks;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field FrozenFor;
            //public System.Nullable`1[System.DateTimeOffset]Field FrozenFrom;
            //public System.Nullable`1[System.DateTimeOffset]Field FrozenTo;
            //public System.StringField FrozenRemarks;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field BlockManualPosting;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field CashFlowRelevant;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field Pcn874ReportRelevant;
            //public System.StringField PrimaryClosingAccount;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field CostAccountingOnly;
            //public System.Nullable`1[SAPB1.BoYesNoEnum]Field CostElementRelevant;
            //public System.StringField CostElementCode;
            //public System.StringField StandardAccountCode;
            //public System.StringField TaxonomyCode;
            //public System.Nullable`1[System.Int32]Field IncomeClassificationCategory;
            //public System.Nullable`1[System.Int32]Field IncomeClassificationType;
            //public System.Nullable`1[System.Int32]Field ExpenseClassificationCategory;
            //public System.Nullable`1[System.Int32]Field ExpenseClassificationType;
            //public System.StringField UZPostType;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Warehouse]Field Warehouses;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.AccrualType]Field AccrualTypes;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxCode]Field WithholdingTaxCodes;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseDeliveryNotes;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field CorrectionPurchaseInvoice;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.VatGroup]Field VatGroups;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Item]Field Items;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field CorrectionInvoiceReversal;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field CorrectionInvoice;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field InventoryGenEntries;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field Orders;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.FAAccountDetermination]Field FaAccountDeterminations;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.WizardPaymentMethod]Field WizardPaymentMethods;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule]Field GlAccountAdvancedRules;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field InventoryGenExits;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field Drafts;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.AdditionalExpense]Field AdditionalExpenses;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.CustomsGroup]Field CustomsGroups;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseCreditNotes;
            //public SAPB1.CurrencyField Currency;
            //public SAPB1.ProjectField Project;
            //public SAPB1.AccountCategoryField AccountCategory;
            //public SAPB1.TransactionCodeField TransactionCode2;
            //public SAPB1.DistributionRuleField DistributionRule;
            //public SAPB1.CostElementField CostElement;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field ReturnRequest;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field DeliveryNotes;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseInvoices;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.SalesTaxAuthority]Field SalesTaxAuthorities;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field Invoices;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field CreditNotes;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]Field PaymentDrafts;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DunningTerm]Field DunningTerms;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPartner]Field BusinessPartners;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field DownPayments;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseDownPayments;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseReturns;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseOrders;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field Quotations;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field Returns;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.HouseBankAccount]Field HouseBankAccounts;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field GoodsReturnRequest;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]Field IncomingPayments;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ExpenseTypeData]Field ExpenseTypes;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseRequests;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BankPage]Field BankPages;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field CorrectionPurchaseInvoiceReversal;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPlace]Field BusinessPlaces;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.CreditCard]Field CreditCards;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]Field VendorPayments;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ItemGroups]Field ItemGroups;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Document]Field PurchaseQuotations;
        }
    }
}
