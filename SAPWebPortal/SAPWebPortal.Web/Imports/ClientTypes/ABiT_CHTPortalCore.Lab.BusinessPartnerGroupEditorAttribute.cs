using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ABiT_CHTPortalCore.Lab
{
    public partial class BusinessPartnerGroupEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "ABiT_CHTPortalCore.Lab.BusinessPartnerGroupEditor";

        public BusinessPartnerGroupEditorAttribute()
            : base(Key)
        {
        }
    }
}
