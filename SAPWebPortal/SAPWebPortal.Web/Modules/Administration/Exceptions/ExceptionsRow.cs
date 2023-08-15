using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[Exceptions]")]
    [DisplayName("Exceptions"), InstanceName("Exceptions")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class ExceptionsRow : Row<ExceptionsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty,SortOrder(1, descending: true)]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Guid"), Column("GUID"), NotNull]
        public Guid? Guid
        {
            get => fields.Guid[this];
            set => fields.Guid[this] = value;
        }

        [DisplayName("Application Name"), Size(50), NotNull, QuickSearch, NameProperty]
        public string ApplicationName
        {
            get => fields.ApplicationName[this];
            set => fields.ApplicationName[this] = value;
        }

        [DisplayName("Machine Name"), Size(50), NotNull]
        public string MachineName
        {
            get => fields.MachineName[this];
            set => fields.MachineName[this] = value;
        }

        [DisplayName("Creation Date"), DisplayFormat("dd/MM/yyyy HH:mm:ss"), NotNull]
        public DateTime? CreationDate
        {
            get => fields.CreationDate[this];
            set => fields.CreationDate[this] = value;
        }

        [DisplayName("Type"), Size(100), NotNull]
        public string Type
        {
            get => fields.Type[this];
            set => fields.Type[this] = value;
        }

        [DisplayName("Is Protected"), NotNull]
        public bool? IsProtected
        {
            get => fields.IsProtected[this];
            set => fields.IsProtected[this] = value;
        }

        [DisplayName("Host"), Size(100)]
        public string Host
        {
            get => fields.Host[this];
            set => fields.Host[this] = value;
        }

        [DisplayName("Url"), Size(500)]
        public string Url
        {
            get => fields.Url[this];
            set => fields.Url[this] = value;
        }

        [DisplayName("Http Method"), Column("HTTPMethod"), Size(10)]
        public string HttpMethod
        {
            get => fields.HttpMethod[this];
            set => fields.HttpMethod[this] = value;
        }

        [DisplayName("Ip Address"), Column("IPAddress"), Size(40)]
        public string IpAddress
        {
            get => fields.IpAddress[this];
            set => fields.IpAddress[this] = value;
        }

        [DisplayName("Source"), Size(100)]
        public string Source
        {
            get => fields.Source[this];
            set => fields.Source[this] = value;
        }

        [DisplayName("Message"), Size(1000)]
        public string Message
        {
            get => fields.Message[this];
            set => fields.Message[this] = value;
        }

        [DisplayName("Detail")]
        public string Detail
        {
            get => fields.Detail[this];
            set => fields.Detail[this] = value;
        }

        [DisplayName("Status Code")]
        public int? StatusCode
        {
            get => fields.StatusCode[this];
            set => fields.StatusCode[this] = value;
        }

        [DisplayName("Sql"), Column("SQL")]
        public string Sql
        {
            get => fields.Sql[this];
            set => fields.Sql[this] = value;
        }

        [DisplayName("Deletion Date")]
        public DateTime? DeletionDate
        {
            get => fields.DeletionDate[this];
            set => fields.DeletionDate[this] = value;
        }
        //DBName
        [DisplayName("DBName"), Size(50), NotNull]
        //notmapped
        [NotMapped]
   
        public string DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }
        [DisplayName("Full Json")]
        public string FullJson
        {
            get => fields.FullJson[this];
            set => fields.FullJson[this] = value;
        }

        [DisplayName("Error Hash")]
        public int? ErrorHash
        {
            get => fields.ErrorHash[this];
            set => fields.ErrorHash[this] = value;
        }

        [DisplayName("Duplicate Count"), NotNull]
        public int? DuplicateCount
        {
            get => fields.DuplicateCount[this];
            set => fields.DuplicateCount[this] = value;
        }

        public ExceptionsRow()
            : base()
        {
        }

        public ExceptionsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public GuidField Guid;
            public StringField ApplicationName;
            public StringField MachineName;
            public DateTimeField CreationDate;
            public StringField Type;
            public BooleanField IsProtected;
            public StringField Host;
            public StringField Url;
            public StringField HttpMethod;
            public StringField IpAddress;
            public StringField Source;
            public StringField Message;
            public StringField Detail;
            public Int32Field StatusCode;
            public StringField Sql;
            public DateTimeField DeletionDate;
            public StringField FullJson;
            public Int32Field ErrorHash;
            public Int32Field DuplicateCount;
            public StringField DBName;
        }
    }
}
