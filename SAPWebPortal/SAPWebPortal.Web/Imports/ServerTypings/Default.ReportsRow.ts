namespace SAPWebPortal.Default {
    export interface ReportsRow {
        Rdocid?: number;
        RptName?: string;
        RptByteArray?: string;
        CreateDate?: string;
        UpdateDate?: string;
        DB_Name?: string;
    }

    export namespace ReportsRow {
        export const idProperty = 'Rdocid';
        export const nameProperty = 'RptName';
        export const localTextPrefix = 'Default.Reports';
        export const lookupKey = 'Default.Reports';

        export function getLookup(): Q.Lookup<ReportsRow> {
            return Q.getLookup<ReportsRow>('Default.Reports');
        }
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Rdocid = "Rdocid",
            RptName = "RptName",
            RptByteArray = "RptByteArray",
            CreateDate = "CreateDate",
            UpdateDate = "UpdateDate",
            DB_Name = "DB_Name"
        }
    }
}
