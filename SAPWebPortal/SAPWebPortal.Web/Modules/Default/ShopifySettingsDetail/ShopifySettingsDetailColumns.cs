using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ShopifySettingsDetail")]
    [BasedOnRow(typeof(ShopifySettingsDetailRow), CheckNames = true)]
    public class ShopifySettingsDetailColumns
    {
        /*[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public int Id { get; set; }*/
        public int ShopifySubSettingsId { get; set; }
        [EditLink]
        public string ShopifySubSettingsSapValue { get; set; }
    }
}