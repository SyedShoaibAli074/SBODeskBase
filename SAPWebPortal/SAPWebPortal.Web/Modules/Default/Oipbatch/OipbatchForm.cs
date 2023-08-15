using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Oipbatch")]
    [BasedOnRow(typeof(OipbatchRow), CheckNames = true)]
    public class OipbatchForm
    {
        [HalfWidth]
        public int UUserid { get; set; }
        [HalfWidth]
        public string UUserCode { get; set; }
        [HalfWidth,BatchTypeValuesEditor, DefaultValue("Cash")]
        public string UBatchType { get; set; }
        [HalfWidth,DateTimeEditor,DefaultValue("Now")]
        public DateTime UDocDate { get; set; }
        [HalfWidth]
        public string UCashAcct { get; set; }
        [HalfWidth]
        public string UTrsfrAcct { get; set; }
        [HalfWidth]
        public int UTDocNum { get; set; }
        [HalfWidth]
        public string UCashierId { get; set; }
        [HalfWidth, StatusValuesEditor,DefaultValue("Open")]
        public string UStatus { get; set; }
        [HalfWidth]
        public decimal UDocTotal { get; set; }
        [Tab("Payment Detail")]
        [Ipbatch1Editor]
        public System.Collections.Generic.List<Ipbatch1Row> DetailList { get; set; }
    }
}