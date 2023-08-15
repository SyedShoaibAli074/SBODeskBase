using B1SLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.ServiceLayerTest
{
    public class ServiceLayerTest
    {
        //Test initialize
        [TestInitialize()]
        public void init()
        {
            //initialize
            var b = false;
            var serviceLayer = new SLConnection("https://192.168.10.230:50000/b1s/v1", "SBODEMOAU", "imran", "1234");
            serviceLayer.AfterCall(async call =>
            {
                Console.WriteLine($"Request: {call.HttpRequestMessage.Method} {call.HttpRequestMessage.RequestUri}");
                Console.WriteLine($"Body sent: {call.RequestBody}");
                Console.WriteLine($"Response: {call.HttpResponseMessage?.StatusCode}");
                Console.WriteLine(await call.HttpResponseMessage?.Content?.ReadAsStringAsync());
                Console.WriteLine($"Call duration: {call.Duration.Value.TotalSeconds} seconds");
            });
            Assert.IsTrue(b);
        }

    }
}
