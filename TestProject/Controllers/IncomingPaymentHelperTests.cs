using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelperWebSL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperWebSL.Models;
using HelperWebSL;

namespace HelpersWebSL.Controllers.Tests
{
    [TestClass()]
    public class IncomingPaymentHelperTests
    {
        //initialize
        [TestInitialize()]
        public void init()
        {
            serenityHelper serenityHelper = new serenityHelper();
            serenityHelper._Login("imran", "1234", "1", "SBODEEMOAU");
        }
        [TestMethod()]
        public void CreateIncomingPaymentTest()
        {
            IncomingPaymentPosting incomingPaymentPosting = new IncomingPaymentPosting();
            incomingPaymentPosting.CardCode = "C00063";
            incomingPaymentPosting.PaymentType = PaymentType.Cash;
            incomingPaymentPosting.ReceivedTotal = 220.0;
            incomingPaymentPosting.ListOfInvoicesDocEntries = new List<int>();
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(1124);
            IncomingPaymentHelper helper = new IncomingPaymentHelper(true);
            var result = helper.CreateIncomingPayment(incomingPaymentPosting);
            Assert.IsTrue(result);
            
        }
    }
}