namespace SAPWebPortal.Default {
    export interface AdditionalExpenseRow {
        ExpensCode?: number;
        Name?: string;
    }

    export namespace AdditionalExpenseRow {
        export const idProperty = 'ExpensCode';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Default.AdditionalExpense';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            ExpensCode = "ExpensCode",
            Name = "Name"
        }
    }
}
