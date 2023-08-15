namespace SAPWebPortal.InventoryCounting {
    export interface InventoryCountingLineRow {
        DocumentEntry?: number;
        LineNumber?: number;
        ItemCode?: string;
        ItemDescription?: string;
        Freeze?: string;
        WarehouseCode?: string;
        BinEntry?: number;
        InWarehouseQuantity?: number;
        Counted?: string;
        UoMCode?: string;
        CountedQuantity?: number;
    }

    export namespace InventoryCountingLineRow {
        export const idProperty = 'DocumentEntry';
        export const nameProperty = 'ItemCode';
        export const localTextPrefix = 'InventoryCounting.InventoryCountingLine';
        export const deletePermission = 'InventoryCounting';
        export const insertPermission = 'InventoryCounting';
        export const readPermission = 'InventoryCounting';
        export const updatePermission = 'InventoryCounting';

        export declare const enum Fields {
            DocumentEntry = "DocumentEntry",
            LineNumber = "LineNumber",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            Freeze = "Freeze",
            WarehouseCode = "WarehouseCode",
            BinEntry = "BinEntry",
            InWarehouseQuantity = "InWarehouseQuantity",
            Counted = "Counted",
            UoMCode = "UoMCode",
            CountedQuantity = "CountedQuantity"
        }
    }
}
