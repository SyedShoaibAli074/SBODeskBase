using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Columns
{
    [ColumnsScript("Administration.UserFormAuthorizationsDetails")]
    [BasedOnRow(typeof(UserFormAuthorizationsDetailsRow), CheckNames = true)]
    public class UserFormAuthorizationsDetailsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
       // public int UserFormAuthorizationId { get; set; }
        [EditLink]
        public string FieldName { get; set; }
        public string FieldDescription { get; set; }
        public string DataType { get; set; }
        public string DefaultValue { get; set; }
        public string DataSize { get; set; }
        public bool Readonly { get; set; }
        public bool Required { get; set; }
        public bool Visible { get; set; }
        public string HtmlClass { get; set; }
        public string HtmlStyle { get; set; }
        public string HtmlAttributes { get; set; }
    }
}