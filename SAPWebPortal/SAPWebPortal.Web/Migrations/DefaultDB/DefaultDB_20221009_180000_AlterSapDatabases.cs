using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20221009180000)]
    public class DefaultDB_20221009_180000_AlterSapDatabases : AutoReversingMigration
    {
        public override void Up()
        {
            this.Alter.Table("SapDatabases")
               .AddColumn("UDFs").AsXml().Nullable();
        }
    }
}