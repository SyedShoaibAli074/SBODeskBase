using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[UserDetail1]")]
    [DisplayName("Add New Autherized Customers"), InstanceName("Add New Autherized Customers")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    public sealed class UserDetail1Row : Row<UserDetail1Row.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }
        //hide field
        [Visible(false)]

        [DisplayName("User D Id")]
        public int? UserDId
        {
            get => fields.UserDId[this];
            set => fields.UserDId[this] = value;
        }

        [DisplayName("User Id")]
        [Visible(false)]
        //default value as current user id 
        public int? UserId
        {
            get => fields.UserId[this];
            set => fields.UserId[this] = value;
        }
        //readonly field
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

        [DisplayName("Customer Code"), Size(254), CardCodeValuesEditor]
        public string CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }
        //hide the field
        
        [ReadOnly(true)]
        [DisplayName("Customer Name"), Size(254)]
        public string CardName
        {
            get => fields.CardName[this];
            set => fields.CardName[this] = value;
        }
        // valid values Y/N
        //make a drop down 
        [Visible(false)]
        [ReadOnly(true)]
        [DefaultValue("Y"),BooleanEditor]
        [DisplayName("Active"), Size(255)]
        public string Active
        {
            get => fields.Active[this];
            set => fields.Active[this] = value;
        }

        public UserDetail1Row()
            : base()
        {
        }

        public UserDetail1Row(RowFields fields)
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
            public StringField CardCode;
            public StringField CardName;
            public StringField Active;
        }
    }
}
