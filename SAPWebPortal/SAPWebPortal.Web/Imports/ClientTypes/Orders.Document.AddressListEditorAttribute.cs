using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Orders.Document
{
    public partial class AddressListEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Orders.Document.AddressListEditor";

        public AddressListEditorAttribute()
            : base(Key)
        {
        }
    }
}
