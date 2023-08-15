namespace SAPWebPortal.VatGroups {
    export interface VatGroupRow {
        Code?: string;
        Name?: string;
        Inactive?: string;
    }

    export namespace VatGroupRow {
        export const idProperty = 'Code';
        export const nameProperty = 'Code';
        export const localTextPrefix = 'VatGroups.VatGroup';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Code = "Code",
            Name = "Name",
            Inactive = "Inactive"
        }
    }
}
