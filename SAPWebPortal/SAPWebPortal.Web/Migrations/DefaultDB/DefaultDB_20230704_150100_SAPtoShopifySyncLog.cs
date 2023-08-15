using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20230704150100)]
    public class DefaultDB_20230704_150100_SAPtoShopifySyncLog : AutoReversingMigration
    {
        public override void Up()
        {
            

            this.CreateTableWithId32("SAPToShopifySyncLog", "Id", s => s

            .WithColumn("DocEntry").AsString().Nullable()
            .WithColumn("SyncStatus").AsString().Nullable()
            .WithColumn("TargetStoreId").AsString().Nullable()

            .WithColumn("SourceObjType").AsString().Nullable()
            .WithColumn("SyncTime").AsString().Nullable()

            );
           
            
            
        }
    }
}