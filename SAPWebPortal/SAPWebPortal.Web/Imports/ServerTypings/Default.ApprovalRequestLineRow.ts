namespace SAPWebPortal.Default {
    export interface ApprovalRequestLineRow {
        StageCode?: number;
        UserID?: number;
        Status?: string;
        DBName?: string;
        Remarks?: string;
        CreationDate?: string;
        UpdateDate?: string;
    }

    export namespace ApprovalRequestLineRow {
        export const idProperty = 'StageCode';
        export const localTextPrefix = 'Default.ApprovalRequestLine';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            StageCode = "StageCode",
            UserID = "UserID",
            Status = "Status",
            DBName = "DBName",
            Remarks = "Remarks",
            CreationDate = "CreationDate",
            UpdateDate = "UpdateDate"
        }
    }
}
