using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Default
{
    public partial class DBDriverEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Default.DBDriverEditor";

        public DBDriverEditorAttribute()
            : base(Key)
        {
        }
    }
}
