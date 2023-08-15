namespace SAPWebPortal.DeliveryLine {
    export interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        U_ShopifyOrderLineId?: string;
        ItemDescription?: string;
        Quantity?: number;
        UnitsOfMeasurment?: number;
        VatGroup?: string;
        UnitPrice?: number;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        AccountCode?: string;
        GrossTotal?: number;
        TaxTotal?: number;
        BaseType?: number;
        BaseEntry?: number;
        BaseLine?: number;
    }

    export namespace DocumentLineRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'DeliveryLine.DocumentLine';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            U_ShopifyOrderLineId = "U_ShopifyOrderLineId",
            ItemDescription = "ItemDescription",
            Quantity = "Quantity",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            AccountCode = "AccountCode",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal",
            BaseType = "BaseType",
            BaseEntry = "BaseEntry",
            BaseLine = "BaseLine"
        }
    }
}
