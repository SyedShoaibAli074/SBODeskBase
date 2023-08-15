using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ContactEmployees")]
    [BasedOnRow(typeof(ContactEmployeesRow), CheckNames = true)]
    public class ContactEmployeesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public string CardCode { get; set; }
        public string Name { get; set; }
    }
}