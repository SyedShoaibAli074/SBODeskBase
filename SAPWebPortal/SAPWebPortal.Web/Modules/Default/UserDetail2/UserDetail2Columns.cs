using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.UserDetail2")]
    [BasedOnRow(typeof(UserDetail2Row), CheckNames = true)]
    public class UserDetail2Columns
    {
        [ DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
        public int UserDId { get; set; }
        public int UserId { get; set; }
        [EditLink]
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string DbName { get; set; }
        public string SalesPersonCode { get; set; }
        public string SalesPersonName { get; set; }
        public string Active { get; set; }
    }
}