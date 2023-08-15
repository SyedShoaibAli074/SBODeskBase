using SAPWebPortal.Modules.DropDownEnums;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[Log]")]
    [DisplayName("Log"), InstanceName("Log")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class LogRow : Row<LogRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Date Time"), Column("U_DateTime"), NotNull]
        public DateTime? UDateTime
        {
            get => fields.UDateTime[this];
            set => fields.UDateTime[this] = value;
        }

        [DisplayName("Direction"), Column("U_Direction"), Size(10), NotNull, QuickSearch, NameProperty,QuickFilter,DirectionEditor]
        public string UDirection
        {
            get => fields.UDirection[this];
            set => fields.UDirection[this] = value;
        }

        [DisplayName("Error"), Column("U_Error"), Size(255), QuickFilter,ErrorEditor]
        public string UError
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

        [DisplayName("Request"), Column("U_Request")]
        public String URequest
        {
            get => fields.URequest[this];
            set => fields.URequest[this] = value;
        }
        [DisplayName("Response"), Column("U_Response")]
        public String UResponse
        {
            get => fields.UResponse[this];
            set => fields.UResponse[this] = value;
        }
        [DisplayName("ShopifyPayload"), Column("ShopifyPayload")]
        public String ShopifyPayload
        {
            get => fields.ShopifyPayload[this];
            set => fields.ShopifyPayload[this] = value;
        }

        [DisplayName("Obj Type"), Column("U_ObjType"), Size(30)]
        public string UObjType
        {
            get => fields.UObjType[this];
            set => fields.UObjType[this] = value;
        }

        [DisplayName("Version"), Column("U_version")]
        public Stream UVersion
        {
            get => fields.UVersion[this];
            set => fields.UVersion[this] = value;
        }

        [DisplayName("Key"), Column("U_KEY"), Size(255)]
        public string UKey
        {
            get => fields.UKey[this];
            set => fields.UKey[this] = value;
        }

        [DisplayName("Doc Num"), Column("U_DocNum"), Size(255)]
        public string UDocNum
        {
            get => fields.UDocNum[this];
            set => fields.UDocNum[this] = value;
        }

        [DisplayName("Shopify Id"), Column("ShopifyID"), Size(255)]
        public string ShopifyId
        {
            get => fields.ShopifyId[this];
            set => fields.ShopifyId[this] = value;
        }

        [DisplayName("Doc Ids"), Size(255)]
        public string DocIds
        {
            get => fields.DocIds[this];
            set => fields.DocIds[this] = value;
        }

        [DisplayName("Updated")]
        public short? Updated
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
            public StringField ShopifyPayload;
            public StringField UXml;
            public StringField URequest;
            public StringField UResponse;
            public StringField UObjType;
            public StreamField UVersion;
            public StringField UKey;
            public StringField UDocNum;
            public StringField ShopifyId;
            public StringField DocIds;
            public Int16Field Updated;
        }
    }
}
