namespace SAPWebPortal.QuotationsExpense {
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
        export const localTextPrefix = 'QuotationsExpense.DocumentAdditionalExpense';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

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
