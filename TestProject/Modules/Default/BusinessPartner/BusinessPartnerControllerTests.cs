using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Membership.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.Default.Endpoints.Tests
{
    [TestClass()]
    public class BusinessPartnerControllerTests : TestBase<BusinessPartnerController, BusinessPartnerRow>
    {
        public BusinessPartnerControllerTests() : base("imran")
        {
        }

        [TestInitialize]
        public void init()
        {
            Program.IsTest = true;
            
        }
        [TestMethod()]
        public void CreateTest()
        {
            BusinessPartnerSaveHandler handler = new BusinessPartnerSaveHandler(this.Context_Test);
            var req = Request;
            req.Entity.CardCode = RandomString(10);
            var response = controller.Create(uow, req, handler);
            Debug.WriteLine("REQUEST:" + JsonConvert.SerializeObject(req));
            Debug.WriteLine("RESPONSE:" + JsonConvert.SerializeObject(response));
            Assert.IsTrue(response.Error == null);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            BusinessPartnerSaveHandler handler = new BusinessPartnerSaveHandler(this.Context_Test);
            var response = controller.Update(uow, Request, handler);
            Debug.WriteLine("REQUEST:" + JsonConvert.SerializeObject(Request));
            Debug.WriteLine("RESPONSE:" + JsonConvert.SerializeObject(response));
            Assert.IsTrue(response.Error == null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            BusinessPartnerDeleteHandler handler = new BusinessPartnerDeleteHandler(this.Context_Test);
            var resp = controller.Delete(uow, new Serenity.Services.DeleteRequest() { EntityId = "V10000" }, handler);
            Debug.WriteLine(JsonConvert.SerializeObject(resp));
        }

        [TestMethod()]
        public void ListTest()
        {
            //start stopwatch
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BusinessPartnerListHandler handler = new BusinessPartnerListHandler(this.Context_Test);

            var lst = controller.List(uow.Connection, ListRequest, handler);
            // print elapsed time
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Debug.WriteLine("Elapsed Time:" + elapsedMs);
            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));

        } 
        

        [TestMethod()]
        public void RetrieveTest()
        {
            BusinessPartnerRetrieveHandler handler = new BusinessPartnerRetrieveHandler(this.Context_Test);

            var lst = controller.Retrieve(uow.Connection, RetrieveRequest, handler);

            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));


        }

        [TestMethod()]
        public void GetAllTest()
        {
            BusinessPartnerRetrieveHandler handler = new BusinessPartnerRetrieveHandler(this.Context_Test);

            var lst = controller.GetAll();

            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));
        }

        [TestMethod()]
        public void FillDataDictionaryTest()
        {
            BusinessPartnerRetrieveHandler handler = new BusinessPartnerRetrieveHandler(this.Context_Test);

              controller.FillDataDictionary("waqas", "1234", "SBODEMOAU");
             
        }
         
    }
}