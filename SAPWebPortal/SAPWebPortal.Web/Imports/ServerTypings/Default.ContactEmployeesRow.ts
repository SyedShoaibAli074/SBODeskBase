namespace SAPWebPortal.Default {
    export interface ContactEmployeesRow {
        CardCode?: string;
        Name?: string;
        Position?: string;
        Address?: string;
        Phone1?: string;
        E_Mail?: string;
        FirstName?: string;
        MiddleName?: string;
        EmailGroupCode?: string;
        LastName?: string;
        Active?: string;
    }

    export namespace ContactEmployeesRow {
        export const idProperty = 'CardCode';
        export const nameProperty = 'CardCode';
        export const localTextPrefix = 'Default.ContactEmployees';
        export const deletePermission = 'ContactEmployees';
        export const insertPermission = 'ContactEmployees';
        export const readPermission = 'ContactEmployees';
        export const updatePermission = 'ContactEmployees';

        export declare const enum Fields {
            CardCode = "CardCode",
            Name = "Name",
            Position = "Position",
            Address = "Address",
            Phone1 = "Phone1",
            E_Mail = "E_Mail",
            FirstName = "FirstName",
            MiddleName = "MiddleName",
            EmailGroupCode = "EmailGroupCode",
            LastName = "LastName",
            Active = "Active"
        }
    }
}
