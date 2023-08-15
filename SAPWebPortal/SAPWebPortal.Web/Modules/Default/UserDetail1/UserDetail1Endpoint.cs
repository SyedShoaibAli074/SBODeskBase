using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using NToastNotify.Helpers;
using SAPWebPortal.Administration.Endpoints;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using MyRow = SAPWebPortal.Default.UserDetail1Row;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/UserDetail1/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UserDetail1Controller : ServiceEndpoint
    {

        public UserDetail1Controller(IRequestContext context, string Companyname = "", string UserName = "")
            : base()
        {
            base.Context = context;
            if(!string.IsNullOrEmpty(Companyname))
            {
                base.Company = Companyname;
            }
            else
            {
                var usercontroller = new UsersController(context);

                var username = context.User?.Identity?.Name?? UserName;
                base.Company = usercontroller.getCompanyName(username);
               
            }
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IUserDetail1SaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IUserDetail1SaveHandler handler)
        {
            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IUserDetail1DeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IUserDetail1RetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IUserDetail1ListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IUserDetail1ListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.UserDetail1Columns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "UserDetail1List_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }

        internal System.Collections.Generic.List<string> GetCustomersRelatedToUser(string username,string CompanyDB)
        {
            var list = new System.Collections.Generic. List<string>();
            var connection = DBHelper.GetSerenDBConnection();
            SqlQuery sqlQuery = new SqlQuery();
            var user = new UsersController(this.Context);
            var companyname = CompanyDB;
            sqlQuery.Select("CardCode").From("UserDetail1").Where($"UserCode='{username}' and DbName = '{CompanyDB}'");
            using (var reader = sqlQuery.ExecuteReader(connection))
            {
                while (reader.Read())
                {
                    list.Add(reader["CardCode"].ToString());
                }
            }
            var lst = ListOfCustomersattachedToTheSalesPersonsAssignedToUser(username, companyname);
            if (lst.Count > 0)
            {
                foreach(var l in lst)
                {
                    list.Add(l);
                }
            }
                
            list =list.Distinct().ToList();
            return list;
        }
        //get sales employee number from username sap business one
        internal int GetSlpCodefromUsername(string username,string DBName)
        {
            int salesemployee =-1;
            //get employee number from username sap b
            var query = $"SELECT T1.\"salesPrson\" FROM OUSR T0  INNER JOIN OHEM T1 ON T0.\"USERID\" = T1.\"userId\" WHERE T0.\"USER_CODE\" ='{username}'";
            var user = new UsersController(this.Context);
            var companyname = DBName;
            using (var connection = DBHelper.GetDBConnection(companyname))
            {
               var table =  DBHelper.GetTableFromQuery(query,companyname);
                if (table.Rows.Count > 0)
                    try { salesemployee = Convert.ToInt32(table.Rows[0]["salesPrson"]??-1); } catch { }
            }
            return salesemployee;
        }
        public JsonResult GetCardName(ApiData cardcode)
        {
            var _cardcode = cardcode.Code;
            var DBName = cardcode.DBName;
            string cardname = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_61", DBName), _cardcode);
                using (var reader = DBHelper.DoQuery(query, DBName))
                {
                    if (reader.Read())
                    {
                        cardname = reader["CardName"].ToString();
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { cardname };
            return Json(res);
        }


        public System.Collections.Generic.List<string> ListOfCustomersattachedToTheSalesPersonsAssignedToUser(string username, string CompanyDB)
        {
            var usercontroller = new UsersController(Context);
            var companyname = CompanyDB;

            var userdetail2controll = new UserDetail2Controller(Context, companyname: CompanyDB, UserName: username);
            var salespersoncodeCSV = userdetail2controll.GetSalesPersonCodeCSV(username, CompanyDB);
            var slpcode = GetSlpCodefromUsername(username, CompanyDB);
                System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
            if (salespersoncodeCSV != "-1"&& !string.IsNullOrEmpty(salespersoncodeCSV))
            {
                var query = $@"select ""CardCode"" from ocrd where ""CardType""='C' and ""SlpCode"" in ({salespersoncodeCSV})";
                var table = DBHelper.GetTableFromQuery(query, CompanyDB);
                // fill the list
                foreach (System.Data.DataRow row in table.Rows)
                {
                    lst.Add(row["CardCode"].ToString());

                }
            }
            return lst;
            


        }
        /// <summary>
        /// Valid Card Codes for the user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        internal string GetCardCodesCSV(string username)
        {
            System.Collections.Generic.List<string> lst = new System.Collections.Generic.List<string>();
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                if(connection.State != ConnectionState.Open)
                connection.Open();
                var table = DBHelper.GetTableFromQuery("select CardCode from UserDetail1 where UserCode='" + username + "'", connection);
                foreach (DataRow row in table.Rows)
                {
                    lst.Add(row["CardCode"].ToString());
                }
                connection.Close();
            }
            //append quote at start and end of each item
            lst = lst.Select(x => "'" + x + "'").ToList();
            return string.Join(",", lst);
        }
        
        // GetSalesPersonCodePersonNameForAuth
       
        //public JsonResult getBusinessPartner()
        //{
        //     var CardCode = "";
        //     var CardName = "";
        //    try
        //    {
        //        var query = String.Format(DBHelper.GetQuery("Query_58") );
        //        using (var reader = DBHelper.DoQuery(query))
        //        {
        //            if (reader.Read())
        //            {
        //                CardCode =  reader["CardCode"].ToString();
        //                CardName =  reader["CardName"].ToString();

        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {        
        //    }
        //    var res = new { CardCode,CardName };
        //    return Json(res);
        //}
    }
}