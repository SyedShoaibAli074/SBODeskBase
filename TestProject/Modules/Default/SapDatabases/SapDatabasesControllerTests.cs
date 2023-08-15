using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
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
    public class SapDatabasesControllerTests : TestBase<SapDatabasesController, SapDatabasesRow>
    {
        [TestInitialize]
        public void init()
        {
            Program.IsTest = true;
        }
        [TestMethod,TestCategory("CreateDatabases_TEST")]
        public void CreateDatabases_TEST()
        {
            SapDatabasesSaveHandler handler = new SapDatabasesSaveHandler(this.Context_Test);
            controller.Create(uow, Request, handler);



        }
        [TestMethod]
        public void ListDatabase_Test()
        {
            SapDatabasesListHandler handler = new SapDatabasesListHandler(this.Context_Test);
            var list = controller.List(uow.Connection, new Serenity.Services.ListRequest() { }, handler);
            Debug.Write(JObject.FromObject(list).ToString());
            Assert.IsTrue(list.TotalCount > 0);
        }
        [TestMethod()]
        public void ConnecteionTestTest()
        {
            var test = controller.ConnecteionTest(Request.Entity);
            Assert.IsTrue(test);
        }

        [TestMethod(),TestCategory("UpdateTest")]
        public void UpdateTest()
        {
            SapDatabasesSaveHandler handler = new SapDatabasesSaveHandler(this.Context_Test);
            controller.Update(uow, Request, handler);

        }

        [TestMethod()]
        public void DeleteTest()
        {
            SapDatabasesDeleteHandler handler = new SapDatabasesDeleteHandler(this.Context_Test);
            Serenity.Services.DeleteRequest request = new Serenity.Services.DeleteRequest();
            controller.Delete(uow, request, handler);
            Assert.Fail();
        }

        [TestMethod(),TestCategory("CreateRelatedTablesTest")]
        public void CreateRelatedTablesTest()
        {
            var response = controller.CreateRelatedTables(Request.Entity, UDType.UDT);
            Assert.IsNotNull(response);
        }
        [TestMethod(),TestCategory("CreateRelatedTablesUDOTest")]
        public void CreateRelatedTablesUDOTest()
        {
            var response = controller.CreateRelatedTables(Request.Entity, UDType.UDO);
            Assert.IsNotNull(response);
        }
        [TestMethod(),TestCategory("CreateRelatedTablesUDFTest")]
        public void CreateRelatedTablesUDFTest()
        {
            var response = controller.CreateRelatedTables(Request.Entity, UDType.UDF);
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void ServiceLayerUrlTest()
        {
            var response = controller.ServiceLayerUrl();
        }
         
    }
}