using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ApprovalRequestLine")]
    [BasedOnRow(typeof(ApprovalRequestLineRow), CheckNames = true)]
    public class ApprovalRequestLineColumns
    {
        public Int32 StageCode { get; set; }
        //public Int32 UserID { get; set; }
        [ApprovalRequestLineEditor]
        public String Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public String Remarks { get; set; }
    }
}