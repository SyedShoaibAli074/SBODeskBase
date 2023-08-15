namespace SAPWebPortal.DraftsExpense {
    export interface DocumentAdditionalExpenseRow {
        ExpenseCode?: number;
        LineNum?: number;
        LineTotal?: number;
        VatGroup?: string;
        TaxPercent?: number;
        TaxSum?: number;
        Remarks?: string;
        U_Amount?: number;
    }

    export namespace DocumentAdditionalExpenseRow {
        export const idProperty = 'ExpenseCode';
        export const localTextPrefix = 'DraftsExpense.DocumentAdditionalExpense';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            ExpenseCode = "ExpenseCode",
            LineNum = "LineNum",
            LineTotal = "LineTotal",
            VatGroup = "VatGroup",
            TaxPercent = "TaxPercent",
            TaxSum = "TaxSum",
            Remarks = "Remarks",
            U_Amount = "U_Amount"
        }
    }
}
