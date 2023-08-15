using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.QuotationsExpense.Columns
{
    [ColumnsScript("QuotationsExpense.DocumentAdditionalExpense")]
    [BasedOnRow(typeof(DocumentAdditionalExpenseRow), CheckNames = true)]
    public class DocumentAdditionalExpenseColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 ExpenseCode { get; set; }
        public decimal U_Amount { get; set; }
        public String VatGroup { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxSum { get; set; }
        public decimal LineTotal { get; set; }
        public String Remarks { get; set; }
        //public Int32 LineNum { get; set; }
        //public decimal LineTotalFc { get; set; }
        //public decimal LineTotalSys { get; set; }
        //public decimal PaidToDate { get; set; }
        //public decimal PaidToDateFc { get; set; }
        //public decimal PaidToDateSys { get; set; }
        //public System.Nullable`1[SAPB1.BoAdEpnsDistribMethods] DistributionMethod { get; set; }
        //public String TaxLiable { get; set; }
        //public decimal TaxSum { get; set; }
        //public decimal TaxSumFc { get; set; }
        //public decimal TaxSumSys { get; set; }
        //public decimal DeductibleTaxSum { get; set; }
        //public decimal DeductibleTaxSumFc { get; set; }
        //public decimal DeductibleTaxSumSys { get; set; }
        //public String AquisitionTax { get; set; }
        //public String TaxCode { get; set; }
        //public System.Nullable`1[SAPB1.BoAdEpnsTaxTypes] TaxType { get; set; }
        //public decimal TaxPaid { get; set; }
        //public decimal TaxPaidFc { get; set; }
        //public decimal TaxPaidSys { get; set; }
        //public decimal EqualizationTaxPercent { get; set; }
        //public decimal EqualizationTaxSum { get; set; }
        //public decimal EqualizationTaxFc { get; set; }
        //public decimal EqualizationTaxSys { get; set; }
        //public decimal TaxTotalSum { get; set; }
        //public decimal TaxTotalSumFc { get; set; }
        //public decimal TaxTotalSumSys { get; set; }
        //public Int32 BaseDocEntry { get; set; }
        //public Int32 BaseDocLine { get; set; }
        //public Int32 BaseDocType { get; set; }
        //public Int32 BaseDocumentReference { get; set; }
        //public String LastPurchasePrice { get; set; }
        //public System.Nullable`1[SAPB1.BoStatus] Status { get; set; }
        //public String Stock { get; set; }
        //public Int32 TargetAbsEntry { get; set; }
        //public Int32 TargetType { get; set; }
        //public String WtLiable { get; set; }
        //public String DistributionRule { get; set; }
        //public String Project { get; set; }
        //public String DistributionRule2 { get; set; }
        //public String DistributionRule3 { get; set; }
        //public String DistributionRule4 { get; set; }
        //public String DistributionRule5 { get; set; }
        //public decimal LineGross { get; set; }
        //public decimal LineGrossSys { get; set; }
        //public decimal LineGrossFc { get; set; }
        //public decimal ExternalCalcTaxRate { get; set; }
        //public decimal ExternalCalcTaxAmount { get; set; }
        //public decimal ExternalCalcTaxAmountFc { get; set; }
        //public decimal ExternalCalcTaxAmountSc { get; set; }
        //public String CuSplit { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocExpenseTaxJurisdiction] DocExpenseTaxJurisdictions { get; set; }
        //public System.Collections.ObjectModel.Collection`1[SAPB1.DocFreightEBooksDetail] DocFreightEBooksDetails { get; set; }
    }
}