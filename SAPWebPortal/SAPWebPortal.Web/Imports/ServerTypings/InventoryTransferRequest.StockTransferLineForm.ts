namespace SAPWebPortal.InventoryTransferRequest {
    export interface StockTransferLineForm {
        DocEntry: Serenity.IntegerEditor;
        ItemCode: Serenity.StringEditor;
        ItemDescription: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        Price: Serenity.DecimalEditor;
        Currency: Serenity.StringEditor;
        Rate: Serenity.DecimalEditor;
        DiscountPercent: Serenity.DecimalEditor;
        VendorNum: Serenity.StringEditor;
        SerialNumber: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        FromWarehouseCode: Serenity.StringEditor;
        ProjectCode: Serenity.StringEditor;
        Factor: Serenity.DecimalEditor;
        Factor2: Serenity.DecimalEditor;
        Factor3: Serenity.DecimalEditor;
        Factor4: Serenity.DecimalEditor;
        DistributionRule: Serenity.StringEditor;
        DistributionRule2: Serenity.StringEditor;
        DistributionRule3: Serenity.StringEditor;
        DistributionRule4: Serenity.StringEditor;
        DistributionRule5: Serenity.StringEditor;
        UseBaseUnits: Serenity.StringEditor;
        MeasureUnit: Serenity.StringEditor;
        UnitsOfMeasurment: Serenity.DecimalEditor;
        BaseType: Serenity.StringEditor;
        BaseLine: Serenity.IntegerEditor;
        BaseEntry: Serenity.IntegerEditor;
        UnitPrice: Serenity.DecimalEditor;
        UoMEntry: Serenity.IntegerEditor;
        UoMCode: Serenity.StringEditor;
        InventoryQuantity: Serenity.DecimalEditor;
        RemainingOpenQuantity: Serenity.DecimalEditor;
        RemainingOpenInventoryQuantity: Serenity.DecimalEditor;
        LineStatus: Serenity.StringEditor;
        U_RecQty: Serenity.DecimalEditor;
    }

    export class StockTransferLineForm extends Serenity.PrefixedContext {
        static formKey = 'InventoryTransferRequest.StockTransferLine';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!StockTransferLineForm.init)  {
                StockTransferLineForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(StockTransferLineForm, [
                    'DocEntry', w0,
                    'ItemCode', w1,
                    'ItemDescription', w1,
                    'Quantity', w2,
                    'Price', w2,
                    'Currency', w1,
                    'Rate', w2,
                    'DiscountPercent', w2,
                    'VendorNum', w1,
                    'SerialNumber', w1,
                    'WarehouseCode', w1,
                    'FromWarehouseCode', w1,
                    'ProjectCode', w1,
                    'Factor', w2,
                    'Factor2', w2,
                    'Factor3', w2,
                    'Factor4', w2,
                    'DistributionRule', w1,
                    'DistributionRule2', w1,
                    'DistributionRule3', w1,
                    'DistributionRule4', w1,
                    'DistributionRule5', w1,
                    'UseBaseUnits', w1,
                    'MeasureUnit', w1,
                    'UnitsOfMeasurment', w2,
                    'BaseType', w1,
                    'BaseLine', w0,
                    'BaseEntry', w0,
                    'UnitPrice', w2,
                    'UoMEntry', w0,
                    'UoMCode', w1,
                    'InventoryQuantity', w2,
                    'RemainingOpenQuantity', w2,
                    'RemainingOpenInventoryQuantity', w2,
                    'LineStatus', w1,
                    'U_RecQty', w2
                ]);
            }
        }
    }
}
