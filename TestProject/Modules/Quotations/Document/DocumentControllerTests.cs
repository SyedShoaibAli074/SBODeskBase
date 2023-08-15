using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SAPWebPortal.Quotations.Endpoints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.Quotations.Endpoints.Tests
{
    [TestClass()]
    public class DocumentControllerTests:TestBase<DocumentController,DocumentRow>
    {
        public DocumentControllerTests() : base("imran")
        {
        }
        [TestMethod()]
        public void ListTest()
        {
            DocumentListHandler handler = new DocumentListHandler(this.Context_Test);
            var resp = controller.List(uow.Connection, ListRequest, handler);
            Debug.WriteLine(JsonConvert.SerializeObject(resp, Formatting.Indented));

        }
    }
}