using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Helpers;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using SAPWebPortal.Web.Helpers;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Sentry;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingRow;

namespace SAPWebPortal.InventoryCounting.Endpoints
{
    [Route("Services/InventoryCounting/InventoryCounting/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class InventoryCountingController : ServiceEndpoint
    {
        private readonly IToastNotification _ToastNotification;
        public InventoryCountingController(IToastNotification ToastNotification, INotyfService Notify)
        {

            _ToastNotification = ToastNotification;
            //_Notify = Notify;
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IInventoryCountingSaveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.CreateInSAP(request);
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public SaveResponse CreateInSAP(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IInventoryCountingSaveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            //loop through lines of entity in request.
            var lines = request.Entity.InventoryCountingLines;
            //foreach lines set the default uomcode
            foreach (var item in lines)
            {
                item.UoMCode = getdefaultUomCode(item.ItemCode, request.DBName);   
                if(item.UoMCode == "")
                {
                    var ex = new Exception("Inventory UOM is empty. Please check if inventory UoM is set for item " + item.ItemCode);
                    SentrySdk.CaptureException(ex);
                    throw ex;
                }
                item.BinEntry = getBinEntry(item.ItemCode, item.WarehouseCode, request.DBName);
            }
              
            return helper.CreateInSAP(request);
        }

        private int? getBinEntry(string itemCode, string warehouseCode, string companyname)
        {
            try
            {
                var connection = DBHelper.GetDBConnection(companyname);
                //SELECT "DftBinAbs" FROM OWHS T0 where T0."WhsCode" ='05'
                string sql = @$"SELECT ""DftBinAbs"" FROM OWHS T0 where T0.""WhsCode"" ='{warehouseCode}'";
                 using (var tbl = DBHelper.GetTableFromQuery(sql, connection))
                {
                    if (tbl.Rows.Count > 0)
                    {
                        return Convert.ToInt32(tbl.Rows[0][0]);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            
            catch (Exception ex)
            {
                ex.Log();
                return null;
            }
        }

        private string getdefaultUomCode(string itemCode,string Dbname)
        {
            string UOMCode = "";
            using (var connection = DBHelper.GetDBConnection())
            {
                try
                {
                    var query = @$"select t1.""UomCode"" from OITM t0 inner join OUOM t1 on t1.""UomEntry"" = t0.""INUoMEntry"" where t0.""ItemCode"" = '{itemCode}'";
                    
                    using (var table = DBHelper.GetTableFromQuery(query, Dbname))
                    {
                        UOMCode = table.Rows[0]["UomCode"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            }

            return UOMCode;
        }


        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IInventoryCountingSaveHandler handler)
        { 
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.UpdateInSAP(request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IInventoryCountingDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.DeleteInSAP(request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IInventoryCountingRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.RetrieveFromSAP(request); 
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IInventoryCountingListHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DataSourceType = DataSourceType.SAP_DataBase;
            return helper.List(request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IInventoryCountingListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.InventoryCountingColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "InventoryCountingList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}