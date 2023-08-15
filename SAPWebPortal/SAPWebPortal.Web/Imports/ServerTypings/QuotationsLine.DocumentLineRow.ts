namespace SAPWebPortal.QuotationsLine {
    export interface DocumentLineRow {
        DocEntry?: number;
        LineNum?: number;
        ItemCode?: string;
        ItemDescription?: string;
        AccountCode?: string;
        Quantity?: number;
        UnitsOfMeasurment?: number;
        VatGroup?: string;
        UnitPrice?: number;
        PriceAfterVat?: number;
        DiscountPercent?: number;
        WarehouseCode?: string;
        UoMCode?: string;
        LineTotal?: number;
        GrossTotal?: number;
        TaxTotal?: number;
    }

    export namespace DocumentLineRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'QuotationsLine.DocumentLine';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            LineNum = "LineNum",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            AccountCode = "AccountCode",
            Quantity = "Quantity",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            VatGroup = "VatGroup",
            UnitPrice = "UnitPrice",
            PriceAfterVat = "PriceAfterVat",
            DiscountPercent = "DiscountPercent",
            WarehouseCode = "WarehouseCode",
            UoMCode = "UoMCode",
            LineTotal = "LineTotal",
            GrossTotal = "GrossTotal",
            TaxTotal = "TaxTotal"
        }
    }
}
