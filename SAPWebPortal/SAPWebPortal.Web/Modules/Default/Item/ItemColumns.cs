using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Item")]
    [BasedOnRow(typeof(ItemRow), CheckNames = true)]
    public class ItemColumns
    {

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ForeignName { get; set; }
        public string DefaultWarehouse { get; set; }
    }
}