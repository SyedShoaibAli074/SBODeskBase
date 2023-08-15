using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Membership
{
    public partial class CompanyDatabaseValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Membership.CompanyDatabaseValuesEditor";

        public CompanyDatabaseValuesEditorAttribute()
            : base(Key)
        {
        }
    }
}
