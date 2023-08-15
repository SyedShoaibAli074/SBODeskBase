using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.UsersDetails")]
    [BasedOnRow(typeof(UsersDetailsRow), CheckNames = true)]
    public class UsersDetailsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public int Id { get; set; }
        public Int32 UserId { get; set; }
        [EditLink, Width(300)]
        public string ParameterName { get; set; }
        [Width(300)]
        public string ParameterQuery { get; set; }
        [Width(300)]
        public String DbName { get; set; }
    }
}