using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20230621150100)]
    public class DefaultDB_20230621_150100_ShopifyWebhookSettings : AutoReversingMigration
    {
        public override void Up()
        {
            

            this.CreateTableWithId32("ShopifyWebkookSettings", "Id", s => s

            .WithColumn("ShopifyWebhookTopic").AsString(int.MaxValue).Nullable()
            .WithColumn("WebhookURL").AsString(int.MaxValue).Nullable()
            .WithColumn("ShopifyStore").AsString().Nullable()
            .WithColumn("WebhookId").AsString().Nullable()

            .WithColumn("CreateDate").AsDateTime().Nullable()
            .WithColumn("CreatedBy").AsString().Nullable()

            );
           
            
            
        }
    }
}