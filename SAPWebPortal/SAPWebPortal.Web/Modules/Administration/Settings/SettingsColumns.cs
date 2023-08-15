using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Columns
{
    [ColumnsScript("Administration.Settings")]
    [BasedOnRow(typeof(SettingsRow), CheckNames = true)]
    public class SettingsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ModuleName { get; set; }
        [EditLink]
        public string ListDataSource { get; set; }
        public string PostByMethod { get; set; }
        public bool IsHana { get; set; }
    }
}