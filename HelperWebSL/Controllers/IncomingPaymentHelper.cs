using HelperWebSL.Models;
using System.Collections.Generic;
using System.Linq;
namespace HelperWebSL.Controllers {


    public class IncomingPaymentHelper
    {
        //serenityhelper 
        serenityHelper serenityHelper;
        //constructor  
        public IncomingPaymentHelper(bool SkipList=true)
        {
            serenityHelper = new serenityHelper();
            if (!SkipList)
            {
                ListofIncomingPayments = serenityHelper.GetIncomingPayments();
                AllIncomingPayments = ListofIncomingPayments;
            }
        }
        public List<IncomingPayments> ListofIncomingPayments { get; set; }

        public static List<IncomingPayments> AllIncomingPayments;
        public List<IncomingPayments> ListofIncomingPaymentsByCustomer(string customerCode)
        {
            AllIncomingPayments=ListofIncomingPayments.Where(x => x.CardCode == customerCode).ToList();
            return ListofIncomingPayments.Where(x => x.CardCode == customerCode).ToList();
        }
        //create Incoming Payment function
        public bool CreateIncomingPayment(IncomingPaymentPosting incomingPayment,bool SkipList=true)
        {
            var b = serenityHelper.CreateIncomingPayment(incomingPayment);
            if (!SkipList)
            {
                if (b)
                    Refresh();
            }
            
            return b;
        }
        //refresh function
        public void Refresh()
        {
            ListofIncomingPayments = serenityHelper.GetIncomingPayments();
        }
    }

}
 
