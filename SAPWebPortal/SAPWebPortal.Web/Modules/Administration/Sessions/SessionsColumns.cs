using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Columns
{
    [ColumnsScript("Administration.Sessions")]
    [BasedOnRow(typeof(SessionsRow), CheckNames = true)]
    public class SessionsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 Id { get; set; }
        [EditLink]
        public String SessionId { get; set; }
        public String UserName { get; set; }
    }
}