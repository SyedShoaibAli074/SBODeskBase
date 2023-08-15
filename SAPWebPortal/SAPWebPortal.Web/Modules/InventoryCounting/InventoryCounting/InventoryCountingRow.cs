using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.InventoryCounting
{
    [ConnectionKey("Default"), Module("InventoryCountings"), ServiceLayer("InventoryCountings")]
    [DisplayName("Inventory Counting"), InstanceName("Inventory Counting")]
    [ReadPermission("InventoryCounting")]
    [ModifyPermission("InventoryCounting")]
    [NotMapped]
    public sealed class InventoryCountingRow : Row<InventoryCountingRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Document Entry"), NotNull, IdProperty]
        [SAPDBFieldName("DocEntry")]
        [NotMapped]
        [SAPPrimaryKeyAttribute]
        public Int32? DocumentEntry
        {
            get => fields.DocumentEntry[this];
            set => fields.DocumentEntry[this] = value;
        }

        [DisplayName("Document Number"), NotNull]
        [SAPDBFieldName("DocNum")]
        [NotMapped]
        public Int32? DocumentNumber
        {
            get => fields.DocumentNumber[this];
            set => fields.DocumentNumber[this] = value;
        }

        [DisplayName("Series"), NotNull]
        [SAPDBFieldName("Series")]
        [NotMapped]
        public Int32? Series
        {
            get => fields.Series[this];
            set => fields.Series[this] = value;
        }

        [DisplayName("Count Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("CountDate")]
        public DateTimeOffset? CountDate
        {
            get => fields.CountDate[this];
            set => fields.CountDate[this] = value;
        }
          
        [DisplayName("Single Counter Id"), Column("SingleCounterID"), NotNull]
        [NotMapped] 
        public Int32? SingleCounterId
        {
            get => fields.SingleCounterId[this];
            set => fields.SingleCounterId[this] = value;
        }

        [DisplayName("Document Status"), NotNull]
        [NotMapped]
        public Int32? DocumentStatus
        {
            get => fields.DocumentStatus[this];
            set => fields.DocumentStatus[this] = value;
        }

        [DisplayName("Remarks"), NotNull, QuickSearch, NameProperty]
        [NotMapped]
        [SAPDBFieldName("Remarks")]
        public String? Remarks
        {
            get => fields.Remarks[this];
            set => fields.Remarks[this] = value;
        }

        [DisplayName("Reference2"), NotNull]
        [NotMapped]
        public String? Reference2
        {
            get => fields.Reference2[this];
            set => fields.Reference2[this] = value;
        } 
  
        //[DisplayName("Counting Type"), NotNull]
        //[NotMapped]
        //public Int32? CountingType
        //{
        //    get => fields.CountingType[this];
        //    set => fields.CountingType[this] = value;
        //}
         

              
        //public String U_CounterUser
        //{
        //    get => fields.U_CounterUser[this];
        //    set => fields.U_CounterUser[this] = value;
        //}
        public System.Collections.Generic.List<InventoryCountingLineRow> InventoryCountingLines
        {
            get => fields.InventoryCountingLines[this];
            set => fields.InventoryCountingLines[this] = value;
        }
        [DisplayName("DBName"), NotNull, RemoveFromEntity]
        [NotMapped]
        public String? DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }
        public InventoryCountingRow()
            : base()
        {
        }

        public InventoryCountingRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DocumentEntry;
            public Int32Field DocumentNumber;
            public Int32Field Series;
            public DateTimeOffsetField CountDate;
            //public StringField U_CounterUser;
            public Int32Field SingleCounterId;
            public Int32Field DocumentStatus;
            public StringField Remarks;
            public StringField Reference2;
            public StringField DBName;
            //public Int32Field CountingType; 
            public RowListField<InventoryCountingLineRow> InventoryCountingLines;
            
        }
    }
}
