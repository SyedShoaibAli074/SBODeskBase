using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[SapDatabases]")]
    [DisplayName("Sap Databases"), InstanceName("Sap Databases")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [LookupScript("Default.SapDatabases")]

    public sealed class SapDatabasesRow : Row<SapDatabasesRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int64? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Server Name"), Size(255), NotNull, QuickSearch]
        public String ServerName
        {
            get => fields.ServerName[this];
            set => fields.ServerName[this] = value;
        }
        [DisplayName("ODBC Server Name"), Size(255), NotNull, QuickSearch]
        public String ODBCServer
        {
            get => fields.ODBCServer[this];
            set => fields.ODBCServer[this] = value;
        }
        //DbServerTypeValuesEditor
        [DisplayName("Db Server Type"), DbServerTypeValuesEditor, Column("DBServerType"), Size(255), NotNull]
        public String DbServerType
        {
            get => fields.DbServerType[this];
            set => fields.DbServerType[this] = value;
        }

        [DisplayName("License Server"), Size(255), NotNull]
        public String LicenseServer
        {
            get => fields.LicenseServer[this];
            set => fields.LicenseServer[this] = value;
        }

        [DisplayName("Company Db"), Column("CompanyDB"), Size(255), NotNull, NameProperty, LookupInclude]
        public String CompanyDb
        {
            get => fields.CompanyDb[this];
            set => fields.CompanyDb[this] = value;
        }

        [DisplayName("DB User Name"), Column("DBUserName"), Size(255), NotNull]
        public String DbUserName
        {
            get => fields.DbUserName[this];
            set => fields.DbUserName[this] = value;
        }

        [DisplayName("DB Password"), Column("DBPassword"), Size(255), NotNull, PasswordEditor]
        public String DbPassword
        {
            get => fields.DbPassword[this];
            set => fields.DbPassword[this] = value;
        }

        [DisplayName("User Name"), Size(255), NotNull]
        public String UserName
        {
            get => fields.UserName[this];
            set => fields.UserName[this] = value;
        }

        [DisplayName("Password"), Size(255), NotNull, PasswordEditor]
        public String Password
        {
            get => fields.Password[this];
            set => fields.Password[this] = value;
        }

        [DisplayName("Alias"), Size(255), NotNull]
        public String Alias
        {
            get => fields.Alias[this];
            set => fields.Alias[this] = value;
        }

        [DisplayName("Service Layer Url"), Column("ServiceLayerURL"), Size(255)]
        public String ServiceLayerUrl
        {
            get => fields.ServiceLayerUrl[this];
            set => fields.ServiceLayerUrl[this] = value;
        }
        [DisplayName("Service Layer Version"), Column("ServiceLayerVersion"), Size(255)]
        public String ServiceLayerVersion
        {
            get => fields.ServiceLayerVersion[this];
            set => fields.ServiceLayerVersion[this] = value;
        }
        [DisplayName("DBDriver"), Column("DBDriver"),DefaultValue("HDBODBC"), DBDriverEditor]
        public String DBDriver
        {
            get => fields.DBDriver[this];
            set => fields.DBDriver[this] = value;
        }

        [DisplayName("Is Default"), Column("IsDefault")] 
        public Boolean? IsDefault
        {
            get => fields.IsDefault[this];
            set => fields.IsDefault[this] = value;
        }
        [DisplayName("CreateUDFs"), NotMapped]
        public Int16? CreateUDFs
        {
            get { return Fields.CreateUDFs[this]; }
            set { Fields.CreateUDFs[this] = value; }
        }
        //udf field
        [DisplayName("UDFs Response"), TextAreaEditor]
        public String UDFs
        {
            get => fields.UDFs[this];
            set => fields.UDFs[this] = value;
        }

        public SapDatabasesRow()
            : base()
        {
        }

        public SapDatabasesRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public StringField ServerName;
            public StringField ODBCServer;
            public StringField DbServerType;
            public StringField LicenseServer;
            public StringField CompanyDb;
            public StringField DbUserName;
            public StringField DbPassword;
            public StringField UserName;
            public StringField Password;
            public StringField Alias;
            public StringField ServiceLayerUrl;
            public StringField ServiceLayerVersion;
            public StringField DBDriver;
            public BooleanField IsDefault;
            public Int16Field CreateUDFs;
            public StringField UDFs;
        }
    }
}
