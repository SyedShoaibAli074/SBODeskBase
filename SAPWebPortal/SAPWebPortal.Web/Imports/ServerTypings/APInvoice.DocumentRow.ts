namespace SAPWebPortal.APInvoice {
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
        DiscountPercent?: string;
        DocumentsOwner?: number;
        DocumentStatus?: string;
        DocCurrency?: string;
        TotalDiscount?: string;
        UserSign?: number;
        Comments?: string;
        Project?: string;
        PaymentGroupCode?: string;
        PayToCode?: string;
        TrackNo?: string;
        ShipToCode?: string;
        U_Cartons?: string;
        U_Total_Weight?: string;
        TrnspCode?: number;
        U_QTY?: number;
        FederalTaxId?: string;
        U_BAL?: string;
        U_ApprovalGUID?: string;
        NumAtCard?: string;
        DocumentLines?: APInvoiceLine.DocumentLineRow[];
        PaidToDate?: number;
    }

    export namespace DocumentRow {
        export const idProperty = 'DocEntry';
        export const localTextPrefix = 'APInvoice.Document';
        export const deletePermission = 'MarketingDocs:APInvoice:Delete';
        export const insertPermission = 'MarketingDocs:APInvoice:Insert';
        export const readPermission = 'MarketingDocs:APInvoice:View';
        export const updatePermission = 'MarketingDocs:APInvoice:Modify';

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
            PaymentGroupCode = "PaymentGroupCode",
            PayToCode = "PayToCode",
            TrackNo = "TrackNo",
            ShipToCode = "ShipToCode",
            U_Cartons = "U_Cartons",
            U_Total_Weight = "U_Total_Weight",
            TrnspCode = "TrnspCode",
            U_QTY = "U_QTY",
            FederalTaxId = "FederalTaxId",
            U_BAL = "U_BAL",
            U_ApprovalGUID = "U_ApprovalGUID",
            NumAtCard = "NumAtCard",
            DocumentLines = "DocumentLines",
            PaidToDate = "PaidToDate"
        }
    }
}
