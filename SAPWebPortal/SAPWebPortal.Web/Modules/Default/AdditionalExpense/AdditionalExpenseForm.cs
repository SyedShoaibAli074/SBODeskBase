using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.AdditionalExpense")]
    [BasedOnRow(typeof(AdditionalExpenseRow), CheckNames = true)]
    public class AdditionalExpenseForm
    {
        public Int32 ExpensCode { get; set; }
        public String Name { get; set; }
        //public String RevenuesAccount { get; set; }
        //public String ExpenseAccount { get; set; }
        //public String TaxLiable { get; set; }
        //public System.Nullable`1[System.Double] FixedAmountRevenues { get; set; }
        //public System.Nullable`1[System.Double] FixedAmountExpenses { get; set; }
        //public String OutputVatGroup { get; set; }
        //public String InputVatGroup { get; set; }
        //public System.Nullable`1[SAPB1.BoAeDistMthd] DistributionMethod { get; set; }
        //public String Includein1099 { get; set; }
        //public String FreightOffsetAccount { get; set; }
        //public String WtLiable { get; set; }
        //public String ExpenseExemptedAccount { get; set; }
        //public String RevenuesExemptedAccount { get; set; }
        //public String DistributionRule { get; set; }
        //public System.Nullable`1[SAPB1.DrawingMethodEnum] DrawingMethod { get; set; }
        //public System.Nullable`1[SAPB1.FreightTypeEnum] FreightType { get; set; }
        //public String Stock { get; set; }
        //public String LastPurchasePrice { get; set; }
        //public String Project { get; set; }
        //public String DistributionRule2 { get; set; }
        //public String DistributionRule3 { get; set; }
        //public String DistributionRule4 { get; set; }
        //public String DistributionRule5 { get; set; }
        //public System.Nullable`1[Int32] DataVersion { get; set; }
        //public SAPB1.ChartOfAccount ChartOfAccount { get; set; }
        //public SAPB1.VatGroup VatGroup { get; set; }
        //public SAPB1.DistributionRule DistributionRule6 { get; set; }
        //public SAPB1.Project Project2 { get; set; }
    }
}