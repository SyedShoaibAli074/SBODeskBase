using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20221128150000)]
    public class DefaultDB_20221128_150000_UpdateSessions : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("Sessions").InSchema("dbo")
                .AddColumn("PortalSessionID").AsString(int.MaxValue).Nullable();



        }
    }
}