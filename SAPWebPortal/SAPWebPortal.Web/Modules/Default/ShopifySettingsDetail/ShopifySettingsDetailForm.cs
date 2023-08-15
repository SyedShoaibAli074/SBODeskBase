using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ShopifySettingsDetail")]
    [BasedOnRow(typeof(ShopifySettingsDetailRow), CheckNames = true)]
    public class ShopifySettingsDetailForm
    {
        [Required]
        public int ShopifySubSettingsId { get; set; }
        [Required]
        public string ShopifySubSettingsSapValue { get; set; }
    }
}