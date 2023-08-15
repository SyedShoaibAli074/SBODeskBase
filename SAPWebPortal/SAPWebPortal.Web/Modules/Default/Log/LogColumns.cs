using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Log")]
    [BasedOnRow(typeof(LogRow), CheckNames = true)]
    public class LogColumns
    {
        [EditLink]
        public string UDirection { get; set; }
        [DisplayFormat("dd-MM-yyyy hh:mm")]
        public DateTime UDateTime { get; set; }
        
        public string UError { get; set; }
        public string UObjType { get; set; }
        public string ShopifyId { get; set; }
    }
}