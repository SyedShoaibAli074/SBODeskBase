using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Default
{
    public partial class BatchTypeValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Default.BatchTypeValuesEditor";

        public BatchTypeValuesEditorAttribute()
            : base(Key)
        {
        }
    }
}
