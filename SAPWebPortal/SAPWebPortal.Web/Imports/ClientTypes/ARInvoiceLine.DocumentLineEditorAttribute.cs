using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.ARInvoiceLine
{
    public partial class DocumentLineEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.ARInvoiceLine.DocumentLineEditor";

        public DocumentLineEditorAttribute()
            : base(Key)
        {
        }
    }
}
