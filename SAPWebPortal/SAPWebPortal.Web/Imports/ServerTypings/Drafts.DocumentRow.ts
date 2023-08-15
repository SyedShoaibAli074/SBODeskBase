namespace SAPWebPortal.Drafts {
    export interface DocumentRow {
        DocEntry?: number;
        Series?: number;
        DocNum?: number;
        DocType?: string;
        DocDate?: string;
        DocDueDate?: string;
        CardCode?: string;
        CardName?: string;
        DocTotal?: number;
        VatSum?: number;
        SalesPersonCode?: number;
        AttachmentEntry?: string;
        DiscountPercent?: number;
        DocumentsOwner?: number;
        DocumentStatus?: string;
        DocCurrency?: string;
        TotalDiscount?: number;
        UserSign?: number;
        Comments?: string;
        Project?: string;
        GroupNumber?: number;
        PayToCode?: string;
        ShipToCode?: string;
        U_Address?: string;
        NumAtCard?: string;
        DocObjectCode?: string;
        AuthorizationStatus?: string;
        DBName?: string;
        DocumentLines?: DraftsLine.DocumentLineRow[];
    }

    export namespace DocumentRow {
        export const idProperty = 'DocEntry';
        export const nameProperty = 'DocEntry';
        export const localTextPrefix = 'Drafts.Document';
        export const deletePermission = 'ApprovalProcess:Drafts:Delete';
        export const insertPermission = 'ApprovalProcess:Drafts:Insert';
        export const readPermission = 'ApprovalProcess:Drafts:View';
        export const updatePermission = 'ApprovalProcess:Drafts:Modify';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            Series = "Series",
            DocNum = "DocNum",
            DocType = "DocType",
            DocDate = "DocDate",
            DocDueDate = "DocDueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            DocTotal = "DocTotal",
            VatSum = "VatSum",
            SalesPersonCode = "SalesPersonCode",
            AttachmentEntry = "AttachmentEntry",
            DiscountPercent = "DiscountPercent",
            DocumentsOwner = "DocumentsOwner",
            DocumentStatus = "DocumentStatus",
            DocCurrency = "DocCurrency",
            TotalDiscount = "TotalDiscount",
            UserSign = "UserSign",
            Comments = "Comments",
            Project = "Project",
            GroupNumber = "GroupNumber",
            PayToCode = "PayToCode",
            ShipToCode = "ShipToCode",
            U_Address = "U_Address",
            NumAtCard = "NumAtCard",
            DocObjectCode = "DocObjectCode",
            AuthorizationStatus = "AuthorizationStatus",
            DBName = "DBName",
            DocumentLines = "DocumentLines"
        }
    }
}
