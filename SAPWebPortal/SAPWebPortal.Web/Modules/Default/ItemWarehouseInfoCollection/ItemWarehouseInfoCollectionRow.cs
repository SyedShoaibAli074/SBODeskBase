using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default")/*, TableName("[dbo].[OITW]")*/]
    [DisplayName("Item Warehouse Info Collection"), InstanceName("Item Warehouse Info Collection")]
    [ReadPermission(Common.PermissionsKeys.MasterDataPermissionKeys.General)]
    [ModifyPermission(Common.PermissionsKeys.MasterDataPermissionKeys.General)]
    public sealed class ItemWarehouseInfoCollectionRow : Row<ItemWarehouseInfoCollectionRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Item Code"), Size(10), NotNull, IdProperty, QuickSearch, NameProperty]
        public string ItemCode
        {
            get => fields.ItemCode[this];
            set => fields.ItemCode[this] = value;
        }
        [DisplayName("Warehouse Code"), Size(10), NotNull]
        public string WarehouseCode
        {
            get => fields.WarehouseCode[this];
            set => fields.WarehouseCode[this] = value;
        }
        [DisplayName("InStock"), Size(10), NotNull]
        public Decimal? InStock
        {
            get => fields.InStock[this];
            set => fields.InStock[this] = value;
        }
        [DisplayName("Committed"), Size(10), NotNull]
        public Decimal? Committed
        {
            get => fields.Committed[this];
            set => fields.Committed[this] = value;
        }
        [DisplayName("Ordered"), Size(10), NotNull]
        public Decimal? Ordered
        {
            get => fields.Ordered[this];
            set => fields.Ordered[this] = value;
        }
        [DisplayName("Counted Quantity"), Size(10), NotNull]
        public Decimal? CountedQuantity
        {
            get => fields.CountedQuantity[this];
            set => fields.CountedQuantity[this] = value;
        }
        public ItemWarehouseInfoCollectionRow()
            : base()
        {
        }

        public ItemWarehouseInfoCollectionRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField ItemCode;
            public StringField WarehouseCode;
            public DecimalField InStock;
            public DecimalField Committed;
            public DecimalField Ordered;
            public DecimalField CountedQuantity;
        }
    }
}
