using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Log")]
    [BasedOnRow(typeof(LogRow), CheckNames = true)]
    public class LogForm
    {
        [HalfWidth]
        public DateTime UDateTime { get; set; }
        [HalfWidth]
        public string UDirection { get; set; }
        [HalfWidth]
        public string UError { get; set; }
        [TextAreaEditor(Rows =6)]
        public String URequest { get; set; }
        [TextAreaEditor(Rows = 6)]
        public String UResponse { get; set; }
        [TextAreaEditor(Rows = 6)]
        public String ShopifyPayload { get; set; }
        public string UObjType { get; set; }
        public string ShopifyId { get; set; }
    }
}