using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Columns
{
    [ColumnsScript("Administration.UserFormAuthorizations")]
    [BasedOnRow(typeof(UserFormAuthorizationsRow), CheckNames = true)]
    public class UserFormAuthorizationsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ModuleName { get; set; }
        [EditLink]
        public string CompanyDb { get; set; }
        public string FormName { get; set; }
        public string FormTitle { get; set; }
        public string FormDescription { get; set; }
    }
}