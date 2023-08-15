using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ShopifyWebkookSettings")]
    [BasedOnRow(typeof(ShopifyWebkookSettingsRow), CheckNames = true)]
    public class ShopifyWebkookSettingsColumns
    {
        
        [EditLink]
        public string ShopifyWebhookTopic { get; set; }
        public String ShopifyStore { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}