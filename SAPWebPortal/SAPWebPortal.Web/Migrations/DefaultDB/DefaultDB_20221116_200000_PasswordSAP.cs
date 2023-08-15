using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20221116200000)]
    public class DefaultDB_20221116_200000_PasswordSAP : AutoReversingMigration
    {
        public override void Up()
        {
              
       
             this.Alter.Table("Users")
             .AddColumn("PasswordSAP").AsString().Nullable();
             
             
        }
    }
}