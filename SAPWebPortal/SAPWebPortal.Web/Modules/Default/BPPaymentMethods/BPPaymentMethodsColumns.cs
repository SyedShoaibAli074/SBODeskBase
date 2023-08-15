using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.BPPaymentMethods")]
    [BasedOnRow(typeof(BPPaymentMethodsRow), CheckNames = true)]
    public class BPPaymentMethodsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public string BPCode { get; set; }
        public string PaymentMethodCode { get; set; }
    }
}