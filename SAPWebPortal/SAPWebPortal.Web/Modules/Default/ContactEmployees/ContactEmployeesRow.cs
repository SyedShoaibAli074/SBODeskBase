using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default")/*, TableName("[dbo].[OCPR]")*/]
    [DisplayName("Contact Employees"), InstanceName("Contact Employees")]
    [ReadPermission("ContactEmployees")]
    [ModifyPermission("ContactEmployees")]
    public sealed class ContactEmployeesRow : Row<ContactEmployeesRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Card Code"), Size(10), NotNull, IdProperty, QuickSearch, NameProperty]
        public string CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }
        [DisplayName("Name"), Size(255), NotMapped]
        public string Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }
        [DisplayName("Position"), Size(255), NotMapped]
        public string Position
        {
            get => fields.Position[this];
            set => fields.Position[this] = value;
        }
        [DisplayName("Address"), Size(255), NotMapped]
        public string Address
        {
            get => fields.Address[this];
            set => fields.Address[this] = value;
        }
        [DisplayName("Phone"), Size(255), NotMapped]
        public string Phone1
        {
            get => fields.Phone1[this];
            set => fields.Phone1[this] = value;
        }
        [DisplayName("E_Mail"), Size(255), NotMapped]
        public string E_Mail
        {
            get => fields.E_Mail[this];
            set => fields.E_Mail[this] = value;
        }
        [DisplayName("First Name"), Size(255), NotMapped]
        public string FirstName
        {
            get => fields.FirstName[this];
            set => fields.FirstName[this] = value;
        }
        [DisplayName("Middle Name"), Size(255), NotMapped]
        public string MiddleName
        {
            get => fields.MiddleName[this];
            set => fields.MiddleName[this] = value;
        }
        [DisplayName("Last Name"), Size(255), NotMapped]
        public string LastName
        {
            get => fields.LastName[this];
            set => fields.LastName[this] = value;
        }
        [DisplayName("Email Group Code"), Size(255), NotMapped]
        public string EmailGroupCode
        {
            get => fields.EmailGroupCode[this];
            set => fields.EmailGroupCode[this] = value;
        }
        [DisplayName("Active"), Size(255), NotMapped]
        public string Active
        {
            get => fields.Active[this];
            set => fields.Active[this] = value;
        }
        public ContactEmployeesRow()
            : base()
        {
        }

        public ContactEmployeesRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField CardCode;
            public StringField Name;
            public StringField Position;
            public StringField Address;
            public StringField Phone1;
            public StringField E_Mail;
            public StringField FirstName;
            public StringField MiddleName;
            public StringField EmailGroupCode;
            public StringField LastName;
            public StringField Active;


        }
    }
}
