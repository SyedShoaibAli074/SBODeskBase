namespace SAPWebPortal.InventoryCounting {
    export interface InventoryCountingLineForm {
        LineNumber: Serenity.IntegerEditor;
        ItemCode: Serenity.StringEditor;
        ItemDescription: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        InWarehouseQuantity: Serenity.DecimalEditor;
        CountedQuantity: Serenity.DecimalEditor;
    }

    export class InventoryCountingLineForm extends Serenity.PrefixedContext {
        static formKey = 'InventoryCounting.InventoryCountingLine';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!InventoryCountingLineForm.init)  {
                InventoryCountingLineForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(InventoryCountingLineForm, [
                    'LineNumber', w0,
                    'ItemCode', w1,
                    'ItemDescription', w1,
                    'WarehouseCode', w1,
                    'InWarehouseQuantity', w2,
                    'CountedQuantity', w2
                ]);
            }
        }
    }
}
