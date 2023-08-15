namespace SAPWebPortal.OrdersLine {
    export interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        ItemDescription?: string;
        Quantity?: number;
        InventoryQuantity?: number;
        UnitsOfMeasurment?: number;
        VatGroup?: string;
        UnitPrice?: number;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        AccountCode?: string;
        U_ShopifyOrderLineId?: string;
        GrossTotal?: number;
        TaxTotal?: number;
    }

    export namespace DocumentLineRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'OrdersLine.DocumentLine';
        export const deletePermission = 'MarketingDocs:SalesOrderLines:Delete';
        export const insertPermission = 'MarketingDocs:SalesOrderLines:Insert';
        export const readPermission = 'MarketingDocs:SalesOrderLines:View';
        export const updatePermission = 'MarketingDocs:SalesOrderLines:Modify';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            Quantity = "Quantity",
            InventoryQuantity = "InventoryQuantity",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            AccountCode = "AccountCode",
            U_ShopifyOrderLineId = "U_ShopifyOrderLineId",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal"
        }
    }
}
