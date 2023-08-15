using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SAPWebPortal.ARInvoice.Endpoints;
using SAPWebPortal.Default;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.ARInvoice.Endpoints.Tests
{
    [TestClass()]
    public class DocumentControllerTests:TestBase<DocumentController,DocumentRow>
    {
        public DocumentControllerTests() : base("imran")
        {
        }
         
        //public getall
        [TestMethod()]
        public void GetAllTest()
        {
             var documents = controller.GetAll();
            //serialize documents
            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(documents, Formatting.Indented));
 

            Assert.IsTrue(documents.Entities.Count >= 0);
            

        }
        //List test
        [TestMethod]
        public void ListTest()
        {
            DocumentListHandler handler = new DocumentListHandler(this.Context_Test);
            var sw = Stopwatch.StartNew();
            var lst = controller.List(uow.Connection, ListRequest, handler);
            Console.WriteLine("FirstCall" + sw.Elapsed.ToString());
            sw.Reset();
            lst = controller.List(uow.Connection, ListRequest, handler);
            Console.WriteLine("SecondCall" + sw.Elapsed.ToString());
            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(lst, Formatting.Indented));
        }
    }
}