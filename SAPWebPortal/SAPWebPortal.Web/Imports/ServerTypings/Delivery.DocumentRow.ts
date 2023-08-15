namespace SAPWebPortal.Delivery {
    export interface DocumentRow {
        DocEntry?: number;
        Series?: number;
        DocNum?: number;
        DocType?: string;
        DocDate?: string;
        DocDueDate?: string;
        CardCode?: string;
        CardName?: string;
        U_FullfilmentId?: string;
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
        DBName?: string;
        DocumentLines?: DeliveryLine.DocumentLineRow[];
        U_OrderNumber?: string;
        U_CanceledAt?: string;
        U_PaymentMethod?: string;
        U_ShopifyOrderId?: string;
        U_dosource?: string;
        U_TID?: string;
        U_ApprovalGUID?: string;
    }

    export namespace DocumentRow {
        export const idProperty = 'DocEntry';
        export const nameProperty = 'DocEntry';
        export const localTextPrefix = 'Delivery.Document';
        export const deletePermission = 'MarketingDocs:Delivery:Delete';
        export const insertPermission = 'MarketingDocs:Delivery:Insert';
        export const readPermission = 'MarketingDocs:Delivery:View';
        export const updatePermission = 'MarketingDocs:Delivery:Modify';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            Series = "Series",
            DocNum = "DocNum",
            DocType = "DocType",
            DocDate = "DocDate",
            DocDueDate = "DocDueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            U_FullfilmentId = "U_FullfilmentId",
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
            DBName = "DBName",
            DocumentLines = "DocumentLines",
            U_OrderNumber = "U_OrderNumber",
            U_CanceledAt = "U_CanceledAt",
            U_PaymentMethod = "U_PaymentMethod",
            U_ShopifyOrderId = "U_ShopifyOrderId",
            U_dosource = "U_dosource",
            U_TID = "U_TID",
            U_ApprovalGUID = "U_ApprovalGUID"
        }
    }
}
