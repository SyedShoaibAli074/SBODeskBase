using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Modules.DropDownEnums
{
    public partial class DocStatusEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Modules.DropDownEnums.DocStatusEditor";

        public DocStatusEditorAttribute()
            : base(Key)
        {
        }
    }
}
