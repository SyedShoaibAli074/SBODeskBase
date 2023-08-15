using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20221010150000)]
    public class DefaultDB_20221010_150000_UserDetail2 : AutoReversingMigration
    {
        public override void Up()
        {
              
       
             this.CreateTableWithId64("UserDetail2", "Id", s => s
             .WithColumn("UserDId").AsInt32().Nullable()
             .WithColumn("UserId").AsInt32().Nullable()
             .WithColumn("UserCode").AsString().Nullable()
             .WithColumn("UserName").AsString(254).Nullable()
             .WithColumn("DBName").AsString(254).Nullable()
             .WithColumn("SalesPersonCode").AsString(254).Nullable() 
             .WithColumn("SalesPersonName").AsString(254).Nullable()  
             .WithColumn("Active").AsString().Nullable()
             
              );
        }
    }
}