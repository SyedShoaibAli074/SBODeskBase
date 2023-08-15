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
        AccountName?: string;
        U_WRNT?: string;
        GrossTotal?: number;
        TaxTotal?: number;
        U_STCK?: number;
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
            AccountName = "AccountName",
            U_WRNT = "U_WRNT",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal",
            U_STCK = "U_STCK",
            BaseType = "BaseType",
            BaseEntry = "BaseEntry",
            BaseLine = "BaseLine",
            CostingCode = "CostingCode",
            CostingCode2 = "CostingCode2",
            ProjectCode = "ProjectCode"
        }
    }
}
