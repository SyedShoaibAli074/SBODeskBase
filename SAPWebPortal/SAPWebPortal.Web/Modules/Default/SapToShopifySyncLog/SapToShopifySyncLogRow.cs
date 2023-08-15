using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), TableName("[dbo].[SAPToShopifySyncLog]")]
    [DisplayName("Sap To Shopify Sync Log"), InstanceName("Sap To Shopify Sync Log")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class SapToShopifySyncLogRow : Row<SapToShopifySyncLogRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity, IdProperty]
        public int? Id
        {
            get => fields.Id[this];
            set => fields.Id[this] = value;
        }

        [DisplayName("Doc Entry"), Size(255), QuickSearch, NameProperty]
        public string DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }

        [DisplayName("Sync Status"), Size(255)]
        public string SyncStatus
        {
            get => fields.SyncStatus[this];
            set => fields.SyncStatus[this] = value;
        }

        [DisplayName("Target Store Id"), Size(255)]
        public string TargetStoreId
        {
            get => fields.TargetStoreId[this];
            set => fields.TargetStoreId[this] = value;
        }

        [DisplayName("Source Obj Type"), Size(255)]
        public string SourceObjType
        {
            get => fields.SourceObjType[this];
            set => fields.SourceObjType[this] = value;
        }

        [DisplayName("Sync Time")]
        public string? SyncTime
        {
            get => fields.SyncTime[this];
            set => fields.SyncTime[this] = value;
        }

        public SapToShopifySyncLogRow()
            : base()
        {
        }

        public SapToShopifySyncLogRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField DocEntry;
            public StringField SyncStatus;
            public StringField TargetStoreId;
            public StringField SourceObjType;
            public StringField SyncTime;
        }
    }
}
