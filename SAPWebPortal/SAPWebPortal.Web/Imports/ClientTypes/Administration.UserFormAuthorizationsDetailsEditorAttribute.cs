﻿using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SAPWebPortal.Administration
{
    public partial class UserFormAuthorizationsDetailsEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Administration.UserFormAuthorizationsDetailsEditor";

        public UserFormAuthorizationsDetailsEditorAttribute()
            : base(Key)
        {
        }
    }
}
