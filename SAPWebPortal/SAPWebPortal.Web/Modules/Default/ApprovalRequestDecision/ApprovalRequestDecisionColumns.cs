using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using SAPWebPortal.Modules.DropDownEnums;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.ApprovalRequestDecision")]
    [BasedOnRow(typeof(ApprovalRequestDecisionRow), CheckNames = true)]
    public class ApprovalRequestDecisionColumns
    {
        //[EditLink, AlignRight]
        //public String ApproverUserName { get; set; }
        //public System.String ApproverPassword { get; set; }
        public StatusEnum Status { get; set; }
        public String Remarks { get; set; }
    }
}