using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ShopifyLocationDetail")]
    [BasedOnRow(typeof(ShopifyLocationDetailRow), CheckNames = true)]
    public class ShopifyLocationDetailColumns
    {
        /*[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public int Id { get; set; }
        public String ShopifySettingsSapDatabase { get; set; }*/
        [EditLink]
        public string SapWarhouseCode { get; set; }
        public string ShopifyLocationCode { get; set; }
    }
}