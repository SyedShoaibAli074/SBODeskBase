using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[UserFormAuthorizations]")]
    [DisplayName("User Form Authorizations"), InstanceName("User Form Authorizations")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class UserFormAuthorizationsRow : Row<UserFormAuthorizationsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("User Id")]
        public int? UserId
        {
            get => fields.UserId[this];
            set => fields.UserId[this] = value;
        }

        [DisplayName("Module Name")]
        public int? ModuleName
        {
            get => fields.ModuleName[this];
            set => fields.ModuleName[this] = value;
        }

        [DisplayName("Company Db"), Column("CompanyDB"), Size(255), QuickSearch, NameProperty]
        public string CompanyDb
        {
            get => fields.CompanyDb[this];
            set => fields.CompanyDb[this] = value;
        }

        [DisplayName("Form Name"), Size(255)]
        public string FormName
        {
            get => fields.FormName[this];
            set => fields.FormName[this] = value;
        }

        [DisplayName("Form Title"), Size(255)]
        public string FormTitle
        {
            get => fields.FormTitle[this];
            set => fields.FormTitle[this] = value;
        }

        [DisplayName("Form Description"), Size(255)]
        public string FormDescription
        {
            get => fields.FormDescription[this];
            set => fields.FormDescription[this] = value;
        }
        [DisplayName("Details"), MasterDetailRelation(foreignKey: "UserFormAuthorizationId")]
        [NotMapped]
        public System.Collections.Generic.List<UserFormAuthorizationsDetailsRow> DetailList
        {
            get => fields.DetailList[this];
            set => fields.DetailList[this] = value;
        }
        public UserFormAuthorizationsRow()
            : base()
        {
        }

        public UserFormAuthorizationsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public Int32Field UserId;
            public Int32Field ModuleName;
            public StringField CompanyDb;
            public StringField FormName;
            public StringField FormTitle;
            public StringField FormDescription;

            public RowListField<UserFormAuthorizationsDetailsRow> DetailList;
        }
    }
}
