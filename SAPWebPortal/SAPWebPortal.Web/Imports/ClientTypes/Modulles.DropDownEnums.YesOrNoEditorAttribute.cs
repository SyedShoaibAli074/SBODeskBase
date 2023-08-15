using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Modulles.DropDownEnums
{
    public partial class YesOrNoEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Modulles.DropDownEnums.YesOrNoEditor";

        public YesOrNoEditorAttribute()
            : base(Key)
        {
        }
    }
}
