using SAPWebPortal.Web.Modules.Common.Helpers;
using Newtonsoft.Json.Linq;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Membership;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using SAPWebPortal.Administration.Endpoints;
using System.Xml.Linq;
using SAPWebPortal.Default;
using SAPbouiCOM;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using B1SLayer;
using static Dapper.SqlMapper;
using AspNetCoreHero.ToastNotification.Helpers;
using Newtonsoft.Json;
using TestProject.TestBase;
using System.Reflection;
using SAPB1;
using SAPWebPortal.Web.Helpers;
using Serenity.Data.Schema;

namespace SAPWebPortal.Web.Modules.Common.Helpers
{
    public class ServiceLayerRestHandler: ServiceLayerHelper
    {
        string UserName = "";
        string Password = "";
        string DBName = "";
        public ServiceLayerRestHandler(string Username, string Passwrod, string DBName, string URL) : base(Username, Passwrod, DBName, URL)
        {

            this.UserName = Username;
            this.Password = Passwrod;
            this.DBName = DBName;
            if (context == null)
            {
                context = new TestContext_Testing(Username);
            }
        }
        
        //SAPB1.JournalEntry je;
        //void func()
        //{
        //    je.JournalEntryLines.Add(new SAPB1.JournalEntryLine());
        //    je.JournalEntryLines[0].BPLID= "123";
        //}
        string session_id = "";
        string NodeId = ""; 
        static IRequestContext context;
        static SapDatabasesRow Entity;
        public static Dictionary<string, (string session, string company,string NodeId)> _SessionDictionary;
        public static Dictionary<string, (string session, string company, string NodeId)> SessionDictionary
        {
            get
            {
                
                #region Get Service Layer Session From DB
                if (_SessionDictionary == null)
                {
                    _SessionDictionary = new Dictionary<string,(string session,string company, string NodeId)>();
                    SqlQuery sqlQuery = new SqlQuery();
                    sqlQuery.From("Sessions").SelectMany("SessionId","UserName","Company","NodeId");
                    using (var connection = DBHelper.GetSerenDBConnection())
                    {
                        connection.Open();
                        var reader = sqlQuery.ExecuteReader(connection);
                        while (reader.Read())
                        {
                            var SessionId = reader["SessionId"]?.ToString().Replace("'", "");
                            var UserName = reader["UserName"]?.ToString().Replace("'", ""); 
                            var CompanyName = reader["Company"]?.ToString().Replace("'", "");
                            var NodeId = reader["NodeId"]?.ToString().Replace("'", "");
                            if (!_SessionDictionary.ContainsKey(reader["UserName"].ToString()))
                                _SessionDictionary.Add(UserName, (SessionId,CompanyName, NodeId));
                        }
                        connection.Close();
                    }
                }
                return _SessionDictionary;
                #endregion
            }
        }
        #region Service Layer Instance
        public static ServiceLayerRestHandler GetInstance(IRequestContext context,string DBName="")
        {
            var _DBName = "";
            try
            {
                 _DBName = DBName;

            }
            catch (Exception ex)
            {
                Sentry.SentrySdk.CaptureException(ex);
            }
            var row = SapDatabasesController.SAPRow(DBName);
            var url = row.ServiceLayerUrl;
            if (!url.EndsWith("/"))
            {
                url += "/";
            }
            url = url + "b1s/" + row.ServiceLayerVersion + "/";
            ServiceLayerRestHandler.context = context;
              var Password = GetPass(context.User.Identity.Name,_DBName);
            var Company = _DBName;
            ServiceLayerRestHandler handler = new ServiceLayerRestHandler(Password.Item1,
               Password.Item2,
                Company, url
                );
          
            return handler;
        }
        public static ServiceLayerRestHandler GetInstance(string username,string password, string companydb)
        {
            var row = SapDatabasesController.SAPRow(companydb);
            var url = row.ServiceLayerUrl;
            if (!url.EndsWith("/"))
            {
                url += "/";
            }
            url = url + "b1s/" + row.ServiceLayerVersion + "/";
           
            ServiceLayerRestHandler handler = new ServiceLayerRestHandler(username,
               password,
                companydb, url
                );
            //todo: if the user is sbo user
            //todo: if the user is serenity user
            return handler;

        }
        private static (string,string) GetPass(string name,string DBName)
        {
            (string, string) usercred;
            if (name == "admin")
            {
                var connection = DBHelper.GetSerenDBConnection();
                var _pass=connection.List<SapDatabasesRow>().Where(x => x.CompanyDb == DBName).FirstOrDefault();
                if (_pass != null)
                {
                    var password = AES.DecryptString(_pass.Password);
                    usercred = (_pass.UserName, password);

                }
                else
                {
                    usercred = (name, "");

                }

            }
            else
            {
                using (var connection = DBHelper.GetSerenDBConnection())
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();
                    string updatequery = $"Select Password from  Sessions Where UserName = '{name}'";
                    //command of sql 
                    var tble = DBHelper.GetTableFromQuery(updatequery, connection);
                    var password = AES.DecryptString(tble.Rows[0][0].ToString());
                    usercred = (name, password);

                    connection.Close();
                }

            }

