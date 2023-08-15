using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[Log]")]
    [DisplayName("Log"), InstanceName("Log")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class LogRow : Row<LogRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty, SortOrder(1, descending: true)]
        public Int64? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Date Time"), Column("U_DateTime"), DisplayFormat("dd/MM/yyyy HH:mm:ss"), NotNull]
        public DateTime? UDateTime
        {
            get => fields.UDateTime[this];
            set => fields.UDateTime[this] = value;
        }

        [DisplayName("Direction"), Column("U_Direction"), Size(10), NotNull, QuickSearch, NameProperty]
        public String UDirection
        {
            get => fields.UDirection[this];
            set => fields.UDirection[this] = value;
        }

        [DisplayName("Error"), Column("U_Error"), Size(255)]
        public String UError
        {
            get => fields.UError[this];
            set => fields.UError[this] = value;
        }

        [DisplayName("Xml"), Column("U_XML")]
        public String UXml
        {
            get => fields.UXml[this];
            set => fields.UXml[this] = value;
        }

        [DisplayName("Response"), Column("U_Response")]
        public String UResponse
        {
            get => fields.UResponse[this];
            set => fields.UResponse[this] = value;
        }

        [DisplayName("Obj Type"), Column("U_ObjType"), Size(30)]
        public String UObjType
        {
            get => fields.UObjType[this];
            set => fields.UObjType[this] = value;
        }

        [DisplayName("Version"), Column("U_version")]
        public String UVersion
        {
            get => fields.UVersion[this];
            set => fields.UVersion[this] = value;
        }

        [DisplayName("Key"), Column("U_KEY"), Size(255)]
        public String UKey
        {
            get => fields.UKey[this];
            set => fields.UKey[this] = value;
        }

        [DisplayName("Doc Num"), Column("U_DocNum"), Size(255)]
        public String UDocNum
        {
            get => fields.UDocNum[this];
            set => fields.UDocNum[this] = value;
        }
        [DisplayName("Updated")]
        public Int16? Updated
        {
            get => fields.Updated[this];
            set => fields.Updated[this] = value;
        }

        public LogRow()
            : base()
        {
        }

        public LogRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public DateTimeField UDateTime;
            public StringField UDirection;
            public StringField UError;
            public StringField UXml;
            public StringField UResponse;
            public StringField UObjType;
            public StringField UVersion;
            public StringField UKey;
            public StringField UDocNum;
            public Int16Field Updated;
        }
    }
}
