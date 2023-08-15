using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Orders.Document
{
    public partial class SelectCodeNameValueEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Orders.Document.SelectCodeNameValueEditor";

        public SelectCodeNameValueEditorAttribute()
            : base(Key)
        {
        }
    }
}
