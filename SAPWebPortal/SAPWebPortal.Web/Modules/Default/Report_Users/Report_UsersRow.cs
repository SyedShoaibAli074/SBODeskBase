using SAPWebPortal.Membership;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[Report_Users]")]
    [DisplayName("Report Users"), InstanceName("Report Users")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [LookupScript("Default.Report_Users")]

    public sealed class Report_UsersRow : Row<Report_UsersRow.RowFields>, IIdRow
    {
        [DisplayName("Id"), Column("ID"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("User Name"), Column("userId"),LookupEditor(typeof(SAPWebPortal.Administration.Entities.UserRow))]
        public int? UserId
        {
            get => fields.UserId[this];
            set => fields.UserId[this] = value;
        }
        [DisplayName("Report Name"), Column("RODCID"), NotNull, LookupEditor(typeof(ReportsRow))]
        public int? Rodcid
        {
            get => fields.Rodcid[this];
            set => fields.Rodcid[this] = value;
        }

        [DisplayName("Report Name")]
        public String RptName
        {
            get { return Fields.RptName[this]; }
            set { Fields.RptName[this] = value; }
        }

        [DisplayName("Db Name"), Column("DB_Name")]
        [CompanyDatabaseValuesEditor]
        public String DB_Name
        {
            get { return Fields.DB_Name[this]; }
            set { Fields.DB_Name[this] = value; }
        }
        public Report_UsersRow()
            : base()
        {
        }

        public Report_UsersRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field UserId;
            public Int32Field Rodcid;
            public StringField DB_Name;
            public StringField RptName;
        }
    }
}
