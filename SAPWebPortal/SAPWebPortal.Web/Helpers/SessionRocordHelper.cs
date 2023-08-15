using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Web.Models.SLModels;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Helpers.SessionRocordHelper
{
    public class SessionRocordHelper
    {

    }
    public class ServiceLayer
    {
       // private IRequestContext Context;
        private static Dictionary<string, string> SessionIdDictionary
        {
            get; set;
        }
        string session_id = "";
        public string ErrorMessage = "";
        public static string UserName = "";
        public static string CompanyDb = "";
        static string ID = "";
        public static ServiceLayer GetInstance(string username, string password, string companydb = "")
        {
            ID = username+ companydb;
            UserName = username; 
            CompanyDb = companydb;
            ServiceLayer handler = new ServiceLayer();
            if (SessionIdDictionary == null) 
                SessionIdDictionary = new Dictionary<string, string>();
            if (SessionIdDictionary.Keys.Contains(ID))
            {
                handler.session_id = SessionIdDictionary[ID];
            }
            else
            {
                if (handler.Login(username, password, companydb))
                {
                    handler.session_id=handler.session_id.Replace("'", "");
                    SessionIdDictionary.Add(ID, handler.session_id);

                }
            }
            return handler;
        }
        private bool Login(string username, string password, string CompanyDB)
        {
            bool b = false;
            var row = SapDatabasesController.SAPRow(CompanyDB);
            if (!row.ServiceLayerUrl.EndsWith("/")) row.ServiceLayerUrl += "/";
            var url = row.ServiceLayerUrl + "b1s/" + row.ServiceLayerVersion + "/" + "Login";
            var data = $@"{{""CompanyDB"": ""{CompanyDB}"", ""UserName"": ""{username}"", ""Password"": ""{password}""}}";
            string Method = "POST";
            JObject resp;
            string response = "";
            CallHTTPCLIENT_API(url, data, Method, out response);
            resp = JObject.Parse(response);
            if (JObject.Parse(response)?["error"]?["code"]?.ToString() == "100000027")
            {
                ErrorMessage = JObject.Parse(response)?["error"]?["message"]?["value"]?.ToString();
                ExceptionsController.Log(new Exception(JObject.Parse(response)?["error"]?["message"]?["value"]?.ToString() + " for " + username), ErrorMessage);
            }
            else if (JObject.Parse(response)?["error"]?["code"]?.ToString() == "206")
            {
                ErrorMessage = JObject.Parse(response)?["error"]?["message"]?["value"]?.ToString();
                ExceptionsController.Log(new Exception(JObject.Parse(response)?["error"]?["message"]?["value"]?.ToString() + " for " + username), ErrorMessage);
            }
            else
            {
                session_id = resp["SessionId"]?.ToString().Replace("'", "");
            }
            b = !string.IsNullOrEmpty(session_id);
            return b;
        }
        private bool Login(string DBName)
        {
            var row = SapDatabasesController.SAPRow(DBName);
            if (!row.ServiceLayerUrl.EndsWith("/")) row.ServiceLayerUrl += "/";
            var url = row.ServiceLayerUrl + "b1s/" + row.ServiceLayerVersion + "/" + "Login";
            var jdata = new JObject();
            jdata["CompanyDB"] = row.CompanyDb;
            jdata["UserName"] = row.UserName;
            jdata["Password"] = AES.DecryptString(row.Password);
            var data = jdata.ToString();
            string Method = "POST";
            JObject resp;
            bool b;
            string response = "";
            CallHTTPCLIENT_API(url, data, Method, out response);
            resp = JObject.Parse(response);
            session_id = resp["SessionId"]?.ToString().Replace("'", "");
            b = !string.IsNullOrEmpty(session_id);
            return b;

        }
        bool CallHTTPCLIENT_API(string url, string data, string Method, out string resp, bool ReplaceCollectionsOnPatch = true)
        {
            var b = false;
            int count = 0;
            bool SessionAvailable = true;
            resp = "";
            try
            {
                do
                {
                    var datum = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                    {
                        return true;
                    };
                    HttpClient httpclient = new System.Net.Http.HttpClient(httpClientHandler);
                    if (!string.IsNullOrEmpty(session_id))
                    {
                        session_id = session_id?.ToString().Replace("'", "");
                        httpclient.DefaultRequestHeaders.Add("Cookie", $"B1SESSION={session_id};ROUTEID=.node0;");
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
                    var message = result.Content.ReadAsStringAsync().Result;
                    b = result.IsSuccessStatusCode;
                    resp = message;
                    var dta= JsonConvert.DeserializeObject<ServiceLayerLogin>(data);
                    if (!b)
                    {
                        try { SessionAvailable = JObject.Parse(message)?["error"]?["code"]?.ToString() == "301"; } catch { }
                        if (SessionAvailable)
                        {
                            
                            if (this.Login(dta.CompanyDB))
                            {
                                if (SessionIdDictionary.Keys.Contains(UserName+CompanyDb))
                                    SessionIdDictionary[UserName + CompanyDb] = this.session_id?.ToString().Replace("'", "");
                                else
                                    SessionIdDictionary.Add(UserName + CompanyDb, this.session_id?.ToString().Replace("'", ""));
                            }
                        }
                    }
                    count++;
                }
                while (!SessionAvailable && count < 2);
            }
            catch(Exception ex)
            {
                ExceptionsController.Log(ex);
            }
            return b;
        }

        public bool GetRecordCount(String BOName, String Payload, out string response)
        {
            bool b = true;
            var row = SapDatabasesController.Row;
            string criteria = "";
            if (BOName == "Drafts")
            {
                criteria += $"?$filter=DocumentStatus eq 'O'";
            }
            else if (BOName == "BusinessPartners")
            {
                criteria += $"?$filter=CardType eq 'C'";
            }
            var url = row.ServiceLayerUrl + "b1s/" + row.ServiceLayerVersion + $"/{BOName}/$count{criteria}";
            var data = Payload.ToString();
            b = CallHTTPCLIENT_API(url, data, "GET", out response);
            return b;
        }                                         
    }
}
