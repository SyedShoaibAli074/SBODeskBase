using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelpersWebSL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperWebSL.Controllers;
using HelperWebSL;

namespace HelpersWebSL.Controllers.Tests
{
    [TestClass()]
    public class InvoiceHelperTests
    {
        //initialize
        [TestInitialize()]
        public void init()
        {
            //init serenity helper
            //login to serenity
            serenityHelper serenity = new serenityHelper();
            var b = serenity._Login("imran", "1234", "12", "SBODEMOAU02");
            Assert.IsTrue(b);
        }
        [TestMethod()]
        public void RefreshTest()
        {
            InvoiceHelper invoiceHelper = new InvoiceHelper();
            invoiceHelper.Refresh();
            //serialize listofcustomers
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(invoiceHelper.ListofInvoices, Newtonsoft.Json.Formatting.Indented);
            //pront json
            Console.WriteLine(json);
            Assert.IsTrue(invoiceHelper.ListofInvoices.Count > 0);
        }
    }
}