using SAPWebPortal.Membership;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using SAPWebPortal.Common.PermissionsKeys;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[RecordCounts]")]
    [DisplayName("Record Counts"), InstanceName("Record Counts")]
    [InsertPermission(MasterDataPermissionKeys.RecordCounts.Insert)]
    [ModifyPermission(MasterDataPermissionKeys.RecordCounts.Modify)]
    [DeletePermission(MasterDataPermissionKeys.RecordCounts.Delete)]
    [ReadPermission(MasterDataPermissionKeys.RecordCounts.View)]
    public sealed class RecordCountsRow : Row<RecordCountsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public long? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Module Name"), Size(255), NotNull, QuickSearch, NameProperty]
        public string ModuleName
        {
            get => fields.ModuleName[this];
            set => fields.ModuleName[this] = value;
        }

        [DisplayName("Object Type"), NotNull, SAPObjectsValuesEditor, QuickFilter]
        public int? ObjectType
        {
            get => fields.ObjectType[this];
            set => fields.ObjectType[this] = value;
        }

        [DisplayName("Company"), Size(255), NotNull, CompanyDatabaseValuesEditor, QuickSearch, QuickFilter]
        public string Company
        {
            get => fields.Company[this];
            set => fields.Company[this] = value;
        }

        [DisplayName("Number of Records")]
        public int? Counts
        {
            get => fields.Counts[this];
            set => fields.Counts[this] = value;
        }

        [DisplayName("Date Time"), DisplayFormat("dd/MM/yyyy HH:mm:ss")]
        public DateTime? DateTimeStamp
        {
            get => fields.DateTimeStamp[this];
            set => fields.DateTimeStamp[this] = value;
        }

        public RecordCountsRow()
            : base()
        {
        }

        public RecordCountsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field Id;
            public StringField ModuleName;
            public Int32Field ObjectType;
            public StringField Company;
            public Int32Field Counts;
            public DateTimeField DateTimeStamp;
        }
    }
}
