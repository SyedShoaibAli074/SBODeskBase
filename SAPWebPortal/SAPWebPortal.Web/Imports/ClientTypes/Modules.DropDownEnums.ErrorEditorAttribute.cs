using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Modules.DropDownEnums
{
    public partial class ErrorEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Modules.DropDownEnums.ErrorEditor";

        public ErrorEditorAttribute()
            : base(Key)
        {
        }
    }
}
