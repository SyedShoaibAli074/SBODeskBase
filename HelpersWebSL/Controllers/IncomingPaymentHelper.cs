using HelpersWebSL.Models;

namespace HelpersWebSL.Controllers;
 
public class IncomingPaymentHelper
{
    //serenityhelper 
    serenityHelper serenityHelper;
    //constructor  
    public IncomingPaymentHelper()
    {
        serenityHelper = new serenityHelper();
        ListofIncomingPayments = serenityHelper.GetIncomingPayments();
    }
    public List<IncomingPayments> ListofIncomingPayments { get; set; }
    public List<IncomingPayments> ListofIncomingPaymentsByCustomer(string customerCode)
    {
        return ListofIncomingPayments.Where(x => x.CardCode == customerCode).ToList();
    }
    //create Incoming Payment function
    public bool CreateIncomingPayment(IncomingPaymentPosting incomingPayment)
    {
       var b =  serenityHelper.CreateIncomingPayment(incomingPayment);
        if(b)
        Refresh();
        return b;
    }
    //refresh function
    public void Refresh()
    {
        ListofIncomingPayments = serenityHelper.GetIncomingPayments();
    }
} 