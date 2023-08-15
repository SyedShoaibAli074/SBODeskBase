namespace SAPWebPortal.Administration {
    export interface UserRow {
        UserId?: number;
        UserCode?: string;
        Username?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        DisplayName?: string;
        Email?: string;
        UserImage?: string;
        LastDirectoryUpdate?: string;
        IsActive?: number;
        Password?: string;
        DBName?: string;
        PasswordConfirm?: string;
        CompanyDatabase?: string;
        CompanyDatabaseName?: string;
        WarehouseCode?: string;
        DetailList?: Default.UserDetail1Row[];
        DetailList1?: Default.UserDetail2Row[];
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace UserRow {
        export const idProperty = 'UserId';
        export const isActiveProperty = 'IsActive';
        export const nameProperty = 'Username';
        export const localTextPrefix = 'Administration.User';
        export const lookupKey = 'Administration.User';

        export function getLookup(): Q.Lookup<UserRow> {
            return Q.getLookup<UserRow>('Administration.User');
        }
        export const deletePermission = 'Administration:Security';
        export const insertPermission = 'Administration:Security';
        export const readPermission = 'Administration:Security';
        export const updatePermission = 'Administration:Security';

        export declare const enum Fields {
            UserId = "UserId",
            UserCode = "UserCode",
            Username = "Username",
            Source = "Source",
            PasswordHash = "PasswordHash",
            PasswordSalt = "PasswordSalt",
            DisplayName = "DisplayName",
            Email = "Email",
            UserImage = "UserImage",
            LastDirectoryUpdate = "LastDirectoryUpdate",
            IsActive = "IsActive",
            Password = "Password",
            DBName = "DBName",
            PasswordConfirm = "PasswordConfirm",
            CompanyDatabase = "CompanyDatabase",
            CompanyDatabaseName = "CompanyDatabaseName",
            WarehouseCode = "WarehouseCode",
            DetailList = "DetailList",
            DetailList1 = "DetailList1",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
