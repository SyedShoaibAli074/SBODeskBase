using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.Default.UsersRow;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using SAPWebPortal.Membership.Pages;

namespace SAPWebPortal.Default.Endpoints
{
   
    [Route("Services/Default/Users/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UsersController : ServiceEndpoint
        
    {
        HttpContext httpcontext { get; }
        public UsersController()
        {
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IUsersSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IUsersSaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IUsersDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IUsersRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IUsersListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IUsersListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.UsersColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "UsersList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }

        internal string getCompanyName(string username,string SessionId)
        {
            SqlQuery sqlquery = new SqlQuery();
            sqlquery.Select("CompanyDatabase").From("Users").Where($"Username='{username}' and PortalSessionID='{SessionId}'");
            //ireader result
            var ans = "";
            
            using(var connection = DBHelper.GetSerenDBConnection())
            {
                if(connection.State != ConnectionState.Open)
                    connection.Open();
                var table = DBHelper.GetTableFromQuery(sqlquery.Text,connection);
                if(table.Rows.Count>0)
                {
                    ans = table.Rows[0][0].ToString();
                }
                //connection is not closed then close it
                if(connection.State != ConnectionState.Closed)
                    connection.Close();
                  
            }
            return ans;
        }
        internal string getCompanyName(string username)
        {
            SqlQuery sqlquery = new SqlQuery();
            sqlquery.Select("CompanyDatabase").From("Users").Where($"Username='{username}'");
            //ireader result
            var ans = "";
            
            using(var connection = DBHelper.GetSerenDBConnection())
            {
                if(connection.State != ConnectionState.Open)
                    connection.Open();
                var table = DBHelper.GetTableFromQuery(sqlquery.Text,connection);
                if(table.Rows.Count>0)
                {
                    ans = table.Rows[0][0].ToString();
                }
                //connection is not closed then close it
                if(connection.State != ConnectionState.Closed)
                    connection.Close();
                  
            }
            return ans;
        }

        

        public UsersController(IRequestContext context)
             : base()
        {
            base.Context = context;
        }
    }
}