using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), ServiceLayer("AdditionalExpenses")]
    [DisplayName("Additional Expense"), InstanceName("Additional Expense")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [NotMapped]
    public sealed class AdditionalExpenseRow : Row<AdditionalExpenseRow.RowFields>, IIdRow
    {
        [DisplayName("Expens Code"), NotNull, IdProperty]
        [NotMapped]
        public Int32? ExpensCode
        {
            get => fields.ExpensCode[this];
            set => fields.ExpensCode[this] = value;
        }
        [DisplayName("Name"),NameProperty]
        [NotMapped]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        //[DisplayName("Revenues Account"), NotNull]
        //[NotMapped]
        //public String RevenuesAccount
        //{
        //    get => fields.RevenuesAccount[this];
        //    set => fields.RevenuesAccount[this] = value;
        //}

        //[DisplayName("Expense Account"), NotNull]
        //[NotMapped]
        //public String ExpenseAccount
        //{
        //    get => fields.ExpenseAccount[this];
        //    set => fields.ExpenseAccount[this] = value;
        //}

        //[DisplayName("Tax Liable"), NotNull]
        //[NotMapped]
        //public String TaxLiable
        //{
        //    get => fields.TaxLiable[this];
        //    set => fields.TaxLiable[this] = value;
        //}

        //[DisplayName("Fixed Amount Revenues"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Double]? FixedAmountRevenues
        //{
        //    get => fields.FixedAmountRevenues[this];
        //    set => fields.FixedAmountRevenues[this] = value;
        //}

        //[DisplayName("Fixed Amount Expenses"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Double]? FixedAmountExpenses
        //{
        //    get => fields.FixedAmountExpenses[this];
        //    set => fields.FixedAmountExpenses[this] = value;
        //}

        //[DisplayName("Output Vat Group"), Column("OutputVATGroup"), NotNull]
        //[NotMapped]
        //public String OutputVatGroup
        //{
        //    get => fields.OutputVatGroup[this];
        //    set => fields.OutputVatGroup[this] = value;
        //}

        //[DisplayName("Input Vat Group"), Column("InputVATGroup"), NotNull]
        //[NotMapped]
        //public String InputVatGroup
        //{
        //    get => fields.InputVatGroup[this];
        //    set => fields.InputVatGroup[this] = value;
        //}

        //[DisplayName("Distribution Method"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoAeDistMthd]? DistributionMethod
        //{
        //    get => fields.DistributionMethod[this];
        //    set => fields.DistributionMethod[this] = value;
        //}

        //[DisplayName("Includein1099"), NotNull]
        //[NotMapped]
        //public String Includein1099
        //{
        //    get => fields.Includein1099[this];
        //    set => fields.Includein1099[this] = value;
        //}

        //[DisplayName("Freight Offset Account"), NotNull]
        //[NotMapped]
        //public String FreightOffsetAccount
        //{
        //    get => fields.FreightOffsetAccount[this];
        //    set => fields.FreightOffsetAccount[this] = value;
        //}

        //[DisplayName("Wt Liable"), Column("WTLiable"), NotNull]
        //[NotMapped]
        //public String WtLiable
        //{
        //    get => fields.WtLiable[this];
        //    set => fields.WtLiable[this] = value;
        //}

        

        //[DisplayName("Expense Exempted Account"), NotNull]
        //[NotMapped]
        //public String ExpenseExemptedAccount
        //{
        //    get => fields.ExpenseExemptedAccount[this];
        //    set => fields.ExpenseExemptedAccount[this] = value;
        //}

        //[DisplayName("Revenues Exempted Account"), NotNull]
        //[NotMapped]
        //public String RevenuesExemptedAccount
        //{
        //    get => fields.RevenuesExemptedAccount[this];
        //    set => fields.RevenuesExemptedAccount[this] = value;
        //}

        //[DisplayName("Distribution Rule"), NotNull]
        //[NotMapped]
        //public String DistributionRule
        //{
        //    get => fields.DistributionRule[this];
        //    set => fields.DistributionRule[this] = value;
        //}

        //[DisplayName("Drawing Method"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.DrawingMethodEnum]? DrawingMethod
        //{
        //    get => fields.DrawingMethod[this];
        //    set => fields.DrawingMethod[this] = value;
        //}

        //[DisplayName("Freight Type"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.FreightTypeEnum]? FreightType
        //{
        //    get => fields.FreightType[this];
        //    set => fields.FreightType[this] = value;
        //}

        //[DisplayName("Stock"), NotNull]
        //[NotMapped]
        //public String Stock
        //{
        //    get => fields.Stock[this];
        //    set => fields.Stock[this] = value;
        //}

        //[DisplayName("Last Purchase Price"), NotNull]
        //[NotMapped]
        //public String LastPurchasePrice
        //{
        //    get => fields.LastPurchasePrice[this];
        //    set => fields.LastPurchasePrice[this] = value;
        //}

        //[DisplayName("Project"), NotNull]
        //[NotMapped]
        //public String Project
        //{
        //    get => fields.Project[this];
        //    set => fields.Project[this] = value;
        //}

        //[DisplayName("Distribution Rule2"), NotNull]
        //[NotMapped]
        //public String DistributionRule2
        //{
        //    get => fields.DistributionRule2[this];
        //    set => fields.DistributionRule2[this] = value;
        //}

        //[DisplayName("Distribution Rule3"), NotNull]
        //[NotMapped]
        //public String DistributionRule3
        //{
        //    get => fields.DistributionRule3[this];
        //    set => fields.DistributionRule3[this] = value;
        //}

        //[DisplayName("Distribution Rule4"), NotNull]
        //[NotMapped]
        //public String DistributionRule4
        //{
        //    get => fields.DistributionRule4[this];
        //    set => fields.DistributionRule4[this] = value;
        //}

        //[DisplayName("Distribution Rule5"), NotNull]
        //[NotMapped]
        //public String DistributionRule5
        //{
        //    get => fields.DistributionRule5[this];
        //    set => fields.DistributionRule5[this] = value;
        //}

        //[DisplayName("Data Version"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[System.Int32]? DataVersion
        //{
        //    get => fields.DataVersion[this];
        //    set => fields.DataVersion[this] = value;
        //}

        //[DisplayName("Chart Of Account"), NotNull]
        //[NotMapped]
        //public SAPB1.ChartOfAccount? ChartOfAccount
        //{
        //    get => fields.ChartOfAccount[this];
        //    set => fields.ChartOfAccount[this] = value;
        //}

        //[DisplayName("Vat Group"), NotNull]
        //[NotMapped]
        //public SAPB1.VatGroup? VatGroup
        //{
        //    get => fields.VatGroup[this];
        //    set => fields.VatGroup[this] = value;
        //}

        //[DisplayName("Distribution Rule6"), NotNull]
        //[NotMapped]
        //public SAPB1.DistributionRule? DistributionRule6
        //{
        //    get => fields.DistributionRule6[this];
        //    set => fields.DistributionRule6[this] = value;
        //}

        //[DisplayName("Project2"), NotNull]
        //[NotMapped]
        //public SAPB1.Project? Project2
        //{
        //    get => fields.Project2[this];
        //    set => fields.Project2[this] = value;
        //}

        public AdditionalExpenseRow()
            : base()
        {
        }

        public AdditionalExpenseRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {

            public Int32Field ExpensCode;
            public StringField Name;
            //public StringField RevenuesAccount;
            //public StringField ExpenseAccount;
            //public StringField TaxLiable;
            //public System.Nullable`1[System.Double]Field FixedAmountRevenues;
            //public System.Nullable`1[System.Double]Field FixedAmountExpenses;
            //public StringField OutputVatGroup;
            //public StringField InputVatGroup;
            //public System.Nullable`1[SAPB1.BoAeDistMthd]Field DistributionMethod;
            //public StringField Includein1099;
            //public StringField FreightOffsetAccount;
            //public StringField WtLiable;
            //public StringField ExpenseExemptedAccount;
            //public StringField RevenuesExemptedAccount;
            //public StringField DistributionRule;
            //public System.Nullable`1[SAPB1.DrawingMethodEnum]Field DrawingMethod;
            //public System.Nullable`1[SAPB1.FreightTypeEnum]Field FreightType;
            //public StringField Stock;
            //public StringField LastPurchasePrice;
            //public StringField Project;
            //public StringField DistributionRule2;
            //public StringField DistributionRule3;
            //public StringField DistributionRule4;
            //public StringField DistributionRule5;
            //public System.Nullable`1[System.Int32]Field DataVersion;
            //public SAPB1.ChartOfAccountField ChartOfAccount;
            //public SAPB1.VatGroupField VatGroup;
            //public SAPB1.DistributionRuleField DistributionRule6;
            //public SAPB1.ProjectField Project2;
        }
    }
}
