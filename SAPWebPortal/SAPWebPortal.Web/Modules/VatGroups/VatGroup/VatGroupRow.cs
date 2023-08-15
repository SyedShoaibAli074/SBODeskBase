using SAPWebPortal.Modules.DropDownEnums;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.VatGroups
{
    [ConnectionKey("Default"), Module("VatGroups"), ServiceLayer("VatGroups")]
    [DisplayName("Vat Group"), InstanceName("Vat Group")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [NotMapped]
    public sealed class VatGroupRow : Row<VatGroupRow.RowFields>, IIdRow
    {
        [DisplayName("Tax Code"), NotNull, IdProperty,NameProperty]
        [NotMapped]
        public String Code
        {
            get => fields.Code[this];
            set => fields.Code[this] = value;
        }

        [DisplayName("Name")]
        [NotMapped]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }
        [DisplayName("Active"), YesOrNoEditor]
        [NotMapped]
        public String Inactive
        {
            get => fields.Inactive[this];
            set => fields.Inactive[this] = value;
        }
        //[DisplayName("Category"), NotNull]
        //[NotMapped]
        //public String Category
        //{
        //    get => fields.Category[this];
        //    set => fields.Category[this] = value;
        //}
        //[DisplayName("Tax Account"), NotNull]
        //[NotMapped]
        //public String TaxAccount
        //{
        //    get => fields.TaxAccount[this];
        //    set => fields.TaxAccount[this] = value;
        //}

        //[DisplayName("Eu"), Column("EU"), NotNull]
        //[NotMapped]
        //public String Eu
        //{
        //    get => fields.Eu[this];
        //    set => fields.Eu[this] = value;
        //}

        //[DisplayName("Triangular Deal"), NotNull]
        //[NotMapped]
        //public String TriangularDeal
        //{
        //    get => fields.TriangularDeal[this];
        //    set => fields.TriangularDeal[this] = value;
        //}

        //[DisplayName("Acquisition Reverse"), NotNull]
        //[NotMapped]
        //public String AcquisitionReverse
        //{
        //    get => fields.AcquisitionReverse[this];
        //    set => fields.AcquisitionReverse[this] = value;
        //}

        //[DisplayName("Non Deduct"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Double]? NonDeduct
        //{
        //    get => fields.NonDeduct[this];
        //    set => fields.NonDeduct[this] = value;
        //}

        //[DisplayName("Acquisition Tax"), NotNull]
        //[NotMapped]
        //public String AcquisitionTax
        //{
        //    get => fields.AcquisitionTax[this];
        //    set => fields.AcquisitionTax[this] = value;
        //}

        //[DisplayName("Goods Shipment"), NotNull]
        //[NotMapped]
        //public String GoodsShipment
        //{
        //    get => fields.GoodsShipment[this];
        //    set => fields.GoodsShipment[this] = value;
        //}

        //[DisplayName("Non Deduct Acc"), NotNull]
        //[NotMapped]
        //public String NonDeductAcc
        //{
        //    get => fields.NonDeductAcc[this];
        //    set => fields.NonDeductAcc[this] = value;
        //}

        //[DisplayName("Deferred Tax Acc"), NotNull]
        //[NotMapped]
        //public String DeferredTaxAcc
        //{
        //    get => fields.DeferredTaxAcc[this];
        //    set => fields.DeferredTaxAcc[this] = value;
        //}

        //[DisplayName("Correction"), NotNull]
        //[NotMapped]
        //public String Correction
        //{
        //    get => fields.Correction[this];
        //    set => fields.Correction[this] = value;
        //}

        //[DisplayName("Vat Correction"), NotNull]
        //[NotMapped]
        //public String VatCorrection
        //{
        //    get => fields.VatCorrection[this];
        //    set => fields.VatCorrection[this] = value;
        //}

        //[DisplayName("Equalization Tax Account"), NotNull]
        //[NotMapped]
        //public String EqualizationTaxAccount
        //{
        //    get => fields.EqualizationTaxAccount[this];
        //    set => fields.EqualizationTaxAccount[this] = value;
        //}

        //[DisplayName("Service Supply"), NotNull]
        //[NotMapped]
        //public String ServiceSupply
        //{
        //    get => fields.ServiceSupply[this];
        //    set => fields.ServiceSupply[this] = value;
        //}



        //[DisplayName("Tax Type Black List"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.TaxTypeBlackListEnum]? TaxTypeBlackList
        //{
        //    get => fields.TaxTypeBlackList[this];
        //    set => fields.TaxTypeBlackList[this] = value;
        //}

        //[DisplayName("Report349 Code"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.Report349CodeListEnum]? Report349Code
        //{
        //    get => fields.Report349Code[this];
        //    set => fields.Report349Code[this] = value;
        //}

        //[DisplayName("Vat In Revenue Account"), Column("VATInRevenueAccount"), NotNull]
        //[NotMapped]
        //public String VatInRevenueAccount
        //{
        //    get => fields.VatInRevenueAccount[this];
        //    set => fields.VatInRevenueAccount[this] = value;
        //}

        //[DisplayName("Down Payment Tax Offset Account"), NotNull]
        //[NotMapped]
        //public String DownPaymentTaxOffsetAccount
        //{
        //    get => fields.DownPaymentTaxOffsetAccount[this];
        //    set => fields.DownPaymentTaxOffsetAccount[this] = value;
        //}

        //[DisplayName("Cash Discount Account"), NotNull]
        //[NotMapped]
        //public String CashDiscountAccount
        //{
        //    get => fields.CashDiscountAccount[this];
        //    set => fields.CashDiscountAccount[this] = value;
        //}

        //[DisplayName("Vat Deductible Account"), Column("VATDeductibleAccount"), NotNull]
        //[NotMapped]
        //public String VatDeductibleAccount
        //{
        //    get => fields.VatDeductibleAccount[this];
        //    set => fields.VatDeductibleAccount[this] = value;
        //}

        //[DisplayName("Tax Region"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.VatGroupsTaxRegionEnum]? TaxRegion
        //{
        //    get => fields.TaxRegion[this];
        //    set => fields.TaxRegion[this] = value;
        //}

        //[DisplayName("Acquisition Reverse Corresponding Tax Code"), NotNull]
        //[NotMapped]
        //public String AcquisitionReverseCorrespondingTaxCode
        //{
        //    get => fields.AcquisitionReverseCorrespondingTaxCode[this];
        //    set => fields.AcquisitionReverseCorrespondingTaxCode[this] = value;
        //}

        //[DisplayName("E Books Vat Category"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? EBooksVatCategory
        //{
        //    get => fields.EBooksVatCategory[this];
        //    set => fields.EBooksVatCategory[this] = value;
        //}


        //[DisplayName("Vat Groups Lines"), Column("VatGroups_Lines"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.VatGroups_Line]? VatGroupsLines
        //{
        //    get => fields.VatGroupsLines[this];
        //    set => fields.VatGroupsLines[this] = value;
        //}

        //[DisplayName("Chart Of Account"), NotNull]
        //[NotMapped]
        //public SAPB1.ChartOfAccount? ChartOfAccount
        //{
        //    get => fields.ChartOfAccount[this];
        //    set => fields.ChartOfAccount[this] = value;
        //}

        //[DisplayName("Items"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Item]? Items
        //{
        //    get => fields.Items[this];
        //    set => fields.Items[this] = value;
        //}

        //[DisplayName("Gl Account Advanced Rules"), Column("GLAccountAdvancedRules"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule]? GlAccountAdvancedRules
        //{
        //    get => fields.GlAccountAdvancedRules[this];
        //    set => fields.GlAccountAdvancedRules[this] = value;
        //}

        //[DisplayName("Additional Expenses"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.AdditionalExpense]? AdditionalExpenses
        //{
        //    get => fields.AdditionalExpenses[this];
        //    set => fields.AdditionalExpenses[this] = value;
        //}

        //[DisplayName("Payment Drafts"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]? PaymentDrafts
        //{
        //    get => fields.PaymentDrafts[this];
        //    set => fields.PaymentDrafts[this] = value;
        //}

        //[DisplayName("Business Partners"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPartner]? BusinessPartners
        //{
        //    get => fields.BusinessPartners[this];
        //    set => fields.BusinessPartners[this] = value;
        //}

        //[DisplayName("Incoming Payments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]? IncomingPayments
        //{
        //    get => fields.IncomingPayments[this];
        //    set => fields.IncomingPayments[this] = value;
        //}

        //[DisplayName("Deposits"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Deposit]? Deposits
        //{
        //    get => fields.Deposits[this];
        //    set => fields.Deposits[this] = value;
        //}

        //[DisplayName("Vendor Payments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]? VendorPayments
        //{
        //    get => fields.VendorPayments[this];
        //    set => fields.VendorPayments[this] = value;
        //}

        public VatGroupRow()
            : base()
        {
        }

        public VatGroupRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField Code;
            public StringField Name;
            public StringField Inactive;
            //public StringField Category;
            //public StringField TaxAccount;
            //public StringField Eu;
            //public StringField TriangularDeal;
            //public StringField AcquisitionReverse;
            //public System.Nullable`1[System.Double]Field NonDeduct;
            //public StringField AcquisitionTax;
            //public StringField GoodsShipment;
            //public StringField NonDeductAcc;
            //public StringField DeferredTaxAcc;
            //public StringField Correction;
            //public StringField VatCorrection;
            //public StringField EqualizationTaxAccount;
            //public StringField ServiceSupply;
            //public System.Nullable`1[SAPB1.TaxTypeBlackListEnum]Field TaxTypeBlackList;
            //public System.Nullable`1[SAPB1.Report349CodeListEnum]Field Report349Code;
            //public StringField VatInRevenueAccount;
            //public StringField DownPaymentTaxOffsetAccount;
            //public StringField CashDiscountAccount;
            //public StringField VatDeductibleAccount;
            //public System.Nullable`1[SAPB1.VatGroupsTaxRegionEnum]Field TaxRegion;
            //public StringField AcquisitionReverseCorrespondingTaxCode;
            //public System.Nullable`1[System.Int32]Field EBooksVatCategory;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.VatGroups_Line]Field VatGroupsLines;
            //public SAPB1.ChartOfAccountField ChartOfAccount;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Item]Field Items;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule]Field GlAccountAdvancedRules;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.AdditionalExpense]Field AdditionalExpenses;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]Field PaymentDrafts;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPartner]Field BusinessPartners;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]Field IncomingPayments;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Deposit]Field Deposits;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment]Field VendorPayments;
        }
    }
}
