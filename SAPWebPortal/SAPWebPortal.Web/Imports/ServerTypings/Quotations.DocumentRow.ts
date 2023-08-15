namespace SAPWebPortal.Quotations {
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
        GroupNum?: string;
        PayToCode?: string;
        ShipToCode?: string;
        NumAtCard?: string;
        U_ApprovalGUID?: string;
        U_Address?: string;
        DBName?: string;
        DocumentLines?: QuotationsLine.DocumentLineRow[];
    }

    export namespace DocumentRow {
        export const idProperty = 'DocEntry';
        export const localTextPrefix = 'Quotations.Document';
        export const deletePermission = 'MarketingDocs:SalesQuotations:Delete';
        export const insertPermission = 'MarketingDocs:SalesQuotations:Insert';
        export const readPermission = 'MarketingDocs:SalesQuotations:View';
        export const updatePermission = 'MarketingDocs:SalesQuotations:Modify';

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
            GroupNum = "GroupNum",
            PayToCode = "PayToCode",
            ShipToCode = "ShipToCode",
            NumAtCard = "NumAtCard",
            U_ApprovalGUID = "U_ApprovalGUID",
            U_Address = "U_Address",
            DBName = "DBName",
            DocumentLines = "DocumentLines"
        }
    }
}
