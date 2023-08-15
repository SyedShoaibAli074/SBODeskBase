using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.IncomingPayment
{
    [ConnectionKey("Default"), Module("IncomingPayment"), ServiceLayer("IncomingPayment")]
    [DisplayName("Payment Credit Card"), InstanceName("Payment Credit Card")]
    [ReadPermission("IncomingPayment")]
    [ModifyPermission("IncomingPayment")]
    [NotMapped]
    public sealed class PaymentCreditCardRow : Row<PaymentCreditCardRow.RowFields>, IIdRow
    {
        [DisplayName("Line Num"), NotNull, IdProperty]
        [NotMapped]
        public System.Int32? LineNum
        {
            get => fields.LineNum[this];
            set => fields.LineNum[this] = value;
        }

        [DisplayName("Credit Card"), NotNull]
        [NotMapped]
        public System.Int32? CreditCard
        {
            get => fields.CreditCard[this];
            set => fields.CreditCard[this] = value;
        }

        [DisplayName("Credit Acct"), NotNull]
        [NotMapped]
        public System.String? CreditAcct
        {
            get => fields.CreditAcct[this];
            set => fields.CreditAcct[this] = value;
        }

        [DisplayName("Credit Card Number"), NotNull]
        [NotMapped]
        public System.String? CreditCardNumber
        {
            get => fields.CreditCardNumber[this];
            set => fields.CreditCardNumber[this] = value;
        }

        [DisplayName("Card Valid Until"), NotNull]
        [NotMapped]
        public DateTime? CardValidUntil
        {
            get => fields.CardValidUntil[this];
            set => fields.CardValidUntil[this] = value;
        }

        [DisplayName("Voucher Num"), NotNull]
        [NotMapped]
        public System.String? VoucherNum
        {
            get => fields.VoucherNum[this];
            set => fields.VoucherNum[this] = value;
        }

        [DisplayName("Owner Id Num"), NotNull]
        [NotMapped]
        public System.String? OwnerIdNum
        {
            get => fields.OwnerIdNum[this];
            set => fields.OwnerIdNum[this] = value;
        }

        [DisplayName("Owner Phone"), NotNull]
        [NotMapped]
        public System.String? OwnerPhone
        {
            get => fields.OwnerPhone[this];
            set => fields.OwnerPhone[this] = value;
        }

        [DisplayName("Payment Method Code"), NotNull]
        [NotMapped]
        public System.Int32? PaymentMethodCode
        {
            get => fields.PaymentMethodCode[this];
            set => fields.PaymentMethodCode[this] = value;
        }

        [DisplayName("Num Of Payments"), NotNull]
        [NotMapped]
        public System.Int32? NumOfPayments
        {
            get => fields.NumOfPayments[this];
            set => fields.NumOfPayments[this] = value;
        }

        [DisplayName("First Payment Due"), NotNull]
        [NotMapped]
        public DateTime? FirstPaymentDue
        {
            get => fields.FirstPaymentDue[this];
            set => fields.FirstPaymentDue[this] = value;
        }

        [DisplayName("First Payment Sum"), NotNull]
        [NotMapped]
        public System.Double? FirstPaymentSum
        {
            get => fields.FirstPaymentSum[this];
            set => fields.FirstPaymentSum[this] = value;
        }

        [DisplayName("Additional Payment Sum"), NotNull]
        [NotMapped]
        public System.Double? AdditionalPaymentSum
        {
            get => fields.AdditionalPaymentSum[this];
            set => fields.AdditionalPaymentSum[this] = value;
        }

        [DisplayName("Credit Sum"), NotNull]
        [NotMapped]
        public System.Double? CreditSum
        {
            get => fields.CreditSum[this];
            set => fields.CreditSum[this] = value;
        }

        [DisplayName("Credit Cur"), NotNull]
        [NotMapped]
        public System.String? CreditCur
        {
            get => fields.CreditCur[this];
            set => fields.CreditCur[this] = value;
        }

        [DisplayName("Credit Rate"), NotNull]
        [NotMapped]
        public System.Double? CreditRate
        {
            get => fields.CreditRate[this];
            set => fields.CreditRate[this] = value;
        }

        [DisplayName("Confirmation Num"), NotNull]
        [NotMapped]
        public System.String? ConfirmationNum
        {
            get => fields.ConfirmationNum[this];
            set => fields.ConfirmationNum[this] = value;
        }

        [DisplayName("Num Of Credit Payments"), NotNull]
        [NotMapped]
        public System.Int32? NumOfCreditPayments
        {
            get => fields.NumOfCreditPayments[this];
            set => fields.NumOfCreditPayments[this] = value;
        }

        [DisplayName("Credit Type"), NotNull]
        [NotMapped]
        public String? CreditType
        {
            get => fields.CreditType[this];
            set => fields.CreditType[this] = value;
        }

        [DisplayName("Split Payments"), NotNull]
        [NotMapped]
        public String? SplitPayments
        {
            get => fields.SplitPayments[this];
            set => fields.SplitPayments[this] = value;
        }

        public PaymentCreditCardRow()
            : base()
        {
        }

        public PaymentCreditCardRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineNum;
            public Int32Field CreditCard;
            public StringField CreditAcct;
            public StringField CreditCardNumber;
            public DateTimeField CardValidUntil;
            public StringField VoucherNum;
            public StringField OwnerIdNum;
            public StringField OwnerPhone;
            public Int32Field PaymentMethodCode;
            public Int32Field NumOfPayments;
            public DateTimeField FirstPaymentDue;
            public DoubleField FirstPaymentSum;
            public DoubleField AdditionalPaymentSum;
            public DoubleField CreditSum;
            public StringField CreditCur;
            public DoubleField CreditRate;
            public StringField ConfirmationNum;
            public Int32Field NumOfCreditPayments;
            public StringField CreditType;
            public StringField SplitPayments;
        }
    }
}
