using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Default
{
    public partial class UsersListFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "SAPWebPortal.Default.UsersListFormatter";

        public UsersListFormatterAttribute()
            : base(Key)
        {
        }
    }
}
