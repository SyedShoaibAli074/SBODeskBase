using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using SAPWebPortal.Modules.DropDownEnums;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), ServiceLayer("Default")]
    [DisplayName("Approval Decision"), InstanceName("Approval Decision")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [NotMapped]
    public sealed class ApprovalRequestDecisionRow : Row<ApprovalRequestDecisionRow.RowFields>, IIdRow
    {
        [DisplayName("Approver"), IdProperty]
        [NotMapped]
        public String ApproverUserName
        {
            get => fields.ApproverUserName[this];
            set => fields.ApproverUserName[this] = value;
        }

        [DisplayName("Approver Password")]
        [NotMapped]
        public String ApproverPassword
        {
            get => fields.ApproverPassword[this];
            set => fields.ApproverPassword[this] = value;
        }

        [DisplayName("Status"), NotNull/*, ApprovalLineStatusEditor*/]
        [NotMapped]
        public String Status
        {
            get => fields.Status[this];
            set => fields.Status[this] = value;
        }

        [DisplayName("Remarks")]
        [NotMapped]
        public String Remarks
        {
            get => fields.Remarks[this];
            set => fields.Remarks[this] = value;
        }

        public ApprovalRequestDecisionRow()
            : base()
        {
        }

        public ApprovalRequestDecisionRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField ApproverUserName;
            public StringField ApproverPassword;
            public StringField Status;
            public StringField Remarks;
        }
    }
}
