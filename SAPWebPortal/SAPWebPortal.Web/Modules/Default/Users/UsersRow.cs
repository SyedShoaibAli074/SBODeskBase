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
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[Users]")]
    [DisplayName("Users"), InstanceName("Users")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [LookupScript]

    public sealed class UsersRow : Row<UsersRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("User Name"), Identity, IdProperty,LookupEditor(typeof(SAPWebPortal.Administration.Entities.UserRow))]
        public int? UserId
        {
            get => fields.UserId[this];
            set => fields.UserId[this] = value;
        }

        [DisplayName("Username"), Size(100), NotNull, QuickSearch, NameProperty]
        public string Username
        {
            get => fields.Username[this];
            set => fields.Username[this] = value;
        }

        [DisplayName("Display Name"), Size(100), NotNull]
        public string DisplayName
        {
            get => fields.DisplayName[this];
            set => fields.DisplayName[this] = value;
        }

        [DisplayName("Email"), Size(100)]
        public string Email
        {
            get => fields.Email[this];
            set => fields.Email[this] = value;
        }

        [DisplayName("Source"), Size(4), NotNull]
        public string Source
        {
            get => fields.Source[this];
            set => fields.Source[this] = value;
        }

        [DisplayName("Password Hash"), Size(86), NotNull]
        public string PasswordHash
        {
            get => fields.PasswordHash[this];
            set => fields.PasswordHash[this] = value;
        }

        [DisplayName("Password Salt"), Size(10), NotNull]
        public string PasswordSalt
        {
            get => fields.PasswordSalt[this];
            set => fields.PasswordSalt[this] = value;
        }
        [DisplayName("Password SAP"), Size(10)]
        public string PasswordSAP
        {
            get => fields.PasswordSAP[this];
            set => fields.PasswordSAP[this] = value;
        }
        

        [DisplayName("Last Directory Update")]
        public DateTime? LastDirectoryUpdate
        {
            get => fields.LastDirectoryUpdate[this];
            set => fields.LastDirectoryUpdate[this] = value;
        }

        [DisplayName("User Image"), Size(100)]
        public string UserImage
        {
            get => fields.UserImage[this];
            set => fields.UserImage[this] = value;
        }

        [DisplayName("Insert Date"), NotNull]
        public DateTime? InsertDate
        {
            get => fields.InsertDate[this];
            set => fields.InsertDate[this] = value;
        }

        [DisplayName("Insert User Id"), NotNull]
        public int? InsertUserId
        {
            get => fields.InsertUserId[this];
            set => fields.InsertUserId[this] = value;
        }

        [DisplayName("Update Date")]
        public DateTime? UpdateDate
        {
            get => fields.UpdateDate[this];
            set => fields.UpdateDate[this] = value;
        }

        [DisplayName("Update User Id")]
        public int? UpdateUserId
        {
            get => fields.UpdateUserId[this];
            set => fields.UpdateUserId[this] = value;
        }

        [DisplayName("Company Database"), Size(255), CompanyDatabaseValuesEditor]
        public string CompanyDatabase
        {
            get => fields.CompanyDatabase[this];
            set => fields.CompanyDatabase[this] = value;
        }
        [DisplayName("Warehouse Code")]
        public string WarehouseCode
        {
            get => fields.WarehouseCode[this];
            set => fields.WarehouseCode[this] = value;
        }

        [DisplayName("Is Active"), NotNull]
        public short? IsActive
        {
            get => fields.IsActive[this];
            set => fields.IsActive[this] = value;
        }
        [DisplayName("Reports Detail"), MasterDetailRelation(foreignKey: "UserId"), NotMapped]
        public System.Collections.Generic.List<Report_UsersRow> DetailList
        {
            get { return Fields.DetailList[this]; }
            set { Fields.DetailList[this] = value; }
        }
        public UsersRow()
            : base()
        {
        }
        
        public UsersRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field UserId;
            public StringField Username;
            public StringField DisplayName;
            public StringField Email;
            public StringField Source;
            public StringField PasswordHash;
            public StringField PasswordSalt;
            public StringField PasswordSAP;
            public DateTimeField LastDirectoryUpdate;
            public StringField UserImage;
            public DateTimeField InsertDate;
            public Int32Field InsertUserId;
            public DateTimeField UpdateDate;
            public Int32Field UpdateUserId;
            public StringField CompanyDatabase;
            public StringField WarehouseCode;
            public Int16Field IsActive;
            public RowListField<Report_UsersRow> DetailList;
        }
    }
}
