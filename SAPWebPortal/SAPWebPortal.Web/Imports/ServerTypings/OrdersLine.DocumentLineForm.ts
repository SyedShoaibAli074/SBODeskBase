namespace SAPWebPortal.OrdersLine {
    export interface DocumentLineForm {
        LineNum: Serenity.IntegerEditor;
        ItemCode: _Ext.GridItemPickerEditor;
        ItemDescription: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        UnitsOfMeasurment: Serenity.DecimalEditor;
        UnitPrice: Serenity.DecimalEditor;
        DiscountPercent: Serenity.DecimalEditor;
        InventoryQuantity: Serenity.DecimalEditor;
        VatGroup: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        UoMCode: Serenity.StringEditor;
        PriceAfterVat: Serenity.DecimalEditor;
        TaxTotal: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
    }

    export class DocumentLineForm extends Serenity.PrefixedContext {
        static formKey = 'OrdersLine.DocumentLine';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!DocumentLineForm.init)  {
                DocumentLineForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = _Ext.GridItemPickerEditor;
                var w2 = s.StringEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(DocumentLineForm, [
                    'LineNum', w0,
                    'ItemCode', w1,
                    'ItemDescription', w2,
                    'Quantity', w3,
                    'UnitsOfMeasurment', w3,
                    'UnitPrice', w3,
                    'DiscountPercent', w3,
                    'InventoryQuantity', w3,
                    'VatGroup', w2,
                    'WarehouseCode', w2,
                    'UoMCode', w2,
                    'PriceAfterVat', w3,
                    'TaxTotal', w3,
                    'LineTotal', w3
                ]);
            }
        }
    }
}
