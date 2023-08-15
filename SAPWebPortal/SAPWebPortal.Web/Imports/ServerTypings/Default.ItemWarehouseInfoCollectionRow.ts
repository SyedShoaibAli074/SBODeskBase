namespace SAPWebPortal.Default {
    export interface ItemWarehouseInfoCollectionRow {
        ItemCode?: string;
        WarehouseCode?: string;
        InStock?: number;
        Committed?: number;
        Ordered?: number;
        CountedQuantity?: number;
    }

    export namespace ItemWarehouseInfoCollectionRow {
        export const idProperty = 'ItemCode';
        export const nameProperty = 'ItemCode';
        export const localTextPrefix = 'Default.ItemWarehouseInfoCollection';
        export const deletePermission = 'MasterData:General';
        export const insertPermission = 'MasterData:General';
        export const readPermission = 'MasterData:General';
        export const updatePermission = 'MasterData:General';

        export declare const enum Fields {
            ItemCode = "ItemCode",
            WarehouseCode = "WarehouseCode",
            InStock = "InStock",
            Committed = "Committed",
            Ordered = "Ordered",
            CountedQuantity = "CountedQuantity"
        }
    }
}
