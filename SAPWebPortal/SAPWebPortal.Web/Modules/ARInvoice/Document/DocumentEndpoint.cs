
using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Web.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.ARInvoice.DocumentRow;

namespace SAPWebPortal.ARInvoice.Endpoints
{
    [Route("Services/ARInvoice/Document/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class DocumentController : ServiceEndpoint
    {
        public DocumentController() 
        {
          
        } 
        //constructor
        
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentSaveHandler handler)
        {
           SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DBName = request.Entity.DBName;
           
            return helper.CreateInSAP(request); 
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentSaveHandler handler)
        { 

            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DBName = request.Entity.DBName;

            return helper.UpdateInSAP(request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IDocumentDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.DeleteInSAP(request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IDocumentRetrieveHandler handler)
        {
            
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.RetrieveFromSAP(request); 
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IDocumentListHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DataSourceType = DataSourceType.SAP_DataBase;
            return helper.List(request);
        }
        [HttpGet]
        public ListResponse<MyRow> GetAll()
        {
            ListResponse<MyRow> response = new ListResponse<MyRow>();

            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            ListRequest request = new ListRequest();
            response.Entities = new System.Collections.Generic.List<MyRow>();
            request.Skip = 0;
            request.Take = 20;
            var count = -1;
            var TotalCount = 0;
            request.DataSourceType = DataSourceType.SAP_DataBase;
            while (count != 0)
            {
                var list = helper.List(request);
                count = list.Entities.Count;
                response.Entities.AddRange(list.Entities);
                request.Skip += 20;
                TotalCount += count;
            }
            response.TotalCount = TotalCount;
            return response; 
        }
        [HttpPost]
        public ListResponse<MyRow> ListforCardCode(IDbConnection connection, String CardCode,
            [FromServices] IDocumentListHandler handler)
        {
            ListRequest request = new ListRequest();
            request.Criteria = new Criteria("CardCode") == CardCode;
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.List(request);
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IDocumentListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.DocumentColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "DocumentList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}