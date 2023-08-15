namespace SAPWebPortal.Default {
    export interface ChartOfAccountRow {
        Code?: string;
        Name?: string;
    }

    export namespace ChartOfAccountRow {
        export const idProperty = 'Code';
        export const nameProperty = 'Code';
        export const localTextPrefix = 'Default.ChartOfAccount';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Code = "Code",
            Name = "Name"
        }
    }
}
