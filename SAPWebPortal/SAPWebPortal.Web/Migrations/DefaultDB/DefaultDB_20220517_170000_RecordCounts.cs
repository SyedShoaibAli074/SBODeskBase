using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20220517170000)]
    public class DefaultDB_20220517_170000_RecordCounts : AutoReversingMigration
    {
        public override void Up()
        {
            this.CreateTableWithId64("RecordCounts", "Id", s => s
                  .WithColumn("ModuleName").AsString().Nullable()
                  .WithColumn("ObjectType").AsInt32().Nullable()
                  .WithColumn("Company").AsString().NotNullable()
                  .WithColumn("Counts").AsInt32().Nullable()
                  .WithColumn("DateTimeStamp").AsDateTime().Nullable()
                  ); 
        }
    }
}