using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ShopifyLocationDetail")]
    [BasedOnRow(typeof(ShopifyLocationDetailRow), CheckNames = true)]
    public class ShopifyLocationDetailForm
    {
        [HalfWidth]
        public string SapWarhouseCode { get; set; }
        [HalfWidth]
        public string ShopifyLocationCode { get; set; }
    }
}