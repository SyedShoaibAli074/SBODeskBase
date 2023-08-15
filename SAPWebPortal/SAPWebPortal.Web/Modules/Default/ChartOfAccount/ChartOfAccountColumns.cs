using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ChartOfAccount")]
    [BasedOnRow(typeof(ChartOfAccountRow), CheckNames = true)]
    public class ChartOfAccountColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public String Code { get; set; }
        public String Name { get; set; }
        
    }
}