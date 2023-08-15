namespace SAPWebPortal.Default {
    export interface UsersDetailsRow {
        Id?: number;
        U1Id?: number;
        UserId?: number;
        ParameterName?: string;
        ParameterQuery?: string;
        Rodcid?: number;
        DbName?: string;
    }

    export namespace UsersDetailsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ParameterName';
        export const localTextPrefix = 'Default.UsersDetails';
        export const lookupKey = 'Default.UsersDetails';

        export function getLookup(): Q.Lookup<UsersDetailsRow> {
            return Q.getLookup<UsersDetailsRow>('Default.UsersDetails');
        }
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Id = "Id",
            U1Id = "U1Id",
            UserId = "UserId",
            ParameterName = "ParameterName",
            ParameterQuery = "ParameterQuery",
            Rodcid = "Rodcid",
            DbName = "DbName"
        }
    }
}
