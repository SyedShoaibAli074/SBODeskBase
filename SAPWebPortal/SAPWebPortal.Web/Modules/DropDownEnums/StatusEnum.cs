using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SAPWebPortal.Modules.DropDownEnums
{
    //[EnumKey("Visitor.VisitorTitle")]
    public enum StatusEnum
    {
        [Description("Pending")]
        [EnumMember(Value = "ardPending")]
        Pending,
        [Description("Approved")]
        [EnumMember(Value = "ardApproved")]
        Approved,
            [Description("Rejected")]
        [EnumMember(Value = "ardNotApproved")]
        Rejected
    }
   
   
}