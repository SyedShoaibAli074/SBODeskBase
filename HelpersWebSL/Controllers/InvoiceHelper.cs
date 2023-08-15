using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpersWebSL.Models;
namespace HelpersWebSL.Controllers
{
    public class InvoiceHelper
    {
        
        serenityHelper serenityHelper;
        //constructor
        public InvoiceHelper()
        {
            serenityHelper = new serenityHelper();
            ListofInvoices = serenityHelper.GetARInvoices();
        }
        public List<Document> ListofInvoices { get; set; }
        public List<Document> ListofInvoicesByCustomer (string customerCode)
        {
            return ListofInvoices.Where(x => x.CardCode == customerCode).ToList();
        }
        //refresh function
        public void Refresh()
        {
            ListofInvoices = serenityHelper.GetARInvoices();
        }
    }
}
