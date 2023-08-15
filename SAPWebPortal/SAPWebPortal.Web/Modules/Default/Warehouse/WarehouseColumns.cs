using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Warehouse")]
    [BasedOnRow(typeof(WarehouseRow), CheckNames = true)]
    public class WarehouseColumns
    {
        public String WarehouseCode { get; set; }
        public String WarehouseName { get; set; }
       
    }
}