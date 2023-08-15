using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[ShopifyLocationDetail]")]
    [DisplayName("Shopify Location Detail"), InstanceName("Shopify Location Detail")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class ShopifyLocationDetailRow : Row<ShopifyLocationDetailRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Shopify Settings"), Column("ShopifySettings_ID"), ForeignKey("[dbo].[ShopifySettings]", "Id"), LeftJoin("jShopifySettings"), TextualField("ShopifySettingsSapDatabase")]
        public int? ShopifySettingsId
        {
            get => fields.ShopifySettingsId[this];
            set => fields.ShopifySettingsId[this] = value;
        }

        [DisplayName("Sap Warhouse Code"), Column("SAPWarhouseCode"), Size(255), QuickSearch, NameProperty]
        public string SapWarhouseCode
        {
            get => fields.SapWarhouseCode[this];
            set => fields.SapWarhouseCode[this] = value;
        }

        [DisplayName("Shopify Location Code"), Size(255)]
        public string ShopifyLocationCode
        {
            get => fields.ShopifyLocationCode[this];
            set => fields.ShopifyLocationCode[this] = value;
        }

        [DisplayName("Shopify Settings Sap Database"), Expression("jShopifySettings.[SAPDatabase]")]
        public string ShopifySettingsSapDatabase
        {
            get => fields.ShopifySettingsSapDatabase[this];
            set => fields.ShopifySettingsSapDatabase[this] = value;
        }

        [DisplayName("Shopify Settings Token"), Expression("jShopifySettings.[Token]")]
        public string ShopifySettingsToken
        {
            get => fields.ShopifySettingsToken[this];
            set => fields.ShopifySettingsToken[this] = value;
        }

        [DisplayName("Shopify Settings Api Key"), Expression("jShopifySettings.[APIKey]")]
        public string ShopifySettingsApiKey
        {
            get => fields.ShopifySettingsApiKey[this];
            set => fields.ShopifySettingsApiKey[this] = value;
        }

        [DisplayName("Shopify Settings Api Key Secret"), Expression("jShopifySettings.[APIKeySecret]")]
        public string ShopifySettingsApiKeySecret
        {
            get => fields.ShopifySettingsApiKeySecret[this];
            set => fields.ShopifySettingsApiKeySecret[this] = value;
        }

        [DisplayName("Shopify Settings Create Date"), Expression("jShopifySettings.[CreateDate]")]
        public DateTime? ShopifySettingsCreateDate
        {
            get => fields.ShopifySettingsCreateDate[this];
            set => fields.ShopifySettingsCreateDate[this] = value;
        }

        [DisplayName("Shopify Settings Created By"), Expression("jShopifySettings.[CreatedBy]")]
        public string ShopifySettingsCreatedBy
        {
            get => fields.ShopifySettingsCreatedBy[this];
            set => fields.ShopifySettingsCreatedBy[this] = value;
        }

        [DisplayName("Shopify Settings Api Version"), Expression("jShopifySettings.[ApiVersion]")]
        public string ShopifySettingsApiVersion
        {
            get => fields.ShopifySettingsApiVersion[this];
            set => fields.ShopifySettingsApiVersion[this] = value;
        }

        [DisplayName("Shopify Settings Store Name"), Expression("jShopifySettings.[StoreName]")]
        public string ShopifySettingsStoreName
        {
            get => fields.ShopifySettingsStoreName[this];
            set => fields.ShopifySettingsStoreName[this] = value;
        }

        [DisplayName("Shopify Settings Api Base Url"), Expression("jShopifySettings.[ApiBaseURL]")]
        public string ShopifySettingsApiBaseUrl
        {
            get => fields.ShopifySettingsApiBaseUrl[this];
            set => fields.ShopifySettingsApiBaseUrl[this] = value;
        }

        public ShopifyLocationDetailRow()
            : base()
        {
        }

        public ShopifyLocationDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field ShopifySettingsId;
            public StringField SapWarhouseCode;
            public StringField ShopifyLocationCode;

            public StringField ShopifySettingsSapDatabase;
            public StringField ShopifySettingsToken;
            public StringField ShopifySettingsApiKey;
            public StringField ShopifySettingsApiKeySecret;
            public DateTimeField ShopifySettingsCreateDate;
            public StringField ShopifySettingsCreatedBy;
            public StringField ShopifySettingsApiVersion;
            public StringField ShopifySettingsStoreName;
            public StringField ShopifySettingsApiBaseUrl;
        }
    }
}
