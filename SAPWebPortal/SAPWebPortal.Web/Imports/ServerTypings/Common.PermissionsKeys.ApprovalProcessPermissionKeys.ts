namespace SAPWebPortal.Common.PermissionsKeys {
    export namespace ApprovalProcessPermissionKeys {
        export const General = "ApprovalProcess:General";
        export const DefaultGeneral = "Administration:DefaultGeneral";

        namespace ApprovalRequests {
            export const Delete = "ApprovalProcess:ApprovalRequests:Delete";
            export const Modify = "ApprovalProcess:ApprovalRequests:Modify";
            export const View = "ApprovalProcess:ApprovalRequests:View";
            export const Insert = "ApprovalProcess:ApprovalRequests:Insert";
        }

        namespace Drafts {
            export const Delete = "ApprovalProcess:Drafts:Delete";
            export const Modify = "ApprovalProcess:Drafts:Modify";
            export const View = "ApprovalProcess:Drafts:View";
            export const Insert = "ApprovalProcess:Drafts:Insert";
        }
    }
}
