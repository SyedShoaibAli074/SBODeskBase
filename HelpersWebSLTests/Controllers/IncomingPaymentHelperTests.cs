using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelperWebSL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperWebSL.Models;
using System.Diagnostics;
using HelperWebSL;

namespace HelpersWebSL.Controllers.Tests
{
    [TestClass()]
    public class IncomingPaymentHelperTests
    {
        //initialize method
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
            IncomingPaymentHelper incomingPaymentHelper = new IncomingPaymentHelper();
            incomingPaymentHelper.Refresh();
            //serialize listofcustomers
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(incomingPaymentHelper.ListofIncomingPayments, Newtonsoft.Json.Formatting.Indented);
            //pront json
            Console.WriteLine(json);
            Assert.IsTrue(incomingPaymentHelper.ListofIncomingPayments.Count > 0);
        }

        [TestMethod()]
        public void CreateIncomingPaymentTest()
        {
            IncomingPaymentHelper incomingPaymentHelper = new IncomingPaymentHelper();
            //call createincoming from incomingpaymenthelper
            //incomingpaymentposting
            IncomingPaymentPosting incomingPaymentPosting = new IncomingPaymentPosting();
            incomingPaymentPosting.CardCode = "C00001";
            incomingPaymentPosting.PaymentType = PaymentType.Cash;
            incomingPaymentPosting.ReceivedTotal = 100.0;
            incomingPaymentPosting.ListOfInvoicesDocEntries = new List<int>();
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(874);
            //incomingpaymentposting to json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(incomingPaymentPosting, Newtonsoft.Json.Formatting.Indented);
             
              Debug.WriteLine(json); 
           var created =  incomingPaymentHelper.CreateIncomingPayment(incomingPaymentPosting);
            Assert.IsTrue(created);
        }
    }
}