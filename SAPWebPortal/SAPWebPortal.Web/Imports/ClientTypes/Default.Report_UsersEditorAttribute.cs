using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Default
{
    public partial class Report_UsersEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Default.Report_UsersEditor";

        public Report_UsersEditorAttribute()
            : base(Key)
        {
        }
    }
}
