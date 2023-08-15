using SAPWebPortal.Common.PermissionsKeys;
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
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[Reports]")]
    [DisplayName("Reports"), InstanceName("Reports")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [LookupScript]

    public sealed class ReportsRow : Row<ReportsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Rdocid"), Column("RDOCID"), Identity, IdProperty, LookupInclude]
        public int? Rdocid
        {
            get => fields.Rdocid[this];
            set => fields.Rdocid[this] = value;
        }

        [DisplayName("Report Name"), Size(100), QuickSearch, NameProperty, LookupInclude]
        public string RptName
        {
            get => fields.RptName[this];
            set => fields.RptName[this] = value;
        }

        [DisplayName("Rpt Byte Array"), Column("Rpt_Byte_Array")]
        [FileUploadEditor(FilenameFormat = "{4}")]
        public string RptByteArray
        {
            get => fields.RptByteArray[this];
            set => fields.RptByteArray[this] = value;
        }

        [DisplayName("Create Date"), Column("Create_date"), NotNull]
        public DateTime? CreateDate
        {
            get => fields.CreateDate[this];
            set => fields.CreateDate[this] = value;
        }

        [DisplayName("Update Date"), Column("Update_date")]
        public DateTime? UpdateDate
        {
            get => fields.UpdateDate[this];
            set => fields.UpdateDate[this] = value;
        }

       
        [DisplayName("Database Name"), Column("DB_Name")]
        [CompanyDatabaseValuesEditor]
        public String DB_Name
        {
            get { return Fields.DB_Name[this]; }
            set { Fields.DB_Name[this] = value; }
        }
        
        public ReportsRow()
            : base()
        {
        }

        public ReportsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Rdocid;
            public StringField RptName;
            public StringField RptByteArray;
            public DateTimeField CreateDate;
            public DateTimeField UpdateDate;
            public StringField DB_Name;
        }
    }
}
