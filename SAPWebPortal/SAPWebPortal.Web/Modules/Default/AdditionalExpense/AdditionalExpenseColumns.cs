using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.AdditionalExpense")]
    [BasedOnRow(typeof(AdditionalExpenseRow), CheckNames = true)]
    public class AdditionalExpenseColumns
    {
        public Int32 ExpensCode { get; set; }
        public String Name { get; set; }
    }
}