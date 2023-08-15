using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ApprovalRequest")]
    [BasedOnRow(typeof(ApprovalRequestRow), CheckNames = true)]
    public class ApprovalRequestForm
    {
        [HalfWidth,ReadOnly(true)]
        public Int32 ApprovalTemplatesID { get; set; }
        [HalfWidth, ReadOnly(true)]
        public String ObjectType { get; set; }
        [HalfWidth, Hidden]
        public String DBName { get; set; }
        [HalfWidth, ReadOnly(true)]
        public String IsDraft { get; set; }
        [HalfWidth, ReadOnly(true)]
        public Int32 ObjectEntry { get; set; }
        [HalfWidth, ReadOnly(true)]
        public String Status { get; set; }
        [HalfWidth, ReadOnly(true),Visible(false)]
        public Int32 CurrentStage { get; set; }
        [HalfWidth, ReadOnly(true)]
        public Int32 OriginatorID { get; set; }
        [HalfWidth, ReadOnly(true)]
        public DateTime CreationDate { get; set; }
        [HalfWidth, ReadOnly(true)]
        public Int32 DraftEntry { get; set; }
        //[HalfWidth]
        //public String DraftType { get; set; }
        public System.Collections.Generic.List<ApprovalRequestLineRow> ApprovalRequestLines { get; set; }
        public System.Collections.Generic.List<ApprovalRequestDecisionRow> ApprovalRequestDecisions { get; set; }
        //public SAPB1.ApprovalTemplate ApprovalTemplate { get; set; }
        //public SAPB1.ApprovalStage ApprovalStage { get; set; }
        //public SAPB1.User User { get; set; }
        [Category("Remarks")]
        public String Remarks { get; set; }
    }
}