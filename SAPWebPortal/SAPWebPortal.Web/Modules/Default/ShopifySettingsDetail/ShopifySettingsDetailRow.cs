using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[ShopifySettingsDetail]")]
    [DisplayName("Shopify Settings Detail"), InstanceName("Shopify Settings Detail")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class ShopifySettingsDetailRow : Row<ShopifySettingsDetailRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Shopify Settings"), Column("ShopifySettings_ID"), NotNull, ForeignKey("[dbo].[ShopifySettings]", "Id"), LeftJoin("jShopifySettings"), TextualField("ShopifySettingsSapDatabase")]
        public int? ShopifySettingsId
        {
            get => fields.ShopifySettingsId[this];
            set => fields.ShopifySettingsId[this] = value;
        }

        [DisplayName("Shopify Sub Settings"), Column("ShopifySubSettings_ID"), NotNull, ForeignKey("[dbo].[ShopifySubSettings]", "Id"), LeftJoin("jShopifySubSettings"),LookupEditor(typeof(ShopifySubSettingsRow)), TextualField("ShopifySubSettingsName")]
        public int? ShopifySubSettingsId
        {
            get => fields.ShopifySubSettingsId[this];
            set => fields.ShopifySubSettingsId[this] = value;
        }

        [DisplayName("Shopify Sub Settings Sap Value"), Column("ShopifySubSettingsSAPValue"), Size(255), QuickSearch, NameProperty]
        public string ShopifySubSettingsSapValue
        {
            get => fields.ShopifySubSettingsSapValue[this];
            set => fields.ShopifySubSettingsSapValue[this] = value;
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
        public DateTime? ShopifySettingsCreatedBy
        {
            get => fields.ShopifySettingsCreatedBy[this];
            set => fields.ShopifySettingsCreatedBy[this] = value;
        }

        [DisplayName("Shopify Sub Settings Name"), Expression("jShopifySubSettings.[Name]")]
        public string ShopifySubSettingsName
        {
            get => fields.ShopifySubSettingsName[this];
            set => fields.ShopifySubSettingsName[this] = value;
        }

        [DisplayName("Shopify Sub Settings Description"), Expression("jShopifySubSettings.[Description]")]
        public string ShopifySubSettingsDescription
        {
            get => fields.ShopifySubSettingsDescription[this];
            set => fields.ShopifySubSettingsDescription[this] = value;
        }

        public ShopifySettingsDetailRow()
            : base()
        {
        }

        public ShopifySettingsDetailRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field ShopifySettingsId;
            public Int32Field ShopifySubSettingsId;
            public StringField ShopifySubSettingsSapValue;

            public StringField ShopifySettingsSapDatabase;
            public StringField ShopifySettingsToken;
            public StringField ShopifySettingsApiKey;
            public StringField ShopifySettingsApiKeySecret;
            public DateTimeField ShopifySettingsCreateDate;
            public DateTimeField ShopifySettingsCreatedBy;

            public StringField ShopifySubSettingsName;
            public StringField ShopifySubSettingsDescription;
        }
    }
}
