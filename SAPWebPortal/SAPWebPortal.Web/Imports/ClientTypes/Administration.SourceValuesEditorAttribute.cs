using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Administration
{
    public partial class SourceValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Administration.SourceValuesEditor";

        public SourceValuesEditorAttribute()
            : base(Key)
        {
        }
    }
}
