namespace SAPWebPortal.Default {
    export interface UserDetail1Row {
        Id?: number;
        UserDId?: number;
        UserId?: number;
        UserCode?: string;
        UserName?: string;
        DbName?: string;
        CardCode?: string;
        CardName?: string;
        Active?: string;
    }

    export namespace UserDetail1Row {
        export const idProperty = 'Id';
        export const nameProperty = 'UserCode';
        export const localTextPrefix = 'Default.UserDetail1';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Id = "Id",
            UserDId = "UserDId",
            UserId = "UserId",
            UserCode = "UserCode",
            UserName = "UserName",
            DbName = "DbName",
            CardCode = "CardCode",
            CardName = "CardName",
            Active = "Active"
        }
    }
}
