using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Orders
{
    public partial class AddressExtensionEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Orders.AddressExtensionEditor";

        public AddressExtensionEditorAttribute()
            : base(Key)
        {
        }
    }
}
