using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20210314130000)]
    public class DefaultDB_20210314_130000_NewTables : AutoReversingMigration
    {
        public override void Up()
        {
            this.CreateTableWithId64("SapDatabases", "Id", s => s
                  .WithColumn("ServerName").AsString().NotNullable()
                  .WithColumn("ODBCServer").AsString().Nullable()
                  .WithColumn("DBServerType").AsString().NotNullable()
                  .WithColumn("LicenseServer").AsString().NotNullable()
                  .WithColumn("CompanyDB").AsString().NotNullable()
                  .WithColumn("DBUserName").AsString().NotNullable()
                  .WithColumn("DBPassword").AsString().NotNullable()
                  .WithColumn("UserName").AsString().NotNullable()
                 .WithColumn("Password").AsString().NotNullable()
                 .WithColumn("Alias").AsString().NotNullable()
                 .WithColumn("ServiceLayerURL").AsString().Nullable()
                 .WithColumn("ServiceLayerVersion").AsString().Nullable()
                 .WithColumn("DBDriver").AsString().Nullable()
                 .WithColumn("IsDefault").AsBoolean().Nullable()
                  );
            this.CreateTableWithId64("Log", "Id", s => s
             .WithColumn("U_DateTime").AsDateTime().NotNullable()
             .WithColumn("U_Direction").AsString(100).NotNullable()//tosap,toapi
             .WithColumn("U_Error").AsString().Nullable()// 
             .WithColumn("U_XML").AsString(int.MaxValue).Nullable()// 
             .WithColumn("U_Response").AsString(int.MaxValue).Nullable()// 
             .WithColumn("U_Request").AsString(int.MaxValue).Nullable()// 
             .WithColumn("ShopifyPayload").AsString(int.MaxValue).Nullable()// 
             .WithColumn("U_ObjType").AsString(30).Nullable()// 
             .WithColumn("U_version").AsXml().Nullable()// 
             .WithColumn("U_KEY").AsString().Nullable()// 
             .WithColumn("U_DocNum").AsString().Nullable()
             .WithColumn("ShopifyID").AsString().Nullable()
             .WithColumn("DocIds").AsString().Nullable()
             .WithColumn("Updated").AsInt16().Nullable()
             );
        }
    }
}