namespace SAPWebPortal.Default {
    export interface ApprovalRequestDecisionRow {
        ApproverUserName?: string;
        ApproverPassword?: string;
        Status?: string;
        Remarks?: string;
    }

    export namespace ApprovalRequestDecisionRow {
        export const idProperty = 'ApproverUserName';
        export const localTextPrefix = 'Default.ApprovalRequestDecision';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            ApproverUserName = "ApproverUserName",
            ApproverPassword = "ApproverPassword",
            Status = "Status",
            Remarks = "Remarks"
        }
    }
}
