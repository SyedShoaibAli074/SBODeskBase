namespace SAPWebPortal.InventoryCounting {
    export interface InventoryCountingRow {
        DocumentEntry?: number;
        DocumentNumber?: number;
        Series?: number;
        CountDate?: string;
        SingleCounterId?: number;
        DocumentStatus?: number;
        Remarks?: string;
        Reference2?: string;
        DBName?: string;
        InventoryCountingLines?: InventoryCountingLineRow[];
    }

    export namespace InventoryCountingRow {
        export const idProperty = 'DocumentEntry';
        export const nameProperty = 'Remarks';
        export const localTextPrefix = 'InventoryCountings.InventoryCounting';
        export const deletePermission = 'InventoryCounting';
        export const insertPermission = 'InventoryCounting';
        export const readPermission = 'InventoryCounting';
        export const updatePermission = 'InventoryCounting';

        export declare const enum Fields {
            DocumentEntry = "DocumentEntry",
            DocumentNumber = "DocumentNumber",
            Series = "Series",
            CountDate = "CountDate",
            SingleCounterId = "SingleCounterId",
            DocumentStatus = "DocumentStatus",
            Remarks = "Remarks",
            Reference2 = "Reference2",
            DBName = "DBName",
            InventoryCountingLines = "InventoryCountingLines"
        }
    }
}
