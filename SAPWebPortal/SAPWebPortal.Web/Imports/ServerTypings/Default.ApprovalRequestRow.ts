namespace SAPWebPortal.Default {
    export interface ApprovalRequestRow {
        Code?: number;
        ApprovalTemplatesID?: number;
        ObjectType?: string;
        IsDraft?: string;
        ObjectEntry?: number;
        Status?: string;
        Remarks?: string;
        CurrentStage?: number;
        OriginatorID?: number;
        CreationDate?: string;
        CreationTime?: string;
        DraftEntry?: number;
        DraftType?: string;
        DBName?: string;
        ApprovalRequestLines?: ApprovalRequestLineRow[];
        ApprovalRequestDecisions?: ApprovalRequestDecisionRow[];
    }

    export namespace ApprovalRequestRow {
        export const idProperty = 'Code';
        export const localTextPrefix = 'Default.ApprovalRequest';
        export const deletePermission = 'ApprovalProcess:ApprovalRequests:Delete';
        export const insertPermission = 'ApprovalProcess:ApprovalRequests:Insert';
        export const readPermission = 'ApprovalProcess:ApprovalRequests:View';
        export const updatePermission = 'ApprovalProcess:ApprovalRequests:Modify';

        export declare const enum Fields {
            Code = "Code",
            ApprovalTemplatesID = "ApprovalTemplatesID",
            ObjectType = "ObjectType",
            IsDraft = "IsDraft",
            ObjectEntry = "ObjectEntry",
            Status = "Status",
            Remarks = "Remarks",
            CurrentStage = "CurrentStage",
            OriginatorID = "OriginatorID",
            CreationDate = "CreationDate",
            CreationTime = "CreationTime",
            DraftEntry = "DraftEntry",
            DraftType = "DraftType",
            DBName = "DBName",
            ApprovalRequestLines = "ApprovalRequestLines",
            ApprovalRequestDecisions = "ApprovalRequestDecisions"
        }
    }
}
