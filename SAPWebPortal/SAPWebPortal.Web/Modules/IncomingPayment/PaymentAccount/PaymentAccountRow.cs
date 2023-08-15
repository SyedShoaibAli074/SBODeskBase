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
    [DisplayName("Payment Account"), InstanceName("Payment Account")]
    [ReadPermission("IncomingPayment")]
    [ModifyPermission("IncomingPayment")]
    [NotMapped]
    public sealed class PaymentAccountRow : Row<PaymentAccountRow.RowFields>, IIdRow
    {
        [DisplayName("Line Num"), NotNull, IdProperty]
        [NotMapped]
        public System.Int32? LineNum
        {
            get => fields.LineNum[this];
            set => fields.LineNum[this] = value;
        }

        [DisplayName("Account Code"), NotNull]
        [NotMapped]
        public System.String? AccountCode
        {
            get => fields.AccountCode[this];
            set => fields.AccountCode[this] = value;
        }

        [DisplayName("Sum Paid"), NotNull]
        [NotMapped]
        public System.Double? SumPaid
        {
            get => fields.SumPaid[this];
            set => fields.SumPaid[this] = value;
        }

        [DisplayName("Sum Paid Fc"), Column("SumPaidFC"), NotNull]
        [NotMapped]
        public System.Double? SumPaidFc
        {
            get => fields.SumPaidFc[this];
            set => fields.SumPaidFc[this] = value;
        }

        [DisplayName("Decription"), NotNull]
        [NotMapped]
        public System.String? Decription
        {
            get => fields.Decription[this];
            set => fields.Decription[this] = value;
        }

        [DisplayName("Vat Group"), NotNull]
        [NotMapped]
        public System.String? VatGroup
        {
            get => fields.VatGroup[this];
            set => fields.VatGroup[this] = value;
        }

        [DisplayName("Account Name"), NotNull]
        [NotMapped]
        public System.String? AccountName
        {
            get => fields.AccountName[this];
            set => fields.AccountName[this] = value;
        }

        [DisplayName("Gross Amount"), NotNull]
        [NotMapped]
        public System.Double? GrossAmount
        {
            get => fields.GrossAmount[this];
            set => fields.GrossAmount[this] = value;
        }

        [DisplayName("Profit Center"), NotNull]
        [NotMapped]
        public System.String? ProfitCenter
        {
            get => fields.ProfitCenter[this];
            set => fields.ProfitCenter[this] = value;
        }

        [DisplayName("Project Code"), NotNull]
        [NotMapped]
        public System.String? ProjectCode
        {
            get => fields.ProjectCode[this];
            set => fields.ProjectCode[this] = value;
        }

        [DisplayName("Vat Amount"), NotNull]
        [NotMapped]
        public System.Double? VatAmount
        {
            get => fields.VatAmount[this];
            set => fields.VatAmount[this] = value;
        }

        [DisplayName("Profit Center2"), NotNull]
        [NotMapped]
        public System.String? ProfitCenter2
        {
            get => fields.ProfitCenter2[this];
            set => fields.ProfitCenter2[this] = value;
        }

        [DisplayName("Profit Center3"), NotNull]
        [NotMapped]
        public System.String? ProfitCenter3
        {
            get => fields.ProfitCenter3[this];
            set => fields.ProfitCenter3[this] = value;
        }

        [DisplayName("Profit Center4"), NotNull]
        [NotMapped]
        public System.String? ProfitCenter4
        {
            get => fields.ProfitCenter4[this];
            set => fields.ProfitCenter4[this] = value;
        }

        [DisplayName("Profit Center5"), NotNull]
        [NotMapped]
        public System.String? ProfitCenter5
        {
            get => fields.ProfitCenter5[this];
            set => fields.ProfitCenter5[this] = value;
        }

        [DisplayName("Location Code"), NotNull]
        [NotMapped]
        public System.Int32? LocationCode
        {
            get => fields.LocationCode[this];
            set => fields.LocationCode[this] = value;
        }

        [DisplayName("Equalization Vat Amount"), NotNull]
        [NotMapped]
        public System.Double? EqualizationVatAmount
        {
            get => fields.EqualizationVatAmount[this];
            set => fields.EqualizationVatAmount[this] = value;
        }

        public PaymentAccountRow()
            : base()
        {
        }

        public PaymentAccountRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineNum;
            public StringField AccountCode;
            public DoubleField SumPaid;
            public DoubleField SumPaidFc;
            public StringField Decription;
            public StringField VatGroup;
            public StringField AccountName;
            public DoubleField GrossAmount;
            public StringField ProfitCenter;
            public StringField ProjectCode;
            public DoubleField VatAmount;
            public StringField ProfitCenter2;
            public StringField ProfitCenter3;
            public StringField ProfitCenter4;
            public StringField ProfitCenter5;
            public Int32Field LocationCode;
            public DoubleField EqualizationVatAmount;
        }
    }
}
