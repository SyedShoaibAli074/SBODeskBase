using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.VatGroups.Forms
{
    [FormScript("VatGroups.VatGroup")]
    [BasedOnRow(typeof(VatGroupRow), CheckNames = true)]
    public class VatGroupForm
    {
        public String Name { get; set; }
        public String Inactive { get; set; }
        //public String Category { get; set; }
        //public String TaxAccount { get; set; }
        //public String Eu { get; set; }
        //public String TriangularDeal { get; set; }
        //public String AcquisitionReverse { get; set; }
        //public System.Nullable`1[System.Double] NonDeduct { get; set; }
        //public String AcquisitionTax { get; set; }
        //public String GoodsShipment { get; set; }
        //public String NonDeductAcc { get; set; }
        //public String DeferredTaxAcc { get; set; }
        //public String Correction { get; set; }
        //public String VatCorrection { get; set; }
        //public String EqualizationTaxAccount { get; set; }
        //public String ServiceSupply { get; set; }
        //public System.Nullable`1[SAPB1.TaxTypeBlackListEnum] TaxTypeBlackList { get; set; }
        //public System.Nullable`1[SAPB1.Report349CodeListEnum] Report349Code { get; set; }
        //public String VatInRevenueAccount { get; set; }
        //public String DownPaymentTaxOffsetAccount { get; set; }
        //public String CashDiscountAccount { get; set; }
        //public String VatDeductibleAccount { get; set; }
        //public System.Nullable`1[SAPB1.VatGroupsTaxRegionEnum] TaxRegion { get; set; }
        //public String AcquisitionReverseCorrespondingTaxCode { get; set; }
        //public System.Nullable`1[System.Int32] EBooksVatCategory { get; set; }
        //public System.Nullable`1[System.Double] UFurtherTaxRate { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.VatGroups_Line] VatGroupsLines { get; set; }
        //public SAPB1.ChartOfAccount ChartOfAccount { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Item] Items { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule] GlAccountAdvancedRules { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.AdditionalExpense] AdditionalExpenses { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment] PaymentDrafts { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPartner] BusinessPartners { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment] IncomingPayments { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Deposit] Deposits { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payment] VendorPayments { get; set; }
    }
}