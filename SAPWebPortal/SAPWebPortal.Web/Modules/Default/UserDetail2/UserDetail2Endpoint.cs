using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using SAPbouiCOM;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using MyRow = SAPWebPortal.Default.UserDetail2Row;
using System.Collections.Generic;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/UserDetail2/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UserDetail2Controller : ServiceEndpoint
    {
        public UserDetail2Controller(IRequestContext context,string companyname="",string UserName = "")
        {
            Context = context;
            if (!string.IsNullOrEmpty(companyname))
            {
                Company = companyname;
            }
            else
            {

                var username = UserName;
                if(string.IsNullOrEmpty(UserName))
                    username = context.User?.Identity.Name;
                var usercontroller = new UsersController(context);
                Company = usercontroller.getCompanyName(username);
            }
        }

        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IUserDetail2SaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IUserDetail2SaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IUserDetail2DeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IUserDetail2RetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IUserDetail2ListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IUserDetail2ListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.UserDetail2Columns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "UserDetail2List_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        //function to get slpname from slpcode from sap
        public string GetSlpNameT(string slpcode)
        {
            var usercontroller = new UsersController(this.Context);
            var username = this.Context.User.Identity.Name;
            var companyname = usercontroller.getCompanyName(username);

            var slpcodeCSV = GetSalesPersonCodeCSV(username, companyname);
            var slpname = "";
            using (var connectionsap = DBHelper.GetDBConnection(companyname))
            {
                
                if(connectionsap.State != ConnectionState.Open) connectionsap.Open();
                var query = $@"select ""SlpName"" from OSLP where ""SlpCode"" = '{slpcode}' ";
                //execute query and get slpname from sap
                //var command = DBHelper.GetTableFromQuery(query, connectionsap);
                //var reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    slpname = reader["SlpName"].ToString();
                //}
                var db = DBHelper.GetTableFromQuery(query, connectionsap);
                foreach (DataRow dr in db.Rows)
                {
                    slpname = dr["SlpName"].ToString();
                    //return slpname;
                }
                connectionsap.Close();
                return slpname;
            }
            
        }
        public JsonResult GetSlpName(ApiData slpcode)
        {
            var _cardcode = slpcode.Code;
            var DBName = slpcode.DBName;

            string slpname = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_60",DBName), _cardcode);
                using (var reader = DBHelper.DoQuery(query,DBName))
                {
                    if (reader.Read())
                    {
                        slpname = reader["SlpName"].ToString();
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { slpname };
            return Json(res);
        }



        public System.Collections.Generic.List<(string SlpCode, string SlpName)> GetSalesPersonNameForAuth(IDbConnection connection,object DBName)
        {
            var usercontroller = new UsersController(this.Context);
            var username = this.Context.User.Identity.Name;
            var companyname = DBName.ToString();

            var slpcodeCSV = GetSalesPersonCodeCSV(username, companyname);
            System.Collections.Generic.List<(string SlpCode, string SlpName)> lst = new System.Collections.Generic.List<(string SlpCode, string SlpName)>();
            lst.Clear();
            using (var connectionsap = DBHelper.GetDBConnection(companyname))
            {
                   if(connectionsap.State != ConnectionState.Open) connectionsap.Open();
             
                var condition = string.Empty;
                if (!string.IsNullOrEmpty(slpcodeCSV))
                {
                    condition = " where SlpCode not in (" + username + ")";
                }
                var query = $@"select ""SlpCode"",""SlpName"" from OSLP {condition} order by ""SlpCode""";
                var db = DBHelper.GetTableFromQuery(query, connectionsap);
                foreach (DataRow dr in db.Rows)
                {
                    lst.Add((dr["SlpCode"].ToString(), dr["SlpName"].ToString()));
                }
                connectionsap.Close();
            }
            return lst;
        }
        internal string GetSalesPersonCodeCSV(string username ,string CompanyDB)
        {

            System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                if(connection.State != ConnectionState.Open)
                    connection.Open();
                var table = DBHelper.GetTableFromQuery("select SalesPersonCode from UserDetail2 where DBName = '"+ CompanyDB + "' and UserCode='" + username + "'", connection);
                foreach (DataRow row in table.Rows)
                {
                    lst.Add(row["SalesPersonCode"].ToString());
                }
                connection.Close();
            }
            //append quote at start and end of each item
            lst = lst.Select(x => "'" + x + "'").ToList();
            return string.Join(",", lst);
        }
        [HttpGet]
        public GETBoard_Response ActiveCompany()
        {
            GETBoard_Response answer = new GETBoard_Response();
            SqlConnection conn = new SqlConnection(Startup.connectionString);
            conn.Open();
            var user = Context.User.Identity.Name;
            string GetUserBoard = string.Format("SELECT CompanyDatabase FROM Users where Username='{0}'", user);
            //"select Quantity from DepItemTable where DepID=depID and ItemID=itemId";
            SqlDataReader sdr;

            using (SqlCommand cmd = new SqlCommand(GetUserBoard, conn))
            {

                sdr = cmd.ExecuteReader();
                if (sdr.HasRows == true)
                {
                    while (sdr.Read())
                    {
                        answer.CompanyDB = sdr[0].ToString();

                        return answer;
                    }
                }


            }

            //answer.AVailableQty = "5.0";
            conn.Close();
            return answer;
        }
    }
    public class GETBoard_Response : ServiceResponse
    {
        public String CompanyDB;
    }
}