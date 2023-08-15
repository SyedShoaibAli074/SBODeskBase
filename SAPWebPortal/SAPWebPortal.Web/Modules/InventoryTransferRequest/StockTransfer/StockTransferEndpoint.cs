using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Web.Helpers;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Linq;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferRow;

namespace SAPWebPortal.InventoryTransferRequest.Endpoints
{
    [Route("Services/InventoryTransferRequest/StockTransfer/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class StockTransferController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IStockTransferSaveHandler handler)
        {
           SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
           return helper.CreateInSAP(request); 
        }

        [HttpPost, IgnoreAntiforgeryToken]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IStockTransferSaveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DBName = request.Entity.DBName;

            request.ReplaceCollectionsOnPatch = true;
            return helper.UpdateInSAP(request);
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public SaveResponse UpdateRecievedQty(IUnitOfWork uow, SaveRequest<SAPWebPortal.Web.Models.SLModels.StockTransfer> request,
            [FromServices] IStockTransferSaveHandler handler)
        {
            SAPHelper<SAPWebPortal.Web.Models.SLModels.StockTransfer> helper = new SAPHelper<SAPWebPortal.Web.Models.SLModels.StockTransfer>(Context);
            request.DBName = request.Entity.DBName;

            request.ReplaceCollectionsOnPatch = true;
            return helper.UpdateInSAP(request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IStockTransferDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.DeleteInSAP(request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IStockTransferRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.RetrieveFromSAP(request); 
        }

        [HttpPost,IgnoreAntiforgeryToken]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IStockTransferListHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DataSourceType = DataSourceType.SAP_DataBase;
            return helper.List(request);
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public ListResponse<MyRow> ListAndRetrieve(ListRequest request)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);

            request.DataSourceType = DataSourceType.SAP_DataBase;
            var response = helper.List(request);
            //get userid
            //warehouse assigned to user
            string whscode = GET_WHS_CODE_FROM_USERID();
            
            response.Entities = response.Entities.Where(x => x.ToWarehouse == whscode).ToList();

            //loop through response.Entities
            foreach (var item in response.Entities)
            {
               var retieved = helper.RetrieveFromSAP(new RetrieveRequest() { EntityId = item.DocEntry.ToString()+","+request.CompanyDB });
                item.StockTransferLines  = retieved.Entity.StockTransferLines ; 
            }
            //filter response.Entities by whscode 
            return response;
        }

        private string GET_WHS_CODE_FROM_USERID()
        { 
            var username = Context.User.Identity.Name;
            var result = "";
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                //select WarehouseCode from users where Username = 'manager'
                var query = $@"select WarehouseCode from users where Username = '{username}'";
                using (var tablename = DBHelper.GetTableFromQuery(query, connection))
                {
                    foreach (DataRow row in tablename.Rows)
                    {
                        result = row["WarehouseCode"].ToString();
                    }
                }
            } 
            return result;
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IStockTransferListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.StockTransferColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "StockTransferList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}