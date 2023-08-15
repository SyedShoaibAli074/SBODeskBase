using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ShopifySettings")]
    [BasedOnRow(typeof(ShopifySettingsRow), CheckNames = true)]
    public class ShopifySettingsForm
    {
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string SAPStoreName { get; set; }
        [Required]
        public string ApiVersion { get; set; }
        [Required]
        public string SapDatabase { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string ApiKey { get; set; }
        [Required]
        public string ApiKeySecret { get; set; }
        [Required]
        public string ApiBaseURL { get; set; }
        [HideOnInsert,ReadOnly(true),DefaultValue("now")]
        public DateTime CreateDate { get; set; }
        [HideOnInsert, ReadOnly(true)]
        public String CreatedBy { get; set; }
        public System.Collections.Generic.List<ShopifySettingsDetailRow> ShopifySettingsDetailList { get; set; }
        public System.Collections.Generic.List<ShopifyLocationDetailRow> ShopifyLocationDetailList { get; set; }
    }
}