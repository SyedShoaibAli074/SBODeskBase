using HelpersWebSL;
using HelpersWebSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpersWebSL.Controllers
{
    public  class CustomerHelper
    {
        //serenityhelper 


        serenityHelper serenityHelper;
        //constructor  
        public CustomerHelper()
        {
            serenityHelper = new serenityHelper();
            ListofCustomers = serenityHelper.GetCustomers();
        }
        public List<BusinessPartners> ListofCustomers { get; set; }

        //refresh function
        public void Refresh()
        {
            ListofCustomers = serenityHelper.GetCustomers();
        }
        
    }
}
