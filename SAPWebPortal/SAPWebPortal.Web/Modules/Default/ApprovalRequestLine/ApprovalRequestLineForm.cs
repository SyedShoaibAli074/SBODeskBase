using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ApprovalRequestLine")]
    [BasedOnRow(typeof(ApprovalRequestLineRow), CheckNames = true)]
    public class ApprovalRequestLineForm
    {
        [HalfWidth, ReadOnly(true)]
        public Int32 UserID { get; set; }
        [HalfWidth,ReadOnly(true)]
        public Int32 StageCode { get; set; }
        
        [HalfWidth, ReadOnly(true)]
        public String Status { get; set; }
        [HalfWidth, Hidden]
        public String DBName { get; set; }
        [HalfWidth, ReadOnly(true),DateTimeEditor]
        public DateTime CreationDate { get; set; }
        [HalfWidth,ReadOnly(true), DateTimeEditor]
        public DateTime UpdateDate { get; set; }
        [ReadOnly(true)]
        public String Remarks { get; set; }
    }
}