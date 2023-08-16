namespace SAPWebPortal.ARInvoiceLine {
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
        GrossTotal?: number;
        TaxTotal?: number;
        U_Payable?: string;
        U_CustOrderNo?: string;
        BaseType?: number;
        BaseEntry?: number;
        BaseLine?: number;
        CostingCode?: string;
        CostingCode2?: string;
        ProjectCode?: string;
    }

    export namespace DocumentLineRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'ARInvoiceLine.DocumentLine';
        export const deletePermission = 'MarketingDocs:ARInvoice:Delete';
        export const insertPermission = 'MarketingDocs:ARInvoice:Insert';
        export const readPermission = 'MarketingDocs:ARInvoice:View';
        export const updatePermission = 'MarketingDocs:ARInvoice:Modify';

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
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal",
            U_Payable = "U_Payable",
            U_CustOrderNo = "U_CustOrderNo",
            BaseType = "BaseType",
            BaseEntry = "BaseEntry",
            BaseLine = "BaseLine",
            CostingCode = "CostingCode",
            CostingCode2 = "CostingCode2",
            ProjectCode = "ProjectCode"
        }
    }
}
