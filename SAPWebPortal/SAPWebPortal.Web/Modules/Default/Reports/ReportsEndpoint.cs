using Microsoft.AspNetCore.Mvc;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using MyRow = SAPWebPortal.Default.ReportsRow;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/Reports/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class ReportsController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IReportsSaveHandler handler)
        {
            //ReportDocument rpt = new ReportDocument();
            var name = request.Entity.RptByteArray;
            string rptPath = Path.Combine(Startup.basePath, Path.Combine(@"App_Data\upload", name));
            string[] arr = name.Split('.');
            var len = (arr.Length) - 1;
            if (arr[len] != "rpt")
            {
                throw new System.Exception("Please Select Correct Report File ");
            }
            else
            {
                //rpt.Load(rptPath);
                //if (rpt.SummaryInfo.ReportTitle != null)
                //    request.Entity.RptName = rpt.SummaryInfo.ReportTitle.ToString();
                request.Entity.CreateDate = System.DateTime.Now;
                using (var connection = new SqlConnection(Startup.connectionString))
                {
                    var sameReport = connection.List<ReportsRow>().Where(x => x.RptName == request.Entity.RptName && x.DB_Name == request.Entity.DB_Name).Count();
                    if (sameReport > 0)
                    {
                        throw new System.Exception("Report with same name already exists");
                    }
                }
                var Resp = handler.Create(uow, request);
                uow.OnCommit += () =>
                {
                    //if (rpt.SummaryInfo.ReportTitle == null)
                    {
                        using (var con = new SqlConnection(Startup.connectionString))
                        {
                            var rdocid = Convert.ToInt32(Resp.EntityId);
                            var rdoc = con.List<ReportsRow>().First(x => x.Rdocid == rdocid);
                            string[] rptname = System.IO.Path.GetFileName(rdoc.RptByteArray).Split('.');
                            rdoc.RptName = rptname[0].ToString();
                            //rdoc.SubmitChanges();
                        }
                    }
                };
                return Resp;
            }
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IReportsSaveHandler handler)
        {
            request.Entity.UpdateDate = System.DateTime.Now;
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IReportsDeleteHandler handler)
        {
            //try
            //{
            //    var dc = new dcDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            //    var rdoc = dc.RDOCs.Where(x => x.RDOCID == Convert.ToInt32(request.EntityId)).First();
            //    var response = new ReportsDeleteHandler().Process(uow, request);
            //    if (response.Error == null)
            //    {
            //        var path = System.IO.Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/"), rdoc.Rpt_Byte_Array);
            //        if (System.IO.File.Exists(path))
            //            System.IO.File.Delete(path);
            //    }
            //    return response;
            //}
            //catch
            //{
            //    throw new System.Exception("Report is assigned to user. To delete report unassign it from User");
            //}
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IReportsRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IReportsListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IReportsListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.ReportsColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "ReportsList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}