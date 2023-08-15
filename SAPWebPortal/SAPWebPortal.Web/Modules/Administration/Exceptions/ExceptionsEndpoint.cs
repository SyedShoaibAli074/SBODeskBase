using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using MyRow = SAPWebPortal.Administration.ExceptionsRow;

namespace SAPWebPortal.Administration.Endpoints
{
    [Route("Services/Administration/Exceptions/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ExceptionsController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IExceptionsSaveHandler handler)
        {
            return handler.Create(uow, request);
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public SaveResponse Create_Exception(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IExceptionsSaveHandler handler)
        {
            if(request.EntityId != null)
            {
                request.Entity.Id = null;
                request.EntityId = null;
            }
            var saverequest =  handler.Create(uow, request);
            return saverequest;
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IExceptionsSaveHandler handler)
        {
            return handler.Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IExceptionsDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IExceptionsRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IExceptionsListHandler handler)
        {
            return handler.List(connection, request);
        }
        public static void Log(Exception exception, string str = "")
        {
            //if debugger is attached
            if (System.Diagnostics.Debugger.IsAttached)
            {
                //save exception to file in temp location
                string tempPath = System.IO.Path.GetTempPath();
                var guid = Guid.NewGuid().ToString();
                string fileName = string.Format("Exception{1}_{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"),guid);
                string filePath = System.IO.Path.Combine(tempPath, fileName);
                System.IO.File.WriteAllText(filePath, exception.ToString());
                //show file content on text box

               Process.Start("notepad.exe",filePath);
            }
            try
            {
                Sentry.SentrySdk.CaptureException(exception);
                if (!string.IsNullOrEmpty(str)) Sentry.SentrySdk.CaptureMessage(str);
            }
            catch { }
            try
            {
                Serenity.Data.SqlInsert insert = new Serenity.Data.SqlInsert("Exceptions");
                {
                    string s = str.Replace("'", "''");
                    insert.SetTo("Guid", "'" + Guid.NewGuid().ToString() + "'");
                    insert.SetTo("ApplicationName", "'SAPWebPortal'");
                    insert.SetTo("MachineName", "'MachineName'");
                    insert.SetTo("CreationDate", "getdate()");
                    insert.SetTo("Type", "'Error'");
                    insert.SetTo("Message", "'" + exception.Message.Replace("'", "''") + "'");
                    insert.SetTo("Detail", "'" + s + " " + exception.StackTrace + "'");

                    using (var connection = new System.Data.SqlClient.SqlConnection(Startup.connectionString))
                    {
                        Serenity.Data.SqlHelper.ExecuteNonQuery(connection, insert.ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            finally
            {
                GC.Collect();
            }
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
        [FromServices] IExceptionsListHandler handler,
        [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.ExceptionsColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "ExceptionsList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}