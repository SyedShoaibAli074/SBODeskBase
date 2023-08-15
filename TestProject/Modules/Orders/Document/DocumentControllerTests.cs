using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using SAPWebPortal.Orders.Endpoints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.Orders.Endpoints.Tests
{ 
    [TestClass()]
    public class DocumentControllerTests:TestBase<DocumentController,DocumentRow>
    {
        public DocumentControllerTests() : base("manager")
        {
        }
        [TestMethod()]
        public void ListTest()
        {
            //start stopwatch
            Stopwatch stopwatch = new Stopwatch();
            DocumentListHandler handler = new DocumentListHandler(this.Context_Test);
            var resp = controller.List(uow.Connection, ListRequest, handler);
            Debug.WriteLine(JsonConvert.SerializeObject(resp,Formatting.Indented));
            stopwatch.Stop();
            Debug.WriteLine("Time taken to execute ListTest() is " + stopwatch.ElapsedMilliseconds + " milliseconds");
        }
        //createTest
        [TestMethod()]
        public void CreateTest()
        {
            //start stopwatch
            Stopwatch stopwatch = new Stopwatch();
            DocumentSaveHandler handler = new DocumentSaveHandler(this.Context_Test);
              var resp = controller.Create(uow,Request, handler);
            Debug.WriteLine("REQUEST:" + JsonConvert.SerializeObject(Request));
            Debug.WriteLine("RESPONSE:" + JsonConvert.SerializeObject(resp));
             stopwatch.Stop();
            Debug.WriteLine("Time taken to execute CreateTest() is " + stopwatch.ElapsedMilliseconds + " milliseconds");
        } 
    }  
}