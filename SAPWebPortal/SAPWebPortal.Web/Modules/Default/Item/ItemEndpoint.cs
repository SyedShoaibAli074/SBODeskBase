using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SAPWebPortal.Web.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.Default.ItemRow;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/Item/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ItemController : ServiceEndpoint,IDataDictionary
    {
        private readonly IToastNotification _ToastNotification;
        public ItemController(IToastNotification ToastNotification, INotyfService Notify)
        {
            _ToastNotification = ToastNotification;
            //_Notify = Notify;
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IItemSaveHandler handler)
        {

            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
             var result =  helper.CreateInSAP(request);
            //helper.RefreshFromSAPPAS();
             return result;
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IItemSaveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);

            var result = helper.UpdateInSAP(request);
            //helper.RefreshFromSAPPAS();
            return result;
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IItemDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);

            return helper.DeleteInSAP(request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IItemRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);

            return helper.RetrieveFromSAP(request); 
        }

        [HttpPost,IgnoreAntiforgeryToken]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IItemListHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DataSourceType = DataSourceType.SAP_DataBase;
            return helper.List(request); 
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IItemListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.ItemColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "ItemList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }

        public void FillDataDictionary(string username, string password, string companyDB)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            helper.FillDataDictionary(username, password, companyDB);
        }
        public System.Collections.Generic.List<(string username, string dbname, string modlulename, int totalcount)> GetAllDataDictionary()
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.GetAllDataDictionary();
        }
    }
}