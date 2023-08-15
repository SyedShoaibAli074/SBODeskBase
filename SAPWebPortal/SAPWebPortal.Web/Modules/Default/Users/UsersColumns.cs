using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.Users")]
    [BasedOnRow(typeof(UsersRow), CheckNames = true)]
    public class UsersColumns
    {
        [EditLink, AlignCenter]
        public Int32 UserId { get; set; }
    }
}