using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20220326130000)]
    public class DefaultDB_20220326_130000_Sessions : AutoReversingMigration
    {
        public override void Up()
        {
            this.CreateTableWithId64("Sessions", "Id", s => s
                  .WithColumn("SessionID").AsString().Nullable()
                  .WithColumn("NodeId").AsString().Nullable()
                  .WithColumn("UserName").AsString().Nullable()
                  .WithColumn("Password").AsString().Nullable()
                  .WithColumn("Company").AsString().Nullable()
                  .WithColumn("DateTimeStamp").AsDateTime().Nullable()
                  ); 
        }
    }
}