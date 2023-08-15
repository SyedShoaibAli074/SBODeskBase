namespace SAPWebPortal.InventoryCounting {
    export interface InventoryCountingForm {
        DocumentNumber: Serenity.IntegerEditor;
        Series: Serenity.IntegerEditor;
        SingleCounterId: Serenity.IntegerEditor;
        Remarks: Serenity.StringEditor;
        InventoryCountingLines: Serenity.StringEditor;
    }

    export class InventoryCountingForm extends Serenity.PrefixedContext {
        static formKey = 'InventoryCounting.InventoryCounting';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!InventoryCountingForm.init)  {
                InventoryCountingForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;

                Q.initFormType(InventoryCountingForm, [
                    'DocumentNumber', w0,
                    'Series', w0,
                    'SingleCounterId', w0,
                    'Remarks', w1,
                    'InventoryCountingLines', w1
                ]);
            }
        }
    }
}
