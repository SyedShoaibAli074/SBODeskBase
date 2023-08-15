using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Administration;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Administration.Repositories;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Extensions;
using Serenity.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using SAPWebPortal.Web.Helpers;
using B1SLayer;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Data;
using System.Data.SqlClient;
using SAPWebPortal.Default;

namespace SAPWebPortal.Membership.Pages
{
    [Route("Account/[action]")]
    public partial class AccountController : Controller
    {
        public ITwoLevelCache Cache { get; }
        public ITextLocalizer Localizer { get; }
        IHttpContextAccessor _httpContextAccessor;
        public AccountController(ITwoLevelCache cache, ITextLocalizer localizer)
        {
            if (cache != null)
            {
                Cache = cache ?? throw new ArgumentNullException(nameof(cache));
                Localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            }
        }
        public static bool UseAdminLTELoginBox = false;

        [HttpGet]
        public ActionResult Login(string activated)
        {
            ViewData["Activated"] = activated;
            ViewData["HideLeftNavigation"] = true;

            return View(MVC.Views.Membership.Account.AccountLogin);
        }

        [HttpGet]
        public ActionResult AccessDenied(string returnURL)
        {
            ViewData["HideLeftNavigation"] = !User.IsLoggedIn();

            return View(MVC.Views.Errors.AccessDenied, (object)returnURL);
        }

