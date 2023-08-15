using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelpersWebSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Helpers;
using HelperWebSL;

namespace HelpersWebSL.Tests
{
    [TestClass()]
    public class serenityHelperTests
    {
        serenityHelper serenityHelper;
        //test initialize
        [TestInitialize()]
        public void init()
        {
            serenityHelper = new serenityHelper();
          var b=  serenityHelper._Login("imran", "1234", "1", "SBODEEMOAU");
            Assert.IsTrue(b);
        }
        [TestMethod()]
        public void GetCustomersTest()
        {
            serenityHelper = new serenityHelper();
            var b = serenityHelper._Login("imran", "1234", "1", "SBODEEMOAU");
            Assert.IsTrue(b);
            var customers = serenityHelper.GetCustomers();
            Debug.WriteLine(customers.ToJson());
            Assert.IsTrue(customers.Count > 0);
        }

        [TestMethod()]
        public void GetARInvoicesTest()
        {
            var arinvoice = serenityHelper.GetARInvoices();
            Debug.WriteLine(arinvoice.ToJson());
            Assert.IsTrue(arinvoice.Count > 0);
        }

        [TestMethod()]
        public void GetIncomingPaymentsTest()
        {
            var incomingpayments = serenityHelper.GetIncomingPayments();
            Debug.WriteLine(incomingpayments.ToJson());
            Assert.IsTrue(incomingpayments.Count > 0);
        }
    }
}