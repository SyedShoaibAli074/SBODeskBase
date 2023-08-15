using SAPWebPortal.Common.PermissionsKeys;
using SAPWebPortal.Drafts;
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
    [ConnectionKey("Default"), Module("Default"), ServiceLayer("ApprovalRequests")]
    [DisplayName("Approval Request"), InstanceName("Approval Request")]
    [InsertPermission(ApprovalProcessPermissionKeys.ApprovalRequests.Insert)]
    [ModifyPermission(ApprovalProcessPermissionKeys.ApprovalRequests.Modify)]
    [DeletePermission(ApprovalProcessPermissionKeys.ApprovalRequests.Delete)]
    [ReadPermission(ApprovalProcessPermissionKeys.ApprovalRequests.View)]
    [NotMapped]
    public sealed class ApprovalRequestRow : Row<ApprovalRequestRow.RowFields>, IIdRow
    {
        [DisplayName("DBName"), Size(255), NotMapped, RemoveFromEntity]
        public string DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }
        [DisplayName("Code"), NotNull, SAPDBFieldName("WddCode"), IdProperty, SortOrder(1, descending: true), SAPPrimaryKey, QuickSearch]
        [NotMapped]
        public Int32? Code
        {
            get => fields.Code[this];
            set => fields.Code[this] = value;
        }

        [DisplayName("Approval Template"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""WtmCode"", ""Name""  FROM OWTM")]
        [NotMapped]
        public Int32? ApprovalTemplatesID
        {
            get => fields.ApprovalTemplatesID[this];
            set => fields.ApprovalTemplatesID[this] = value;
        }

        [DisplayName("Object Type"), ApprovalDocsEditor]
        [NotMapped]
        public String ObjectType
        {
            get => fields.ObjectType[this];
            set => fields.ObjectType[this] = value;
        }

        [DisplayName("Is Draft"), IsYOrNEditor]
        [NotMapped]
        public String IsDraft
        {
            get => fields.IsDraft[this];
            set => fields.IsDraft[this] = value;
        }

        [DisplayName("Object Entry")]
        [NotMapped]
        public Int32? ObjectEntry
        {
            get => fields.ObjectEntry[this];
            set => fields.ObjectEntry[this] = value;
        }

        [DisplayName("Status"), SAPDBFieldName("Status"), ApprovalStatusEditor]
        [NotMapped]
        public String Status
        {
            get => fields.Status[this];
            set => fields.Status[this] = value;
        }

        [DisplayName("Originator Remarks"), SAPDBFieldName("Remarks"), TextAreaEditor ,ReadOnly(true)]
        [NotMapped]
        public String Remarks
        {
            get => fields.Remarks[this];
            set => fields.Remarks[this] = value;
        }

        [DisplayName("Current Stage")]
        [NotMapped]
        public Int32? CurrentStage
        {
            get => fields.CurrentStage[this];
            set => fields.CurrentStage[this] = value;
        }

        [DisplayName("Originator"), SAPDBFieldName("OwnerID"), SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""USERID"", ""USER_CODE""  FROM OUSR")]
        [NotMapped]
        public Int32? OriginatorID
        {
            get => fields.OriginatorID[this];
            set => fields.OriginatorID[this] = value;
        }

        [DisplayName("Creation Date"), SAPDBFieldName("DocDate")]
        [NotMapped]
        public DateTime? CreationDate
        {
            get => fields.CreationDate[this];
            set => fields.CreationDate[this] = value;
        }

        [DisplayName("Creation Time")]
        [NotMapped]
        public DateTime? CreationTime
        {
            get => fields.CreationTime[this];
            set => fields.CreationTime[this] = value;
        }

        [DisplayName("Draft Entry"), SAPDBFieldName("DraftEntry"), _Ext.GridItemPickerEditor(typeof(DocumentRow))]
        [NotMapped]
        public Int32? DraftEntry
        {
            get => fields.DraftEntry[this];
            set => fields.DraftEntry[this] = value;
        }

        [DisplayName("Draft Type") ]
        [NotMapped]
        public String DraftType
        {
            get => fields.DraftType[this];
            set => fields.DraftType[this] = value;
        }
        [DisplayName("Approval Request Lines"), MasterDetailRelation(foreignKey: "StageCode"), NotMapped, ApprovalRequestLineEditor]
        public System.Collections.Generic.List<ApprovalRequestLineRow> ApprovalRequestLines
        {
            get => fields.ApprovalRequestLines[this];
            set => fields.ApprovalRequestLines[this] = value;
        }

        [DisplayName("Approval Request Decisions"), MasterDetailRelation(foreignKey: "ApproverUserName"), NotMapped, ApprovalRequestDecisionEditor]
 
        public System.Collections.Generic.List<ApprovalRequestDecisionRow> ApprovalRequestDecisions
        {
            get => fields.ApprovalRequestDecisions[this];
            set => fields.ApprovalRequestDecisions[this] = value;
        }

        //[DisplayName("Approval Template"), NotNull]
        //[NotMapped]
        //public SAPB1.ApprovalTemplate? ApprovalTemplate
        //{
        //    get => fields.ApprovalTemplate[this];
        //    set => fields.ApprovalTemplate[this] = value;
        //}

        //[DisplayName("Approval Stage"), NotNull]
        //[NotMapped]
        //public SAPB1.ApprovalStage? ApprovalStage
        //{
        //    get => fields.ApprovalStage[this];
        //    set => fields.ApprovalStage[this] = value;
        //}

        //[DisplayName("User"), NotNull]
        //[NotMapped]
        //public SAPB1.User? User
        //{
        //    get => fields.User[this];
        //    set => fields.User[this] = value;
        //}

        public ApprovalRequestRow()
            : base()
        {
        }

        public ApprovalRequestRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Code;
            public Int32Field ApprovalTemplatesID;
            public StringField ObjectType;
            public StringField IsDraft;
            public Int32Field ObjectEntry;
            public StringField Status;
            public StringField Remarks;
            public Int32Field CurrentStage;
            public Int32Field OriginatorID;
            public DateTimeField CreationDate;
            public DateTimeField CreationTime;
            public Int32Field DraftEntry;
            public StringField DraftType;
            public StringField DBName;
            public RowListField<ApprovalRequestLineRow> ApprovalRequestLines; 
            public RowListField<ApprovalRequestDecisionRow> ApprovalRequestDecisions;
            //public SAPB1.ApprovalTemplateField ApprovalTemplate;
            //public SAPB1.ApprovalStageField ApprovalStage;
            //public SAPB1.UserField User;
        }
    }
}
