using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.VatGroups.Columns
{
    [ColumnsScript("VatGroups.VatGroup")]
    [BasedOnRow(typeof(VatGroupRow), CheckNames = true)]
    public class VatGroupColumns
    {
        public String Code { get; set; }
        public String Name { get; set; }
        //public String Inactive { get; set; }
        
    }
}