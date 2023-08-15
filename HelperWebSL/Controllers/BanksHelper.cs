using System;
using System.Collections.Generic;
using System.Text;

namespace HelperWebSL.Controllers
{
    public class BanksHelper
    {

        public List<(string BankCode,string BankName)> ListofBanks { get; set; }
        serenityHelper serenityHelper;
        public BanksHelper()
        {
            serenityHelper = new serenityHelper();
            ListofBanks = new List<(string BankCode, string BankName)>();
        }
        public void Refresh()
        {
            ListofBanks.Clear();
            var banks = serenityHelper.GetBanks();
            foreach (var bank in banks )
            {
                ListofBanks.Add((bank.BankCode, bank.BankName));
            }
        
         }

    }
}
