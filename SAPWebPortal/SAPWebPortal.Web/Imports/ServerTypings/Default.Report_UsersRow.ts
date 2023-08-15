namespace SAPWebPortal.Default {
    export interface Report_UsersRow {
        Id?: number;
        UserId?: number;
        Rodcid?: number;
        DB_Name?: string;
        RptName?: string;
    }

    export namespace Report_UsersRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Default.Report_Users';
        export const lookupKey = 'Default.Report_Users';

        export function getLookup(): Q.Lookup<Report_UsersRow> {
            return Q.getLookup<Report_UsersRow>('Default.Report_Users');
        }
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Id = "Id",
            UserId = "UserId",
            Rodcid = "Rodcid",
            DB_Name = "DB_Name",
            RptName = "RptName"
        }
    }
}
