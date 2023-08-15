using AspNetCoreHero.ToastNotification.Helpers;
using HelperWebSL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SAPWebPortal.IncomingPayment.Endpoints;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.IncomingPayment.Endpoints.Tests
{
    [TestClass()]
    public class PaymentControllerTests : TestBase<PaymentController, PaymentRow>
    {
        //constructor
        public PaymentControllerTests() : base("imran")
        {

        }
        //initialize
        [TestInitialize()]
        public void init()
        {

        }
        [TestMethod()]
        public void GetAllTest()
        {

            var payments = controller.GetAll();
            Assert.IsNotNull(payments);
            //print payments
            Debug.WriteLine(JsonConvert.SerializeObject(payments, Formatting.Indented));
            Assert.IsTrue(payments.Entities.Count() > 0);

        }
        [TestMethod]
        public void GetBanksTest()
        {
            var banks = controller.GetBanks();
            //print
            Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(banks, Formatting.Indented));
            Assert.IsNotNull(banks);
            
        }
        [TestMethod()]
        public void PostPaymentCashTest()
        {

            IncomingPaymentPosting incomingPaymentPosting = new IncomingPaymentPosting();
            incomingPaymentPosting.CardCode = "C00063";
            incomingPaymentPosting.PaymentType = PaymentType.Cash;
            incomingPaymentPosting.ReceivedTotal = 400;
            incomingPaymentPosting.ListOfInvoicesDocEntries = new List<int>();
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(1127);
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(1124);
            var json = incomingPaymentPosting.ToJson();

           var s =  controller.PostPayment(incomingPaymentPosting);
            Debug.WriteLine(s.EntityId);
            Assert.IsTrue(Convert.ToInt32( s.EntityId )> 0);
            

        }
        [TestMethod]
        public void PostPaymentChequeTest()
        {
            IncomingPaymentPosting incomingPaymentPosting = new IncomingPaymentPosting();
            incomingPaymentPosting.CardCode = "C00063";
            incomingPaymentPosting.PaymentType = PaymentType.Cheque;
            incomingPaymentPosting.ReceivedTotal = 400;
            incomingPaymentPosting.ListOfInvoicesDocEntries = new List<int>();
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(1127);
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(1124);
            incomingPaymentPosting.ListOfChecks = new List<(int CheckNumber, double CheckSum , string BankCode, DateTime? CheckDate)>();
            incomingPaymentPosting.ListOfChecks.Add((123, 400, "123456" , DateTime.Now));
            
            var json = incomingPaymentPosting.ToJson();

            var s = controller.PostPayment(incomingPaymentPosting);
            Debug.WriteLine(s.EntityId);
            Assert.IsTrue(Convert.ToInt32(s.EntityId) > 0);
        }
        //post payment with transfer bank
        [TestMethod]
        public void PostPaymentTransferTest()
        {
            IncomingPaymentPosting incomingPaymentPosting = new IncomingPaymentPosting();
            incomingPaymentPosting.CardCode = "C00063";
            incomingPaymentPosting.PaymentType = PaymentType.BankTransfer;
            incomingPaymentPosting.ReceivedTotal = 400;
            incomingPaymentPosting.ListOfInvoicesDocEntries = new List<int>();
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(1127);
            incomingPaymentPosting.ListOfInvoicesDocEntries.Add(1124); 
            var json = incomingPaymentPosting.ToJson(); 
            var s = controller.PostPayment(incomingPaymentPosting);
            Debug.WriteLine(s.EntityId);
            Assert.IsTrue(Convert.ToInt32(s.EntityId) > 0);
        }
    }
}