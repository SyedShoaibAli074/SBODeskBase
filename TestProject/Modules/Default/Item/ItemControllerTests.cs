using B1SLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SAPWebPortal.Default.Endpoints;
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
    public class ItemControllerTests : TestBase<ItemController, ItemRow>
    {
        public ItemControllerTests() : base("imran")
        {
        }
        [TestInitialize]
        public void init()
        {

            var row = SapDatabasesController.Row;
        }
        [TestMethod()]
        public void CreateTest()
        {
            ItemSaveHandler handler = new ItemSaveHandler(this.Context_Test);
            var req = Request;
            req.Entity.ItemCode= RandomString(10);
            var response = controller.Create(uow, req, handler);
            Debug.WriteLine("REQUEST:" + JsonConvert.SerializeObject(req));
            Debug.WriteLine("RESPONSE:" + JsonConvert.SerializeObject(response));
            Assert.IsTrue(response.Error == null);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            ItemSaveHandler handler = new ItemSaveHandler(this.Context_Test);
            var response = controller.Update(uow, Request, handler);
            Debug.WriteLine("REQUEST:" + JsonConvert.SerializeObject(Request));
            Debug.WriteLine("RESPONSE:" + JsonConvert.SerializeObject(response));
            Assert.IsTrue(response.Error == null);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            ItemDeleteHandler handler = new ItemDeleteHandler(this.Context_Test);
            controller.Delete(uow, new Serenity.Services.DeleteRequest() { EntityId = "Test00012" }, handler);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            ItemRetrieveHandler handler = new ItemRetrieveHandler(this.Context_Test);

            var lst = controller.Retrieve(uow.Connection, RetrieveRequest, handler);

            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(lst));

        }

        [TestMethod()]
        public void ListTest()
        {
            ItemListHandler handler = new ItemListHandler(this.Context_Test);
            var sw = Stopwatch.StartNew();
            var lst = controller.List(uow.Connection, ListRequest, handler);
            Console.WriteLine("FirstCall"+sw.Elapsed.ToString());
            sw.Reset(); 
            lst = controller.List(uow.Connection, ListRequest, handler);
            Console.WriteLine("SecondCall" + sw.Elapsed.ToString());
            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(lst,Formatting.Indented));
        }
        [TestMethod]
        public void DirectFromServiceLayer()
        {
            B1SLayer.ServiceLayerHelper helper = new B1SLayer.ServiceLayerHelper(
                "imran", "1234", "SBODEMOAU02","https://192.168.10.230:50000/b1s/v1/"
                ); 
            var res= helper.Connection.Request("Items?$take=1").GetAllAsync<ItemRow>().Result;
            res = res.Take(1).Skip(1).ToList();
            Debug.WriteLine(JsonConvert.SerializeObject(res, Formatting.Indented));
        }


    }
            
    
}