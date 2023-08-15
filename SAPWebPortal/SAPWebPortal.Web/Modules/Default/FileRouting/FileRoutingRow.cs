using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[FileRouting]")]
    [DisplayName("Report File"), InstanceName("Report File")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    public sealed class FileRoutingRow : Row<FileRoutingRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public Int64? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Name"), Size(255), NotNull, QuickSearch, NameProperty]
        public String Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }
        [DisplayName("Company Name"), Size(255), NotNull, SAPCompanyEditor, QuickSearch,QuickFilter]
       
        public String CompanyDB
        {
            get => fields.CompanyDB[this];
            set => fields.CompanyDB[this] = value;
        }
        [DisplayName("Object Type"), Column("SLObjectType"), Size(254), NotNull,SAPObectsValuesEditor ]
        public String SlObjectType
        {
            get => fields.SlObjectType[this];
            set => fields.SlObjectType[this] = value;
        }

        [DisplayName("Report Path"), NotNull]

        [FileUploadEditor(FilenameFormat = "Files/Uploads/~", AllowNonImage = true, CopyToHistory = true)]
        public String ReportPath
        {
            get => fields.ReportPath[this];
            set => fields.ReportPath[this] = value;
        }
        [DisplayName("FileName Template"),Visible(false)]
        public String FileNameTemplate
        {
            get => fields.FileNameTemplate[this];
            set => fields.FileNameTemplate[this] = value;
        }
        
        [DisplayName("Rdoc Code"), Column("RDOC_Code"), Size(255),Visible (false )]
        public String RdocCode
        {
            get => fields.RdocCode[this];
            set => fields.RdocCode[this] = value;
        }

        [DisplayName("Export Extension"), Size(10), ExtensionsValuesEditor]
        public String ExportExtension
        {
            get => fields.ExportExtension[this];
            set => fields.ExportExtension[this] = value;
        }
        [DisplayName("ExportPath"), NotNull]
        public String ExportPath
        {
            get => fields.ExportPath[this];
            set => fields.ExportPath[this] = value;
        }

        public FileRoutingRow()
            : base()
        {
        }

        public FileRoutingRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public StringField Name;
            public StringField SlObjectType;
            public StringField ReportPath;
            public StringField RdocCode;
            public StringField ExportExtension;
            public StringField FileNameTemplate;
            public StringField ExportPath;  
            public StringField CompanyDB;
        }
    }
}
