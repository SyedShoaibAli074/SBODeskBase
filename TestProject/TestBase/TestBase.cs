using SAPWebPortal.Web.Modules.Common.Helpers; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SAPWebPortal;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using NToastNotify;
using SAPWebPortal.Membership.Pages;

namespace TestProject.TestBase
{
    public abstract class TestBase<T,TRow>// where T : ServiceEndpoint,  new()
    {
        protected T controller;
        protected Serenity.Data.WrappedConnection connection;
        protected UnitOfWork uow;
        string userid = "";
        public TestBase(string userid = "admin")
        { this.userid = userid;
            Program.IsTest = true;
            //create instance of T
            controller = (T)Activator.CreateInstance(typeof(T), new object[] { null,null }); 
            controller.SetPrivatePropertyValue<IRequestContext>("Context", Context_Test);
            //     ((dynamic)controller).Context_Test = Context_Test 
            connection = new Serenity.Data.WrappedConnection(new System.Data.SqlClient.SqlConnection(Startup.connectionString), new SqlServer2012Dialect());
            uow = new UnitOfWork(connection);
            Startup.basePath = "";
            //get running running dll path
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Startup.basePath =Path.GetDirectoryName( path); 
            AccountController accountController = new AccountController(null,null) ;
          //  accountController.SessionManagement().Wait();
            // SAPDBNameHandler.AddDBName("admin", "SBODEMOAU");
            //Program.Main(new string[] { "%LAUNCHER_ARGS%" });
        }
        public IRequestContext Context_Test { get { return new TestContext_Testing(userid); } }

        public TestBase(T controller)
        {
            this.controller = controller;

        }
        public string Payload
        {
            get
            {
                var filename = this.controller.GetType().Name.Replace("Controller", "Row") + ".json";
                var path = Path.Combine("JSON\\", filename);
                return File.ReadAllText(path);
            }
        }
        public string PayloadListRequest
        {
            get
            {
                var filename = this.controller.GetType().Name.Replace("Controller", "ListRequest") + ".json";
                var path = Path.Combine("JSON\\", filename);
                return File.ReadAllText(path);
            }
        }
        public string PayloadRetrieveRequest
        {
            get
            {
                var filename = this.controller.GetType().Name.Replace("Controller", "RetrieveRequest") + ".json";
                var path = Path.Combine("JSON\\", filename);
                return File.ReadAllText(path);
            }
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            if(uow != null)
            uow.Commit();
        }
        public Serenity.Services.SaveRequest<TRow> Request
        {
            get
            {
                var req = (Serenity.Services.SaveRequest<TRow>)JsonConvert.DeserializeObject(Payload, typeof(Serenity.Services.SaveRequest<TRow>));

                return req;
            }
        }
        public Serenity.Services.ListRequest ListRequest
        {
            get
            {
                var req = (Serenity.Services.ListRequest )JsonConvert.DeserializeObject(PayloadListRequest, typeof(Serenity.Services.ListRequest ));

                return req;
            }
        }
        public Serenity.Services.RetrieveRequest RetrieveRequest
        {
            get
            {
                var req = (Serenity.Services.RetrieveRequest)JsonConvert.DeserializeObject(PayloadRetrieveRequest, typeof(Serenity.Services.RetrieveRequest));

                return req;
            }
        }
        public   string RandomString(int length)
        {
            Random random = new Random(DateTime.Now.Millisecond);
           const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}
