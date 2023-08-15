using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.IncomingPayment
{
    public partial class PaymentAccountEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.IncomingPayment.PaymentAccountEditor";

        public PaymentAccountEditorAttribute()
            : base(Key)
        {
        }
    }
}
