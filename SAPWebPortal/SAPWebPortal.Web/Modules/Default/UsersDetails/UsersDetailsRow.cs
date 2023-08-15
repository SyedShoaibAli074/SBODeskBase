using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[Report_UserDetails]")]
    [DisplayName("Parameter Setup"), InstanceName("Parameter Setup")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [LookupScript]

    public sealed class UsersDetailsRow : Row<UsersDetailsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Column("ID"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("U1"), NotNull, ForeignKey("[dbo].[Report_Users]", "ID"), LeftJoin("jU1")]
        public int? U1Id
        {
            get => fields.U1Id[this];
            set => fields.U1Id[this] = value;
        }

        [DisplayName("User Name"), Column("UserID"), LookupEditor(typeof(SAPWebPortal.Administration.Entities.UserRow))]
        public int? UserId
        {
            get => fields.UserId[this];
            set => fields.UserId[this] = value;
        }
       
        [DisplayName("Parameter Name"), Size(250), QuickSearch, NameProperty]
        public string ParameterName
        {
            get => fields.ParameterName[this];
            set => fields.ParameterName[this] = value;
        }

        [DisplayName("Parameter Query")]
        public string ParameterQuery
        {
            get => fields.ParameterQuery[this];
            set => fields.ParameterQuery[this] = value;
        }

        [DisplayName("Rodcid"), Column("RODCID"), LookupEditor(typeof(ReportsRow))]
        public int? Rodcid
        {
            get => fields.Rodcid[this];
            set => fields.Rodcid[this] = value;
        }
        
        [DisplayName("Db Name"), Column("DB_Name")]
        public String DbName
        {
            get => fields.DbName[this];
            set => fields.DbName[this] = value;
        }
        public UsersDetailsRow()
            : base()
        {
        }

        public UsersDetailsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public Int32Field U1Id;
            public Int32Field UserId;
            public StringField ParameterName;
            public StringField ParameterQuery;
            public Int32Field Rodcid;
            public StringField DbName;

        }
    }
}
