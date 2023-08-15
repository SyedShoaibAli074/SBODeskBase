using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.BPPaymentMethods")]
    [BasedOnRow(typeof(BPPaymentMethodsRow), CheckNames = true)]
    public class BPPaymentMethodsForm
    {
        //public string BPCode { get; set; }
        public string PaymentMethodCode { get; set; }
        public string DBName { get; set; }
       
    }
}