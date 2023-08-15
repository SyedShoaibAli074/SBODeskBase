using SAPWebPortal.Modules.DropDownEnums;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), ServiceLayer("ApprovalRequestLine")]
    [DisplayName("Approval Request Line"), InstanceName("Approval Request Line")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [NotMapped]
    public sealed class ApprovalRequestLineRow : Row<ApprovalRequestLineRow.RowFields>, IIdRow
    {

        [DisplayName("Stage"), IdProperty,Width(50)]
        [NotMapped]
        public Int32? StageCode
        {
            get => fields.StageCode[this];
            set => fields.StageCode[this] = value;
        }

        [DisplayName("Approver")]
        [NotMapped]
        public Int32? UserID
        {
            get => fields.UserID[this];
            set => fields.UserID[this] = value;
        }

        [DisplayName("Status"), ApprovalLineStatusEditor]
        [NotMapped]
        public String Status
        {
            get => fields.Status[this];
            set => fields.Status[this] = value;
        }
        [DisplayName("DBName")]
        [NotMapped]
        public String DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }

        [DisplayName("Approver Remarks"),TextAreaEditor]
        [NotMapped]
        public String Remarks
        {
            get => fields.Remarks[this];
            set => fields.Remarks[this] = value;
        }

        [DisplayName("Update Date"), NotNull]
        [NotMapped]
        public DateTime? UpdateDate
        {
            get => fields.UpdateDate[this];
            set => fields.UpdateDate[this] = value;
        }
        [DisplayName("Creation Date"), NotNull]
        [NotMapped]
        public DateTime? CreationDate
        {
            get => fields.CreationDate[this];
            set => fields.CreationDate[this] = value;
        }
        //[DisplayName("Update Time"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]? UpdateTime
        //{
        //    get => fields.UpdateTime[this];
        //    set => fields.UpdateTime[this] = value;
        //}



        //[DisplayName("Creation Time"), NotNull]
        //[NotMapped]
        //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]? CreationTime
        //{
        //    get => fields.CreationTime[this];
        //    set => fields.CreationTime[this] = value;
        //}

        public ApprovalRequestLineRow()
            : base()
        {
        }

        public ApprovalRequestLineRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field StageCode;
            public Int32Field UserID;
            public StringField Status;
            public StringField DBName;
            public StringField Remarks;
            public DateTimeField CreationDate;
            public DateTimeField UpdateDate;
            //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]Field UpdateTime;
            //public System.Nullable`1[Microsoft.OData.Edm.TimeOfDay]Field CreationTime;
        }
    }
}
