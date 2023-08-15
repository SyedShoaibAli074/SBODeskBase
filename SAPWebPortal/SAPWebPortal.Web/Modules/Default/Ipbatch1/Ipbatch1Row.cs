using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[IPBATCH1]")]
    [DisplayName("Add Detail"), InstanceName("Add Detail")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class Ipbatch1Row : Row<Ipbatch1Row.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Card Code"), Column("U_CardCode"), Size(30), QuickSearch, NameProperty]
        public string UCardCode
        {
            get => fields.UCardCode[this];
            set => fields.UCardCode[this] = value;
        }

        [DisplayName("Doc Sum"), Column("U_DocSum"), Size(10)]
        public string UDocSum
        {
            get => fields.UDocSum[this];
            set => fields.UDocSum[this] = value;
        }

        [DisplayName("Base Doc Num"), Column("U_BDocNum"), Size(10)]
        public string UBDocNum
        {
            get => fields.UBDocNum[this];
            set => fields.UBDocNum[this] = value;
        }

        [DisplayName("B Doc Entry"), Column("U_BDocEntry"), Size(10),Hidden]
        public string UBDocEntry
        {
            get => fields.UBDocEntry[this];
            set => fields.UBDocEntry[this] = value;
        }

        [DisplayName("Card Name"), Column("U_CardName"), Size(200)]
        public string UCardName
        {
            get => fields.UCardName[this];
            set => fields.UCardName[this] = value;
        }

        [DisplayName("Batch Id"), Column("U_BatchId")]
        public int? UBatchId
        {
            get => fields.UBatchId[this];
            set => fields.UBatchId[this] = value;
        }

        public Ipbatch1Row()
            : base()
        {
        }

        public Ipbatch1Row(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public StringField UCardCode;
            public StringField UDocSum;
            public StringField UBDocNum;
            public StringField UBDocEntry;
            public StringField UCardName;
            public Int32Field UBatchId;
        }
    }
}
