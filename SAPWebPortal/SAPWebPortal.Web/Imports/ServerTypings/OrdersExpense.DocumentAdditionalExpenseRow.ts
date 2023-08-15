namespace SAPWebPortal.OrdersExpense {
    export interface DocumentAdditionalExpenseRow {
        ExpenseCode?: number;
        LineNum?: number;
        LineTotal?: number;
        VatGroup?: string;
        TaxPercent?: number;
        TaxSum?: number;
        Remarks?: string;
    }

    export namespace DocumentAdditionalExpenseRow {
        export const idProperty = 'ExpenseCode';
        export const localTextPrefix = 'OrdersExpense.DocumentAdditionalExpense';
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
            Remarks = "Remarks"
        }
    }
}
