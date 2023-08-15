using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[UserDetail2]")]
    [DisplayName("Add New Autherized SalesPerson"), InstanceName("Add New Autherized SalesPerson")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class UserDetail2Row : Row<UserDetail2Row.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        [Visible(false)]
        [DisplayName("User D Id")]
        public int? UserDId
        {
            get => fields.UserDId[this];
            set => fields.UserDId[this] = value;
        }
        [Visible(false)]
        [DisplayName("User Id")]
        public int? UserId
        {
            get => fields.UserId[this];
            set => fields.UserId[this] = value;
        }
        [ReadOnly(true)]
        [DisplayName("User Code"), Size(255), QuickSearch, NameProperty]
        public string UserCode
        {
            get => fields.UserCode[this];
            set => fields.UserCode[this] = value;
        }
        [ReadOnly(true)]
        [DisplayName("User Name"), Size(254)]
        public string UserName
        {
            get => fields.UserName[this];
            set => fields.UserName[this] = value;
        }
        [ReadOnly(true)]
        [DisplayName("Db Name"), Column("DBName"), Size(254)]
        public string DbName
        {
            get => fields.DbName[this];
            set => fields.DbName[this] = value;
        }

        [DisplayName("Sales Person Code"), Size(254),SalesPersonValuesEditor]
        public string SalesPersonCode
        {
            get => fields.SalesPersonCode[this];
            set => fields.SalesPersonCode[this] = value;
        }
        [ReadOnly(true)]
        [DisplayName("Sales Person Name"), Size(254)]
        public string SalesPersonName
        {
            get => fields.SalesPersonName[this];
            set => fields.SalesPersonName[this] = value;
        }
        [Visible(false)]
        [DisplayName("Active"), Size(255),BooleanEditor,DefaultValue("Y")]
        public string Active
        {
            get => fields.Active[this];
            set => fields.Active[this] = value;
        }

        public UserDetail2Row()
            : base()
        {
        }

        public UserDetail2Row(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public Int32Field UserDId;
            public Int32Field UserId;
            public StringField UserCode;
            public StringField UserName;
            public StringField DbName;
            public StringField SalesPersonCode;
            public StringField SalesPersonName;
            public StringField Active;
        }
    }
}
