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
    [DisplayName("Payment Check"), InstanceName("Payment Check")]
    [ReadPermission("IncomingPayment")]
    [ModifyPermission("IncomingPayment")]
    [NotMapped]
    public sealed class PaymentCheckRow : Row<PaymentCheckRow.RowFields>, IIdRow
    {
        [DisplayName("Line Num"), NotNull, IdProperty]
        [NotMapped]
        public Int32? LineNum
        {
            get => fields.LineNum[this];
            set => fields.LineNum[this] = value;
        }

        [DisplayName("Due Date"), NotNull]
        [NotMapped]
        public DateTime? DueDate
        {
            get => fields.DueDate[this];
            set => fields.DueDate[this] = value;
        }

        [DisplayName("Check Number"), NotNull]
        [NotMapped]
        public Int32? CheckNumber
        {
            get => fields.CheckNumber[this];
            set => fields.CheckNumber[this] = value;
        }

        [DisplayName("Bank Code"), NotNull]
        [NotMapped]
        public System.String? BankCode
        {
            get => fields.BankCode[this];
            set => fields.BankCode[this] = value;
        }

        [DisplayName("Branch"), NotNull]
        [NotMapped]
        public System.String? Branch
        {
            get => fields.Branch[this];
            set => fields.Branch[this] = value;
        }

        [DisplayName("Accountt Num"), NotNull]
        [NotMapped]
        public System.String? AccounttNum
        {
            get => fields.AccounttNum[this];
            set => fields.AccounttNum[this] = value;
        }

        [DisplayName("Details"), NotNull]
        [NotMapped]
        public System.String? Details
        {
            get => fields.Details[this];
            set => fields.Details[this] = value;
        }

        [DisplayName("Trnsfrable"), NotNull]
        [NotMapped]
        public String? Trnsfrable
        {
            get => fields.Trnsfrable[this];
            set => fields.Trnsfrable[this] = value;
        }

        [DisplayName("Check Sum"), NotNull]
        [NotMapped]
        public System.Double? CheckSum
        {
            get => fields.CheckSum[this];
            set => fields.CheckSum[this] = value;
        }

        [DisplayName("Currency"), NotNull]
        [NotMapped]
        public System.String? Currency
        {
            get => fields.Currency[this];
            set => fields.Currency[this] = value;
        }

        [DisplayName("Country Code"), NotNull]
        [NotMapped]
        public System.String? CountryCode
        {
            get => fields.CountryCode[this];
            set => fields.CountryCode[this] = value;
        }

        [DisplayName("Check Abs Entry"), NotNull]
        [NotMapped]
        public System.Int32? CheckAbsEntry
        {
            get => fields.CheckAbsEntry[this];
            set => fields.CheckAbsEntry[this] = value;
        }

        [DisplayName("Check Account"), NotNull]
        [NotMapped]
        public System.String? CheckAccount
        {
            get => fields.CheckAccount[this];
            set => fields.CheckAccount[this] = value;
        }

        [DisplayName("Manual Check"), NotNull]
        [NotMapped]
        public String? ManualCheck
        {
            get => fields.ManualCheck[this];
            set => fields.ManualCheck[this] = value;
        }

        [DisplayName("Fiscal Id"), Column("FiscalID"), NotNull]
        [NotMapped]
        public System.String? FiscalId
        {
            get => fields.FiscalId[this];
            set => fields.FiscalId[this] = value;
        }

        [DisplayName("Originally Issued By"), NotNull]
        [NotMapped]
        public System.String? OriginallyIssuedBy
        {
            get => fields.OriginallyIssuedBy[this];
            set => fields.OriginallyIssuedBy[this] = value;
        }

        [DisplayName("Endorse"), NotNull]
        [NotMapped]
        public String? Endorse
        {
            get => fields.Endorse[this];
            set => fields.Endorse[this] = value;
        }

        [DisplayName("Endorsable Check No"), NotNull]
        [NotMapped]
        public System.Int32? EndorsableCheckNo
        {
            get => fields.EndorsableCheckNo[this];
            set => fields.EndorsableCheckNo[this] = value;
        }
        //BankAccount
         
        //U_UserSign
        [DisplayName("User Code"), NotNull]
        [NotMapped]
        public System.String? U_UserCode
        {
            get => fields.U_UserCode[this];
            set => fields.U_UserCode[this] = value;
        }
        public PaymentCheckRow()
            : base()
        {
        }

        public PaymentCheckRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineNum;
            public DateTimeField DueDate;
            public Int32Field CheckNumber;
            public StringField BankCode;
            public StringField Branch;
            public StringField AccounttNum;
            public StringField Details;
            public StringField Trnsfrable;
            public DoubleField CheckSum;
            public StringField Currency;
            public StringField CountryCode;
            public Int32Field CheckAbsEntry;
            public StringField CheckAccount;
            public StringField ManualCheck;
            public StringField FiscalId;
            public StringField OriginallyIssuedBy;
            public StringField Endorse;
            public Int32Field EndorsableCheckNo; 
           // public DateTimeField CheckDate;
            
            //U_UserSign

            public StringField U_UserCode;
        }
    }
}
