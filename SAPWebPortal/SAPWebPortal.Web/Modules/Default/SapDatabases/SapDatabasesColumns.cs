using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.SapDatabases")]
    [BasedOnRow(typeof(SapDatabasesRow), CheckNames = true)]
    public class SapDatabasesColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int64 Id { get; set; }
        [EditLink]
        public String ServerName { get; set; }
        public String ODBCServer { get; set; }
        
        public String DbServerType { get; set; }
        public String LicenseServer { get; set; }
        public String CompanyDb { get; set; }
        public String DbUserName { get; set; }
        public String DbPassword { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Alias { get; set; }
        public String ServiceLayerUrl { get; set; }
        public String ServiceLayerVersion { get; set; }
        public String DBDriver { get; set; }
        public Boolean? IsDefault { get; set; }
    }
}