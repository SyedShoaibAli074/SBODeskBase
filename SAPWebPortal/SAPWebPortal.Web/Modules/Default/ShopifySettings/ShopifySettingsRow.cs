using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[ShopifySettings]")]
    [DisplayName("Shopify Settings"), InstanceName("Shopify Settings")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class ShopifySettingsRow : Row<ShopifySettingsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [DisplayName("Store Name"), Size(255), NameProperty]
        public string StoreName
        {
            get => fields.StoreName[this];
            set => fields.StoreName[this] = value;
        }
        [DisplayName("SAP Store Name"), Size(255)]
        public string SAPStoreName
        {
            get => fields.SAPStoreName[this];
            set => fields.SAPStoreName[this] = value;
        }
        [DisplayName("Api Version"), Size(255)]
        public string ApiVersion
        {
            get => fields.ApiVersion[this];
            set => fields.ApiVersion[this] = value;
        }
        [DisplayName("Sap Database"), Column("SAPDatabase"), Size(255), QuickSearch,LookupEditor(typeof(SapDatabasesRow))]
        public string SapDatabase
        {
            get => fields.SapDatabase[this];
            set => fields.SapDatabase[this] = value;
        }

        
        [DisplayName("Token"), Size(255)]
        public string Token
        {
            get => fields.Token[this];
            set => fields.Token[this] = value;
        }

        [DisplayName("Api Key"), Column("APIKey"), Size(255)]
        public string ApiKey
        {
            get => fields.ApiKey[this];
            set => fields.ApiKey[this] = value;
        }

        [DisplayName("Api Key Secret"), Column("APIKeySecret"), Size(255)]
        public string ApiKeySecret
        {
            get => fields.ApiKeySecret[this];
            set => fields.ApiKeySecret[this] = value;
        } 
        [DisplayName("Api Base URL"), Column("ApiBaseURL"), Size(255)]
        public string ApiBaseURL
        {
            get => fields.ApiBaseURL[this];
            set => fields.ApiBaseURL[this] = value;
        }

        [DisplayName("Create Date")]
        public DateTime? CreateDate
        {
            get => fields.CreateDate[this];
            set => fields.CreateDate[this] = value;
        }

        [DisplayName("Created By"),LookupEditor(typeof(UsersRow))]
        public String? CreatedBy
        {
            get => fields.CreatedBy[this];
            set => fields.CreatedBy[this] = value;
        }
        [DisplayName(""), LabelWidth(0), MasterDetailRelation(foreignKey: "ShopifySettings_ID"),ShopifySettingsDetailEditor]

        public System.Collections.Generic.List<ShopifySettingsDetailRow> ShopifySettingsDetailList
        {
            get => fields.ShopifySettingsDetailList[this];
            set => fields.ShopifySettingsDetailList[this] = value;
        }
        [DisplayName(""), LabelWidth(0), MasterDetailRelation(foreignKey: "ShopifySettings_ID"), ShopifyLocationDetailEditor]

        public System.Collections.Generic.List<ShopifyLocationDetailRow> ShopifyLocationDetailList
        {
            get => fields.ShopifyLocationDetailList[this];
            set => fields.ShopifyLocationDetailList[this] = value;
        }
        public ShopifySettingsRow()
            : base()
        {
        }

        public ShopifySettingsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField ApiVersion;
            public StringField StoreName;
            public StringField SAPStoreName;
            public StringField SapDatabase;
            public StringField Token;
            public StringField ApiKey;
            public StringField ApiKeySecret;
            public StringField ApiBaseURL;
            public DateTimeField CreateDate;
            public StringField CreatedBy;
            public RowListField<ShopifySettingsDetailRow> ShopifySettingsDetailList;
            public RowListField<ShopifyLocationDetailRow> ShopifyLocationDetailList;

        }
    }
}
