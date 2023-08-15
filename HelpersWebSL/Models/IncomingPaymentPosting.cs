using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpersWebSL.Models
{
    public class IncomingPaymentPosting
    {
        public string TransferAccount { get; set; }
        public string CardCode { get; set; }
        public List<int> ListOfInvoicesDocEntries  { get; set; }
        public List<(int CheckNumber, double CheckSum ,string BankAccount, string BankCode,DateTime? CheckDate)> ListOfChecks { get; set; }
        public double ReceivedTotal { get; set; }
        public PaymentType PaymentType { get; set; }
        
    }
    public enum PaymentType
    {
        Cash,
        Cheque,
        BankTransfer
    }
}
