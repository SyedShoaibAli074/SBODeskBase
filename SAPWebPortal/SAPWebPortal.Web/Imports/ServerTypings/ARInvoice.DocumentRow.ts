namespace SAPWebPortal.ARInvoice {
    export interface DocumentRow {
        DocEntry?: number;
        DocNum?: number;
        DocType?: string;
        DBName?: string;
        DocDate?: string;
        DocDueDate?: string;
        CardCode?: string;
        CardName?: string;
        Address?: string;
        BPL_IDAssignedToInvoice?: string;
        NumAtCard?: string;
        DocTotal?: number;
        PaidToDate?: number;
        DocumentLines?: ARInvoiceLine.DocumentLineRow[];
    }

    export namespace DocumentRow {
        export const idProperty = 'DocEntry';
        export const localTextPrefix = 'ARInvoice.Document';
        export const deletePermission = 'ARInvoice';
        export const insertPermission = 'ARInvoice';
        export const readPermission = 'ARInvoice';
        export const updatePermission = 'ARInvoice';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            DocNum = "DocNum",
            DocType = "DocType",
            DBName = "DBName",
            DocDate = "DocDate",
            DocDueDate = "DocDueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            Address = "Address",
            BPL_IDAssignedToInvoice = "BPL_IDAssignedToInvoice",
            NumAtCard = "NumAtCard",
            DocTotal = "DocTotal",
            PaidToDate = "PaidToDate",
            DocumentLines = "DocumentLines"
        }
    }
}
