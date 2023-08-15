using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20221117150000)]
    public class DefaultDB_20221117_150000_FormAuthorizations : AutoReversingMigration
    {
        public override void Up()
        { 
             this.CreateTableWithId64("UserFormAuthorizations", "Id", s => s
             .WithColumn("UserId").AsInt32().Nullable()
            .WithColumn("ModuleName").AsInt32().Nullable()
            .WithColumn("CompanyDB").AsString().Nullable()
            .WithColumn("FormName").AsString().Nullable()
            .WithColumn("FormTitle").AsString().Nullable()
            .WithColumn("FormDescription").AsString().Nullable()
              );
              this.CreateTableWithId64("UserFormAuthorizationsDetails", "Id", s => s
              .WithColumn("UserFormAuthorizationId").AsInt32().Nullable()
              
                .WithColumn("FieldName").AsString().Nullable() 
                .WithColumn("FieldDescription").AsString().Nullable()
                .WithColumn("DataType").AsString().Nullable()
                .WithColumn("DefaultValue").AsString().Nullable()
                .WithColumn("DataSize").AsString().Nullable()
                .WithColumn("Readonly").AsBoolean().Nullable()
                .WithColumn("Required").AsBoolean().Nullable()
                .WithColumn("Visible").AsBoolean().Nullable()
                .WithColumn("HTMLClass").AsString().Nullable()
                .WithColumn("HTMLStyle").AsString().Nullable()
                .WithColumn("HTMLAttributes").AsString().Nullable()
                );
            
            this.CreateTableWithId64("Settings", "Id", s => s
            .WithColumn("UserId").AsInt32().Nullable()
            .WithColumn("ModuleName").AsInt32().Nullable()
            .WithColumn("ListDataSource").AsString().Nullable()//service layer, database
            .WithColumn("PostByMethod").AsString().Nullable()//Service Layer, DI-API
            .WithColumn("IsHana").AsBoolean().Nullable()
            );


        }
    }
}