using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Web.Helpers;
using SAPWebPortal.Web.Helpers.SessionRocordHelper;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using Sentry;
using SAPWebPortal.Membership.Pages;
using Serenity.Tests;
using TestProject.TestBase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SAPWebPortal.Web.DependencyInjections;
using SAPWebPortal.Web.Modules.SAPApp;
using SAPWebPortal.Administration.Pages;
using SAPWebPortal.Web.Modules.ARInvoiceToAPInvoiceIntegration;
using Microsoft.AspNetCore.Mvc;
using Sentry.Protocol;

namespace SAPWebPortal

{
    public class Program
    {
        public static bool IsTest = false;
        public static void Main(string[] args)
        {


            // Call the MyAction method on the controller
            

            Thread PAthread = new Thread(new ThreadStart(PAThreadFunc));
            PAthread.IsBackground = true;
            PAthread.Name = "PAThreadFunc";
            PAthread.Start();
            Thread SessionTimeoutThread = new Thread(new ThreadStart(SessionTimeOutThreadFunc));
            SessionTimeoutThread.IsBackground = true;
            SessionTimeoutThread.Name = "SessionTimeOutThreadFunc";
            SessionTimeoutThread.Start();



            

            ARInvoiceToAPInvoiceIntegration aRInvoiceToAPInvoiceIntegration = new ARInvoiceToAPInvoiceIntegration();

            Thread ARtoAPThread = new Thread(new ThreadStart(aRInvoiceToAPInvoiceIntegration.IterationFunc));
            ARtoAPThread.IsBackground = true;
            ARtoAPThread.Name = "ARtoAPThreadFunc";
            ARtoAPThread.Start();
            CreateHostBuilder(args).Build().Run();
        }
        //cronjob junction to run every 3 min
        
        
            
        protected static void PAThreadFunc()
        {

            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(PATimerWorker);
            t.Interval = Convert.ToDouble(Startup.getConfigValue("HeartBeatTimer")) * 60 * 1000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        } 
       
        protected static void PATimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();

            try
            {
                PAIteration();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
            finally
            {
                ((System.Timers.Timer)sender).Start();
            }
        }
         
