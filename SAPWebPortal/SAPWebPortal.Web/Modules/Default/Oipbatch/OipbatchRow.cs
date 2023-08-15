using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[OIPBATCH]")]
    [DisplayName("Incoming Payment Batch"), InstanceName("Incoming Payment Batch")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class OipbatchRow : Row<OipbatchRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Userid"), Column("U_Userid"),Hidden]
        public int? UUserid
        {
            get => fields.UUserid[this];
            set => fields.UUserid[this] = value;
        }

        [DisplayName("User Code"), Column("U_User_Code"), Size(30), QuickSearch, NameProperty]
        public string UUserCode
        {
            get => fields.UUserCode[this];
            set => fields.UUserCode[this] = value;
        }

        [DisplayName("Batch Type"), Column("U_BatchType"), Size(10)]
        public string UBatchType
        {
            get => fields.UBatchType[this];
            set => fields.UBatchType[this] = value;
        }

        [DisplayName("Doc Date"), Column("U_DocDate")]
        public DateTime? UDocDate
        {
            get => fields.UDocDate[this];
            set => fields.UDocDate[this] = value;
        }

        [DisplayName("Cash Acct"), Column("U_CashAcct"), Size(15)]
        public string UCashAcct
        {
            get => fields.UCashAcct[this];
            set => fields.UCashAcct[this] = value;
        }

        [DisplayName("Transfer Account"), Column("U_TrsfrAcct"), Size(15)]
        public string UTrsfrAcct
        {
            get => fields.UTrsfrAcct[this];
            set => fields.UTrsfrAcct[this] = value;
        }

        [DisplayName("Target Doc Num"), Column("U_TDocNum")]
        public int? UTDocNum
        {
            get => fields.UTDocNum[this];
            set => fields.UTDocNum[this] = value;
        }

        [DisplayName("Cashier Id"), Column("U_CashierId"), Size(30)]
        public string UCashierId
        {
            get => fields.UCashierId[this];
            set => fields.UCashierId[this] = value;
        }

        [DisplayName("Status"), Column("U_Status"), Size(10)]
        public string UStatus
        {
            get => fields.UStatus[this];
            set => fields.UStatus[this] = value;
        }

        [DisplayName("Doc Total"), Column("U_DocTotal"), Size(19), Scale(5)]
        public decimal? UDocTotal
        {
            get => fields.UDocTotal[this];
            set => fields.UDocTotal[this] = value;
        }
        [DisplayName("Payment Detail"), MasterDetailRelation(foreignKey: "U_BatchId"), NotMapped]
        public System.Collections.Generic.List<Ipbatch1Row> DetailList
        {
            get { return Fields.DetailList[this]; }
            set { Fields.DetailList[this] = value; }
        }
        public OipbatchRow()
            : base()
        {
        }

        public OipbatchRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public Int32Field UUserid;
            public StringField UUserCode;
            public StringField UBatchType;
            public DateTimeField UDocDate;
            public StringField UCashAcct;
            public StringField UTrsfrAcct;
            public Int32Field UTDocNum;
            public StringField UCashierId;
            public StringField UStatus;
            public DecimalField UDocTotal;
            public RowListField<Ipbatch1Row> DetailList;
        }
    }
}
