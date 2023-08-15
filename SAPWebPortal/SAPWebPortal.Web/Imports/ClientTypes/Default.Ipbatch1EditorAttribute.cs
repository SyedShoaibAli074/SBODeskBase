using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Default
{
    public partial class Ipbatch1EditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Default.Ipbatch1Editor";

        public Ipbatch1EditorAttribute()
            : base(Key)
        {
        }
    }
}
