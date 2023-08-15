using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ApprovalRequest")]
    [BasedOnRow(typeof(ApprovalRequestRow), CheckNames = true)]
    public class ApprovalRequestColumns
    {
        public Int32 Code { get; set; }
        public Int32 DraftEntry { get; set; }
        public Int32 OriginatorID { get; set; }
        //public String ObjectType { get; set; }
        //public String IsDraft { get; set; }
        //public Int32 ObjectEntry { get; set; }
        public String Status { get; set; }
        public String Remarks { get; set; }
      
        public DateTime  CreationDate { get; set; }


    }
}