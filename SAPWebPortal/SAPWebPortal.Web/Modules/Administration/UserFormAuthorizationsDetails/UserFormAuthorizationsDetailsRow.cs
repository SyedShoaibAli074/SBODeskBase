using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[UserFormAuthorizationsDetails]")]
    [DisplayName("User Form Authorizations Details"), InstanceName("User Form Authorizations Details")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class UserFormAuthorizationsDetailsRow : Row<UserFormAuthorizationsDetailsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("User Form Authorization Id")]
        public int? UserFormAuthorizationId
        {
            get => fields.UserFormAuthorizationId[this];
            set => fields.UserFormAuthorizationId[this] = value;
        }

        [DisplayName("Field Name"), Size(255), QuickSearch, NameProperty]
        public string FieldName
        {
            get => fields.FieldName[this];
            set => fields.FieldName[this] = value;
        }

        [DisplayName("Field Description"), Size(255)]
        public string FieldDescription
        {
            get => fields.FieldDescription[this];
            set => fields.FieldDescription[this] = value;
        }

        [DisplayName("Data Type"), Size(255)]
        public string DataType
        {
            get => fields.DataType[this];
            set => fields.DataType[this] = value;
        }

        [DisplayName("Default Value"), Size(255)]
        public string DefaultValue
        {
            get => fields.DefaultValue[this];
            set => fields.DefaultValue[this] = value;
        }

        [DisplayName("Data Size"), Size(255)]
        public string DataSize
        {
            get => fields.DataSize[this];
            set => fields.DataSize[this] = value;
        }

        [DisplayName("Readonly")]
        public bool? Readonly
        {
            get => fields.Readonly[this];
            set => fields.Readonly[this] = value;
        }

        [DisplayName("Required")]
        public bool? Required
        {
            get => fields.Required[this];
            set => fields.Required[this] = value;
        }

        [DisplayName("Visible")]
        public bool? Visible
        {
            get => fields.Visible[this];
            set => fields.Visible[this] = value;
        }

        [DisplayName("Html Class"), Column("HTMLClass"), Size(255)]
        public string HtmlClass
        {
            get => fields.HtmlClass[this];
            set => fields.HtmlClass[this] = value;
        }

        [DisplayName("Html Style"), Column("HTMLStyle"), Size(255)]
        public string HtmlStyle
        {
            get => fields.HtmlStyle[this];
            set => fields.HtmlStyle[this] = value;
        }

        [DisplayName("Html Attributes"), Column("HTMLAttributes"), Size(255)]
        public string HtmlAttributes
        {
            get => fields.HtmlAttributes[this];
            set => fields.HtmlAttributes[this] = value;
        }

        public UserFormAuthorizationsDetailsRow()
            : base()
        {
        }

        public UserFormAuthorizationsDetailsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public Int32Field UserFormAuthorizationId;
            public StringField FieldName;
            public StringField FieldDescription;
            public StringField DataType;
            public StringField DefaultValue;
            public StringField DataSize;
            public BooleanField Readonly;
            public BooleanField Required;
            public BooleanField Visible;
            public StringField HtmlClass;
            public StringField HtmlStyle;
            public StringField HtmlAttributes;
        }
    }
}
