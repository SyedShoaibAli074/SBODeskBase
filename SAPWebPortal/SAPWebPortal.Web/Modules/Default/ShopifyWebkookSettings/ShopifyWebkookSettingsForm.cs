using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ShopifyWebkookSettings")]
    [BasedOnRow(typeof(ShopifyWebkookSettingsRow), CheckNames = true)]
    public class ShopifyWebkookSettingsForm
    {
        [HalfWidth,HideOnInsert,ReadOnly(true)]
        public string WebhookId { get; set; }
        [HalfWidth]
        public string ShopifyWebhookTopic { get; set; }
        [HalfWidth]
        public string ShopifyStore { get; set; }
        [FullWidth,TextAreaEditor(Rows =2)]
        public string WebhookUrl { get; set; }
        
        [Hidden]
        public DateTime CreateDate { get; set; }
        [Hidden]
        public string CreatedBy { get; set; }
    }
}