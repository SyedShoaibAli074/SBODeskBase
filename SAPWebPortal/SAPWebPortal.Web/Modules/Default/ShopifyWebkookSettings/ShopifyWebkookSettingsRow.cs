using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[ShopifyWebkookSettings]")]
    [DisplayName("Shopify Webkook Settings"), InstanceName("Shopify Webkook Settings")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [UniqueConstraint("ShopifyWebhookTopic", "ShopifyStore", CheckBeforeSave =true,ErrorMessage ="There is Already a Webhook registered for this topic in this store")]
    public sealed class ShopifyWebkookSettingsRow : Row<ShopifyWebkookSettingsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Shopify Webhook Topic"), QuickSearch, NameProperty]
        public string ShopifyWebhookTopic
        {
            get => fields.ShopifyWebhookTopic[this];
            set => fields.ShopifyWebhookTopic[this] = value;
        }
        [DisplayName("WebhookId")]
        public string WebhookId
        {
            get => fields.WebhookId[this];
            set => fields.WebhookId[this] = value;
        }

        [DisplayName("Webhook Url"), Column("WebhookURL")]
        public string WebhookUrl
        {
            get => fields.WebhookUrl[this];
            set => fields.WebhookUrl[this] = value;
        }

        [DisplayName("Shopify Store"), NotNull,LookupEditor(typeof(ShopifySettingsRow)),QuickFilter]
        public string ShopifyStore
        {
            get => fields.ShopifyStore[this];
            set => fields.ShopifyStore[this] = value;
        }

        [DisplayName("Create Date")]
        public DateTime? CreateDate
        {
            get => fields.CreateDate[this];
            set => fields.CreateDate[this] = value;
        }

        [DisplayName("Created By"), Size(255),LookupEditor(typeof(UsersRow))]
        public string CreatedBy
        {
            get => fields.CreatedBy[this];
            set => fields.CreatedBy[this] = value;
        }

       

        public ShopifyWebkookSettingsRow()
            : base()
        {
        }

        public ShopifyWebkookSettingsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField ShopifyWebhookTopic;
            public StringField WebhookUrl;
            public StringField ShopifyStore;
            public StringField WebhookId;
            public DateTimeField CreateDate;
            public StringField CreatedBy;

           
        }
    }
}
