namespace SAPWebPortal.Default {
    export interface WarehouseRow {
        WarehouseCode?: string;
        WarehouseName?: string;
    }

    export namespace WarehouseRow {
        export const idProperty = 'WarehouseCode';
        export const nameProperty = 'WarehouseCode';
        export const localTextPrefix = 'Default.Warehouse';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            WarehouseCode = "WarehouseCode",
            WarehouseName = "WarehouseName"
        }
    }
}
