using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[Settings]")]
    [DisplayName("Settings"), InstanceName("Settings")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class SettingsRow : Row<SettingsRow.RowFields>, IIdRow, INameRow
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

        [DisplayName("List Data Source"), Size(255), QuickSearch, NameProperty]
        public string ListDataSource
        {
            get => fields.ListDataSource[this];
            set => fields.ListDataSource[this] = value;
        }

        [DisplayName("Post By Method"), Size(255)]
        public string PostByMethod
        {
            get => fields.PostByMethod[this];
            set => fields.PostByMethod[this] = value;
        }

        [DisplayName("Is Hana")]
        public bool? IsHana
        {
            get => fields.IsHana[this];
            set => fields.IsHana[this] = value;
        }

        public SettingsRow()
            : base()
        {
        }

        public SettingsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public Int32Field UserId;
            public Int32Field ModuleName;
            public StringField ListDataSource;
            public StringField PostByMethod;
            public BooleanField IsHana;
        }
    }
}
