using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ShopifySubSettings")]
    [BasedOnRow(typeof(ShopifySubSettingsRow), CheckNames = true)]
    public class ShopifySubSettingsForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}