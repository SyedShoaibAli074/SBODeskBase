using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20230608150100)]
    public class DefaultDB_20230608_150100_ShopifySettings : AutoReversingMigration
    {
        public override void Up()
        {
            this.CreateTableWithId32("ShopifySubSettings", "Id", s => s
           .WithColumn("Name").AsString().Nullable()
           .WithColumn("Description").AsString().Nullable()
           );

            this.CreateTableWithId32("ShopifySettings", "Id", s => s

            .WithColumn("StoreName").AsString().Nullable()
            .WithColumn("SAPStoreName").AsString().Nullable()
            .WithColumn("ApiBaseURL").AsString().Nullable()
            .WithColumn("SAPDatabase").AsString().Nullable()
            .WithColumn("Token").AsString().Nullable()
            .WithColumn("APIKey").AsString().Nullable()
            .WithColumn("APIKeySecret").AsString().Nullable()
            .WithColumn("ApiVersion").AsString().Nullable()
            .WithColumn("CreateDate").AsDateTime().Nullable()
            .WithColumn("CreatedBy").AsString().Nullable()
            );
           
            
            this.CreateTableWithId32("ShopifySettingsDetail", "Id", s => s
              .WithColumn("ShopifySettings_ID").AsInt32().ForeignKey("ShopifySettings", "Id")
              .WithColumn("ShopifySubSettings_ID").AsInt32().ForeignKey("ShopifySubSettings", "Id")
              .WithColumn("ShopifySubSettingsSAPValue").AsString().Nullable()
              );

            this.CreateTableWithId32("ShopifyLocationDetail", "Id", s => s
             .WithColumn("ShopifySettings_ID").AsInt32().ForeignKey("ShopifySettings", "Id")
             .WithColumn("SAPWarhouseCode").AsString().Nullable()
             .WithColumn("ShopifyLocationCode").AsString().Nullable()
             );
        }
    }
}