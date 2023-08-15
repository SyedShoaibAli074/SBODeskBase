namespace SAPWebPortal.Administration {
    export interface SessionsRow {
        Id?: number;
        SessionId?: string;
        PortalSessionID?: string;
        UserName?: string;
        DateTimeStamp?: string;
    }

    export namespace SessionsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'SessionId';
        export const localTextPrefix = 'Administration.Sessions';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            SessionId = "SessionId",
            PortalSessionID = "PortalSessionID",
            UserName = "UserName",
            DateTimeStamp = "DateTimeStamp"
        }
    }
}