        [HttpPost, JsonRequest,IgnoreAntiforgeryToken]
        public Result<ServiceResponse> Login(LoginRequest request,
            [FromServices] IUserPasswordValidator passwordValidator,
            [FromServices] IUserRetrieveService userRetriever,
            [FromServices] IEmailSender emailSender = null)
        {
            return this.ExecuteMethod(() =>
            {
                string DBNAME = "";
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                if (string.IsNullOrEmpty(request.Username))
                    throw new ArgumentNullException("username");
               if (!string.IsNullOrEmpty( request.CompanyDatabase  ))
                {
                    SqlQuery sqlQuery = new SqlQuery();
                    sqlQuery.From("Sapdatabases").Select("CompanyDB").Where($"Id = {request.CompanyDatabase}");
                    using (var connection = new System.Data.SqlClient.SqlConnection(Startup.connectionString))
                    {
                       var reader =  sqlQuery.ExecuteReader(connection);
                        if(reader.Read())
                        {
                            DBNAME = reader["CompanyDB"].ToString();
                            passwordValidator = new UserPasswordValidator(reader["CompanyDB"].ToString());
                            reader.Close();
                        }
                    }


                }
                if (!string.IsNullOrEmpty(request.CompanyDatabaseName))
                {
                    passwordValidator = new UserPasswordValidator(request.CompanyDatabaseName);
                }
                if (passwordValidator is null)
                    throw new ArgumentNullException(nameof(passwordValidator));

                if (userRetriever is null)
                    throw new ArgumentNullException(nameof(userRetriever));

                var username = request.Username;
                var result = passwordValidator.Validate(ref username, request.Password);
                if (result == PasswordValidationResult.Valid)
                {
                    


                   

                        try
                        {
                            SqlQuery sqlQuery = new SqlQuery();
                            sqlQuery.From("Users").Select("Source").Where($"Username = '{username}'");
                            bool exists = false;
                            string source = "";
                            using (var connection = DBHelper.GetSerenDBConnection())
                            {
                                connection.Open();
                                var reader = sqlQuery.ExecuteReader(connection);
                                if (reader.Read())
                                {
                                    exists = true;
                                    source = reader["Source"].ToString();
                                    reader.Close();
                                }
                                connection.Close();
                            }
                            if (!exists)
                            {

                            //get user from sap
                            SqlConnection conn = new SqlConnection(Startup.connectionString);
                            var DBName = "";
                            if (!string.IsNullOrEmpty(request.CompanyDatabase))
                                DBName = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt64(request.CompanyDatabase)).FirstOrDefault().CompanyDb;
                            if (!string.IsNullOrEmpty(request.CompanyDatabaseName))
                                DBName = request.CompanyDatabaseName;
                            SqlInsert sql = new SqlInsert("Users");
                                {
                                    using (var sapconnection = DBHelper.GetDBConnection(DBName))
                                    {
                                        if (sapconnection.State != System.Data.ConnectionState.Open)
                                            sapconnection.Open();
                                        using (var command = sapconnection.CreateCommand())
                                        {
                                            command.CommandText = $"SELECT * FROM OUSR WHERE USER_CODE = '{username}'";
                                            using (var reader = command.ExecuteReader())
                                            {
                                                if (reader.Read())
                                                {
                                                    sql.SetTo("Username", $"'{username}'");
                                                    sql.SetTo("DisplayName", $"'{reader["U_Name"].ToString()}'");
                                                    if (!string.IsNullOrEmpty(reader["E_Mail"].ToString()))
                                                        sql.SetTo("Email", $"'{reader["E_Mail"].ToString()}'");
                                                    sql.SetTo("Source", "'SBO'");
                                                    sql.SetTo("IsActive", "1");
                                                    sql.SetTo("InsertDate", $"'{DateTime.Now.ToString("yyyyMMdd")}'");
                                                    sql.SetTo("InsertUserId", "1");
                                                    //todo: push real hash and salt as per the input
                                                    string PasswordSalt = null;
                                                    var PasswordHash = UserRepository.GenerateHash(request.Password, ref PasswordSalt);
                                                    sql.SetTo("PasswordHash", $"'{PasswordHash}'");
                                                    sql.SetTo("PasswordSalt", $"'{PasswordSalt}'");
                                                    reader.Close();
                                                }
                                            }
                                        }
                                        sapconnection.Close();
                                    }
                                }
                                using (var connection = DBHelper.GetSerenDBConnection())
                                {
                                    connection.Open();
                                    sql.Execute(connection);
                                    connection.Close();
                                }
                            }

                            if (exists)
                            {
                                string updatequery = $"Update Users Set CompanyDatabase = '{DBNAME}' Where Username = '{username}'";
                                using (var connection = DBHelper.GetSerenDBConnection())
                                {
                                    connection.Open();
                                    using (var command = connection.CreateCommand())
                                    {
                                        command.CommandText = updatequery;
                                        command.ExecuteNonQuery();
                                    }
                                    string sessionquery = $"Select * From Sessions Where UserName = '{username}' And Company = '{DBNAME}'";
                                    using (var command = connection.CreateCommand())
                                    {
                                        command.CommandText = sessionquery;
                                        using (var reader = command.ExecuteReader())
                                        {
                                            if (reader.Read())
                                            {
                                                reader.Close();

                                                var now = DateTime.Now;
                                                //sqlformat of datetime
                                                var sqlformat = now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                                                string updateSessionQuery = $"Update Sessions Set Password = '{AES.EncryptString(request.Password)}',DateTimeStamp ='{sqlformat}'   Where UserName = '{username}' And Company = '{DBNAME}'";
                                                using (var command1 = connection.CreateCommand())
                                                {
                                                    command1.CommandText = updateSessionQuery;
                                                    command1.ExecuteNonQuery();
                                                }
                                            }
                                            else
                                            {
                                                reader.Close();
                                                //convert date time to sql datetime string
                                                var now = DateTime.Now;
                                                var sqlFormattedDate = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                                SqlInsert sql = new SqlInsert("Sessions");
                                                sql.SetTo("SessionId", $"'{Guid.NewGuid().ToString()}'");
                                                sql.SetTo("UserName", $"'{username}'");
                                                sql.SetTo("DateTimeStamp", $"'{sqlFormattedDate}'");
                                                sql.SetTo("Password", $"'{AES.EncryptString(request.Password)}'");
                                                sql.SetTo("Company", $"'{DBNAME}'");

                                                sql.Execute(connection);
                                            }
                                        }
                                    }

                                    connection.Close();
                                }
                            }
                        try
                        {
                            if (HttpContext.Request.Cookies.ContainsKey("DBName"))
                            {
                                // Get the session cookie
                                HttpContext.Response.Cookies.Append("DBName", "", new CookieOptions()
                                {
                                    Expires = DateTime.Now.AddDays(-1)
                                });

                                HttpContext.Response.Cookies.Delete("CookieName", new CookieOptions()
                                {
                                    Secure = true,
                                });
                                string sessionId = HttpContext.Request.Cookies["DBName"];
                                var _DBName = HttpContext.Request.Cookies.Where(x => x.Key == "DBName").FirstOrDefault();
                                HttpContext.Response.Cookies.Append("DBName", DBNAME);
                                // Use the sessionId value to retrieve information about the user's session...
                            }
                            else
                            {
                                // Generate a new session cookie
                               HttpContext.Response.Cookies.Append("DBName", DBNAME);

                                // Use the sessionId value to create a new session for the user...
                            }
                        }
                        catch (Exception ex)
                        {

                            //throw;
                        }

                       
                        //_ = SessionManagement(username, request.Password, DBNAME);
                        }
                        catch (Exception Ex)
                        {
                            ExceptionsController.Log(Ex);
                            throw new Exception($"UserName '{username}' might not be present in portal. Please create the same users in portal as those in SAP");

                        }

                    var principal = UserRetrieveService.CreatePrincipal(userRetriever, username, authType: "Password");
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal)
                        .GetAwaiter().GetResult();


                    return new ServiceResponse();
                }

                throw new ValidationError("AuthenticationError", Texts.Validation.AuthenticationError.ToString(Localizer));
            });
        }


        [HttpGet, IgnoreAntiforgeryToken]
        public System.Collections.Generic.List<String> GetDatabases()
        {
            System.Collections.Generic.List<String> list = new System.Collections.Generic.List<String>();
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                var query = "select CompanyDb from sapdatabases ";
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader["CompanyDb"].ToString());
                        }
                    }
                } 
            }
            return list;
        } 
        [HttpPost, IgnoreAntiforgeryToken, JsonRequest]
        public JsonResult GetDbName(object request)
        {
            var username = "";
            string dbname;


            var DBName = request;
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                string GetItems = string.Format("select CompanyDb from SapDatabases where Id='{0}'", DBName);
                SqlDataReader sdr;
                var table = DBHelper.GetTableFromQuery(GetItems, connection);
                if (table.Rows.Count > 0)
                {
                    username = table.Rows[0][0].ToString();
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();

            }
            return Json(username);

        }
        public async Task SessionManagement(string Username,string password,string dbname)
        {
            await Task.Run(() =>
            {
                var controllers = AppDomain.CurrentDomain.GetAssemblies()
                   .SelectMany(s => s.GetTypes())
                   .Where(p => typeof(IDataDictionary).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract).ToList();
                Parallel.ForEach(controllers, (v) => {

                    //parallel foreach loop
                         try
                        {
                         var controller = (IDataDictionary)Activator.CreateInstance(v, new object[] { null, null });

                        controller.FillDataDictionary(Username,  password ,  dbname);
                        }
                        catch (Exception ex)
                        {
                            ExceptionsController.Log(ex);
                        }
                 });
             });  
        }
        //todo:call this function on every 3 min like heartbeat
        [HttpPost,IgnoreAntiforgeryToken]
        public async Task SessionManagement()
        {
             await Task.Run(() =>
            {
                //get all rows from Sessions table    
                string sessionquery = $"Select UserName,Company,Password From Sessions where UserName <> 'admin'";
               System.Collections.Generic. List<(string username,string company ,string password)> keys = new System.Collections.Generic.List<(string username,string company, string password)>();
                using (var connection = DBHelper.GetSerenDBConnection())
                {
                    if(connection.State != System.Data.ConnectionState.Open)
                         connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = sessionquery;
                        using (var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                keys.Add((reader["UserName"].ToString() , reader["Company"].ToString(), reader["Password"].ToString()));
                            }
                            reader.Close();
                        }
                    }
                    //if connection is not close
                    if(connection.State != System.Data.ConnectionState.Closed) 
                        connection.Close();
                }
                //get name of all controllers having interface IDataDictionary USE reflection

                var controllers = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => typeof(IDataDictionary).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract).ToList();
                
            
            //parallel loop through all controllers
            //call filldata dictionary for each controller
            Parallel.ForEach(controllers, (v)    =>{

                //parallel foreach loop
                Parallel.ForEach(keys, (k) =>
                {
                    try
                    {
                        var controller = (IDataDictionary)Activator.CreateInstance(v, new object[] { null, null });
                        controller.FillDataDictionary(k.username, AES.DecryptString(k.password), k.company);
                    }
                    catch (Exception ex)
                    {
                        ExceptionsController.Log(ex);
                    }
                });
            });


        });
        }
        private ActionResult Error(string message)
        {
            return View(MVC.Views.Errors.ValidationError, message);
        }

        public ActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return new RedirectResult("~/");
        }
        public class UserPasswordValidator : IUserPasswordValidator
        {
            string DBName;
            public UserPasswordValidator(string DBName)
            {
                this.DBName = DBName;

            }
            public static bool ValidatedThroughSL { get; private set; }
            public PasswordValidationResult Validate(ref string username, string password)
            {
                PasswordValidationResult result = PasswordValidationResult.Invalid;
                ValidatedThroughSL = false;
                SapDatabasesController.isHana(this.DBName);
                var row = SapDatabasesController.SAPRow(this.DBName);
                //todo:call service layer
                var url = row.ServiceLayerUrl;
                if(!url.EndsWith("/"))
                {
                    url += "/";
                }
                
                SLConnection sLConnection = new SLConnection(url+"b1s/"+row.ServiceLayerVersion, this.DBName, username, password);
                var res = sLConnection.LoginAsync().Result;
                if(!string.IsNullOrEmpty(res.SessionId))
                {
                    ValidatedThroughSL = true;
                   // result = PasswordValidationResult.Valid;
                }
                 //ValidatedThroughSL = ServiceLayerRestHandler.SLUserLogin(row.ServiceLayerUrl, row.ServiceLayerVersion, username, password, this.DBName);
                if (ValidatedThroughSL) 
                    result = PasswordValidationResult.Valid;
                return result;
            }
        }
       
    }
}