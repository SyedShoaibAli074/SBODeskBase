namespace SAPWebPortal.Default {
    export interface UsersRow {
        UserId?: number;
        Username?: string;
        DisplayName?: string;
        Email?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        PasswordSAP?: string;
        LastDirectoryUpdate?: string;
        UserImage?: string;
        InsertDate?: string;
        InsertUserId?: number;
        UpdateDate?: string;
        UpdateUserId?: number;
        CompanyDatabase?: string;
        WarehouseCode?: string;
        IsActive?: number;
        DetailList?: Report_UsersRow[];
    }

    export namespace UsersRow {
        export const idProperty = 'UserId';
        export const nameProperty = 'Username';
        export const localTextPrefix = 'Default.Users';
        export const lookupKey = 'Default.Users';

        export function getLookup(): Q.Lookup<UsersRow> {
            return Q.getLookup<UsersRow>('Default.Users');
        }
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            UserId = "UserId",
            Username = "Username",
            DisplayName = "DisplayName",
            Email = "Email",
            Source = "Source",
            PasswordHash = "PasswordHash",
            PasswordSalt = "PasswordSalt",
            PasswordSAP = "PasswordSAP",
            LastDirectoryUpdate = "LastDirectoryUpdate",
            UserImage = "UserImage",
            InsertDate = "InsertDate",
            InsertUserId = "InsertUserId",
            UpdateDate = "UpdateDate",
            UpdateUserId = "UpdateUserId",
            CompanyDatabase = "CompanyDatabase",
            WarehouseCode = "WarehouseCode",
            IsActive = "IsActive",
            DetailList = "DetailList"
        }
    }
}
