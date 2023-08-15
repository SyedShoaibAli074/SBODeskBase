using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default.Pages;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using MyRow = SAPWebPortal.Default.FileRoutingRow;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/FileRouting/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class FileRoutingController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IFileRoutingSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IFileRoutingSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IFileRoutingDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IFileRoutingRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IFileRoutingListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IFileRoutingListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.FileRoutingColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "FileRoutingList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }

        public JsonResult SAPCompanies(string DBName)
        {
            System.Collections.Generic.List<SelectListItem> result = new System.Collections.Generic.List<SelectListItem>();
            string Query = SapDatabasesController.GetSAPCompanies(DBName);
            using (var reader = DBHelper.GetDbDataReaderFromQuery(Query, DBName))
            {
                while (reader.Read())
                {
                    result.Add(new SelectListItem { Text = reader["Company DB"].ToString(), Value = reader["Company DB"].ToString() });
                }
            }
            return Json(result);
        }
        public static string GetExportPath(int ObjType, string DBName)
        {
            var str = DateTime.Now.ToString("yyyyMMddTHHmmss").ToString();
            var path = "";
            try
            {
                str = Regex.Replace(str, @"[^0-9a-zA-Z]+", "");
                SqlQuery sqlQuery = new SqlQuery();
                sqlQuery.From("FileRouting").SelectMany("ExportPath", "ExportExtension").Where($"SLObjectType = '{ObjType}' AND CompanyDB ='{DBName}'");
                using (var connection = DBHelper.GetSerenDBConnection())
                {
                    connection.Open();
                    var reader = sqlQuery.ExecuteReader(connection);
                    if (reader.Read())
                    {
                        path = reader["ExportPath"].ToString();
                        str += reader["ExportExtension"].ToString();
                    }
                    connection.Close();
                }
                str = Path.Combine(path, str);

            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            return str;
        }
        
        public static string GetReportFilePath(int invoiceTemplate, string CompanyDB)
        {
            //invoiceTemplate = "INV20027";
            string reportFilePath = "";
            try
            {
                SqlQuery sqlQuery = new SqlQuery();
                sqlQuery.From("FileRouting").SelectMany("ReportPath").Where($"SLObjectType = '{invoiceTemplate}' AND CompanyDB ='{CompanyDB}'");                
                using (var connection = DBHelper.GetSerenDBConnection())
                {
                    connection.Open();
                    var reader = sqlQuery.ExecuteReader(connection);
                    if (reader.Read())
                    {
                        try
                        {
                            reportFilePath = "APP_DATA\\upload\\" + reader["ReportPath"].ToString().Trim().Replace("/", "\\");
                            reader.Close();
                            
                        }
                        catch (Exception Ex)
                        {
                            ExceptionsController.Log(Ex);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            return reportFilePath;
        }
        public static void callexe(string args)
        {
            //call exe for notification
            try
            {
                var path = Path.Combine(Startup.basePath, Path.Combine(@"App_Data\CrystalReportHelper", "CrystalReportsHelper.exe"));
                Sentry.SentrySdk.CaptureMessage(path);
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = path;
                startInfo.Arguments = args;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                Sentry.SentrySdk.CaptureMessage(startInfo.ToJson());
                Process processTemp = new Process();
                processTemp.StartInfo = startInfo;
                processTemp.EnableRaisingEvents = true;
                processTemp.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processTemp.Start();
                processTemp.WaitForExit();
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
            }
        }
    }
}