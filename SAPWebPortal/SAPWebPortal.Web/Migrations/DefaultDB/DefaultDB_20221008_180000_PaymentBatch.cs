using FluentMigrator;
using Serenity.Extensions;

namespace SAPWebPortal.Migrations.DefaultDB
{
    [Migration(20221008180000)]
    public class DefaultDB_20221008_180000_PaymentBatch : AutoReversingMigration
    {
        public override void Up()
        {

             this.CreateTableWithId64("OIPBATCH", "Id", s => s
             .WithColumn("U_Userid").AsInt32().Nullable()
             .WithColumn("U_User_Code").AsString(30).Nullable()
             .WithColumn("U_BatchType").AsString(10).Nullable()
             .WithColumn("U_DocDate").AsDateTime().Nullable()
             .WithColumn("U_CashAcct").AsString(15).Nullable()
             .WithColumn("U_TrsfrAcct").AsString(15).Nullable() 
             .WithColumn("U_TDocNum").AsInt32().Nullable() 
             .WithColumn("U_CashierId").AsString(30).Nullable()  
             .WithColumn("U_Status").AsString(10).Nullable()
             .WithColumn("U_DocTotal").AsDecimal().Nullable()
             
              );
          
            this.CreateTableWithId64("IPBATCH1", "Id", s => s
             .WithColumn("U_CardCode").AsString(30).Nullable()
             
             .WithColumn("U_DocSum").AsString(10).Nullable()
             .WithColumn("U_BDocNum").AsString(10).Nullable()
             .WithColumn("U_BDocEntry").AsString(10).Nullable()
             .WithColumn("U_CardName").AsString(200).Nullable()
             .WithColumn("U_BatchId").AsInt32().Nullable()

              
             


              );
        }
    }
}