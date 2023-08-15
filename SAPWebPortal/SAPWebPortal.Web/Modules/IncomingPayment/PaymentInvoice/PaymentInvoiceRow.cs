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
    [DisplayName("Payment Invoice"), InstanceName("Payment Invoice")]
    [ReadPermission("IncomingPayment")]
    [ModifyPermission("IncomingPayment")]
    [NotMapped]
    public sealed class PaymentInvoiceRow : Row<PaymentInvoiceRow.RowFields>, IIdRow
    {
        [DisplayName("Line Num"), NotNull, IdProperty]
        [NotMapped]
        public Int32? LineNum
        {
            get => fields.LineNum[this];
            set => fields.LineNum[this] = value;
        }

        [DisplayName("Doc Entry"), NotNull]
        [NotMapped]
        public Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }

        [DisplayName("Sum Applied"), NotNull]
        [NotMapped]
        public Double? SumApplied
        {
            get => fields.SumApplied[this];
            set => fields.SumApplied[this] = value;
        }

        [DisplayName("Applied Fc"), Column("AppliedFC"), NotNull]
        [NotMapped]
        public Double? AppliedFc
        {
            get => fields.AppliedFc[this];
            set => fields.AppliedFc[this] = value;
        }

        [DisplayName("Applied Sys"), NotNull]
        [NotMapped]
        public Double? AppliedSys
        {
            get => fields.AppliedSys[this];
            set => fields.AppliedSys[this] = value;
        }

        [DisplayName("Doc Rate"), NotNull]
        [NotMapped]
        public Double? DocRate
        {
            get => fields.DocRate[this];
            set => fields.DocRate[this] = value;
        }

        [DisplayName("Doc Line"), NotNull]
        [NotMapped]
        public Int32? DocLine
        {
            get => fields.DocLine[this];
            set => fields.DocLine[this] = value;
        }

        [DisplayName("Invoice Type"), NotNull]
        [NotMapped]
        public String? InvoiceType
        {
            get => fields.InvoiceType[this];
            set => fields.InvoiceType[this] = value;
        }

        [DisplayName("Discount Percent"), NotNull]
        [NotMapped]
        public Double? DiscountPercent
        {
            get => fields.DiscountPercent[this];
            set => fields.DiscountPercent[this] = value;
        }

        [DisplayName("Paid Sum"), NotNull]
        [NotMapped]
        public Double? PaidSum
        {
            get => fields.PaidSum[this];
            set => fields.PaidSum[this] = value;
        }

        [DisplayName("Installment Id"), NotNull]
        [NotMapped]
        public Int32? InstallmentId
        {
            get => fields.InstallmentId[this];
            set => fields.InstallmentId[this] = value;
        }

        [DisplayName("Witholding Tax Applied"), NotNull]
        [NotMapped]
        public Double? WitholdingTaxApplied
        {
            get => fields.WitholdingTaxApplied[this];
            set => fields.WitholdingTaxApplied[this] = value;
        }

        [DisplayName("Witholding Tax Applied Fc"), Column("WitholdingTaxAppliedFC"), NotNull]
        [NotMapped]
        public Double? WitholdingTaxAppliedFc
        {
            get => fields.WitholdingTaxAppliedFc[this];
            set => fields.WitholdingTaxAppliedFc[this] = value;
        }

        [DisplayName("Witholding Tax Applied Sc"), Column("WitholdingTaxAppliedSC"), NotNull]
        [NotMapped]
        public Double? WitholdingTaxAppliedSc
        {
            get => fields.WitholdingTaxAppliedSc[this];
            set => fields.WitholdingTaxAppliedSc[this] = value;
        }

        [DisplayName("Link Date"), NotNull]
        [NotMapped]
        public DateTime? LinkDate
        {
            get => fields.LinkDate[this];
            set => fields.LinkDate[this] = value;
        }

        [DisplayName("Distribution Rule"), NotNull]
        [NotMapped]
        public System.String? DistributionRule
        {
            get => fields.DistributionRule[this];
            set => fields.DistributionRule[this] = value;
        }

        [DisplayName("Distribution Rule2"), NotNull]
        [NotMapped]
        public System.String? DistributionRule2
        {
            get => fields.DistributionRule2[this];
            set => fields.DistributionRule2[this] = value;
        }

        [DisplayName("Distribution Rule3"), NotNull]
        [NotMapped]
        public System.String? DistributionRule3
        {
            get => fields.DistributionRule3[this];
            set => fields.DistributionRule3[this] = value;
        }

        [DisplayName("Distribution Rule4"), NotNull]
        [NotMapped]
        public System.String? DistributionRule4
        {
            get => fields.DistributionRule4[this];
            set => fields.DistributionRule4[this] = value;
        }

        [DisplayName("Distribution Rule5"), NotNull]
        [NotMapped]
        public System.String? DistributionRule5
        {
            get => fields.DistributionRule5[this];
            set => fields.DistributionRule5[this] = value;
        }

        [DisplayName("Total Discount"), NotNull]
        [NotMapped]
        public Double? TotalDiscount
        {
            get => fields.TotalDiscount[this];
            set => fields.TotalDiscount[this] = value;
        }

        [DisplayName("Total Discount Fc"), Column("TotalDiscountFC"), NotNull]
        [NotMapped]
        public Double? TotalDiscountFc
        {
            get => fields.TotalDiscountFc[this];
            set => fields.TotalDiscountFc[this] = value;
        }

        [DisplayName("Total Discount Sc"), Column("TotalDiscountSC"), NotNull]
        [NotMapped]
        public Double? TotalDiscountSc
        {
            get => fields.TotalDiscountSc[this];
            set => fields.TotalDiscountSc[this] = value;
        }

        [DisplayName("U Ocr Code6"), Column("U_OcrCode6"), NotNull]
        [NotMapped]
        public System.String? UOcrCode6
        {
            get => fields.UOcrCode6[this];
            set => fields.UOcrCode6[this] = value;
        }

        [DisplayName("U Ocr Code7"), Column("U_OcrCode7"), NotNull]
        [NotMapped]
        public System.String? UOcrCode7
        {
            get => fields.UOcrCode7[this];
            set => fields.UOcrCode7[this] = value;
        }

        [DisplayName("U Ocr Code8"), Column("U_OcrCode8"), NotNull]
        [NotMapped]
        public System.String? UOcrCode8
        {
            get => fields.UOcrCode8[this];
            set => fields.UOcrCode8[this] = value;
        }

        [DisplayName("U Ocr Code9"), Column("U_OcrCode9"), NotNull]
        [NotMapped]
        public System.String? UOcrCode9
        {
            get => fields.UOcrCode9[this];
            set => fields.UOcrCode9[this] = value;
        }

        [DisplayName("U Ocr Code10"), Column("U_OcrCode10"), NotNull]
        [NotMapped]
        public System.String? UOcrCode10
        {
            get => fields.UOcrCode10[this];
            set => fields.UOcrCode10[this] = value;
        }

        [DisplayName("U Ocr Code11"), Column("U_OcrCode11"), NotNull]
        [NotMapped]
        public System.String? UOcrCode11
        {
            get => fields.UOcrCode11[this];
            set => fields.UOcrCode11[this] = value;
        }

        public PaymentInvoiceRow()
            : base()
        {
        }

        public PaymentInvoiceRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineNum;
            public Int32Field DocEntry;
            public DoubleField SumApplied;
            public DoubleField AppliedFc;
            public DoubleField AppliedSys;
            public DoubleField DocRate;
            public Int32Field DocLine;
            public StringField InvoiceType;
            public DoubleField DiscountPercent;
            public DoubleField PaidSum;
            public Int32Field InstallmentId;
            public DoubleField WitholdingTaxApplied;
            public DoubleField WitholdingTaxAppliedFc;
            public DoubleField WitholdingTaxAppliedSc;
            public DateTimeField LinkDate;
            public StringField DistributionRule;
            public StringField DistributionRule2;
            public StringField DistributionRule3;
            public StringField DistributionRule4;
            public StringField DistributionRule5;
            public DoubleField TotalDiscount;
            public DoubleField TotalDiscountFc;
            public DoubleField TotalDiscountSc;
            public StringField UOcrCode6;
            public StringField UOcrCode7;
            public StringField UOcrCode8;
            public StringField UOcrCode9;
            public StringField UOcrCode10;
            public StringField UOcrCode11;
        }
    }
}
