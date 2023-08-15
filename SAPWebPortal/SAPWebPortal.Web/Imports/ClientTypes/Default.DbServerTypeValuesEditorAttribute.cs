using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Default
{
    public partial class DbServerTypeValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Default.DbServerTypeValuesEditor";

        public DbServerTypeValuesEditorAttribute()
            : base(Key)
        {
        }
    }
}
