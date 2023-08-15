using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperWebSL;
using HelperWebSL.Controllers;

namespace HelpersWebSL.Controllers.Tests
{
    [TestClass()]
    public class CustomerHelperTests
    {
            serenityHelper serenity = new serenityHelper();
        //void init of test initialize
        [TestInitialize()]
        public void init()
        {
            //init serenity helper
            //login to serenity
      var b =       serenity._Login("imran", "1234", "12", "SBODEMOAU02");
            Assert.IsTrue(b);
        }
        [TestMethod()]
        public void RefreshTest()
        {
            CustomerHelper customerHelper = new CustomerHelper();
            customerHelper.Refresh();
            //serialize listofcustomers
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(customerHelper.ListofCustomers,Newtonsoft.Json.Formatting.Indented);
            //pront json
            Console.WriteLine(json);
            Assert.IsTrue(customerHelper.ListofCustomers.Count > 0);
        }
    } 
}