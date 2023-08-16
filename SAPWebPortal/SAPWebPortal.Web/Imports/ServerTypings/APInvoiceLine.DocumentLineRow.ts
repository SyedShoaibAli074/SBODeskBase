namespace SAPWebPortal.APInvoiceLine {
    export interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        ItemDescription?: string;
        Quantity?: number;
        VatGroup?: string;
        UnitPrice?: string;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        AccountCode?: string;
        U_CustOrderNo?: string;
        AccountName?: string;
        GrossTotal?: number;
        TaxTotal?: number;
        BaseType?: number;
        BaseEntry?: number;
        BaseLine?: number;
        CostingCode?: string;
        CostingCode2?: string;
        ProjectCode?: string;
    }

    export namespace DocumentLineRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'APInvoiceLine.DocumentLine';
        export const deletePermission = 'MarketingDocs:APInvoice:Delete';
        export const insertPermission = 'MarketingDocs:APInvoice:Insert';
        export const readPermission = 'MarketingDocs:APInvoice:View';
        export const updatePermission = 'MarketingDocs:APInvoice:Modify';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            Quantity = "Quantity",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            AccountCode = "AccountCode",
            U_CustOrderNo = "U_CustOrderNo",
            AccountName = "AccountName",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal",
            BaseType = "BaseType",
            BaseEntry = "BaseEntry",
            BaseLine = "BaseLine",
            CostingCode = "CostingCode",
            CostingCode2 = "CostingCode2",
            ProjectCode = "ProjectCode"
        }
    }
}
