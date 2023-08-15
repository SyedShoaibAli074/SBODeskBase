using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Ipbatch1")]
    [BasedOnRow(typeof(Ipbatch1Row), CheckNames = true)]
    public class Ipbatch1Form
    {
        public string UCardCode { get; set; }
        public string UDocSum { get; set; }
        public string UBDocNum { get; set; }
        public string UBDocEntry { get; set; }
        public string UCardName { get; set; }
        public int UBatchId { get; set; }
    }
}