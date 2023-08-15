using FluentMigrator;
using Serenity.Extensions;
using System.IO;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20220809160000)]
    public class DefaultDB_20220809_160000_CrystalReport : Migration
    {
        private string GetScript(string name)
        {
            using (var sr = new StreamReader(this.GetType().Assembly.GetManifestResourceStream(name)))
                return sr.ReadToEnd();
        }
        public override void Up()
        {
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe").Execute.Sql
            (GetScript("SAPWebPortal.Web.Migrations.DefaultDB.DefaultDBScript_SqlServer_Reports.sql"));
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe").Execute.Sql
            (GetScript("SAPWebPortal.Web.Migrations.DefaultDB.DefaultDBScript_SqlServer_Report_Users.sql"));
            IfDatabase("SqlServer", "SqlServer2000", "SqlServerCe").Execute.Sql
            (GetScript("SAPWebPortal.Web.Migrations.DefaultDB.DefaultDBScript_SqlServer_Report_UserDetails.sql"));
        }
        public override void Down()
        {
        }
    }
}
