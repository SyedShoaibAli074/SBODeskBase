using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ShopifySettings")]
    [BasedOnRow(typeof(ShopifySettingsRow), CheckNames = true)]
    public class ShopifySettingsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public int Id { get; set; }
        public string ApiVersion { get; set; }
        [EditLink]
        public string StoreName { get; set; }
        public string SAPStoreName { get; set; }

        
        public string SapDatabase { get; set; }
       
        public DateTime CreateDate { get; set; }
        public String CreatedBy { get; set; }
    }
}