using SAPWebPortal.Default;
using SAPWebPortal.VatGroups;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.DraftsExpense
{
    [ConnectionKey("Default"), Module("DraftsExpense"), ServiceLayer("DraftsExpense")]
    [DisplayName("Document Additional Expense"), InstanceName("Document Additional Expense")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [NotMapped]
    public sealed class DocumentAdditionalExpenseRow : Row<DocumentAdditionalExpenseRow.RowFields>, IIdRow
    {
        [DisplayName("Expense Code"), IdProperty, _Ext.GridItemPickerEditor(typeof(AdditionalExpenseRow))]
        [NotMapped]
        public Int32? ExpenseCode
        {
            get => fields.ExpenseCode[this];
            set => fields.ExpenseCode[this] = value;
        }
        [DisplayName("Line Num"), Visible(false)]
        [NotMapped]
        public Int32? LineNum
        {
            get => fields.LineNum[this];
            set => fields.LineNum[this] = value;
        }
        [DisplayName("Line Total"), ReadOnly(true)]
        [NotMapped]
        public decimal? LineTotal
        {
            get => fields.LineTotal[this];
            set => fields.LineTotal[this] = value;
        }
        [DisplayName("Tax Code"), _Ext.GridItemPickerEditor(typeof(VatGroupRow))]
        [NotMapped]
        public String VatGroup
        {
            get => fields.VatGroup[this];
            set => fields.VatGroup[this] = value;
        }

        [DisplayName("Tax %"), ReadOnly(true)]
        [NotMapped]
        public decimal? TaxPercent
        {
            get => fields.TaxPercent[this];
            set => fields.TaxPercent[this] = value;
        }

        [DisplayName("Tax Sum"), ReadOnly(true)]
        [NotMapped]
        public decimal? TaxSum
        {
            get => fields.TaxSum[this];
            set => fields.TaxSum[this] = value;
        }
        [DisplayName("Remarks")]
        [NotMapped]
        public String Remarks
        {
            get => fields.Remarks[this];
            set => fields.Remarks[this] = value;
        }
        [DisplayName("Amount")]
        [NotMapped]
        public decimal? U_Amount
        {
            get => fields.U_Amount[this];
            set => fields.U_Amount[this] = value;
        }
        //[DisplayName("Line Total Fc"), Column("LineTotalFC"), NotNull]
        //[NotMapped]
        //public decimal? LineTotalFc
        //{
        //    get => fields.LineTotalFc[this];
        //    set => fields.LineTotalFc[this] = value;
        //}

        //[DisplayName("Line Total Sys"), NotNull]
        //[NotMapped]
        //public decimal? LineTotalSys
        //{
        //    get => fields.LineTotalSys[this];
        //    set => fields.LineTotalSys[this] = value;
        //}

        //[DisplayName("Paid To Date"), NotNull]
        //[NotMapped]
        //public decimal? PaidToDate
        //{
        //    get => fields.PaidToDate[this];
        //    set => fields.PaidToDate[this] = value;
        //}

        //[DisplayName("Paid To Date Fc"), Column("PaidToDateFC"), NotNull]
        //[NotMapped]
        //public decimal? PaidToDateFc
        //{
        //    get => fields.PaidToDateFc[this];
        //    set => fields.PaidToDateFc[this] = value;
        //}

        //[DisplayName("Paid To Date Sys"), NotNull]
        //[NotMapped]
        //public decimal? PaidToDateSys
        //{
        //    get => fields.PaidToDateSys[this];
        //    set => fields.PaidToDateSys[this] = value;
        //}


        //[DisplayName("Distribution Method"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoAdEpnsDistribMethods]? DistributionMethod
        //{
        //    get => fields.DistributionMethod[this];
        //    set => fields.DistributionMethod[this] = value;
        //}

        //[DisplayName("Tax Liable"), NotNull]
        //[NotMapped]
        //public String TaxLiable
        //{
        //    get => fields.TaxLiable[this];
        //    set => fields.TaxLiable[this] = value;
        //}



        //[DisplayName("Tax Sum Fc"), Column("TaxSumFC"), NotNull]
        //[NotMapped]
        //public decimal? TaxSumFc
        //{
        //    get => fields.TaxSumFc[this];
        //    set => fields.TaxSumFc[this] = value;
        //}

        //[DisplayName("Tax Sum Sys"), NotNull]
        //[NotMapped]
        //public decimal? TaxSumSys
        //{
        //    get => fields.TaxSumSys[this];
        //    set => fields.TaxSumSys[this] = value;
        //}

        //[DisplayName("Deductible Tax Sum"), NotNull]
        //[NotMapped]
        //public decimal? DeductibleTaxSum
        //{
        //    get => fields.DeductibleTaxSum[this];
        //    set => fields.DeductibleTaxSum[this] = value;
        //}

        //[DisplayName("Deductible Tax Sum Fc"), Column("DeductibleTaxSumFC"), NotNull]
        //[NotMapped]
        //public decimal? DeductibleTaxSumFc
        //{
        //    get => fields.DeductibleTaxSumFc[this];
        //    set => fields.DeductibleTaxSumFc[this] = value;
        //}

        //[DisplayName("Deductible Tax Sum Sys"), NotNull]
        //[NotMapped]
        //public decimal? DeductibleTaxSumSys
        //{
        //    get => fields.DeductibleTaxSumSys[this];
        //    set => fields.DeductibleTaxSumSys[this] = value;
        //}

        //[DisplayName("Aquisition Tax"), NotNull]
        //[NotMapped]
        //public String AquisitionTax
        //{
        //    get => fields.AquisitionTax[this];
        //    set => fields.AquisitionTax[this] = value;
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
        //public System.Nullable`1[SAPB1.BoAdEpnsTaxTypes]? TaxType
        //{
        //    get => fields.TaxType[this];
        //    set => fields.TaxType[this] = value;
        //}

        //[DisplayName("Tax Paid"), NotNull]
        //[NotMapped]
        //public decimal? TaxPaid
        //{
        //    get => fields.TaxPaid[this];
        //    set => fields.TaxPaid[this] = value;
        //}

        //[DisplayName("Tax Paid Fc"), Column("TaxPaidFC"), NotNull]
        //[NotMapped]
        //public decimal? TaxPaidFc
        //{
        //    get => fields.TaxPaidFc[this];
        //    set => fields.TaxPaidFc[this] = value;
        //}

        //[DisplayName("Tax Paid Sys"), NotNull]
        //[NotMapped]
        //public decimal? TaxPaidSys
        //{
        //    get => fields.TaxPaidSys[this];
        //    set => fields.TaxPaidSys[this] = value;
        //}

        //[DisplayName("Equalization Tax Percent"), NotNull]
        //[NotMapped]
        //public decimal? EqualizationTaxPercent
        //{
        //    get => fields.EqualizationTaxPercent[this];
        //    set => fields.EqualizationTaxPercent[this] = value;
        //}

        //[DisplayName("Equalization Tax Sum"), NotNull]
        //[NotMapped]
        //public decimal? EqualizationTaxSum
        //{
        //    get => fields.EqualizationTaxSum[this];
        //    set => fields.EqualizationTaxSum[this] = value;
        //}

        //[DisplayName("Equalization Tax Fc"), Column("EqualizationTaxFC"), NotNull]
        //[NotMapped]
        //public decimal? EqualizationTaxFc
        //{
        //    get => fields.EqualizationTaxFc[this];
        //    set => fields.EqualizationTaxFc[this] = value;
        //}

        //[DisplayName("Equalization Tax Sys"), NotNull]
        //[NotMapped]
        //public decimal? EqualizationTaxSys
        //{
        //    get => fields.EqualizationTaxSys[this];
        //    set => fields.EqualizationTaxSys[this] = value;
        //}

        //[DisplayName("Tax Total Sum"), NotNull]
        //[NotMapped]
        //public decimal? TaxTotalSum
        //{
        //    get => fields.TaxTotalSum[this];
        //    set => fields.TaxTotalSum[this] = value;
        //}

        //[DisplayName("Tax Total Sum Fc"), Column("TaxTotalSumFC"), NotNull]
        //[NotMapped]
        //public decimal? TaxTotalSumFc
        //{
        //    get => fields.TaxTotalSumFc[this];
        //    set => fields.TaxTotalSumFc[this] = value;
        //}

        //[DisplayName("Tax Total Sum Sys"), NotNull]
        //[NotMapped]
        //public decimal? TaxTotalSumSys
        //{
        //    get => fields.TaxTotalSumSys[this];
        //    set => fields.TaxTotalSumSys[this] = value;
        //}

        //[DisplayName("Base Doc Entry"), NotNull]
        //[NotMapped]
        //public Int32? BaseDocEntry
        //{
        //    get => fields.BaseDocEntry[this];
        //    set => fields.BaseDocEntry[this] = value;
        //}

        //[DisplayName("Base Doc Line"), NotNull]
        //[NotMapped]
        //public Int32? BaseDocLine
        //{
        //    get => fields.BaseDocLine[this];
        //    set => fields.BaseDocLine[this] = value;
        //}

        //[DisplayName("Base Doc Type"), NotNull]
        //[NotMapped]
        //public Int32? BaseDocType
        //{
        //    get => fields.BaseDocType[this];
        //    set => fields.BaseDocType[this] = value;
        //}

        //[DisplayName("Base Document Reference"), NotNull]
        //[NotMapped]
        //public Int32? BaseDocumentReference
        //{
        //    get => fields.BaseDocumentReference[this];
        //    set => fields.BaseDocumentReference[this] = value;
        //}



        //[DisplayName("Last Purchase Price"), NotNull]
        //[NotMapped]
        //public String LastPurchasePrice
        //{
        //    get => fields.LastPurchasePrice[this];
        //    set => fields.LastPurchasePrice[this] = value;
        //}

        //[DisplayName("Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoStatus]? Status
        //{
        //    get => fields.Status[this];
        //    set => fields.Status[this] = value;
        //}

        //[DisplayName("Stock"), NotNull]
        //[NotMapped]
        //public String Stock
        //{
        //    get => fields.Stock[this];
        //    set => fields.Stock[this] = value;
        //}

        //[DisplayName("Target Abs Entry"), NotNull]
        //[NotMapped]
        //public Int32? TargetAbsEntry
        //{
        //    get => fields.TargetAbsEntry[this];
        //    set => fields.TargetAbsEntry[this] = value;
        //}

        //[DisplayName("Target Type"), NotNull]
        //[NotMapped]
        //public Int32? TargetType
        //{
        //    get => fields.TargetType[this];
        //    set => fields.TargetType[this] = value;
        //}

        //[DisplayName("Wt Liable"), Column("WTLiable"), NotNull]
        //[NotMapped]
        //public String WtLiable
        //{
        //    get => fields.WtLiable[this];
        //    set => fields.WtLiable[this] = value;
        //}

        //[DisplayName("Distribution Rule"), NotNull]
        //[NotMapped]
        //public String DistributionRule
        //{
        //    get => fields.DistributionRule[this];
        //    set => fields.DistributionRule[this] = value;
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

        //[DisplayName("Line Gross"), NotNull]
        //[NotMapped]
        //public decimal? LineGross
        //{
        //    get => fields.LineGross[this];
        //    set => fields.LineGross[this] = value;
        //}

        //[DisplayName("Line Gross Sys"), NotNull]
        //[NotMapped]
        //public decimal? LineGrossSys
        //{
        //    get => fields.LineGrossSys[this];
        //    set => fields.LineGrossSys[this] = value;
        //}

        //[DisplayName("Line Gross Fc"), Column("LineGrossFC"), NotNull]
        //[NotMapped]
        //public decimal? LineGrossFc
        //{
        //    get => fields.LineGrossFc[this];
        //    set => fields.LineGrossFc[this] = value;
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

        //[DisplayName("Cu Split"), Column("CUSplit"), NotNull]
        //[NotMapped]
        //public String CuSplit
        //{
        //    get => fields.CuSplit[this];
        //    set => fields.CuSplit[this] = value;
        //}

        //[DisplayName("Doc Expense Tax Jurisdictions"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocExpenseTaxJurisdiction]? DocExpenseTaxJurisdictions
        //{
        //    get => fields.DocExpenseTaxJurisdictions[this];
        //    set => fields.DocExpenseTaxJurisdictions[this] = value;
        //}

        //[DisplayName("Doc Freight E Books Details"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocFreightEBooksDetail]? DocFreightEBooksDetails
        //{
        //    get => fields.DocFreightEBooksDetails[this];
        //    set => fields.DocFreightEBooksDetails[this] = value;
        //}

        public DocumentAdditionalExpenseRow()
            : base()
        {
        }

        public DocumentAdditionalExpenseRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field ExpenseCode;

            public Int32Field LineNum;
            public DecimalField LineTotal;
            public StringField VatGroup;
            public DecimalField TaxPercent;
            public DecimalField TaxSum;
            public StringField Remarks; 
            public DecimalField U_Amount;
            //public DecimalField LineTotalFc;
            //public DecimalField LineTotalSys;
            //public DecimalField PaidToDate;
            //public DecimalField PaidToDateFc;
            //public DecimalField PaidToDateSys;

            //public System.Nullable`1[SAPB1.BoAdEpnsDistribMethods]Field DistributionMethod;
            //public StringField TaxLiable;

            //public DecimalField TaxSumFc;
            //public DecimalField TaxSumSys;
            //public DecimalField DeductibleTaxSum;
            //public DecimalField DeductibleTaxSumFc;
            //public DecimalField DeductibleTaxSumSys;
            //public StringField AquisitionTax;
            //public StringField TaxCode;
            //public System.Nullable`1[SAPB1.BoAdEpnsTaxTypes]Field TaxType;
            //public DecimalField TaxPaid;
            //public DecimalField TaxPaidFc;
            //public DecimalField TaxPaidSys;
            //public DecimalField EqualizationTaxPercent;
            //public DecimalField EqualizationTaxSum;
            //public DecimalField EqualizationTaxFc;
            //public DecimalField EqualizationTaxSys;
            //public DecimalField TaxTotalSum;
            //public DecimalField TaxTotalSumFc;
            //public DecimalField TaxTotalSumSys;
            //public Int32Field BaseDocEntry;
            //public Int32Field BaseDocLine;
            //public Int32Field BaseDocType;
            //public Int32Field BaseDocumentReference;
            //public StringField LastPurchasePrice;
            //public System.Nullable`1[SAPB1.BoStatus]Field Status;
            //public StringField Stock;
            //public Int32Field TargetAbsEntry;
            //public Int32Field TargetType;
            //public StringField WtLiable;
            //public StringField DistributionRule;
            //public StringField Project;
            //public StringField DistributionRule2;
            //public StringField DistributionRule3;
            //public StringField DistributionRule4;
            //public StringField DistributionRule5;
            //public DecimalField LineGross;
            //public DecimalField LineGrossSys;
            //public DecimalField LineGrossFc;
            //public DecimalField ExternalCalcTaxRate;
            //public DecimalField ExternalCalcTaxAmount;
            //public DecimalField ExternalCalcTaxAmountFc;
            //public DecimalField ExternalCalcTaxAmountSc;
            //public StringField CuSplit;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocExpenseTaxJurisdiction]Field DocExpenseTaxJurisdictions;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.DocFreightEBooksDetail]Field DocFreightEBooksDetails;
        }
    }
}
