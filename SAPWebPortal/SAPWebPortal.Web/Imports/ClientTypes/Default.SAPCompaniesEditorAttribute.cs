using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Default
{
    public partial class SAPCompaniesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Default.SAPCompaniesEditor";

        public SAPCompaniesEditorAttribute()
            : base(Key)
        {
        }
    }
}
