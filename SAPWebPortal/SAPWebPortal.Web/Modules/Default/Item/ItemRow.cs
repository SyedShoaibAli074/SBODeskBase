using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using SAPWebPortal.Common.PermissionsKeys;
using SAPWebPortal.Modules.DropDownEnums;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default")]
    [DisplayName("Item"), InstanceName("Item")]
    [InsertPermission(MasterDataPermissionKeys.Items.Insert)]
    [ModifyPermission(MasterDataPermissionKeys.Items.Modify)]
    [DeletePermission(MasterDataPermissionKeys.Items.Delete)]
    [ReadPermission(MasterDataPermissionKeys.Items.View)]
    [LookupScript("Default.Item", Permission =Common.PermissionsKeys.MasterDataPermissionKeys.General)]
    [NotMapped, ServiceLayer("Items")]
    public sealed class ItemRow : Row<ItemRow.RowFields>, IIdRow, INameRow
    {
         

        [DisplayName("Item Code"), NotNull, Size(255), IdProperty, SAPPrimaryKey, NotMapped, QuickSearch, NameProperty]
        [SAPDBFieldName("ItemCode")]
        public string ItemCode
        {
            get => fields.ItemCode[this];
            set => fields.ItemCode[this] = value;
        }
        [SAPDBFieldName("ItemName")]
        [DisplayName("Item Name"), Size(255), NotMapped, QuickSearch]
        public string ItemName
        {
            get => fields.ItemName[this];
            set => fields.ItemName[this] = value;
        }
        [SAPDBFieldName("U_ParentId")]
        [DisplayName("U_ParentId"), Size(255), NotMapped, QuickSearch]
        public string U_ParentId
        {
            get => fields.U_ParentId[this];
            set => fields.U_ParentId[this] = value;
        }
        [SAPDBFieldName("U_IsParent")]
        [DisplayName("U_IsParent"), Size(255), NotMapped, QuickSearch]
        public string U_IsParent
        {
            get => fields.U_IsParent[this];
            set => fields.U_IsParent[this] = value;
        }
        [SAPDBFieldName("U_SH_Des")]
        [DisplayName("U_SH_Des"), Size(255), NotMapped, QuickSearch]
        public string U_SH_Des
        {
            get => fields.U_SH_Des[this];
            set => fields.U_SH_Des[this] = value;
        }
        [SAPDBFieldName("U_Active")]
        [DisplayName("U_Active"), Size(255), NotMapped, QuickSearch]
        public string U_Active
        {
            get => fields.U_Active[this];
            set => fields.U_Active[this] = value;
        }
        
        [SAPDBFieldName("UserText")]
        [DisplayName("User_Text"), Size(255), NotMapped]
        public string User_Text
        {
            get => fields.User_Text[this];
            set => fields.User_Text[this] = value;
        }
        [SAPDBFieldName("FrgnName")]
        [DisplayName("Foreign Name"), Size(255), NotMapped]
        public string ForeignName
        {
            get => fields.ForeignName[this];
            set => fields.ForeignName[this] = value;
        }
        //[DisplayName("ItemsGroupCode"), Size(255), NotMapped]
        //public decimal ItemsGroupCode
        //{
        //    get => (decimal)fields.ItemsGroupCode[this];
        //    set => fields.ItemsGroupCode[this] = value;
        //}
        //[DisplayName("Customs Group Code"), Size(255), NotMapped]
        //public decimal CustomsGroupCode
        //{
        //    get => (decimal)fields.CustomsGroupCode[this];
        //    set => fields.CustomsGroupCode[this] = value;
        //}
        [DisplayName("BarCode"), Size(255), NotMapped]
        public string BarCode
        {
            get => fields.BarCode[this];
            set => fields.BarCode[this] = value;
        }
        [DisplayName("Purchase Item"), Size(255), YesOrNoEditor,NotMapped]
        public string PurchaseItem
        {
            get => fields.PurchaseItem[this];
            set => fields.PurchaseItem[this] = value;
        }
        [DisplayName("Mainsupplier"), Size(255)]
        public string Mainsupplier
        {
            get => fields.PurchaseItem[this];
            set => fields.PurchaseItem[this] = value;
        }
        [DisplayName("U_cat"), Size(255)]
        public string U_cat
        {
            get => fields.U_cat[this];
            set => fields.U_cat[this] = value;
        }
        [DisplayName("U_sub"), Size(255)]
        public string U_sub
        {
            get => fields.U_sub[this];
            set => fields.U_sub[this] = value;
        }
        [DisplayName("U_brand"), Size(255)]
        public string U_brand
        {
            get => fields.U_brand[this];
            set => fields.U_brand[this] = value;
        }
        [DisplayName("U_PID"), Size(255)]
        public string U_PID
        {
            get => fields.U_PID[this];
            set => fields.U_PID[this] = value;
        }
        [DisplayName("Sales Item"), Size(255), YesOrNoEditor, NotMapped]
        public string SalesItem
        {
            get => fields.SalesItem[this];
            set => fields.SalesItem[this] = value;
        }
        [DisplayName("Inventory Item"), Size(255), YesOrNoEditor, NotMapped]
        public string InventoryItem
        {
            get => fields.InventoryItem[this];
            set => fields.InventoryItem[this] = value;
        }
        [SAPDBFieldName("U_ItemStat")]
        [DisplayName("U_ItemStat"), Size(255), NotMapped, QuickSearch]
        public string U_ItemStat
        {
            get => fields.U_ItemStat[this];
            set => fields.U_ItemStat[this] = value;
        }
        [SAPDBFieldName("U_Yatas")]
        [DisplayName("U_Yatas"), Size(255), NotMapped, QuickSearch]
        public string U_Yatas
        {
            get => fields.U_Yatas[this];
            set => fields.U_Yatas[this] = value;
        }

        [DisplayName("U_Enza"), Size(255), NotMapped, QuickSearch]
        public string U_Enza
        {
            get => fields.U_Enza[this];
            set => fields.U_Enza[this] = value;
        }

        [DisplayName("Default Warehouse"), NotMapped]
        [SAPDBFieldName("DfltWH")]
       public string DefaultWarehouse
        {
            get => fields.DefaultWarehouse[this];
            set => fields.DefaultWarehouse[this] = value;
        }
        [DisplayName("ItemWarehouseInfoCollection"), MasterDetailRelation(foreignKey: "ItemCode"), ItemWarehouseInfoCollectionEditor, NotMapped]
        public System.Collections.Generic.List<ItemWarehouseInfoCollectionRow> ItemWarehouseInfoCollection
        {
            get => fields.ItemWarehouseInfoCollection[this];
            set => fields.ItemWarehouseInfoCollection[this] = value;
        }
        
        public ItemRow()
            : base()
        {
        }

        public ItemRow(RowFields fields)
            : base(fields)
        {
        } 
        public class RowFields : RowFieldsBase
        { 
            public StringField ItemCode;
            public StringField ItemName;
            public StringField U_ParentId;
            public StringField U_IsParent;
            public StringField U_sub;
            public StringField User_Text;
            public StringField ForeignName;
            public StringField Mainsupplier;
            public StringField U_cat;
            public StringField U_PID;
            public StringField U_brand;
            public StringField U_SH_Des;
            public StringField U_Active;
           // public DecimalField ItemsGroupCode;
            //public DecimalField CustomsGroupCode;
            public StringField BarCode;
            public StringField PurchaseItem;
            public StringField SalesItem;
            public StringField InventoryItem;
            public StringField DefaultWarehouse;
            public StringField U_ItemStat;
            public StringField U_Yatas;
            public StringField U_Enza;
            //public StringField Mainsupplier;
            //public StringField SupplierCatalogNo;
            public RowListField<ItemWarehouseInfoCollectionRow> ItemWarehouseInfoCollection;
        }
    }
}
