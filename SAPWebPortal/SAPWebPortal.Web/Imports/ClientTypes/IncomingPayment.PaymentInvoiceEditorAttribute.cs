using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.IncomingPayment
{
    public partial class PaymentInvoiceEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.IncomingPayment.PaymentInvoiceEditor";

        public PaymentInvoiceEditorAttribute()
            : base(Key)
        {
        }
    }
}
