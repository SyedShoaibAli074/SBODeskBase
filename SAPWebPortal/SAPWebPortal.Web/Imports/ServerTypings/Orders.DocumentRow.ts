namespace SAPWebPortal.Orders {
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
        U_ShopifyOrderId?: string;
        U_OrderNumber?: string;
        U_CanceledAt?: string;
        U_PaymentMethod?: string;
        U_Address?: string;
        DBName?: string;
        NumAtCard?: string;
        AddressExtension?: AddressExtensionRow;
        DocumentLines?: OrdersLine.DocumentLineRow[];
        DocumentAdditionalExpenses?: OrdersExpense.DocumentAdditionalExpenseRow[];
    }

    export namespace DocumentRow {
        export const idProperty = 'DocEntry';
        export const localTextPrefix = 'Orders.Document';
        export const deletePermission = 'MarketingDocs:SalesOrder:Delete';
        export const insertPermission = 'MarketingDocs:SalesOrder:Insert';
        export const readPermission = 'MarketingDocs:SalesOrder:View';
        export const updatePermission = 'MarketingDocs:SalesOrder:Modify';

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
            U_ShopifyOrderId = "U_ShopifyOrderId",
            U_OrderNumber = "U_OrderNumber",
            U_CanceledAt = "U_CanceledAt",
            U_PaymentMethod = "U_PaymentMethod",
            U_Address = "U_Address",
            DBName = "DBName",
            NumAtCard = "NumAtCard",
            AddressExtension = "AddressExtension",
            DocumentLines = "DocumentLines",
            DocumentAdditionalExpenses = "DocumentAdditionalExpenses"
        }
    }
}
