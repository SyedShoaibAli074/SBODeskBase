using SAPWebPortal.Default;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.IncomingPayment
{
    [ConnectionKey("Default"), Module("IncomingPayment"), ServiceLayer("IncomingPayments")]
    [DisplayName("Payment"), InstanceName("Payment")]
    [ReadPermission("IncomingPayment")]
    [ModifyPermission("IncomingPayment")] 
    [NotMapped]
    public sealed class PaymentRow : Row<PaymentRow.RowFields>, IIdRow
    {
        [DisplayName("Payment Type"), NotNull]
        [NotMapped]
        [SAPDBFieldName("PaymType")]
        //System.Nullable`1[SAPB1.BoORCTPaymentTypeEnum]?
        public String PaymentType
        {
            get => fields.PaymentType[this];
            set => fields.PaymentType[this] = value;
        }
        [DisplayName("DBName")]
        [NotMapped]
        //System.Nullable`1[SAPB1.BoORCTPaymentTypeEnum]?
        public String DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }

        [DisplayName("Card Code"), NotNull,QuickSearch]
        [NotMapped]
        [SAPDBFieldName("CardCode")]

        //[SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor($@"Select ""CardCode"" , ""CardName"" from OCRD ""CardType"" ='@DocType'")]

        [_Ext.GridItemPickerEditor(typeof(BusinessPartnerRow))]
        public System.String? CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }
        [DisplayName("Card Name"), NotNull,ReadOnly(true)]
        [NotMapped]
        [SAPDBFieldName("CardName")]
        [QuickSearch]
        public System.String? CardName
        {
            get => fields.CardName[this];
            set => fields.CardName[this] = value;
        }

        [DisplayName("Series"), NotNull, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$" SELECT ""Series"", ""SeriesName""  FROM NNM1 WHERE NNM1.""ObjectCode"" = '24'")]
        [NotMapped]
        [SAPDBFieldName("Series")]
        public Int32? Series
        {
            get => fields.Series[this];
            set => fields.Series[this] = value;
        }
        [DisplayName("Doc Num"), NotNull, IdProperty]
        [SAPPrimaryKey]
        [NotMapped]
        [SAPDBFieldName("DocNum")]
        public Int32? DocNum
        {
            get => fields.DocNum[this];
            set => fields.DocNum[this] = value;
        }

        [DisplayName("Doc Type"), NotNull,DocTypeValuesEditor,DefaultValue("C")]
        [NotMapped]
        [SAPDBFieldName("DocType")]
        // System.Nullable`1[SAPB1.BoRcptTypes]?
        public String? DocType
        {
            get => fields.DocType[this];
            set => fields.DocType[this] = value;
        }

        [DisplayName("Pay To Code"), NotNull]
        [NotMapped]
        [SAPDBFieldName("PayToCode")]

        public System.String? PayToCode
        {
            get => fields.PayToCode[this];
            set => fields.PayToCode[this] = value;
        }



        [DisplayName("Contact Person Code"), NotNull]
        [NotMapped]
        [SAPDBFieldName("CntctCode")]
        public System.Int32? ContactPersonCode
        {
            get => fields.ContactPersonCode[this];
            set => fields.ContactPersonCode[this] = value;
        }

        [DisplayName("Project Code"), NotNull]
        [NotMapped]
        [SAPDBFieldName("PrjCode")]
        public System.String? ProjectCode
        {
            get => fields.ProjectCode[this];
            set => fields.ProjectCode[this] = value;
        }

        [DisplayName("Doc Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocDate")]
        public DateTime? DocDate
        {
            get => fields.DocDate[this];
            set => fields.DocDate[this] = value;
        }

        [DisplayName("Due Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocDueDate")]
        public DateTime? DueDate
        {
            get => fields.DueDate[this];
            set => fields.DueDate[this] = value;
        }

        [DisplayName("Counter Reference"), NotNull]
        [NotMapped]
        public System.String? CounterReference
        {
            get => fields.CounterReference[this];
            set => fields.CounterReference[this] = value;
        }
        [DisplayName("Address"), NotNull]
        [NotMapped]
        public System.String? Address
        {
            get => fields.Address[this];
            set => fields.Address[this] = value;
        }

        [DisplayName("Cash Account"), NotNull]
        [NotMapped]
        public System.String? CashAccount
        {
            get => fields.CashAccount[this];
            set => fields.CashAccount[this] = value;
        }

        [DisplayName("Doc Currency"), NotNull]
        [NotMapped]
        public System.String? DocCurrency
        {
            get => fields.DocCurrency[this];
            set => fields.DocCurrency[this] = value;
        }

        [DisplayName("Cash Sum"), NotNull]
        [NotMapped]
        public System.Double? CashSum
        {
            get => fields.CashSum[this];
            set => fields.CashSum[this] = value;
        }

        [DisplayName("Check Account"), NotNull]
        [NotMapped]
        public System.String? CheckAccount
        {
            get => fields.CheckAccount[this];
            set => fields.CheckAccount[this] = value;
        }

        [DisplayName("Transfer Account"), NotNull]
        [NotMapped]
        public System.String? TransferAccount
        {
            get => fields.TransferAccount[this];
            set => fields.TransferAccount[this] = value;
        }

        [DisplayName("Transfer Sum"), NotNull]
        [NotMapped]
        public System.Double? TransferSum
        {
            get => fields.TransferSum[this];
            set => fields.TransferSum[this] = value;
        }

        [DisplayName("Transfer Date"), NotNull]
        [NotMapped]
        public DateTime? TransferDate
        {
            get => fields.TransferDate[this];
            set => fields.TransferDate[this] = value;
        }

        [DisplayName("Transfer Reference"), NotNull]
        [NotMapped]
        public System.String? TransferReference
        {
            get => fields.TransferReference[this];
            set => fields.TransferReference[this] = value;
        }
        //TransactionCode
        [DisplayName("Transaction Code"), NotNull]
        [NotMapped]
        public System.String? TransactionCode
        {
            get => fields.TransactionCode[this];
            set => fields.TransactionCode[this] = value;
        }

        [DisplayName("Local Currency"), NotNull]
        [NotMapped]
        public String? LocalCurrency
        {
            get => fields.LocalCurrency[this];
            set => fields.LocalCurrency[this] = value;
        }

        [DisplayName("Doc Rate"), NotNull]
        [NotMapped]
        public Double? DocRate
        {
            get => fields.DocRate[this];
            set => fields.DocRate[this] = value;
        }

        //[DisplayName("Reference1"), NotNull]
        //[NotMapped]
        //public System.String? Reference1
        //{
        //    get => fields.Reference1[this];
        //    set => fields.Reference1[this] = value;
        //}

        //[DisplayName("Reference2"), NotNull]
        //[NotMapped]
        //public System.String? Reference2
        //{
        //    get => fields.Reference2[this];
        //    set => fields.Reference2[this] = value;
        //}


        [DisplayName("Remarks"), NotNull]
        [NotMapped]
        public System.String? Remarks
        {
            get => fields.Remarks[this];
            set => fields.Remarks[this] = value;
        }

        [DisplayName("Journal Remarks"), NotNull]
        [NotMapped]
        public System.String? JournalRemarks
        {
            get => fields.JournalRemarks[this];
            set => fields.JournalRemarks[this] = value;
        }

        //[DisplayName("Split Transaction"), NotNull]
        //[NotMapped]
        //public String? SplitTransaction
        //{
        //    get => fields.SplitTransaction[this];
        //    set => fields.SplitTransaction[this] = value;
        //}
        //[DisplayName("Apply Vat"), Column("ApplyVAT"), NotNull]
        //[NotMapped]
        //public String? ApplyVat
        //{
        //    get => fields.ApplyVat[this];
        //    set => fields.ApplyVat[this] = value;
        //}

        [DisplayName("Tax Date"), NotNull]
        [NotMapped]
        public DateTime? TaxDate
        {
            get => fields.TaxDate[this];
            set => fields.TaxDate[this] = value;
        }
        //docentry
        [DisplayName("Doc Entry"), NotNull]
        [NotMapped]
        public System.Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }
        //Paymentinvoices
        [DisplayName("Payment Invoices"), NotNull]
        [NotMapped]
        public System.Collections.Generic.List<PaymentInvoiceRow> PaymentInvoices
        {
            get => fields.PaymentInvoices[this];
            set => fields.PaymentInvoices[this] = value;
        }
        //PaymentChecks
        [DisplayName("Payment Checks"), NotNull]
        [NotMapped]
        public System.Collections.Generic.List<PaymentCheckRow> PaymentChecks
        {
            get => fields.PaymentChecks[this];
            set => fields.PaymentChecks[this] = value;
        }
        //PaymentCreditCards
        [DisplayName("Payment Credit Cards"), NotNull]
        [NotMapped]
        public System.Collections.Generic.List<PaymentCreditCardRow> PaymentCreditCards
        {
            get => fields.PaymentCreditCards[this];
            set => fields.PaymentCreditCards[this] = value;
        }
        //PaymentAccounts
        [DisplayName("Payment Accounts"), NotNull]
        [NotMapped]
        public System.Collections.Generic.List<PaymentAccountRow> PaymentAccounts
        {
            get => fields.PaymentAccounts[this];
            set => fields.PaymentAccounts[this] = value;
        }
        //[DisplayName("Bank Code"), NotNull]
        //[NotMapped]
        //public System.String? BankCode
        //{
        //    get => fields.BankCode[this];
        //    set => fields.BankCode[this] = value;
        //}

        //[DisplayName("Bank Account"), NotNull]
        //[NotMapped]
        //public System.String? BankAccount
        //{
        //    get => fields.BankAccount[this];
        //    set => fields.BankAccount[this] = value;
        //}

        //[DisplayName("Discount Percent"), NotNull]
        //[NotMapped]
        //public Double?? DiscountPercent
        //{
        //    get => fields.DiscountPercent[this];
        //    set => fields.DiscountPercent[this] = value;
        //}


        //[DisplayName("Currency Is Local"), NotNull]
        //[NotMapped]
        //public String? CurrencyIsLocal
        //{
        //    get => fields.CurrencyIsLocal[this];
        //    set => fields.CurrencyIsLocal[this] = value;
        //}

        //[DisplayName("Deduction Percent"), NotNull]
        //[NotMapped]
        //public Double?? DeductionPercent
        //{
        //    get => fields.DeductionPercent[this];
        //    set => fields.DeductionPercent[this] = value;
        //}

        //[DisplayName("Deduction Sum"), NotNull]
        //[NotMapped]
        //public Double?? DeductionSum
        //{
        //    get => fields.DeductionSum[this];
        //    set => fields.DeductionSum[this] = value;
        //}

        //[DisplayName("Cash Sum Fc"), Column("CashSumFC"), NotNull]
        //[NotMapped]
        //public Double?? CashSumFc
        //{
        //    get => fields.CashSumFc[this];
        //    set => fields.CashSumFc[this] = value;
        //}

        //[DisplayName("Cash Sum Sys"), NotNull]
        //[NotMapped]
        //public Double?? CashSumSys
        //{
        //    get => fields.CashSumSys[this];
        //    set => fields.CashSumSys[this] = value;
        //}

        //[DisplayName("Boe Account"), NotNull]
        //[NotMapped]
        //public System.String? BoeAccount
        //{
        //    get => fields.BoeAccount[this];
        //    set => fields.BoeAccount[this] = value;
        //}

        //[DisplayName("Bill Of Exchange Amount"), NotNull]
        //[NotMapped]
        //public Double?? BillOfExchangeAmount
        //{
        //    get => fields.BillOfExchangeAmount[this];
        //    set => fields.BillOfExchangeAmount[this] = value;
        //}

        //[DisplayName("Billof Exchange Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoBoeStatus]? BillofExchangeStatus
        //{
        //    get => fields.BillofExchangeStatus[this];
        //    set => fields.BillofExchangeStatus[this] = value;
        //}

        //[DisplayName("Bill Of Exchange Amount Fc"), Column("BillOfExchangeAmountFC"), NotNull]
        //[NotMapped]
        //public Double?? BillOfExchangeAmountFc
        //{
        //    get => fields.BillOfExchangeAmountFc[this];
        //    set => fields.BillOfExchangeAmountFc[this] = value;
        //}

        //[DisplayName("Bill Of Exchange Amount Sc"), Column("BillOfExchangeAmountSC"), NotNull]
        //[NotMapped]
        //public Double?? BillOfExchangeAmountSc
        //{
        //    get => fields.BillOfExchangeAmountSc[this];
        //    set => fields.BillOfExchangeAmountSc[this] = value;
        //}

        //[DisplayName("Bill Of Exchange Agent"), NotNull]
        //[NotMapped]
        //public System.String? BillOfExchangeAgent
        //{
        //    get => fields.BillOfExchangeAgent[this];
        //    set => fields.BillOfExchangeAgent[this] = value;
        //}

        //[DisplayName("Wt Code"), Column("WTCode"), NotNull]
        //[NotMapped]
        //public System.String? WtCode
        //{
        //    get => fields.WtCode[this];
        //    set => fields.WtCode[this] = value;
        //}

        //[DisplayName("Wt Amount"), Column("WTAmount"), NotNull]
        //[NotMapped]
        //public Double?? WtAmount
        //{
        //    get => fields.WtAmount[this];
        //    set => fields.WtAmount[this] = value;
        //}

        //[DisplayName("Wt Amount Fc"), Column("WTAmountFC"), NotNull]
        //[NotMapped]
        //public Double?? WtAmountFc
        //{
        //    get => fields.WtAmountFc[this];
        //    set => fields.WtAmountFc[this] = value;
        //}

        //[DisplayName("Wt Amount Sc"), Column("WTAmountSC"), NotNull]
        //[NotMapped]
        //public Double?? WtAmountSc
        //{
        //    get => fields.WtAmountSc[this];
        //    set => fields.WtAmountSc[this] = value;
        //}

        //[DisplayName("Wt Account"), Column("WTAccount"), NotNull]
        //[NotMapped]
        //public System.String? WtAccount
        //{
        //    get => fields.WtAccount[this];
        //    set => fields.WtAccount[this] = value;
        //}

        //[DisplayName("Wt Taxable Amount"), Column("WTTaxableAmount"), NotNull]
        //[NotMapped]
        //public Double?? WtTaxableAmount
        //{
        //    get => fields.WtTaxableAmount[this];
        //    set => fields.WtTaxableAmount[this] = value;
        //}

        //[DisplayName("Proforma"), NotNull]
        //[NotMapped]
        //public String? Proforma
        //{
        //    get => fields.Proforma[this];
        //    set => fields.Proforma[this] = value;
        //}

        //[DisplayName("Pay To Bank Code"), NotNull]
        //[NotMapped]
        //public System.String? PayToBankCode
        //{
        //    get => fields.PayToBankCode[this];
        //    set => fields.PayToBankCode[this] = value;
        //}

        //[DisplayName("Pay To Bank Branch"), NotNull]
        //[NotMapped]
        //public System.String? PayToBankBranch
        //{
        //    get => fields.PayToBankBranch[this];
        //    set => fields.PayToBankBranch[this] = value;
        //}

        //[DisplayName("Pay To Bank Account No"), NotNull]
        //[NotMapped]
        //public System.String? PayToBankAccountNo
        //{
        //    get => fields.PayToBankAccountNo[this];
        //    set => fields.PayToBankAccountNo[this] = value;
        //}

        //[DisplayName("Pay To Bank Country"), NotNull]
        //[NotMapped]
        //public System.String? PayToBankCountry
        //{
        //    get => fields.PayToBankCountry[this];
        //    set => fields.PayToBankCountry[this] = value;
        //}

        //[DisplayName("Is Pay To Bank"), NotNull]
        //[NotMapped]
        //public String? IsPayToBank
        //{
        //    get => fields.IsPayToBank[this];
        //    set => fields.IsPayToBank[this] = value;
        //}

        //[DisplayName("Doc Entry"), NotNull]
        //[NotMapped]
        //public System.Int32? DocEntry
        //{
        //    get => fields.DocEntry[this];
        //    set => fields.DocEntry[this] = value;
        //}

        //[DisplayName("Payment Priority"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoPaymentPriorities]? PaymentPriority
        //{
        //    get => fields.PaymentPriority[this];
        //    set => fields.PaymentPriority[this] = value;
        //}

        //[DisplayName("Tax Group"), NotNull]
        //[NotMapped]
        //public System.String? TaxGroup
        //{
        //    get => fields.TaxGroup[this];
        //    set => fields.TaxGroup[this] = value;
        //}

        //[DisplayName("Bank Charge Amount"), NotNull]
        //[NotMapped]
        //public Double?? BankChargeAmount
        //{
        //    get => fields.BankChargeAmount[this];
        //    set => fields.BankChargeAmount[this] = value;
        //}

        //[DisplayName("Bank Charge Amount In Fc"), Column("BankChargeAmountInFC"), NotNull]
        //[NotMapped]
        //public Double?? BankChargeAmountInFc
        //{
        //    get => fields.BankChargeAmountInFc[this];
        //    set => fields.BankChargeAmountInFc[this] = value;
        //}

        //[DisplayName("Bank Charge Amount In Sc"), Column("BankChargeAmountInSC"), NotNull]
        //[NotMapped]
        //public Double?? BankChargeAmountInSc
        //{
        //    get => fields.BankChargeAmountInSc[this];
        //    set => fields.BankChargeAmountInSc[this] = value;
        //}

        //[DisplayName("Under Overpaymentdifference"), NotNull]
        //[NotMapped]
        //public Double?? UnderOverpaymentdifference
        //{
        //    get => fields.UnderOverpaymentdifference[this];
        //    set => fields.UnderOverpaymentdifference[this] = value;
        //}

        //[DisplayName("Under Overpaymentdiff Sc"), Column("UnderOverpaymentdiffSC"), NotNull]
        //[NotMapped]
        //public Double?? UnderOverpaymentdiffSc
        //{
        //    get => fields.UnderOverpaymentdiffSc[this];
        //    set => fields.UnderOverpaymentdiffSc[this] = value;
        //}

        //[DisplayName("Wt Base Sum"), NotNull]
        //[NotMapped]
        //public Double?? WtBaseSum
        //{
        //    get => fields.WtBaseSum[this];
        //    set => fields.WtBaseSum[this] = value;
        //}

        //[DisplayName("Wt Base Sum Fc"), Column("WtBaseSumFC"), NotNull]
        //[NotMapped]
        //public Double?? WtBaseSumFc
        //{
        //    get => fields.WtBaseSumFc[this];
        //    set => fields.WtBaseSumFc[this] = value;
        //}

        //[DisplayName("Wt Base Sum Sc"), Column("WtBaseSumSC"), NotNull]
        //[NotMapped]
        //public Double?? WtBaseSumSc
        //{
        //    get => fields.WtBaseSumSc[this];
        //    set => fields.WtBaseSumSc[this] = value;
        //}

        //[DisplayName("Vat Date"), NotNull]
        //[NotMapped]
        //public DateTime? VatDate
        //{
        //    get => fields.VatDate[this];
        //    set => fields.VatDate[this] = value;
        //}

        //[DisplayName("Transaction Code"), NotNull]
        //[NotMapped]
        //public System.String? TransactionCode
        //{
        //    get => fields.TransactionCode[this];
        //    set => fields.TransactionCode[this] = value;
        //}


        //[DisplayName("Transfer Real Amount"), NotNull]
        //[NotMapped]
        //public Double?? TransferRealAmount
        //{
        //    get => fields.TransferRealAmount[this];
        //    set => fields.TransferRealAmount[this] = value;
        //}

        //[DisplayName("Doc Object Code"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoPaymentsObjectType]? DocObjectCode
        //{
        //    get => fields.DocObjectCode[this];
        //    set => fields.DocObjectCode[this] = value;
        //}

        //[DisplayName("Doc Typte"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.BoRcptTypes]? DocTypte
        //{
        //    get => fields.DocTypte[this];
        //    set => fields.DocTypte[this] = value;
        //}


        //[DisplayName("Location Code"), NotNull]
        //[NotMapped]
        //public Int32? LocationCode
        //{
        //    get => fields.LocationCode[this];
        //    set => fields.LocationCode[this] = value;
        //}

        //[DisplayName("Cancelled"), NotNull]
        //[NotMapped]
        //public String? Cancelled
        //{
        //    get => fields.Cancelled[this];
        //    set => fields.Cancelled[this] = value;
        //}

        //[DisplayName("Control Account"), NotNull]
        //[NotMapped]
        //public System.String? ControlAccount
        //{
        //    get => fields.ControlAccount[this];
        //    set => fields.ControlAccount[this] = value;
        //}

        //[DisplayName("Under Overpaymentdiff Fc"), Column("UnderOverpaymentdiffFC"), NotNull]
        //[NotMapped]
        //public Double?? UnderOverpaymentdiffFc
        //{
        //    get => fields.UnderOverpaymentdiffFc[this];
        //    set => fields.UnderOverpaymentdiffFc[this] = value;
        //}

        //[DisplayName("Authorization Status"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[SAPB1.PaymentsAuthorizationStatusEnum]? AuthorizationStatus
        //{
        //    get => fields.AuthorizationStatus[this];
        //    set => fields.AuthorizationStatus[this] = value;
        //}

        //[DisplayName("Bplid"), Column("BPLID"), NotNull]
        //[NotMapped]
        //public Int32? Bplid
        //{
        //    get => fields.Bplid[this];
        //    set => fields.Bplid[this] = value;
        //}

        //[DisplayName("Bpl Name"), Column("BPLName"), NotNull]
        //[NotMapped]
        //public System.String? BplName
        //{
        //    get => fields.BplName[this];
        //    set => fields.BplName[this] = value;
        //}

        //[DisplayName("Vat Reg Num"), Column("VATRegNum"), NotNull]
        //[NotMapped]
        //public System.String? VatRegNum
        //{
        //    get => fields.VatRegNum[this];
        //    set => fields.VatRegNum[this] = value;
        //}

        //[DisplayName("Blanket Agreement"), NotNull]
        //[NotMapped]
        //public Int32? BlanketAgreement
        //{
        //    get => fields.BlanketAgreement[this];
        //    set => fields.BlanketAgreement[this] = value;
        //}

        //[DisplayName("Payment By Wt Certif"), Column("PaymentByWTCertif"), NotNull]
        //[NotMapped]
        //public String? PaymentByWtCertif
        //{
        //    get => fields.PaymentByWtCertif[this];
        //    set => fields.PaymentByWtCertif[this] = value;
        //}

        //[DisplayName("Cig"), NotNull]
        //[NotMapped]
        //public Int32? Cig
        //{
        //    get => fields.Cig[this];
        //    set => fields.Cig[this] = value;
        //}

        //[DisplayName("Cup"), NotNull]
        //[NotMapped]
        //public Int32? Cup
        //{
        //    get => fields.Cup[this];
        //    set => fields.Cup[this] = value;
        //}

        //[DisplayName("Attachment Entry"), NotNull]
        //[NotMapped]
        //public Int32? AttachmentEntry
        //{
        //    get => fields.AttachmentEntry[this];
        //    set => fields.AttachmentEntry[this] = value;
        //}

        //[DisplayName("U Branch"), Column("U_Branch"), NotNull]
        //[NotMapped]
        //public System.String? UBranch
        //{
        //    get => fields.UBranch[this];
        //    set => fields.UBranch[this] = value;
        //}

        //[DisplayName("U Z Cont Id"), Column("U_Z_ContID"), NotNull]
        //[NotMapped]
        //public Int32? UZContId
        //{
        //    get => fields.UZContId[this];
        //    set => fields.UZContId[this] = value;
        //}

        //[DisplayName("U Z Cont Number"), Column("U_Z_ContNumber"), NotNull]
        //[NotMapped]
        //public System.String? UZContNumber
        //{
        //    get => fields.UZContNumber[this];
        //    set => fields.UZContNumber[this] = value;
        //}

        //[DisplayName("U Z Cnt Number"), Column("U_Z_CntNumber"), NotNull]
        //[NotMapped]
        //public System.String? UZCntNumber
        //{
        //    get => fields.UZCntNumber[this];
        //    set => fields.UZCntNumber[this] = value;
        //}

        //[DisplayName("U Seq"), Column("U_Seq"), NotNull]
        //[NotMapped]
        //public Int32? USeq
        //{
        //    get => fields.USeq[this];
        //    set => fields.USeq[this] = value;
        //}

        //[DisplayName("U Z From Date"), Column("U_Z_FromDate"), NotNull]
        //[NotMapped]
        //public DateTime? UZFromDate
        //{
        //    get => fields.UZFromDate[this];
        //    set => fields.UZFromDate[this] = value;
        //}

        //[DisplayName("U Z To Date"), Column("U_Z_ToDate"), NotNull]
        //[NotMapped]
        //public DateTime? UZToDate
        //{
        //    get => fields.UZToDate[this];
        //    set => fields.UZToDate[this] = value;
        //}

        //[DisplayName("Payment Checks"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.PaymentCheck]? PaymentChecks
        //{
        //    get => fields.PaymentChecks[this];
        //    set => fields.PaymentChecks[this] = value;
        //}

        //[DisplayName("Payment Invoices"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.PaymentInvoice]? PaymentInvoices
        //{
        //    get => fields.PaymentInvoices[this];
        //    set => fields.PaymentInvoices[this] = value;
        //}

        //[DisplayName("Payment Credit Cards"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.PaymentCreditCard]? PaymentCreditCards
        //{
        //    get => fields.PaymentCreditCards[this];
        //    set => fields.PaymentCreditCards[this] = value;
        //}

        //[DisplayName("Payment Accounts"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.PaymentAccount]? PaymentAccounts
        //{
        //    get => fields.PaymentAccounts[this];
        //    set => fields.PaymentAccounts[this] = value;
        //}

        //[DisplayName("Payment Document References Collection"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.PaymentDocumentReferences]? PaymentDocumentReferencesCollection
        //{
        //    get => fields.PaymentDocumentReferencesCollection[this];
        //    set => fields.PaymentDocumentReferencesCollection[this] = value;
        //}

        //[DisplayName("Bill Of Exchange"), NotNull]
        //[NotMapped]
        //public SAPB1.BillOfExchange? BillOfExchange
        //{
        //    get => fields.BillOfExchange[this];
        //    set => fields.BillOfExchange[this] = value;
        //}

        //[DisplayName("Withholding Tax Certificates Collection"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxCertificatesData]? WithholdingTaxCertificatesCollection
        //{
        //    get => fields.WithholdingTaxCertificatesCollection[this];
        //    set => fields.WithholdingTaxCertificatesCollection[this] = value;
        //}

        //[DisplayName("Electronic Protocols"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.ElectronicProtocol]? ElectronicProtocols
        //{
        //    get => fields.ElectronicProtocols[this];
        //    set => fields.ElectronicProtocols[this] = value;
        //}

        //[DisplayName("Cash Flow Assignments"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.CashFlowAssignment]? CashFlowAssignments
        //{
        //    get => fields.CashFlowAssignments[this];
        //    set => fields.CashFlowAssignments[this] = value;
        //}

        //[DisplayName("Payments Approval Requests"), Column("Payments_ApprovalRequests"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.Payments_ApprovalRequest]? PaymentsApprovalRequests
        //{
        //    get => fields.PaymentsApprovalRequests[this];
        //    set => fields.PaymentsApprovalRequests[this] = value;
        //}

        //[DisplayName("Withholding Tax Data Wtx Collection"), Column("WithholdingTaxDataWTXCollection"), NotNull]
        //[NotMapped]
        //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxDataWTX]? WithholdingTaxDataWtxCollection
        //{
        //    get => fields.WithholdingTaxDataWtxCollection[this];
        //    set => fields.WithholdingTaxDataWtxCollection[this] = value;
        //}

        //[DisplayName("Chart Of Account"), NotNull]
        //[NotMapped]
        //public SAPB1.ChartOfAccount? ChartOfAccount
        //{
        //    get => fields.ChartOfAccount[this];
        //    set => fields.ChartOfAccount[this] = value;
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

        //[DisplayName("Withholding Tax Code"), NotNull]
        //[NotMapped]
        //public SAPB1.WithholdingTaxCode? WithholdingTaxCode
        //{
        //    get => fields.WithholdingTaxCode[this];
        //    set => fields.WithholdingTaxCode[this] = value;
        //}

        //[DisplayName("Country"), NotNull]
        //[NotMapped]
        //public SAPB1.Country? Country
        //{
        //    get => fields.Country[this];
        //    set => fields.Country[this] = value;
        //}

        //[DisplayName("Vat Group"), NotNull]
        //[NotMapped]
        //public SAPB1.VatGroup? VatGroup
        //{
        //    get => fields.VatGroup[this];
        //    set => fields.VatGroup[this] = value;
        //}

        //[DisplayName("Transaction Code2"), NotNull]
        //[NotMapped]
        //public SAPB1.TransactionCode? TransactionCode2
        //{
        //    get => fields.TransactionCode2[this];
        //    set => fields.TransactionCode2[this] = value;
        //}

        //[DisplayName("Warehouse Location"), NotNull]
        //[NotMapped]
        //public SAPB1.WarehouseLocation? WarehouseLocation
        //{
        //    get => fields.WarehouseLocation[this];
        //    set => fields.WarehouseLocation[this] = value;
        //}

        //[DisplayName("Business Place"), NotNull]
        //[NotMapped]
        //public SAPB1.BusinessPlace? BusinessPlace
        //{
        //    get => fields.BusinessPlace[this];
        //    set => fields.BusinessPlace[this] = value;
        //}

        //[DisplayName("Blanket Agreement2"), NotNull]
        //[NotMapped]
        //public SAPB1.BlanketAgreement? BlanketAgreement2
        //{
        //    get => fields.BlanketAgreement2[this];
        //    set => fields.BlanketAgreement2[this] = value;
        //}

        //[DisplayName("Attachments2"), NotNull]
        //[NotMapped]
        //public SAPB1.Attachments2? Attachments2
        //{
        //    get => fields.Attachments2[this];
        //    set => fields.Attachments2[this] = value;
        //}
        //U_UserSign
        [DisplayName("User Sign"), Size(20), NotNull]
        [NotMapped]
        public int? U_UserSign
        {
            get => fields.U_UserSign[this];
            set => fields.U_UserSign[this] = value;
        }
        [DisplayName("U_Sector"), Size(200), NotNull]
        [NotMapped]
        public String U_Sector
        {
            get => fields.U_Sector[this];
            set => fields.U_Sector[this] = value;
        }
        //U_UserCode
        [DisplayName("User Code"), Size(20), NotNull]
        [NotMapped]
        public string? U_UserCode
        {
            get => fields.U_UserCode[this];
            set => fields.U_UserCode[this] = value;
        }
        public PaymentRow()
            : base()
        {
        }

        public PaymentRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField PaymentType;
            public StringField CardCode;
            public StringField CardName;
            public StringField DBName;
            public Int32Field Series;
            public  Int32Field DocNum;
            public StringField DocType;
            public StringField PayToCode;
            public Int32Field ContactPersonCode;
            public StringField ProjectCode;
            public DateTimeField DocDate;
            public DateTimeField DueDate;
            public StringField CounterReference;
            //public Int32Field HandWritten;
            //public Int32Field Printed;
            public StringField Address;
            public StringField U_Sector;
            public StringField CashAccount;
            public StringField DocCurrency;
            public DoubleField CashSum;
            public StringField CheckAccount;
            public StringField TransferAccount;
            public DoubleField TransferSum;
            public DateTimeField TransferDate;
            public StringField TransferReference;
            public StringField TransactionCode;
            public StringField LocalCurrency;
            public DoubleField DocRate;
            //public StringField Reference1;
            //public StringField Reference2;
            //
            public StringField Remarks;
            public StringField JournalRemarks;
            public Int32Field U_UserSign;
            public StringField U_UserCode;
            //public StringField SplitTransaction;

            //public StringField ApplyVat;
            public DateTimeField TaxDate;
            //public StringField BankCode;
            //public StringField BankAccount;
            //public DoubleField DiscountPercent;
            //
            //public StringField CurrencyIsLocal;
            //public DoubleField DeductionPercent;
            //public DoubleField DeductionSum;
            //public DoubleField CashSumFc;
            //public DoubleField CashSumSys;
            //public StringField BoeAccount;
            //public DoubleField BillOfExchangeAmount;
            //public StringField BillofExchangeStatus;
            //public DoubleField BillOfExchangeAmountFc;
            //public DoubleField BillOfExchangeAmountSc;
            //public StringField BillOfExchangeAgent;
            //public StringField WtCode;
            //public DoubleField WtAmount;
            //public DoubleField WtAmountFc;
            //public DoubleField WtAmountSc;
            //public StringField WtAccount;
            //public DoubleField WtTaxableAmount;
            //public StringField Proforma;
            //public StringField PayToBankCode;
            //public StringField PayToBankBranch;
            //public StringField PayToBankAccountNo;
            
            //public StringField PayToBankCountry;
            //public StringField IsPayToBank;
            public Int32Field DocEntry;
            //public StringField PaymentPriority;
            //public StringField TaxGroup;
            //public DoubleField BankChargeAmount;
            //public DoubleField BankChargeAmountInFc;
            //public DoubleField BankChargeAmountInSc;
            //public DoubleField UnderOverpaymentdifference;
            //public DoubleField UnderOverpaymentdiffSc;
            //public DoubleField WtBaseSum;
            //public DoubleField WtBaseSumFc;
            //public DoubleField WtBaseSumSc;
            //public DateTimeField VatDate;
            //public DoubleField TransferRealAmount;
            //public StringField DocObjectCode;
            //public StringField DocTypte;
            //public Int32Field LocationCode;
            //public StringField Cancelled;
            //public StringField ControlAccount;
            //public DoubleField UnderOverpaymentdiffFc;
            //public StringField AuthorizationStatus;
            //public Int32Field Bplid;
            //public StringField BplName;
            //public StringField VatRegNum;
            //public Int32Field BlanketAgreement;
            //public StringField PaymentByWtCertif;
            //public Int32Field Cig;
            //public Int32Field Cup;
            //public Int32Field AttachmentEntry;
            //public StringField UBranch;
            //public Int32Field UZContId;
            //public StringField UZContNumber;
            //public StringField UZCntNumber;
            //public Int32Field USeq;
            //public DateTimeField UZFromDate;
            //public DateTimeField UZToDate;
            
            public RowListField<PaymentInvoiceRow> PaymentInvoices;
            public RowListField< PaymentCheckRow> PaymentChecks;
            public RowListField<PaymentCreditCardRow> PaymentCreditCards;
            public RowListField<PaymentAccountRow> PaymentAccounts;
           // public System.Collections.ObjectModel.Collection`1[SAPB1.PaymentDocumentReferences]Field PaymentDocumentReferencesCollection;
           // public SAPB1.BillOfExchange Field BillOfExchange;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxCertificatesData]Field WithholdingTaxCertificatesCollection;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.ElectronicProtocol]Field ElectronicProtocols;
           // public System.Collections.ObjectModel.Collection`1[SAPB1.CashFlowAssignment]Field CashFlowAssignments;
           // public System.Collections.ObjectModel.Collection`1[SAPB1.Payments_ApprovalRequest]Field PaymentsApprovalRequests;
           // public System.Collections.ObjectModel.Collection`1[SAPB1.WithholdingTaxDataWTX]Field WithholdingTaxDataWtxCollection;
           // public SAPB1.ChartOfAccountField ChartOfAccount;
            //public StringField Currency;
            //public SAPB1.Project Field Project;
            //public SAPB1.WithholdingTaxCode Field WithholdingTaxCode;
            //public SAPB1.Country Field Country;
            //public SAPB1.VatGroup Field VatGroup;
            //public SAPB1.TransactionCode Field TransactionCode2;
            //public SAPB1.WarehouseLocation Field WarehouseLocation;
            //public SAPB1.BusinessPlace Field BusinessPlace;
            //public SAPB1.BlanketAgreement Field BlanketAgreement2;
            //public SAPB1.Attachments2 Field Attachments2;
        }
    }
}
