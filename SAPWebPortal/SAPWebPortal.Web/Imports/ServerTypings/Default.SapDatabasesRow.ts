namespace SAPWebPortal.Default {
    export interface SapDatabasesRow {
        Id?: number;
        ServerName?: string;
        ODBCServer?: string;
        DbServerType?: string;
        LicenseServer?: string;
        CompanyDb?: string;
        DbUserName?: string;
        DbPassword?: string;
        UserName?: string;
        Password?: string;
        Alias?: string;
        ServiceLayerUrl?: string;
        ServiceLayerVersion?: string;
        DBDriver?: string;
        IsDefault?: boolean;
        CreateUDFs?: number;
        UDFs?: string;
    }

    export namespace SapDatabasesRow {
        export const idProperty = 'Id';
        export const nameProperty = 'CompanyDb';
        export const localTextPrefix = 'Default.SapDatabases';
        export const lookupKey = 'Default.SapDatabases';

        export function getLookup(): Q.Lookup<SapDatabasesRow> {
            return Q.getLookup<SapDatabasesRow>('Default.SapDatabases');
        }
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Id = "Id",
            ServerName = "ServerName",
            ODBCServer = "ODBCServer",
            DbServerType = "DbServerType",
            LicenseServer = "LicenseServer",
            CompanyDb = "CompanyDb",
            DbUserName = "DbUserName",
            DbPassword = "DbPassword",
            UserName = "UserName",
            Password = "Password",
            Alias = "Alias",
            ServiceLayerUrl = "ServiceLayerUrl",
            ServiceLayerVersion = "ServiceLayerVersion",
            DBDriver = "DBDriver",
            IsDefault = "IsDefault",
            CreateUDFs = "CreateUDFs",
            UDFs = "UDFs"
        }
    }
}
