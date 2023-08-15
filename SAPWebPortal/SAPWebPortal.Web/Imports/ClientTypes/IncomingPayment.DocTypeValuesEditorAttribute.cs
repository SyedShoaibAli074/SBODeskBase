using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.IncomingPayment
{
    public partial class DocTypeValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.IncomingPayment.DocTypeValuesEditor";

        public DocTypeValuesEditorAttribute()
            : base(Key)
        {
        }
    }
}
