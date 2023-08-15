using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using SAPWebPortal.Modules.DropDownEnums;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ApprovalRequestDecision")]
    [BasedOnRow(typeof(ApprovalRequestDecisionRow), CheckNames = true)]
    public class ApprovalRequestDecisionForm
    {
        //public String ApproverPassword { get; set; }
        [HalfWidth]
        public StatusEnum Status { get; set; }
        [TextAreaEditor]
        public String Remarks { get; set; }
    }
}