            return usercred;
        }
        private static string GetCompany(string name)
        {
            string password = "";
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                if(connection.State != System.Data.ConnectionState.Open)
                connection.Open();
                string updatequery = $"Select CompanyDatabase from  users Where UserName = '{name}'";
                //command of sql 
                var tble = DBHelper.GetTableFromQuery(updatequery, connection);

                password = tble.Rows[0][0].ToString();
                connection.Close();
            }

            return password;
        }
        internal static ServiceLayerRestHandler GetInstance(SapDatabasesRow entity)
        {
            var row = SapDatabasesController.SAPRow(entity.CompanyDb);
            var url = entity.ServiceLayerUrl;
            if (!url.EndsWith("/"))
            {
                url += "/";
            }
            url = url + "b1s/" + entity.ServiceLayerVersion + "/";
            ServiceLayerRestHandler handler = new ServiceLayerRestHandler(entity.UserName, AES.EncryptString(entity.Password).Trim(), entity.CompanyDb, url);
            Entity = entity;
            
            return handler;
        }
        #endregion
        #region Login Functions

        #region Login If Session Expired
        private bool Login(string CompanyUserName, string CompanyPassword, string CompanyDb)
        {
            bool Login = false;
            try
            {
                
                var row = SapDatabasesController.SAPRow(CompanyDb);
                var url = row.ServiceLayerUrl + "b1s/" + row.ServiceLayerVersion + "/" + "Login";
                var jdata = new JObject();
                jdata["CompanyDB"] = CompanyDb;
                jdata["UserName"] = CompanyUserName;
                jdata["Password"] = AES.DecryptString(CompanyPassword);
                var data = jdata.ToString();
                var datum = new StringContent(data, Encoding.UTF8, "application/json");
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                };
                HttpClient httpclient = new System.Net.Http.HttpClient(httpClientHandler);
                var result = httpclient.PostAsync(url, datum).Result;
                var message = result.Content.ReadAsStringAsync().Result;
                var resp = JObject.Parse(message);
                var cookies = httpClientHandler.CookieContainer.GetCookies(new Uri(url));
                foreach (System.Net.Cookie Cooki in cookies)
                {
                    if (Cooki.Name == "ROUTEID")
                    {
                        NodeId = Cooki.Value;
                    }
                }
                if (resp.ContainsKey("SessionId"))
                {
                    session_id = resp["SessionId"].ToString();
                    Login = !string.IsNullOrEmpty(session_id);
                }
            }
            catch(Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            
            return Login;
        }

        #endregion
        #region Check Is Service Layer Available Or Not
        public static bool LoginConnection(string ServiceLayerURL, string ServiceLayerVersion, string CompanyUserName, string CompanyPassword, string companydb)
        {
            var url = ServiceLayerURL;
            if (!url.EndsWith("/"))
            {
                url += "/";
            }
            url = url + "b1s/" + ServiceLayerVersion + "/";
            var servicelayerrequsthandler = new ServiceLayerHelper(CompanyUserName, CompanyPassword, companydb, url);
            var Login = !String.IsNullOrEmpty(servicelayerrequsthandler.Connection.LoginAsync().Result.SessionId);
            return Login;
        }
        #endregion
        #region  User Login Page Through Service Layer
        public static bool SLUserLogin(string ServiceLayerURL, string ServiceLayerVersion, string CompanyUserName, string CompanyPassword, string CompanyDB)
        {
            bool Login = false;
            var session_id = "";
            var Node_Id = "";
            if (!ServiceLayerURL.EndsWith("/")) ServiceLayerURL += "/";
            var url = ServiceLayerURL + "b1s/" + ServiceLayerVersion + "/";
            var jdata = new JObject();
            var helper = new ServiceLayerHelper(CompanyUserName, CompanyPassword, CompanyDB,url);
            var result = helper.Connection.LoginAsync().Result;
            Login = !string.IsNullOrEmpty(result.SessionId);

            //jdata["CompanyDB"] = CompanyDB;
            //jdata["UserName"] = CompanyUserName;
            //jdata["Password"] = CompanyPassword;
            //url = url  +"Login"; 
            //Company =CompanyDB;
            //var data = jdata.ToString();
            //var datum = new StringContent(data, Encoding.UTF8, "application/json");
            //HttpClientHandler httpClientHandler = new HttpClientHandler();
            //httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            //{
            //    return true;
            //};
            //HttpClient httpclient = new System.Net.Http.HttpClient(httpClientHandler);
            //var result = httpclient.PostAsync(url, datum).Result;
            //var message = result.Content.ReadAsStringAsync().Result;
            //var resp = JObject.Parse(message); 
            //var cookies = httpClientHandler.CookieContainer.GetCookies(new Uri(url));
            //try{
            //    foreach(System.Net.Cookie Cooki in cookies)
            //    {
            //        if (Cooki.Name == "ROUTEID")
            //        {
            //            Node_Id = Cooki.Value;
            //        }
            //    }
            //    if (resp.ContainsKey("SessionId"))
            //    {
            //        session_id = resp["SessionId"]?.ToString();
            //        Login = !string.IsNullOrEmpty(session_id);
            //    }
            //}catch(Exception ex)
            //{

            //    Sentry.SentrySdk.CaptureException(ex);
            //    Sentry.SentrySdk.CaptureMessage(message);
            //    Sentry.SentrySdk.CaptureMessage(url);
            //    Sentry.SentrySdk.CaptureMessage(datum.ToString());
            //}
            #region If Login Save New Session And Delete Previous 
            if (Login)
            {
                using (var connection = DBHelper.GetSerenDBConnection())
                {
                    //if connection is not open
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                    } 
                    SqlDelete deletesql = new SqlDelete("Sessions");
                    deletesql.Where($"UserName ='{CompanyUserName}'")
                        .Execute(connection, ExpectedRows.Ignore);
                    SqlInsert insert = new SqlInsert("Sessions");
                    insert.SetTo("UserName", $"'{CompanyUserName}'");
                    insert.SetTo("Password", $"{AES.EncryptString(CompanyPassword).Trim()}");
                    insert.SetTo("Company", $"'{CompanyDB}'");
                    insert.SetTo("SessionId", $"'{session_id}'");
                    insert.SetTo("NodeId", $"'{Node_Id}'");
                    insert.SetTo("DateTimeStamp", $"'{ DateTime.Now}'");
                    insert.Execute(connection);

                    //update user table with company
                    
                        SqlUpdate update = new SqlUpdate("Users");
                        update.SetTo("CompanyDatabase", $"'{CompanyDB}'");
                    try
                    {
                        update.Where($"Username ='{CompanyUserName}'")
                                 .Execute(connection);
                    }
                    catch { }
//if connection is not closed
                    if (connection.State != System.Data.ConnectionState.Closed) 
                        connection.Close();

                    ExceptionsController.Log(new Exception("New Login & Save Session -- " + insert.ToString()));
                }
                if (SessionDictionary.Keys.Contains(CompanyUserName))
                {
                    SessionDictionary[CompanyUserName] = (session_id, CompanyDB, Node_Id);
                }
                else
                {
                    SessionDictionary.Add(CompanyUserName, (session_id, CompanyDB, Node_Id));
                }
            }
            #endregion
            return Login;
        }

        #endregion

        #endregion
        #region DraftsService_SaveDraftToDocument
        public bool DraftsService_SaveDraftToDocument(int DocEntry ,out string response)
        {
            JObject jobject = new JObject();
            JObject Document = new JObject();
            Document.Add("DocEntry", DocEntry);
            jobject.Add("Document", Document);
            var b = AddToBO("DraftsService_SaveDraftToDocument", jobject.ToString(), out   response);
            try
            {
                var responseobject = JObject.Parse(response);
                if (responseobject["error"]["code"].ToString() == "-10" && responseobject["error"]["message"].ToString().Contains ("This document was already updated after it was approved"))
                    b = true;
            }catch (Exception ex)
            {
                Sentry.SentrySdk.CaptureException(ex);
            }
            return b;
        }
        #endregion
        #region Add Business Objects
        public bool AddToBO<T>(String BOName, String Payload, out string response)
        {
            var b = true;
            try
            {
                //deserialize Payload to T
                var obj = JsonConvert.DeserializeObject<T>(Payload);
                //var jobj = this.Connection.Request(BOName).PostStringAsync(Payload);
                var jobj = this.Connection.Request(BOName).PostAsync<T>(obj);
                response  = JsonConvert.SerializeObject(jobj.Result);
            }catch(Exception ex)
            { //if ex.message = "One or more errors occurred. (No matching records found (ODBC -2028))"
                //then return true
                ex.Log(Payload);
                if (ex.Message.Contains("No matching records found (ODBC -2028)")|| ex.Message.Contains("One or more errors occurred. (Input string was not in a correct format.)"))
                {
                    response = "-2028";
                    b = true;
                }
                else
                {
                    response = ex.Message;

                    b = false;
                    throw;
                }

            }
            return b;
        }
        public bool AddToBO(String BOName, String Payload, out string response)
        {
            var b = true;
            try
            {
                var jobj = this.Connection.Request(BOName).PostStringAsync(Payload);
                jobj.Wait();

                response = jobj.ToString();
            }
            catch (Exception ex)
            {
                b = false;
                throw;
            }
            return b;
        }
       
        #endregion
        #region Update Business Objects
        public bool UpdateBO(String BOName, object Key, string Payload, out string response, bool ReplaceCollectionsOnPatch = true)
        {
            var b = true;
            response = "";
            try
            {
                var req = this.Connection.Request(BOName, Key);
                if (ReplaceCollectionsOnPatch)
                    req = req.WithReplaceCollectionsOnPatch();
                req.PatchStringAsync(Payload).Wait();
               
            }catch(Exception ex)
            {
                b = false;
                response = ex.Message;
                throw ;
            }
            return b;
        }
        public bool UpdateProductionOrder(string Key, string payloadproduction, out string response)
        {
            var b = UpdateBO("ProductionOrders", Key, payloadproduction, out response, true);
            return b;
        }
        #endregion
        #region Delete Business Objects
        public bool DeleteBO(string moduleName, string keyvalue, out string response)
        {
            response = "";
            var b = true;
            try
            {
                this.Connection.Request(moduleName, keyvalue).DeleteAsync().Wait();
            }catch(Exception ex)
            {
                b = false;
                response = ex.Message;
                throw;
                
            }
            return b;
        }
        #endregion
        #region Service Layer List
        public bool GetSLEntity<T>(string moduleName, object keyvalue, out string resp)
        {
            //Debug.WriteLine($"moduleName:{moduleName}, keyvalue: {keyvalue}");
            var b = true;
            resp = "";
            try
            {
                var jobject = this.Connection.Request(moduleName, keyvalue).GetAsync<T>().Result;
                // jobject.Result to json 
                resp = JsonConvert.SerializeObject(jobject); 
            }
            catch(Exception ex)
            {
                b = false;
                throw;
            }
            return b;
        }

        public bool GetSLList<T>(string moduleName, ListRequest request, out string resp, out long TotalCount, System.Collections.Generic.HashSet<string> selected, string containstext, System.Collections.Generic.List<string> QuicksearchFeildsName, string criteriastring = "", string CompanyDB = "",string UserName = "")
        {
            var take = request.Take;
            var skip = request.Skip;
            var sortby = request.Sort;
            TotalCount = 0;
            string criteria = "";
            string where = "";
            bool b = false;
            string resp1 = "";
            long Records = 0;
            DBName = CompanyDB;
            //Debug.WriteLine($"moduleName:{moduleName}, criteria: {criteria}");
            if (request.DataSourceType == DataSourceType.SAPServiceLayer)
            {
                if (take > 0)
                    criteria += $"&$top={take}";
                if (skip > 0)
                    criteria += $"&$skip={skip}";
                if (sortby?.Length > 0)
                {
                    criteria += $"&$orderby=";
                    bool bf = true;
                    foreach (var item in sortby)
                    {
                        bf = false;
                        criteria += (bf ? "," : "") + item.Field.ToString() + " " + (item.Descending ? "desc" : "asc");
                    }

                }
                if (criteria.Length > 0)
                {
                    criteria = criteria.Substring(1);
                    criteria = "?" + criteria;
                }

                if (selected?.Count > 0)
                {
                    criteria += $"&$select=";
                    bool bf = false;
                    foreach (var item in selected)
                    {
                        if (item != "RowNum" && item != "inline-actions" && item != "row-selection" && item != "__select__")
                        {
                            criteria += (bf ? "," : "") + item;
                            bf = true;
                        }
                    }
                    if (!string.IsNullOrEmpty(containstext))
                    {
                        if (criteria.Length > 0)
                        {
                            System.Collections.Generic.List<string> conditions = new System.Collections.Generic.List<string>();
                            System.Collections.Generic.List<string> sqlconditions = new System.Collections.Generic.List<string>();
                            foreach (var list in QuicksearchFeildsName)
                            {
                                if (list != "RowNum" && list != "inline-actions" && list != "row-selection" && list != "__select__")
                                {
                                    conditions.Add("contains(" + list.ToString() + ",'" + containstext.ToLower() + "')");
                                    conditions.Add("contains(" + list.ToString() + ",'" + containstext.ToUpper() + "')");
                                    //sqlconditions.Add(@$"""{list.ToString()}"" like  '%{containstext}%' ");

                                }
                            }
                            //if criteria contains the word filter
                            if (criteria.Contains("filter"))
                            {
                                criteria += " and ";
                            }
                            else
                            {
                                criteria += $"&$filter=";
                            }

                            criteria += "(" + string.Join(" or ", conditions) + ")";
                            //if (!string.IsNullOrEmpty(whereclause)) whereclause += " and ";
                            //whereclause += " (" + string.Join(" or ", sqlconditions) + ")";
                        }
                    }
                   
                }
                if (moduleName == "BusinessPartners")
                {

                    criteria += $"&$filter=  Valid eq 'tYES'";
                    //whereclause = @"""CardType""='C' and ""validFor""='Y'";
                } 
                else if (moduleName == "Quotations" || moduleName == "Orders" || moduleName == "Invoices" || moduleName == "DeliveryNotes" || moduleName == "PurchaseOrders" || moduleName == "PurchaseInvoices" || moduleName == "PurchaseDeliveryNotes" || moduleName == "PurchaseReturns" || moduleName == "Returns" || moduleName == "Drafts")
                {
                    //service layer filter open orders
                    if (criteria.Contains("filter"))
                    {
                        criteria += " and ";
                    }
                    else
                    {
                        criteria += $"&$filter=";
                    }
                    criteria += $" DocumentStatus eq 'O'";


                }
                else if (moduleName == "IncomingPayments")
                {

                }
                else if (moduleName == "Quotations" || moduleName == "BusinessPartners" || moduleName == "Orders" || moduleName == "Invoices" || moduleName == "DeliveryNotes" || moduleName == "PurchaseOrders" || moduleName == "PurchaseInvoices" || moduleName == "PurchaseDeliveryNotes" || moduleName == "PurchaseReturns" || moduleName == "Returns" || moduleName == "Drafts" || moduleName == "IncomingPayments")
                {
                    var username = "";
                    if (context != null)
                    {
                        username = context?.User?.Identity?.Name;
                    }

                    if (Entity != null && username != "admin")
                    {
                        username = Entity.UserName;
                    }

                    //query to get values from table where
                    //todo: implement authorization filter
                    string CompanyName = "";
                    if (context != null)
                    {
                        var userController = new UsersController(context);
                        CompanyName = CompanyDB;
                    }
                    if (!string.IsNullOrEmpty(this.DBName))
                    {
                        CompanyName = this.DBName;
                    }
                    if (!string.IsNullOrEmpty(this.UserName))
                    {
                        username = this.UserName;
                    }

                    if (!string.IsNullOrEmpty(CompanyName))
                    {
                        //todo: if context is nul then fake the context with username   
                        if (context == null)
                        {
                            context = new TestContext_Testing(username);
                        }
                        UserDetail1Controller userDetail1Controller = new UserDetail1Controller(context, CompanyName);
                        System.Collections.Generic.List<string> cardcodes = userDetail1Controller.GetCustomersRelatedToUser(username,CompanyDB);
                        System.Collections.Generic.List<string> commands = new System.Collections.Generic.List<string>();
                        System.Collections.Generic.List<string> commandsSQL = new System.Collections.Generic.List<string>();

                        foreach (var cardcode in cardcodes)
                        {
                            commands.Add("CardCode eq '" + cardcode + "'");
                            commandsSQL.Add($@"""CardCode"" = '{cardcode}'");
                        }
                        var command = string.Join(" or ", commands); 

                        if (!string.IsNullOrEmpty(command))
                        {
                            command = " and (" + command + ")";
                        }
                        criteria += command;
                    }
                }
                if (!string.IsNullOrEmpty(criteriastring))
                {
                    //if criteria is not null
                    if (!string.IsNullOrEmpty(criteria))
                    {
                        criteria += " and " + criteriastring;
                    }
                    else
                    {
                        criteria += "?$filter=" + criteriastring;
                    }
                }


                var row = SapDatabasesController.SAPRow(DBName);
                var url = row.ServiceLayerUrl + "b1s/" + row.ServiceLayerVersion + "/" + $"{moduleName}{criteria}";
                var urlcount = row.ServiceLayerUrl + "b1s/" + row.ServiceLayerVersion + $"/{moduleName}/$count{criteria}";
                // print url in log file


                string Method = "GET"; 
                string resp2 = "";
                // get strng after "filter=" from criteria
                var filter = "";

                var somevar = this.Connection.Request(moduleName);
                if (criteria.Contains("filter="))
                {
                    filter = criteria.Split("filter=")[1];
                    somevar = somevar.Filter(filter);
                }

                Records = somevar.GetCountAsync().Result;
                b = true;// CallHTTPCLIENT_API(url, criteria, Method, out resp1);
                try
                {
                  filter = criteria;
                    var requ = this.Connection.Request(moduleName) ;
                    if (filter.Contains("filter="))
                    {
                        filter = filter.Split("filter=")[1];
                        requ = requ.Filter(filter);
                    }
                    var obje_respons = requ.GetAllAsync<T>().Result;
                    //serialize object
                    resp1 = Newtonsoft.Json.JsonConvert.SerializeObject(obje_respons);
                }
                catch (Exception ex)
                {
                    Sentry.SentrySdk.CaptureException(ex);
                }
            }
            else// for sql 
            {
                string whereclause = "";
                var username = UserName;
                if (string.IsNullOrEmpty(username))
                {
                    if (context != null)
                    {
                        username = context?.User?.Identity?.Name;
                    }

                    if (Entity != null && username != "admin")
                    {
                        username = Entity.UserName;
                    }
                    if (context != null)
                    {
                        username = context.User?.Identity.Name ?? this.UserName;
                    }
                    if (Entity != null && username != "admin")
                    {
                        username = Entity.UserName;
                    }
                }
                where = "where ";
                string CompanyName = CompanyDB;
                

                var tablename = GetTableName(moduleName);
                //if CardCode field exists in table in database 
                bool exists = DBHelper.ColumnExistsInTable(tablename, "CardCode",CompanyName);
                 
                if (exists&& tablename.ToLower() != "oitm") 
                {
                    if (context == null)
                    {
                        context = new TestContext_Testing(username);
                    }
                    UserDetail1Controller userDetail1Controller = new UserDetail1Controller(context, CompanyName,username);
                    System.Collections.Generic.List<string> cardcodes = userDetail1Controller.GetCustomersRelatedToUser(username, CompanyDB);
                    System.Collections.Generic.List<string> commandsSQL = new System.Collections.Generic.List<string>();

                    foreach (var cardcode in cardcodes)
                    {
                        commandsSQL.Add($@"""CardCode"" = '{cardcode}'");
                    }
                    if (commandsSQL.Count > 0)
                        whereclause += $@" and ({string.Join(" or ", commandsSQL)})";
                    //CardType field exists in T
                    
                }
                // IF DocStatus field exists in T
                if (DBHelper.ColumnExistsInTable(tablename, "DocStatus", CompanyName)  )
                { 
                    whereclause += $@" and ""DocStatus"" = 'O'";
                }
                // IF validFor field exists in T
                if (DBHelper.ColumnExistsInTable(tablename, "validFor", CompanyName)) 
                {
                    whereclause += $@" and ""validFor"" = 'Y'";
                }
                //Canceled field exists in T
                if (DBHelper.ColumnExistsInTable(tablename, "CANCELED", CompanyName)) 
                {
                    whereclause += $@" and ""CANCELED"" = 'N'";
                }
                
               
               

                    //query to get values from table where
                    //todo: implement authorization filter
                     
                    //if (!string.IsNullOrEmpty(containstext))
                    //{

                    //    System.Collections.Generic.List<string> conditions = new System.Collections.Generic.List<string>();
                    //    System.Collections.Generic.List<string> sqlconditions = new System.Collections.Generic.List<string>();
                    //    //if (QuicksearchFeildsName != null)
                    //    //    foreach (var list in QuicksearchFeildsName)
                    //    //    {
                    //    //        if (list != "RowNum" && list != "inline-actions" && list != "row-selection" && list != "__select__")
                    //    //        {
                    //    //            sqlconditions.Add(@$"""{list.ToString()}"" like  '%{containstext}%' ");

                    //    //        }
                    //    //    }
                    //    //if criteria contains the word filter
                    //    if (sqlconditions.Count > 0)
                    //    {
                    //        if (!string.IsNullOrEmpty(whereclause)) whereclause += " and ";
                    //        whereclause += " (" + string.Join(" or ", sqlconditions) + ")";
                    //    }
                    //}
                    if (!whereclause.Trim().StartsWith("and") && !string.IsNullOrEmpty(whereclause))
                        whereclause = " and " + whereclause;
                    //if (request.EqualityFilter != null)
                    //{
                    //    foreach (var item in request.EqualityFilter)
                    //    {
                    //        //if (!whereclause.Trim().StartsWith("and") && !string.IsNullOrEmpty(whereclause))
                    //        //    whereclause = " and " + whereclause;

                    //        whereclause += $@" and (""{item.Key}"" = '{item.Value}' or '{item.Value}' = '') ";
                    //    }
                    //}
                //remove and from start of whereclause
                if (whereclause.Trim().StartsWith("and"))
                    whereclause = whereclause.Trim().Substring(3);
                if (!String.IsNullOrEmpty(whereclause)) {              
                    whereclause = where + whereclause;
                }
                var countquery = $"select count(*) from {tablename} {whereclause}";

                    using (var connection = DBHelper.GetDBConnection(CompanyName))
                    {
                        if (connection.State != System.Data.ConnectionState.Open)
                            connection.Open();
                        var count = DBHelper.GetTableFromQuery(countquery, CompanyName);
                        Records = Convert.ToInt32(count.Rows[0][0]);
                        connection.Close();
                    } 

                
               

                b = CallHTTPCLIENT_SQL<T>(moduleName, whereclause, take, skip, out resp1);

            } 
           
            // service layer module for quotation 
            TotalCount = Records;
            resp = resp1;
            return b;
        }

        public bool CallHTTPCLIENT_SQL<T>(string moduleName, string criteria,int take , int Skip, out string resp1)
        {
            var b = false;
            resp1 = "";
            var TableName = GetTableName(moduleName);
            var primarykey = PrimerykeyName(moduleName);
            //if primarykey is null then throw error with message that "SAPPrimaryKeyAttribute is not defined on any field in the modulename class
            if (string.IsNullOrEmpty(primarykey))
            {
                throw new Exception($"SAPPrimaryKeyAttribute is not defined on any field in the {moduleName}");
            }
            var columns  = "";
            //get models having an attribute of [ServiceLayer("ModuleName")]
            var models = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttributes(typeof(ServiceLayerAttribute), false).Length > 0).ToList();
            var model = models.Where(x => x.GetCustomAttribute<ServiceLayerAttribute>().ModuleName == moduleName).FirstOrDefault();
            //Debug.WriteLine(model.ToString());
            if (model != null)
            {
                var props = model.GetProperties();
                foreach (var prop in props)
                {
                    var attr = prop.GetCustomAttribute<SAPDBFieldNameAttribute>();
                    if (attr != null)
                    {
                        columns+= $@"""{attr.ColumnName}"" ""{prop.Name}"",";
                        //columns += attr.ColumnName + " " + prop.Name +",";
                    }
                }
                columns = columns.TrimEnd(',');
            }
            if(string.IsNullOrEmpty(columns))
            {
                throw new Exception("Columns not found. ");
            }
            if(criteria.Contains("and  ()"))
            {
                criteria = criteria.Replace("and  ()", "");
            }
            var query = $"select {columns} from {TableName} {criteria}";
            Sentry.SentrySdk.CaptureMessage(query);

            using(var connection = DBHelper.GetDBConnection(DBName))
            {
                if(connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
               using( var table = DBHelper.GetTableFromQuery(query,connection,primarykey)){
               System.Collections.Generic.List<T> obj = FromTabletoObject<T>(table);

                resp1 = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                b = table.Rows.Count >0;
               }
                connection.Close();
            }
            return b ;

        }

        private System.Collections.Generic. List<T> FromTabletoObject<T>(System.Data.DataTable table)
        {
            System.Collections.Generic. List<T> obj=new System.Collections.Generic.List<T>();
            //convert table to T
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
           obj = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<T>>(json);

            return obj;
        }
        private static   Dictionary<string,string> ModuleTableDictionary() {
            return new Dictionary<string, string>()
{
    { "BusinessPartners", "OCRD" },
    { "Quotations", "OQUT" },
    { "Orders", "ORDR" },
    { "PurchaseOrders", "OPOR" },
    { "PurchaseInvoices", "OPCH" },
    { "PurchaseDeliveryNotes", "OPDN" },
    { "PurchaseReturns", "ORPC" },
    { "Returns", "ORIN" },
    { "Drafts", "ODRF" },
    { "Items", "OITM" },
    { "Users", "OUSR" },
    { "IncomingPayments", "ORCT" },
    { "ApprovalRequests", "OWDD" },
    { "Delivery", "ODLN" },
    { "InventoryTransferRequests", "OWTQ" },
    { "InventoryTransfers", "OWTR" },
    { "InventoryCountings", "OINC" },
    { "Invoices", "OINV" },
    { "DeliveryNotes", "ODLN" },
    { "Activities", "OACT" },
    { "ServiceCalls", "OSCL" },
    { "Opportunities", "OOPR" },
    { "Contacts", "OCPR" },
    { "Campaigns", "OCMN" },
    { "BusinessPartnerProspects", "OSLP" },
    { "EquipmentServiceCalls", "OSCN" },
    { "ServiceContracts", "OSCO" },
    { "ServiceCallTypes", "OSCT" },
    { "ServiceCallSolutions", "OSCS" },
    { "ServiceCallOrigins", "OSCR" },
    { "ServiceCallStatus", "OSCY" },
    { "ServiceCallProblemTypes", "OSPT" }
}; 
        }
        private string PrimerykeyName (string moduleName )
        {
            var PrimerykeyName = "";
            var models = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttributes(typeof(ServiceLayerAttribute), false).Length > 0).ToList();
            var model = models.Where(x => x.GetCustomAttribute<ServiceLayerAttribute>().ModuleName == moduleName).FirstOrDefault();
            if (model != null)
            {
                var props = model.GetProperties();
                foreach (var prop in props)
                {
                    var attr = prop.GetCustomAttribute<SAPPrimaryKeyAttribute>();
                    if (attr != null)
                    {
                        PrimerykeyName = prop.GetCustomAttribute<SAPDBFieldNameAttribute>()?.ColumnName;
                        break;
                    }
                }
            }
            return PrimerykeyName;
        }
        public static  string GetTableName(string moduleName)
        {
            var TableName = "";
            var moduletable = ModuleTableDictionary();
            if (moduletable.ContainsKey(moduleName))
            {
                TableName = moduletable[moduleName];
            }
            else
            {
                throw new Exception("Module Name not found");
            }  

            return TableName;
        
        }
        public static string GetModuleName (string TableName)
        {
            var moduleName = "";
            var moduletable = ModuleTableDictionary();
            if (moduletable.ContainsValue(TableName))
            {
                moduleName = moduletable.FirstOrDefault(x => x.Value == TableName).Key;
            }
            else
            {
                throw new Exception("Table Name not found");
            }

            return moduleName;
        }

        #endregion
        #region Service Layer Call
        bool CallHTTPCLIENT_API(string url, string data, string Method, out string resp, bool ReplaceCollectionsOnPatch = true)
        {
            var b = false;
            int count = 0;
            bool SessionAvailable = false;
            do
            {
                var datum = new StringContent(data, Encoding.UTF8, "application/json");
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                }; 
                HttpClient httpclient = new System.Net.Http.HttpClient(httpClientHandler);
                resp = ""; 
                if (!string.IsNullOrEmpty(session_id))
                {
                    httpclient.DefaultRequestHeaders.Add("Cookie", $"B1SESSION={session_id};ROUTEID={NodeId};");
                    if (ReplaceCollectionsOnPatch)
                        httpclient.DefaultRequestHeaders.Add("B1S-ReplaceCollectionsOnPatch", "true");
                }
                HttpResponseMessage result = null;
                if (Method == "PATCH")
                {
                    result = httpclient.PatchAsync(url, datum).Result;
                }
                else if (Method == "POST")
                {
                    result = httpclient.PostAsync(url, datum).Result;
                }
                else if (Method == "DELETE")
                {
                    result = httpclient.DeleteAsync(url).Result;
                }
                else if (Method == "GET")
                {
                    result = httpclient.GetAsync(url).Result;
                }
                //var cookies = httpClientHandler.CookieContainer.GetCookies(new Uri(url));
                //foreach (System.Net.Cookie Cooki in cookies)
                //{
                //    if (Cooki.Name == "ROUTEID")
                //    {
                //        NodeId = Cooki.Value;
                //    }
                //}
                var message = result.Content.ReadAsStringAsync().Result;
                b = result.IsSuccessStatusCode;
                resp = message;
                try
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                     JObject json = JObject.Parse(message);
                    if (json.ContainsKey("error"))
                    {
                        SessionAvailable = json?["error"]?["code"]?.ToString() != "301";
                    }
                    else
                    {
                        SessionAvailable = true;
                        break;
                    }
                    }
                   
                }
                catch { }
                if(!SessionAvailable)
                {
                    #region If Login Update Session
                    try
                    {
                        var username = "";
                        if (context != null)
                        {
                            username = context.User.Identity.Name;
                        }
                        if (Entity != null)
                        {
                            username = Entity.UserName;
                        }
                        ExceptionsController.Log(new Exception("Session Expired..! " + session_id));
                        SqlQuery sqlQuery = new SqlQuery();
                        sqlQuery.From("Sessions")
                       .SelectMany("SessionId", "UserName", "Password", "Company", "NodeId")
                       .Where($"UserName ='{username}'")
                       .Where($"Company ='{SessionDictionary[username].company}'");
                        using (var connection = DBHelper.GetSerenDBConnection())
                        {
                            //if connection state is not open then open it
                            if (connection.State != System.Data.ConnectionState.Open)
                                connection.Open(); 
                            var reader = sqlQuery.ExecuteReader(connection);
                            if (reader.Read())
                            {
                                try
                                {
                                    var UserName = reader["UserName"].ToString().Trim();
                                    var Password = reader["Password"].ToString().Trim();
                                    var CompanyDB = reader["Company"].ToString().Trim();
                                    var NodeId = reader["NodeId"].ToString().Trim();
                                    reader.Close();
                                    if (Login(UserName, Password, CompanyDB))
                                    {
                                        if (SessionDictionary.Keys.Contains(username))
                                        {
                                            ExceptionsController.Log(new Exception("Previous Session..! " + SessionDictionary[username].session + " New Session..! " + this.session_id));
                                            SessionDictionary[username] = (this.session_id, CompanyDB, this.NodeId);
                                        }
                                        else
                                        {
                                            ExceptionsController.Log(new Exception("New Session..! " + this.session_id));
                                            SessionDictionary.Add(username, (this.session_id, CompanyDB, this.NodeId));
                                        } 
                                        int Updatesql = new SqlUpdate("Sessions")
                                                .Set("UserName", $"{username.ToString()}")
                                                .Set("SessionId", $"{this.session_id}") 
                                                .Set("NodeId", $"{this.NodeId}")
                                                .Set("DateTimeStamp", DateTime.Now)
                                                .Where($"UserName ='{username}'").Where($"Company ='{CompanyDB}'")
                                                .Execute(connection, ExpectedRows.Ignore);
                                        ExceptionsController.Log(new Exception("Session Updated in Table Successfully..!"));
                                        SqlUpdate update = new SqlUpdate("Users");
                                        update.SetTo("CompanyDatabase", $"'{CompanyDB}'");

                                        update.Where($"Username ='{username}'")
                                                 .Execute(connection, ExpectedRows.Ignore);

                                    }
                                }
                                catch (Exception Ex)
                                {
                                    ExceptionsController.Log(Ex);
                                }
                            }
                            //if connection is not closed
                            if (connection.State == System.Data.ConnectionState.Closed)
                            {
                                connection.Close();
                            } 
                        }
                    }
                    catch(Exception Ex)
                    {
                        ExceptionsController.Log(Ex);
                    }
                    
                    #endregion
                }
                count++;
            } 
            while (!SessionAvailable && count < 2);
            return b;
        }

       
        #endregion
    }
}
