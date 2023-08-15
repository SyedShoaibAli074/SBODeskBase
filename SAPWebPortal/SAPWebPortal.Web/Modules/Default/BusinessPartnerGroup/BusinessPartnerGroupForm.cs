using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.BusinessPartnerGroup")]
    [BasedOnRow(typeof(BusinessPartnerGroupRow), CheckNames = true)]
    public class BusinessPartnerGroupForm
    {
        public System.String Name { get; set; }
        public SAPB1.BoBusinessPartnerGroupTypes Type { get; set; }
    }
}