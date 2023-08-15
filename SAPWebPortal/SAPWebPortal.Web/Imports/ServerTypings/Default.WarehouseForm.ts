namespace SAPWebPortal.Default {
    export interface WarehouseForm {
        WarehouseCode: Serenity.StringEditor;
        WarehouseName: Serenity.StringEditor;
    }

    export class WarehouseForm extends Serenity.PrefixedContext {
        static formKey = 'Default.Warehouse';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!WarehouseForm.init)  {
                WarehouseForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(WarehouseForm, [
                    'WarehouseCode', w0,
                    'WarehouseName', w0
                ]);
            }
        }
    }
}
