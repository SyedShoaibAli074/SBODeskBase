namespace SAPWebPortal.Default {
    export interface ItemRow {
        ItemCode?: string;
        ItemName?: string;
        U_ParentId?: string;
        U_IsParent?: string;
        U_sub?: string;
        User_Text?: string;
        ForeignName?: string;
        Mainsupplier?: string;
        U_cat?: string;
        U_PID?: string;
        U_brand?: string;
        U_SH_Des?: string;
        U_Active?: string;
        BarCode?: string;
        PurchaseItem?: string;
        SalesItem?: string;
        InventoryItem?: string;
        DefaultWarehouse?: string;
        U_ItemStat?: string;
        U_Yatas?: string;
        U_Enza?: string;
        ItemWarehouseInfoCollection?: ItemWarehouseInfoCollectionRow[];
    }

    export namespace ItemRow {
        export const idProperty = 'ItemCode';
        export const nameProperty = 'ItemCode';
        export const localTextPrefix = 'Default.Item';
        export const lookupKey = 'Default.Item';

        export function getLookup(): Q.Lookup<ItemRow> {
            return Q.getLookup<ItemRow>('Default.Item');
        }
        export const deletePermission = 'MasterData:Items:Delete';
        export const insertPermission = 'MasterData:Items:Insert';
        export const readPermission = 'MasterData:Items:View';
        export const updatePermission = 'MasterData:Items:Modify';

        export declare const enum Fields {
            ItemCode = "ItemCode",
            ItemName = "ItemName",
            U_ParentId = "U_ParentId",
            U_IsParent = "U_IsParent",
            U_sub = "U_sub",
            User_Text = "User_Text",
            ForeignName = "ForeignName",
            Mainsupplier = "Mainsupplier",
            U_cat = "U_cat",
            U_PID = "U_PID",
            U_brand = "U_brand",
            U_SH_Des = "U_SH_Des",
            U_Active = "U_Active",
            BarCode = "BarCode",
            PurchaseItem = "PurchaseItem",
            SalesItem = "SalesItem",
            InventoryItem = "InventoryItem",
            DefaultWarehouse = "DefaultWarehouse",
            U_ItemStat = "U_ItemStat",
            U_Yatas = "U_Yatas",
            U_Enza = "U_Enza",
            ItemWarehouseInfoCollection = "ItemWarehouseInfoCollection"
        }
    }
}
