namespace SAPWebPortal.Default {
    export interface UserDetail2Row {
        Id?: number;
        UserDId?: number;
        UserId?: number;
        UserCode?: string;
        UserName?: string;
        DbName?: string;
        SalesPersonCode?: string;
        SalesPersonName?: string;
        Active?: string;
    }

    export namespace UserDetail2Row {
        export const idProperty = 'Id';
        export const nameProperty = 'UserCode';
        export const localTextPrefix = 'Default.UserDetail2';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UserDId = "UserDId",
            UserId = "UserId",
            UserCode = "UserCode",
            UserName = "UserName",
            DbName = "DbName",
            SalesPersonCode = "SalesPersonCode",
            SalesPersonName = "SalesPersonName",
            Active = "Active"
        }
    }
}
