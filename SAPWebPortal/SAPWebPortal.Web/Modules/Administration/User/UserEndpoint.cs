using AspNetCoreHero.ToastNotification.Abstractions;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using Org.BouncyCastle.Ocsp;
using SAPWebPortal.Default;
using SAPWebPortal.Web.Helpers;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using MyRepository = SAPWebPortal.Administration.Repositories.UserRepository;
using MyRow = SAPWebPortal.Administration.Entities.UserRow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SAPWebPortal.Membership.Pages;

namespace SAPWebPortal.Administration.Endpoints
{
    //, ServiceAuthorize(typeof(MyRow))
    [Route("Services/Administration/User/[action]")]
    [ConnectionKey(typeof(MyRow))]
    public class UserController : ServiceEndpoint
    {

        //constructor
        public UserController(IHttpContextAccessor Accesser)
            : base()
        {

        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            if (request.Entity.Source == "SBO")
            {
                // Add UserCode in request
                request.Entity.UserCode = request.Entity.Username;

                request.DBName = request.Entity.DBName;
                

                SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
                
                    //var dbname = item.CompanyDb;
                    var Res = helper.CreateUserInSAP(request);
                    var Dic = new Dictionary<string, object>();
                    Dic = Res.CustomData;
                    //if (Dic != null)
                    //{
                    //    var Result = Dic["Approval"];
                    //    if ((bool)Result)
                    //    {
                    //        _ToastNotification.AddSuccessToastMessage("The Document is Successfully Posted for Approval...!");
                    //    }
                    //}
                    return Res;

            //    }

            }
            return new MyRepository(Context).Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
          
           
            return new MyRepository(Context).Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository(Context).Delete(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public UndeleteResponse Undelete(IUnitOfWork uow, UndeleteRequest request)
        {
            return new MyRepository(Context).Undelete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            //_Notify.Success("The Retrieve is Successful...!", 10);
           
            return new MyRepository(Context).Retrieve(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            //_Notify.Success("The List is Successfully Retrived...!", 10);
            return new MyRepository(Context).List(connection, request);
        }
        [HttpPost]
        public void SetActiveCompany(IDbConnection connection, object obj)
        {
            //todo: update the field
            connection = DBHelper.GetSerenDBConnection();
            if(connection.State != ConnectionState.Open)
            connection.Open();
            var CompanyDB = "";
            try { obj.GetType().GetProperty("CompanyDB").GetValue(obj); } catch { }
            if(string.IsNullOrEmpty(CompanyDB))
                CompanyDB = ((dynamic)obj).CompanyDB;
            string updatequery = string.Format("update Users set CompanyDatabase = '{0}' where Username = '{1}'", CompanyDB, Context.User.Identity.Name);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = updatequery;
                int i = command.ExecuteNonQuery();
            }
        }
        //remove anty forgery
        
        [HttpGet,IgnoreAntiforgeryToken]
        public GETBoard_Response ActiveCompany()
        {
            GETBoard_Response answer = new GETBoard_Response();
            using(SqlConnection conn = new SqlConnection(Startup.connectionString))
            {
                
            //if conn is not open
            if (conn.State != ConnectionState.Open)
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
            //if conn is not closed
            if (conn.State != ConnectionState.Closed)
                conn.Close();
                
            }
            return answer;
        }
        [HttpPost,IgnoreAntiforgeryToken]
        public GETBoard_Response getActiveCompanyName(object DB)
        {
            GETBoard_Response answer = new GETBoard_Response();
            SqlConnection conn = new SqlConnection(Startup.connectionString);
            try
            {
                answer.CompanyDB =DB.ToString();

            }
            catch (Exception ex)
            {

               // throw;
            }
            return answer;
        }
        [HttpGet,IgnoreAntiforgeryToken]
        public JsonResult SAPCOMPANYLIST()
        {

          System.Collections.Generic.  List<SelectListItem> result = new System.Collections.Generic.List<SelectListItem>();

            SqlConnection conn = new SqlConnection(Startup.connectionString);
            conn.Open();
            string GetItems = string.Format("select Id as CompanyID, CompanyDB from SapDatabases ");

            SqlDataReader sdr;

            using (SqlCommand cmd = new SqlCommand(GetItems, conn))
            {
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows == true)
                {
                    while (sdr.Read())
                    {
                        result.Add(new SelectListItem { Text = sdr["CompanyDB"].ToString(), Value = sdr["CompanyDB"].ToString() });
                    }
                }

            } 
            conn.Close();

            //return Json(result, JsonRequestBehavior.AllowGet);
            return Json(result);

        }

        public JsonResult GetCodeNameValues(CodeNameValuesInputParams row)
        {
            return Json(SAPHelper<MyRow>.GetListFromQuery(row.row, row.propertyNameSAP, row.row.DBName));
        }


    }
    public class GETBoard_Response : ServiceResponse
    {
        public String CompanyDB;
    }
    public class CodeNameValuesInputParams
    {
        public MyRow row { get; set; }
        public string propertyNameSAP { get; set; }
    }

}
