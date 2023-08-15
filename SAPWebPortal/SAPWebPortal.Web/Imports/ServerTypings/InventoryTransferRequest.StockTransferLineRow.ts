namespace SAPWebPortal.InventoryTransferRequest {
    export interface StockTransferLineRow {
        LineNum?: number;
        DocEntry?: number;
        ItemCode?: string;
        ItemDescription?: string;
        Quantity?: number;
        Price?: number;
        Currency?: string;
        Rate?: number;
        DiscountPercent?: number;
        VendorNum?: string;
        SerialNumber?: string;
        WarehouseCode?: string;
        FromWarehouseCode?: string;
        ProjectCode?: string;
        Factor?: number;
        Factor2?: number;
        Factor3?: number;
        Factor4?: number;
        DistributionRule?: string;
        DistributionRule2?: string;
        DistributionRule3?: string;
        DistributionRule4?: string;
        DistributionRule5?: string;
        UseBaseUnits?: string;
        MeasureUnit?: string;
        UnitsOfMeasurment?: number;
        BaseType?: string;
        BaseLine?: number;
        BaseEntry?: number;
        UnitPrice?: number;
        UoMEntry?: number;
        UoMCode?: string;
        InventoryQuantity?: number;
        RemainingOpenQuantity?: number;
        RemainingOpenInventoryQuantity?: number;
        LineStatus?: string;
        U_RecQty?: number;
    }

    export namespace StockTransferLineRow {
        export const idProperty = 'LineNum';
        export const nameProperty = 'ItemCode';
        export const localTextPrefix = 'InventoryTransferRequest.StockTransferLine';
        export const deletePermission = 'InventoryTransferRequest';
        export const insertPermission = 'InventoryTransferRequest';
        export const readPermission = 'InventoryTransferRequest';
        export const updatePermission = 'InventoryTransferRequest';

        export declare const enum Fields {
            LineNum = "LineNum",
            DocEntry = "DocEntry",
            ItemCode = "ItemCode",
            ItemDescription = "ItemDescription",
            Quantity = "Quantity",
            Price = "Price",
            Currency = "Currency",
            Rate = "Rate",
            DiscountPercent = "DiscountPercent",
            VendorNum = "VendorNum",
            SerialNumber = "SerialNumber",
            WarehouseCode = "WarehouseCode",
            FromWarehouseCode = "FromWarehouseCode",
            ProjectCode = "ProjectCode",
            Factor = "Factor",
            Factor2 = "Factor2",
            Factor3 = "Factor3",
            Factor4 = "Factor4",
            DistributionRule = "DistributionRule",
            DistributionRule2 = "DistributionRule2",
            DistributionRule3 = "DistributionRule3",
            DistributionRule4 = "DistributionRule4",
            DistributionRule5 = "DistributionRule5",
            UseBaseUnits = "UseBaseUnits",
            MeasureUnit = "MeasureUnit",
            UnitsOfMeasurment = "UnitsOfMeasurment",
            BaseType = "BaseType",
            BaseLine = "BaseLine",
            BaseEntry = "BaseEntry",
            UnitPrice = "UnitPrice",
            UoMEntry = "UoMEntry",
            UoMCode = "UoMCode",
            InventoryQuantity = "InventoryQuantity",
            RemainingOpenQuantity = "RemainingOpenQuantity",
            RemainingOpenInventoryQuantity = "RemainingOpenInventoryQuantity",
            LineStatus = "LineStatus",
            U_RecQty = "U_RecQty"
        }
    }
}
