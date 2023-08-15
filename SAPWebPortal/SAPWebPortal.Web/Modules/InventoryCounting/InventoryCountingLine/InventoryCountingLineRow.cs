using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.InventoryCounting
{
    [ConnectionKey("Default"), Module("InventoryCounting"), ServiceLayer("InventoryCountingLine")]
    [DisplayName("Inventory Counting Line"), InstanceName("Inventory Counting Line")]
    [ReadPermission("InventoryCounting")]
    [ModifyPermission("InventoryCounting")]
    [NotMapped]
    public sealed class InventoryCountingLineRow : Row<InventoryCountingLineRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Document Entry"), NotNull, IdProperty]
        [NotMapped]
        public Int32? DocumentEntry
        {
            get => fields.DocumentEntry[this];
            set => fields.DocumentEntry[this] = value;
        }

        [DisplayName("Line Number"), NotNull]
        [NotMapped]
        public Int32? LineNumber
        {
            get => fields.LineNumber[this];
            set => fields.LineNumber[this] = value;
        }

        [DisplayName("Item Code"), NotNull, QuickSearch, NameProperty]
        [NotMapped]
        public String? ItemCode
        {
            get => fields.ItemCode[this];
            set => fields.ItemCode[this] = value;
        }

        [DisplayName("Item Description"), NotNull]
        [NotMapped]
        public String? ItemDescription
        {
            get => fields.ItemDescription[this];
            set => fields.ItemDescription[this] = value;
        }

        [DisplayName("Freeze"), NotNull]
        [NotMapped]
        public String? Freeze
        {
            get => fields.Freeze[this];
            set => fields.Freeze[this] = value;
        }

        [DisplayName("Warehouse Code"), NotNull]
        [NotMapped]
        public String? WarehouseCode
        {
            get => fields.WarehouseCode[this];
            set => fields.WarehouseCode[this] = value;
        }

        [DisplayName("Bin Entry"), NotNull]
        [NotMapped]
        public Int32? BinEntry
        {
            get => fields.BinEntry[this];
            set => fields.BinEntry[this] = value;
        }

        [DisplayName("In Warehouse Quantity"), NotNull]
        [NotMapped]
        public Double? InWarehouseQuantity
        {
            get => fields.InWarehouseQuantity[this];
            set => fields.InWarehouseQuantity[this] = value;
        }

        [DisplayName("Counted"), NotNull]
        [NotMapped]
        public String? Counted
        {
            get => fields.Counted[this];
            set => fields.Counted[this] = value;
        }

        [DisplayName("UoM Code"), NotNull]
        [NotMapped]
        public String? UoMCode
        {
            get => fields.UoMCode[this];
            set => fields.UoMCode[this] = value;
        }

        //[DisplayName("Bar Code"), NotNull]
        //[NotMapped]
        //public String? BarCode
        //{
        //    get => fields.BarCode[this];
        //    set => fields.BarCode[this] = value;
        //}

        //[DisplayName("Uo M Counted Quantity"), NotNull]
        //[NotMapped]
        //public Double? UoMCountedQuantity
        //{
        //    get => fields.UoMCountedQuantity[this];
        //    set => fields.UoMCountedQuantity[this] = value;
        //}

        //[DisplayName("Items Per Unit"), NotNull]
        //[NotMapped]
        //public Double? ItemsPerUnit
        //{
        //    get => fields.ItemsPerUnit[this];
        //    set => fields.ItemsPerUnit[this] = value;
        //}

        [DisplayName("Counted Quantity"), NotNull]
        [NotMapped]
        public Double? CountedQuantity
        {
            get => fields.CountedQuantity[this];
            set => fields.CountedQuantity[this] = value;
        }

        //[DisplayName("Variance"), NotNull]
        //[NotMapped]
        //public Double? Variance
        //{
        //    get => fields.Variance[this];
        //    set => fields.Variance[this] = value;
        //}

        //[DisplayName("Variance Percentage"), NotNull]
        //[NotMapped]
        //public Double? VariancePercentage
        //{
        //    get => fields.VariancePercentage[this];
        //    set => fields.VariancePercentage[this] = value;
        //}

        //[DisplayName("Visual Order"), NotNull]
        //[NotMapped]
        //public Int32? VisualOrder
        //{
        //    get => fields.VisualOrder[this];
        //    set => fields.VisualOrder[this] = value;
        //}

        //[DisplayName("Target Entry"), NotNull]
        //[NotMapped]
        //public Int32? TargetEntry
        //{
        //    get => fields.TargetEntry[this];
        //    set => fields.TargetEntry[this] = value;
        //}

        //[DisplayName("Target Line"), NotNull]
        //[NotMapped]
        //public Int32? TargetLine
        //{
        //    get => fields.TargetLine[this];
        //    set => fields.TargetLine[this] = value;
        //}

        //[DisplayName("Target Type"), NotNull]
        //[NotMapped]
        //public Int32? TargetType
        //{
        //    get => fields.TargetType[this];
        //    set => fields.TargetType[this] = value;
        //}

        //[DisplayName("Target Reference"), NotNull]
        //[NotMapped]
        //public String? TargetReference
        //{
        //    get => fields.TargetReference[this];
        //    set => fields.TargetReference[this] = value;
        //}

        //[DisplayName("Project Code"), NotNull]
        //[NotMapped]
        //public String? ProjectCode
        //{
        //    get => fields.ProjectCode[this];
        //    set => fields.ProjectCode[this] = value;
        //}

        //[DisplayName("Manufacturer"), NotNull]
        //[NotMapped]
        //public Int32? Manufacturer
        //{
        //    get => fields.Manufacturer[this];
        //    set => fields.Manufacturer[this] = value;
        //}

        //[DisplayName("Supplier Catalog No"), NotNull]
        //[NotMapped]
        //public String? SupplierCatalogNo
        //{
        //    get => fields.SupplierCatalogNo[this];
        //    set => fields.SupplierCatalogNo[this] = value;
        //}

        //[DisplayName("Preferred Vendor"), NotNull]
        //[NotMapped]
        //public String? PreferredVendor
        //{
        //    get => fields.PreferredVendor[this];
        //    set => fields.PreferredVendor[this] = value;
        //}

        //[DisplayName("Costing Code"), NotNull]
        //[NotMapped]
        //public String? CostingCode
        //{
        //    get => fields.CostingCode[this];
        //    set => fields.CostingCode[this] = value;
        //}

        //[DisplayName("Costing Code2"), NotNull]
        //[NotMapped]
        //public String? CostingCode2
        //{
        //    get => fields.CostingCode2[this];
        //    set => fields.CostingCode2[this] = value;
        //}

        //[DisplayName("Costing Code3"), NotNull]
        //[NotMapped]
        //public String? CostingCode3
        //{
        //    get => fields.CostingCode3[this];
        //    set => fields.CostingCode3[this] = value;
        //}

        //[DisplayName("Costing Code4"), NotNull]
        //[NotMapped]
        //public String? CostingCode4
        //{
        //    get => fields.CostingCode4[this];
        //    set => fields.CostingCode4[this] = value;
        //}

        //[DisplayName("Costing Code5"), NotNull]
        //[NotMapped]
        //public String? CostingCode5
        //{
        //    get => fields.CostingCode5[this];
        //    set => fields.CostingCode5[this] = value;
        //}

        //[DisplayName("Remarks"), NotNull]
        //[NotMapped]
        //public String? Remarks
        //{
        //    get => fields.Remarks[this];
        //    set => fields.Remarks[this] = value;
        //}
         

        //[DisplayName("Counter Id"), Column("CounterID"), NotNull]
        //[NotMapped]
        //public Int32? CounterId
        //{
        //    get => fields.CounterId[this];
        //    set => fields.CounterId[this] = value;
        //}
 

        public InventoryCountingLineRow()
            : base()
        {
        }

        public InventoryCountingLineRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DocumentEntry;
            public Int32Field LineNumber;
            public StringField ItemCode;
            public StringField ItemDescription;
            public StringField Freeze;
            public StringField WarehouseCode;
            public Int32Field BinEntry;
            public DoubleField InWarehouseQuantity;
            public StringField Counted;
            public StringField UoMCode;
            //public StringField BarCode;
            //public DoubleField UoMCountedQuantity;
            //public DoubleField ItemsPerUnit;
            public DoubleField CountedQuantity;
            //public DoubleField Variance;
            //public DoubleField VariancePercentage;
            //public Int32Field VisualOrder;
            //public Int32Field TargetEntry;
            //public Int32Field TargetLine;
            //public Int32Field TargetType;
            //public StringField TargetReference;
            //public StringField ProjectCode;
            //public Int32Field Manufacturer;
            //public StringField SupplierCatalogNo;
            //public StringField PreferredVendor;
            //public StringField CostingCode;
            //public StringField CostingCode2;
            //public StringField CostingCode3;
            //public StringField CostingCode4;
            //public StringField CostingCode5;
            //public StringField Remarks; 
            //public Int32Field CounterId;
            //public SAPB1.MultipleCounterRoleEnumField MultipleCounterRole;
            //public Collections.ObjectModel.Collection`1SAPB1.InventoryCountingLineUoMField InventoryCountingLineUoMs;
            //public Collections.ObjectModel.Collection`1SAPB1.InventoryCountingSerialNumberField InventoryCountingSerialNumbers;
            //public Collections.ObjectModel.Collection`1SAPB1.InventoryCountingBatchNumberField InventoryCountingBatchNumbers;
        }
    }
}
