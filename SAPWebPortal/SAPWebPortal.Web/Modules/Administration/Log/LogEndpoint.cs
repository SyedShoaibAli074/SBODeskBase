
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.Administration.LogRow;

namespace SAPWebPortal.Administration.Endpoints
{
    [Route("Services/Administration/Log/[action]")]
    [ConnectionKey(typeof(MyRow))]
    public class LogController : ServiceEndpoint
    {
        [HttpPost]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] ILogSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] ILogSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] ILogDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] ILogRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public ListResponse<MyRow> HeartBeat(IDbConnection connection, ListRequest request)
        {
            return new ListResponse<MyRow>();
        }
        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] ILogListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] ILogListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.LogColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "LogList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        
        public static bool DBLog(string Direction, string U_Error, string U_XML, string U_ObjType, string U_version,out string id, string U_KEY = "", string U_DocNum = "", string response = "")
        {
            bool ret = true;
            String pattern = "yyyy-MM-dd HH:mm:ss";
            id = ""; var idnum = "";
            try
            {
                using (var connection1 = new System.Data.SqlClient.SqlConnection(Startup.connectionString))
                {
                        var dt = DateTime.Now.ToString(pattern);
                        MyRow row = new MyRow();
                        SqlInsert sqlInsert = new SqlInsert(row.Table);
                        sqlInsert.SetTo("U_Direction", "'" + Direction + "'");
                        sqlInsert.SetTo("U_Error", "'" + U_Error + "'");
                        sqlInsert.SetTo("U_Xml", "'" + System.Net.WebUtility.HtmlEncode(U_XML.Replace("'", "''")) + "'");
                        sqlInsert.SetTo("U_Response", "'" + System.Net.WebUtility.HtmlEncode(response.Replace("'", "''")) + "'");
                        sqlInsert.SetTo("U_ObjType", "'" + U_ObjType + "'");
                        if (!string.IsNullOrEmpty(U_KEY)) sqlInsert.SetTo("U_Key", "'" + U_KEY + "'");
                        if (!string.IsNullOrEmpty(U_DocNum)) sqlInsert.SetTo("U_DocNum", "'" + U_DocNum + "'");
                        sqlInsert.SetTo("U_DateTime", "'" + dt + "'");
                        idnum = sqlInsert.ExecuteAndGetID(connection1).ToString();
                }
            }
            catch (Exception Ex) { ExceptionsController.Log(Ex); ret = false; }
            finally { if (ret) id = idnum; }

            return ret;
        }
        public static bool DBLogDelete()
        {
            bool ret = true;
            try
            {
                using (var connection1 = new System.Data.SqlClient.SqlConnection(Startup.connectionString))
                {
                    connection1.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(@" DELETE FROM Log WHERE CONVERT(date,U_DateTime) < CONVERT(date, DATEADD(dd,-1,GETDATE()) ) ", connection1);
                    cmd.ExecuteNonQuery();
                    connection1.Close();
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
                ret = false;
            }
            finally
            {
            }
            return ret;
        }
        public static bool ExceptionLogDelete()
        {
            bool ret = true;
            try
            {
                using (var connection1 = new System.Data.SqlClient.SqlConnection(Startup.connectionString))
                {
                    connection1.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(@" DELETE FROM Exceptions WHERE CONVERT(date,CreationDate) < CONVERT(date, DATEADD(dd,-2,GETDATE()) ) ", connection1);
                    cmd.ExecuteNonQuery();
                    connection1.Close();
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
                ret = false;
            }
            finally
            {
            }
            return ret;
        }
    }
}