        public static void PAIteration()
        {
            try
            {

                var services = new ServiceCollection();
                /*var payload = @"{""Take"":100 }";
                var path =string.Format( Startup.getHeartBeat,Startup.Port, Startup.Http_Protocol);
                string resp = "";
                var done = CallHTTPCLIENT_API(path, payload, "POST", out resp);
                string id = "";
                Administration.Endpoints.LogController.DBLog(3.ToString(), done.ToString(), "", "", "", out id, "", "", resp);
                //Administration.Endpoints.LogController.DBLogDelete();
                Administration.Endpoints.LogController.ExceptionLogDelete();*/
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }


        
        static System.Net.Http.HttpClient _httpclient = null;
        static System.Net.Http.HttpClient httpClient
        {
            get
            {
                if (_httpclient == null)
                {
                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
                    {
                        return true;
                    };
                    _httpclient = new System.Net.Http.HttpClient(httpClientHandler);
                }
                return _httpclient;
            }
        }
        static bool CallHTTPCLIENT_API(string url, string data, string Method, out string resp, bool ReplaceCollectionsOnPatch = true)
        {
            var b = false;
            {
                var datum = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                resp = "";
                HttpResponseMessage result = null;
                {
                    //ignore ssl certificate bypass
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                    result = httpClient.PostAsync(url, datum).Result;
                }
                var message = result.Content.ReadAsStringAsync().Result;
                b = result.IsSuccessStatusCode;
                resp = message;
            }
            return b;
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                   /* webBuilder.UseSentry(o =>
                    {
                        var SentryIP = Startup.getConfigValue("SentryIP").ToString();
                        if (isrunningatoffice())
                        {
                            SentryIP = Startup.getConfigValue("SentryIPLocal").ToString();
                        }
                        //  o.Dsn = "http://50d6438790e940c58d95734946ad149d@124.29.220.60:9000/16";
                        o.Dsn = $"http://50d6438790e940c58d95734946ad149d@{SentryIP}:9000/16";
                        // When configuring for the first time, to see what the SDK is doing:
                        o.Debug = true;
                        // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                        // We recommend adjusting this value in production.
                        o.TracesSampleRate = 1.0;
                    });*/
                })
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("appsettings.bundles.json");
                    config.AddJsonFile($"appsettings.machine.json", optional: true);
                });
        }
        static bool isrunningatoffice()
        {
            var domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            return domain.ToLower() == "abitcons.com";
        } 
         

        #region Session TimeOut
        protected static void SessionTimeOutThreadFunc()
        {
           /* System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(SessionTimeOutTimerWorker);
            //3 min interval
            t.Interval=1*60*1000; 
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();*/
        }
        protected static void SessionTimeOutTimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();
            try
            {
            var twolevelcashe = new NullTwoLevelCache();
            var textlocalizer = new TextLocalizer();
                HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                    Startup.RegisterDataProviders(); 
            //AccountController controller = new AccountController(twolevelcashe, textlocalizer, httpContextAccessor);
           //_ = controller.SessionManagement();
                // SessionTimeOutLoop();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
            finally
            {
                ((System.Timers.Timer)sender).Start();
            }
        }
        public static void SessionTimeOutLoop()
        {
            using (var Connection = new SqlConnection(Startup.connectionString))
            {
                var Query = @"SELECT * FROM Sessions";
                var row = SapDatabasesController.Row;
                string resp = "";
                using (var command = new SqlCommand(Query, Connection))
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var UserName = reader["UserName"].ToString();
                        var Password = AES.DecryptString(reader["Password"].ToString().Trim());
                        var CompanyDB = reader["Company"].ToString().Trim();
                        var SessionId = reader["SessionID"].ToString().Trim();
                        if (!SessionId.StartsWith("'"))
                        {
                            var url = row.ServiceLayerUrl + "b1s/" + row.ServiceLayerVersion + $"/BusinessPartners/$count";
                            var IsTimeOut = SessionTimeOut_API_Call_Check(url, SessionId, "{}", out resp);
                            if (IsTimeOut)
                            {
                                ServiceLayerRestHandler.SLUserLogin(row.ServiceLayerUrl, row.ServiceLayerVersion, UserName, Password, CompanyDB);
                                String Pattern = "yyyy-MM-dd HH:mm:ss";
                                var Date = DateTime.Now.ToString(Pattern);
                                Administration.Endpoints.ExceptionsController.Log(new Exception("Session TimeOut- " + Date));
                            }
                        }
                    }
                    reader.Close();
                    Connection.Close();
                }
            }
        }
        public static bool SessionTimeOut_API_Call_Check(string url, string SessionId, string data, out string resp, bool ReplaceCollectionsOnPatch = true)
        {
            var IsTimeOut = false;
            SessionId = SessionId.Replace("'", "");
            var datum = new StringContent(data, Encoding.UTF8, "application/json");
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            HttpClient httpclient = new System.Net.Http.HttpClient(httpClientHandler);
            resp = "";
            if (!string.IsNullOrEmpty(SessionId))
            {
                httpclient.DefaultRequestHeaders.Add("Cookie", $"B1SESSION={SessionId};ROUTEID=.node0;");
                if (ReplaceCollectionsOnPatch)
                    httpclient.DefaultRequestHeaders.Add("B1S-ReplaceCollectionsOnPatch", "true");
            }
            HttpResponseMessage result = httpclient.GetAsync(url).Result;
            var message = result.Content.ReadAsStringAsync().Result;
            var Res = result.IsSuccessStatusCode;
            resp = message;
            try
            {
                JObject json = JObject.Parse(message);
                if (json.ContainsKey("error"))
                {
                    IsTimeOut = json?["error"]?["code"]?.ToString() == "301";
                }
            }
            catch
            {
            }
            return IsTimeOut;
        }
        #endregion
    }
}
