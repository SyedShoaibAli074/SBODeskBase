using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.SapDatabases")]
    [BasedOnRow(typeof(SapDatabasesRow), CheckNames = true)]
    public class SapDatabasesForm
    {
        [HalfWidth]
        public String ServerName { get; set; }
      
        [HalfWidth]
        public String DbServerType { get; set; }
        [HalfWidth]
        public String LicenseServer { get; set; }
        [HalfWidth]
        public String CompanyDb { get; set; }
        [HalfWidth]
        public String DbUserName { get; set; }
        [HalfWidth]
        public String DbPassword { get; set; }
        [HalfWidth]
        public String UserName { get; set; }
        [HalfWidth]
        public String Password { get; set; }
        [HalfWidth]
        public String ODBCServer { get; set; }
        [HalfWidth]
        public String Alias { get; set; }
        [HalfWidth]
        public String ServiceLayerUrl { get; set; }
        [HalfWidth]
        public String ServiceLayerVersion { get; set; }
        [HalfWidth]
        public String DBDriver { get; set; }
        [HalfWidth, BooleanEditor]
        public Int16 CreateUDFs { get; set; }
        [HalfWidth]
        public Boolean? IsDefault { get; set; }

    }
}