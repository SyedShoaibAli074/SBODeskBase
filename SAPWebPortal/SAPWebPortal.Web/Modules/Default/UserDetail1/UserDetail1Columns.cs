using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.UserDetail1")]
    [BasedOnRow(typeof(UserDetail1Row), CheckNames = true)]
    public class UserDetail1Columns
    {
        [DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
        public int UserDId { get; set; }
        public int UserId { get; set; }
        [EditLink]
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string DbName { get; set; }
        [CardCodeValuesEditor]
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Active { get; set; }
    }
}