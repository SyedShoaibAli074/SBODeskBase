using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20210220140000)]
    public class DefaultDB_20210220_140000_FileRouting : AutoReversingMigration
    {
        public override void Up()
        {
            //todo:on update of the report validate if the report has valid parameters. @objtype,@dockey
            this.CreateTableWithId64("FileRouting", "Id", s => s
             .WithColumn("Name").AsString().NotNullable()
             .WithColumn("SLObjectType").AsString(254).NotNullable()
             .WithColumn("FileNameTemplate").AsXml(-1).Nullable()
             .WithColumn("ReportPath").AsXml( ).Nullable() 
             .WithColumn("RDOC_Code").AsString().Nullable()  
             .WithColumn("CompanyDB").AsString().Nullable()
             .WithColumn("Type").AsString().Nullable()
             .WithColumn("ExportExtension").AsString(10).Nullable()
             .WithColumn("ExportPath").AsXml().Nullable()
              );
        }
    }
}