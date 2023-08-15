using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SAPWebPortal.Default;
using SAPWebPortal.InventoryCounting.Endpoints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.InventoryCounting.Endpoints.Tests
{
    
    [TestClass()]
    public class InventoryCountingControllerTests : TestBase<InventoryCountingController, InventoryCountingRow>
    {
        public InventoryCountingControllerTests() : base("imran")
        {
        }
        [TestInitialize]
        public void init()
        {
            Program.IsTest = true;
        }
        [TestMethod()]
        public void RetrieveTest()
        {
            InventoryCountingRetrieveHandler handler = new InventoryCountingRetrieveHandler(this.Context_Test);

            var lst = controller.Retrieve(uow.Connection, RetrieveRequest, handler);

            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));

        }
    }
}