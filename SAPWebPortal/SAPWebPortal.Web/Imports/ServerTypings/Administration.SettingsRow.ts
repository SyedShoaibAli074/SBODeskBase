namespace SAPWebPortal.Administration {
    export interface SettingsRow {
        Id?: number;
        UserId?: number;
        ModuleName?: number;
        ListDataSource?: string;
        PostByMethod?: string;
        IsHana?: boolean;
    }

    export namespace SettingsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ListDataSource';
        export const localTextPrefix = 'Administration.Settings';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UserId = "UserId",
            ModuleName = "ModuleName",
            ListDataSource = "ListDataSource",
            PostByMethod = "PostByMethod",
            IsHana = "IsHana"
        }
    }
}
