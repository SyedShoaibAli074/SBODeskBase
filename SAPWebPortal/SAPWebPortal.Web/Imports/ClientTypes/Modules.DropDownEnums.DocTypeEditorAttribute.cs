using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Modules.DropDownEnums
{
    public partial class DocTypeEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Modules.DropDownEnums.DocTypeEditor";

        public DocTypeEditorAttribute()
            : base(Key)
        {
        }
    }
}
