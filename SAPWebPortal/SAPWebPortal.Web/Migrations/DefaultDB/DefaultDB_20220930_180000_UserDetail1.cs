using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20220930180000)]
    public class DefaultDB_20220930_180000_UserDetail1 : AutoReversingMigration
    {
        public override void Up()
        {
             this.CreateTableWithId64("UserDetail1", "Id", s => s
             .WithColumn("UserDId").AsInt32().Nullable()
             .WithColumn("UserId").AsInt32().Nullable()
             .WithColumn("UserCode").AsString().Nullable()
             .WithColumn("UserName").AsString(254).Nullable()
             .WithColumn("DBName").AsString(254).Nullable()
             .WithColumn("CardCode").AsString(254).Nullable() 
             .WithColumn("CardName").AsString(254).Nullable()  
             .WithColumn("Active").AsString().Nullable()
             
              );
       
              
        }
    }
}