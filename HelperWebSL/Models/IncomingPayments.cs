using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperWebSL.Models
{
       
    public class PaymentCheck
    {
        public int LineNum { get; set; }
        public DateTime DueDate { get; set; }
        public int CheckNumber { get; set; }
        public string BankCode { get; set; }
        public string Branch { get; set; }
        public string AccounttNum { get; set; }
        public object Details { get; set; }
        public string Trnsfrable { get; set; }
        public double CheckSum { get; set; }
        public string Currency { get; set; }
        public string CountryCode { get; set; }
        public int CheckAbsEntry { get; set; }
        public string CheckAccount { get; set; }
        public string ManualCheck { get; set; }
        public object FiscalID { get; set; }
        public object OriginallyIssuedBy { get; set; }
        public string Endorse { get; set; }
        public object EndorsableCheckNo { get; set; } 
    }

    public class PaymentCreditCard
    {
        public int LineNum { get; set; }
        public int CreditCard { get; set; }
        public string CreditAcct { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardValidUntil { get; set; }
        public string VoucherNum { get; set; }
        public object OwnerIdNum { get; set; }
        public string OwnerPhone { get; set; }
        public int PaymentMethodCode { get; set; }
        public int NumOfPayments { get; set; }
        public string FirstPaymentDue { get; set; }
        public double FirstPaymentSum { get; set; }
        public double AdditionalPaymentSum { get; set; }
        public double CreditSum { get; set; }
        public string CreditCur { get; set; }
        public double CreditRate { get; set; }
        public object ConfirmationNum { get; set; }
        public int NumOfCreditPayments { get; set; }
        public string CreditType { get; set; }
        public string SplitPayments { get; set; }
    }

    public class PaymentInvoice
    {
        public int LineNum { get; set; }
        public int DocEntry { get; set; }
        public double SumApplied { get; set; }
        public double AppliedFC { get; set; }
        public double AppliedSys { get; set; }
        public double DocRate { get; set; }
        public int DocLine { get; set; }
        public string InvoiceType { get; set; }
        public double DiscountPercent { get; set; }
        public double PaidSum { get; set; }
        public int InstallmentId { get; set; }
        public double WitholdingTaxApplied { get; set; }
        public double WitholdingTaxAppliedFC { get; set; }
        public double WitholdingTaxAppliedSC { get; set; }
        public DateTime? LinkDate { get; set; }
        public object DistributionRule { get; set; }
        public object DistributionRule2 { get; set; }
        public object DistributionRule3 { get; set; }
        public object DistributionRule4 { get; set; }
        public object DistributionRule5 { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalDiscountFC { get; set; }
        public double TotalDiscountSC { get; set; } 
    }
 
    public class IncomingPayments
    {
        public int DocNum { get; set; }
        public string DocType { get; set; }
        public string HandWritten { get; set; }
        public string Printed { get; set; }
        public DateTime DocDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string CashAccount { get; set; }
        public string DocCurrency { get; set; }
        public double CashSum { get; set; }
        public string CheckAccount { get; set; }
        public string TransferAccount { get; set; }
        public double TransferSum { get; set; }
        public string TransferDate { get; set; }
        public string TransferReference { get; set; }
        public string LocalCurrency { get; set; }
        public double DocRate { get; set; }
        public string Reference1 { get; set; }
        public object Reference2 { get; set; }
        public object CounterReference { get; set; }
        public object Remarks { get; set; }
        public string JournalRemarks { get; set; }
        public string SplitTransaction { get; set; }
        public int? ContactPersonCode { get; set; }
        public string ApplyVAT { get; set; }
        public DateTime TaxDate { get; set; }
        public int Series { get; set; }
        public string BankCode { get; set; }
        public string BankAccount { get; set; }
        public double DiscountPercent { get; set; }
        public object ProjectCode { get; set; }
        public string CurrencyIsLocal { get; set; }
        public double DeductionPercent { get; set; }
        public double DeductionSum { get; set; }
        public double CashSumFC { get; set; }
        public double CashSumSys { get; set; }
        public object BoeAccount { get; set; }
        public double BillOfExchangeAmount { get; set; }
        public object BillofExchangeStatus { get; set; }
        public double BillOfExchangeAmountFC { get; set; }
        public double BillOfExchangeAmountSC { get; set; }
        public object BillOfExchangeAgent { get; set; }
        public object WTCode { get; set; }
        public double WTAmount { get; set; }
        public double WTAmountFC { get; set; }
        public double WTAmountSC { get; set; }
        public object WTAccount { get; set; }
        public double WTTaxableAmount { get; set; }
        public string Proforma { get; set; }
        public object PayToBankCode { get; set; }
        public object PayToBankBranch { get; set; }
        public object PayToBankAccountNo { get; set; }
        public string PayToCode { get; set; }
        public object PayToBankCountry { get; set; }
        public string IsPayToBank { get; set; }
        public int DocEntry { get; set; }
        public string PaymentPriority { get; set; }
        public object TaxGroup { get; set; }
        public double BankChargeAmount { get; set; }
        public double BankChargeAmountInFC { get; set; }
        public double BankChargeAmountInSC { get; set; }
        public double UnderOverpaymentdifference { get; set; }
        public double UnderOverpaymentdiffSC { get; set; }
        public double WtBaseSum { get; set; }
        public double WtBaseSumFC { get; set; }
        public double WtBaseSumSC { get; set; }
        public object VatDate { get; set; }
        public object TransactionCode { get; set; }
        public string PaymentType { get; set; }
        public double TransferRealAmount { get; set; }
        public string DocObjectCode { get; set; }
        public string DocTypte { get; set; }
        public DateTime DueDate { get; set; }
        public object LocationCode { get; set; }
        public string Cancelled { get; set; }
        public string ControlAccount { get; set; }
        public double? UnderOverpaymentdiffFC { get; set; }
        public string AuthorizationStatus { get; set; }
        public object BPLID { get; set; }
        public object BPLName { get; set; }
        public object VATRegNum { get; set; }
        public object BlanketAgreement { get; set; }
        public string PaymentByWTCertif { get; set; }
        public object Cig { get; set; }
        public object Cup { get; set; }
        public object AttachmentEntry { get; set; } 
        public List<PaymentCheck> PaymentChecks { get; set; }
        public List<PaymentInvoice> PaymentInvoices { get; set; } 
    }


}
