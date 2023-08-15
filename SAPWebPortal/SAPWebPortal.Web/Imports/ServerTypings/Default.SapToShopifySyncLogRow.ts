namespace SAPWebPortal.Default {
    export interface SapToShopifySyncLogRow {
        Id?: number;
        DocEntry?: string;
        SyncStatus?: string;
        TargetStoreId?: string;
        SourceObjType?: string;
        SyncTime?: string;
    }

    export namespace SapToShopifySyncLogRow {
        export const idProperty = 'Id';
        export const nameProperty = 'DocEntry';
        export const localTextPrefix = 'Default.SapToShopifySyncLog';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            DocEntry = "DocEntry",
            SyncStatus = "SyncStatus",
            TargetStoreId = "TargetStoreId",
            SourceObjType = "SourceObjType",
            SyncTime = "SyncTime"
        }
    }
}
