namespace SAPWebPortal.ARInvoiceLine {
    export interface DocumentLineForm {
        LineNum: Serenity.IntegerEditor;
        ItemCode: _Ext.GridItemPickerEditor;
        ItemDescription: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        UnitPrice: Serenity.StringEditor;
        DiscountPercent: Serenity.DecimalEditor;
        VatGroup: _Ext.GridItemPickerEditor;
        U_WRNT: Serenity.StringEditor;
        WarehouseCode: _Ext.GridItemPickerEditor;
        UoMCode: Serenity.StringEditor;
        PriceAfterVat: Serenity.DecimalEditor;
        TaxTotal: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        BaseEntry: Serenity.IntegerEditor;
        BaseType: Serenity.IntegerEditor;
        BaseLine: Serenity.IntegerEditor;
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
                    'UnitPrice', w2,
                    'DiscountPercent', w3,
                    'VatGroup', w1,
                    'U_WRNT', w2,
                    'WarehouseCode', w1,
                    'UoMCode', w2,
                    'PriceAfterVat', w3,
                    'TaxTotal', w3,
                    'LineTotal', w3,
                    'BaseEntry', w0,
                    'BaseType', w0,
                    'BaseLine', w0
                ]);
            }
        }
    }
}
