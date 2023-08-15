using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPB1;
using SAPWebPortal.Default;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace SAPWebPortal.Web.Modules.Common.Helpers.Tests
{
    [TestClass()]
    public class ServiceLayerRestHandlerTests : TestBaseHelpers
    {

        [TestMethod()]
        public void GetSLEntityTest()
        {
            string resp = "";
            ServiceLayerRestHandler serviceLayerRestHandlerTests = ServiceLayerRestHandler.GetInstance(base.Context_Test);
            var b = serviceLayerRestHandlerTests.GetSLEntity<BusinessPartnerRow>("BusinessPartners", "'C00003'", out resp);
            Debug.WriteLine(resp);
            Assert.IsTrue(b);
        }

        [TestMethod()]
        public void DeleteBOTest()
        {
            string resp = "";
            ServiceLayerRestHandler serviceLayerRestHandlerTests = ServiceLayerRestHandler.GetInstance(base.Context_Test);
            var b = serviceLayerRestHandlerTests.DeleteBO("BusinessPartners", "'C00003'", out resp);
            Debug.WriteLine(resp);
        }

        [TestMethod()]
        public void GetSLListTest()
        {
            string resp = "";
            long totalcount = 0;
            List<string> quicksearchFieldnames = null;
            System.Collections.Generic.HashSet<string> selected = null;
            ListRequest request = new ListRequest();
            request.Skip = 0;
            request.Take = 0;
            ServiceLayerRestHandler serviceLayerRestHandlerTests = ServiceLayerRestHandler.GetInstance(base.Context_Test);
            var b = serviceLayerRestHandlerTests.GetSLList<BusinessPartnerRow>("BusinessPartners", request, out resp, out totalcount, selected, "C", quicksearchFieldnames);
            Debug.WriteLine(resp);

        }

        [TestMethod()]
        public void GetInstanceTest()
        {
            ServiceLayerRestHandler serviceLayerRestHandler = ServiceLayerRestHandler.GetInstance(base.Context_Test);
    
        }

        [TestMethod()]
        public void ServiceLayerSession_Test()
        {
            var row = SapDatabasesController.Row;
            if(!string.IsNullOrEmpty(row.ServiceLayerUrl))
                ServiceLayerRestHandler.SLUserLogin(row.ServiceLayerUrl, row.ServiceLayerVersion, "manager", "1234", "SBODEMOAU");

        }
        // CallHTTPCLIENT_SQLTest
        [TestMethod()]
        public void CallHTTPCLIENT_SQL()
        {
            string resp = "";
            ServiceLayerRestHandler serviceLayerRestHandler = ServiceLayerRestHandler.GetInstance(base.Context_Test);
            var b = serviceLayerRestHandler.CallHTTPCLIENT_SQL<BusinessPartnerRow>("BusinessPartners", "",1,1,out resp);
            Debug.WriteLine(resp);
            Assert.IsTrue(b); 
        }
    }
}