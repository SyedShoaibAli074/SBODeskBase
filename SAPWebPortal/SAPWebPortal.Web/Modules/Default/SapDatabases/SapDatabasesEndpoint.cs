using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using static SAPWebPortal.Web.Models.SLModels.UDFs;
using MyRow = SAPWebPortal.Default.SapDatabasesRow;
using System.Linq;

namespace SAPWebPortal.Default.Endpoints
{

    [Route("Services/Default/SapDatabases/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class SapDatabasesController : ServiceEndpoint
    {
        static SapDatabasesRow row = new SapDatabasesRow();
        //static string server = "";
        //static string odbcServer = "";
        //static string dbusername = "";
        //static string dbpassword = "";
        //static string companydb = "";
        //static string companyuser = "";
        //static string companypassword = "";
        //static string servicelayerurl = "";
        //static string serviceLayerVersion = "";
        //static string dbdriver = "";
        // static Boolean isDefault = false;
        public static SapDatabasesRow Row
        {
            get
            {
                if (string.IsNullOrEmpty(row.ServerName))
                {
                    isHana();
                }
                return row;
            }
        }
        public static SapDatabasesRow SAPRow(string DBName) {

            if (string.IsNullOrEmpty(row.ServerName))
            {
                isHana(DBName);
            }
            return row;

        }



        //get service layer url
        /// <summary>
        /// request has username,dbname
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //
        //with no authorizations 
        // set permission key

        [HttpGet]
        public string ServiceLayerUrl()
        {
            var username = Context.User.Identity.Name;
            var usercontroller = new UsersController();
            var dbname = usercontroller.getCompanyName(username);
            var servicelayerurl = "";
            var ServiceLayerVersion = "";
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                if(connection.State != ConnectionState.Open)
                connection.Open();
                string query = $"select ServiceLayerURL,ServiceLayerVersion from SapDatabases where CompanyDB = '{dbname}'";

                Sentry.SentrySdk.CaptureMessage(query);
                var table = DBHelper.GetTableFromQuery(query, connection);
                servicelayerurl = table.Rows[0][0].ToString();
                ServiceLayerVersion = table.Rows[0][1].ToString();
                connection.Close();
            }
            //if servicelayerurl doesn't ends with / then append /
            if (!servicelayerurl.EndsWith("/"))
            {
                servicelayerurl = servicelayerurl + "/";
            }
            return servicelayerurl + "b1s/" + ServiceLayerVersion;
        }
        public static string GetSAPCompanies(string DBName)
        {
            var query = "";
            try
            {
                if (!SapDatabasesController.isHana(DBName))
                    query = "SELECT \"dbName\" AS \"Company DB\",\"cmpName\" AS \"Company Name\" from \"SBO-Common\".\"dbo\".SRGC";
                else
                    query = "SELECT \"dbName\" AS \"Company DB\",\"cmpName\" AS \"Company Name\" from \"SBOCOMMON\".SRGC";
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            return query;
        }
        static bool? isHanavar = null;
        public static bool isHana()
        {
            //string dbserverType = "";
            //string LicenseServer = "";
            if (isHanavar != null)
            {
                return (bool)isHanavar;
            }
            SqlQuery sql = new SqlQuery();
            var count = 0;
            sql.From("SapDatabases").SelectMany("DBServerType", "ServerName", "LicenseServer", "CompanyDB", "DBUserName", "DBPassword", "UserName", "Password", "ODBCServer", "ServiceLayerURL", "ServiceLayerVersion", "DBDriver", "IsDefault");


            using (var connection = new SqlConnection(Startup.connectionString))
            {

                if (connection.State != ConnectionState.Open)
                    connection.Open();
                    using (var reader = sql.ExecuteReader(connection))
                {

                    if (reader.Read())
                    {
                        count++;
                        row.LicenseServer = reader["LicenseServer"].ToString();
                        row.DbServerType = reader["DBServerType"].ToString();
                        row.ServerName = reader["ServerName"].ToString();
                        row.ODBCServer = reader["ODBCServer"].ToString();
                        row.CompanyDb = reader["CompanyDB"].ToString();
                        row.DbUserName = reader["DBUserName"].ToString();
                        row.DbPassword = reader["DBPassword"].ToString();
                        row.UserName = reader["UserName"].ToString();
                        row.Password = reader["Password"].ToString();
                        row.ServiceLayerUrl = reader["ServiceLayerURL"].ToString();
                        row.ServiceLayerVersion = reader["ServiceLayerVersion"].ToString();
                        row.DBDriver = reader["DBDriver"].ToString();
                        row.IsDefault = Convert.ToBoolean(reader["IsDefault"].ToString());
                    }
                    //close reader
                    reader.Close();

                }
                if(connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            if (count == 0) throw new Exception("SAP Database not defined");
            isHanavar = (SAPbobsCOM.BoDataServerTypes)Enum.Parse(typeof(SAPbobsCOM.BoDataServerTypes), row.DbServerType) == SAPbobsCOM.BoDataServerTypes.dst_HANADB;

            return (bool)isHanavar;
        }
        
        public static bool isHana(string DBName)
        {
            string dbserverType = "";
            string LicenseServer = "";
            SqlQuery sql = new SqlQuery();
            var count = 0;
            sql.From("SapDatabases").SelectMany("DBServerType", "ServerName", "LicenseServer", "CompanyDB", "DBUserName", "DBPassword", "UserName", "Password", "ODBCServer", "ServiceLayerURL", "ServiceLayerVersion", "DBDriver", "IsDefault");
            sql.Where($"CompanyDB= '{DBName}'");

            using (var connection = new SqlConnection(Startup.connectionString))
            {
                //open connection if not opened
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var reader = sql.ExecuteReader(connection))
                {

                    if (reader.Read())
                    {
                        count++;
                        dbserverType = reader["DBServerType"].ToString();
                        LicenseServer = reader["LicenseServer"].ToString();
                        Row.ServerName = reader["ServerName"].ToString();
                        Row.ODBCServer = reader["ODBCServer"].ToString();
                        Row.CompanyDb = reader["CompanyDB"].ToString();
                        Row.DbUserName = reader["DBUserName"].ToString();
                        Row.DbPassword = reader["DBPassword"].ToString();
                        Row.UserName = reader["UserName"].ToString();
                        Row.Password = reader["Password"].ToString();
                        Row.ServiceLayerUrl = reader["ServiceLayerURL"].ToString();
                        Row.ServiceLayerVersion = reader["ServiceLayerVersion"].ToString();
                        Row.DBDriver = reader["DBDriver"].ToString();
                        Row.IsDefault = Convert.ToBoolean(reader["IsDefault"].ToString());
                    
                    }
                    //close reader
                    reader.Close();

                }
                //close connection if not closed
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            if (count == 0) throw new Exception("SAP Database not defined " + DBName + " " + sql.ToString());
            return (SAPbobsCOM.BoDataServerTypes)Enum.Parse(typeof(SAPbobsCOM.BoDataServerTypes), dbserverType) == SAPbobsCOM.BoDataServerTypes.dst_HANADB;
        }
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] ISapDatabasesSaveHandler handler)
        {
            //todo: if db is connectable
            //todo: if sl is connectable
            //else throw exception 
            //if (!ConnecteionTest(request.Entity)) throw new Exception("Unable to connect");
            uow.OnCommit += () =>
            {
                if (request.Entity.CreateUDFs == 1)
                {
                    var udfresp = CreateRelatedTables(request.Entity);
                    request.Entity.UDFs = JsonConvert.SerializeObject(udfresp);
                }

            };

            request.Entity.DbPassword = AES.EncryptString(request.Entity.DbPassword);
            request.Entity.Password = AES.EncryptString(request.Entity.Password);
            return handler.Create(uow, request);
        }

        public UdfsResponse CreateRelatedTables(MyRow entity, UDType type = UDType.ALL)
        {
            var req = new UdfsRequest();
            var res = new UdfsResponse();
            try
            {

                var path = Path.Combine(Startup.basePath, @"App_Data\Schema\udfs.json");
                var text = System.IO.File.ReadAllText(path);

                res.UserFields = new System.Collections.Generic.List<UserFieldResponse>();
                res.UserObjects = new System.Collections.Generic.List<UserObjectResponse>();
                res.UserTables = new System.Collections.Generic.List<UserTableResponse>();

                try
                {
                    req = JsonConvert.DeserializeObject<UdfsRequest>(text);
                    if (type == UDType.ALL || type == UDType.UDT)
                        foreach (var row in req.UserTables)
                        {
                            try
                            {
                                ServiceLayerRestHandler serviceLayerRestHandler = ServiceLayerRestHandler.GetInstance(entity);

                                var added = false; String JOBJ;

                                added = serviceLayerRestHandler.AddToBO("UserTablesMD", JsonConvert.SerializeObject(row), out JOBJ);
                                var msg = "";
                                if (!added) { msg = JObject.Parse(JOBJ)?["error"]?["message"]?["value"]?.ToString(); }
                                res.UserTables.Add(new UserTableResponse { TableName = row.TableName, Created = added, Reason = msg });
                            }
                            catch (Exception ex) { ExceptionsController.Log(ex); }

                        }
                    if (type == UDType.ALL || type == UDType.UDF)
                        foreach (var row in req.UserFields)
                        {
                            try
                            {
                                ServiceLayerRestHandler serviceLayerRestHandler = ServiceLayerRestHandler.GetInstance(entity);

                                var added = false; string JOBJ;
                                added = serviceLayerRestHandler.AddToBO("UserFieldsMD", JsonConvert.SerializeObject(row), out JOBJ);
                                var msg = "";

                                if (!added) { msg = ((Newtonsoft.Json.Linq.JValue)(JObject.Parse(JOBJ)?["error"]?["message"])).Value.ToString(); }
                                //if (!added) { msg = JObject.Parse(JOBJ)?["error"]?["message"]?["value"]?.ToString(); }
                                res.UserFields.Add(new UserFieldResponse { Name = row.Name, TableName = row.TableName, Created = added, Reason = msg });
                            }
                            catch (Exception ex)
                            { ExceptionsController.Log(ex); }

                        }
                    if (type == UDType.ALL || type == UDType.UDO)
                        foreach (var row in req.UserObjects)
                        {
                            try
                            {
                                ServiceLayerRestHandler serviceLayerRestHandler = ServiceLayerRestHandler.GetInstance(entity);
                                var added = false; String JOBJ;
                                added = serviceLayerRestHandler.AddToBO("UserObjectsMD", JsonConvert.SerializeObject(row), out JOBJ);
                                var msg = "";
                                if (!added) { msg = JObject.Parse(JOBJ)?["error"]?["message"]?["value"]?.ToString(); }
                                res.UserObjects.Add(new UserObjectResponse { Code = row.Code, Created = added, Reason = msg });
                            }
                            catch (Exception ex) { ExceptionsController.Log(ex); }

                        }
                }
                catch (Exception ex) { ExceptionsController.Log(ex); }
            }
            catch (Exception ex) { ExceptionsController.Log(ex); }

            return res;
        }

        public bool ConnecteionTest(MyRow request)
        {
            bool dbconnected = false;
            using (var connection = DBHelper.GetDBConnection(request.ODBCServer, request.CompanyDb, request.DbUserName, request.DbPassword, request.DbServerType, request.DBDriver))
            {
                if (connection.State != ConnectionState.Open)
                {
                    throw new Exception("Unable to connect to database");
                }
                else
                {
                    connection.Close();
                    dbconnected = true;
                }
            }
            var slconnected = ServiceLayerRestHandler.LoginConnection(request.ServiceLayerUrl, request.ServiceLayerVersion, request.UserName,AES.DecryptString( request.Password), request.CompanyDb);
            if (!slconnected)
            {
                throw new Exception("Service Layer is not reachable");
            }
            return dbconnected & slconnected;
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] ISapDatabasesSaveHandler handler)
        {
            uow.OnCommit += () =>
            {
                if (request.Entity.CreateUDFs == 1)
                {
                    var udfresp = CreateRelatedTables(request.Entity);
                    request.Entity.UDFs = JsonConvert.SerializeObject(udfresp);
                }

            };
            if (!ConnecteionTest(request.Entity)) throw new Exception("Unable to connect");
            request.Entity.DbPassword = AES.EncryptString(request.Entity.DbPassword);
            request.Entity.Password = AES.EncryptString(request.Entity.Password);
            return handler.Update(uow, request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] ISapDatabasesDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] ISapDatabasesRetrieveHandler handler)
        {
            var ret = handler.Retrieve(connection, request);
            try { ret.Entity.Password = AES.DecryptString(ret.Entity.Password); } catch { }
            try { ret.Entity.DbPassword = AES.DecryptString(ret.Entity.DbPassword); } catch { }
            return ret;
        }
        //[HttpGet]
        //public bool isCompanyConnected()
        //{
        //    bool b = false;

        //    SAPbobsCOM.Company company = null;
        //    try
        //    {
        //        company = GetnewCompanyInstance();
        //        b = company.Connected;

        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Log();
        //    }
        //    finally
        //    {
        //        if (company != null)
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(company);
        //        GC.Collect();
        //    }
        //    return b;

        //}
        [HttpPost, IgnoreAntiforgeryToken]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] ISapDatabasesListHandler handler)
        {
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] ISapDatabasesListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.SapDatabasesColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "SapDatabasesList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        [HttpGet]
        public JsonResult SAPCOMPANYLIST()
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();

            SqlConnection conn = new SqlConnection(Startup.connectionString);
            conn.Open();
            string GetItems = string.Format("select CompanyDB from SapDatabases ");

            SqlDataReader sdr;

            using (SqlCommand cmd = new SqlCommand(GetItems, conn))
            {
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows == true)
                {
                    while (sdr.Read())
                    {


                        result.Add(sdr["CompanyDB"].ToString());
                    }
                }

            }


            conn.Close();

            //return Json(result, JsonRequestBehavior.AllowGet);
            return Json(result);

        }

        /// <summary>
        /// for display on top left user field
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost,IgnoreAntiforgeryToken]
        public JsonResult GetUserNameofDbName(object DB)
        {
            var username = "";
            string dbname;
            username = Context.User.Identity.Name;
            if (username != "admin") return Json(username);
            var usercontroller = new UsersController(this.Context);
            //dbname = usercontroller.getCompanyName(username);
            SqlConnection conn = new SqlConnection(Startup.connectionString);
            var DBName= DB;
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                string GetItems = string.Format("select UserName from SapDatabases where CompanyDb='{0}'", DBName);
                SqlDataReader sdr;
                var table = DBHelper.GetTableFromQuery(GetItems, connection);
                if (table.Rows.Count > 0)
                {
                    username = table.Rows[0][0].ToString();
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();

            }
            return Json(Context.User.Identity.Name + "-" + username);

        }
        


    }
    public class GETBoard_Response1 : ServiceResponse
    {
        public String CompanyDB;
    }
    //make enum of type UDType
    public enum UDType
    {
        UDF,
        UDT,
        UDO,
        ALL
    }
}