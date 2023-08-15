using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ABiT_WHATSAP.Default
{
    public partial class DBDriverEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "ABiT_WHATSAP.Default.DBDriverEditor";

        public DBDriverEditorAttribute()
            : base(Key)
        {
        }
    }
}
