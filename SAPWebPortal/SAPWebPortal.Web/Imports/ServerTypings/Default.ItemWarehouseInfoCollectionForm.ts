namespace SAPWebPortal.Default {
    export interface ItemWarehouseInfoCollectionForm {
        ItemCode: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        InStock: Serenity.StringEditor;
        Committed: Serenity.StringEditor;
        Ordered: Serenity.StringEditor;
        CountedQuantity: Serenity.StringEditor;
    }

    export class ItemWarehouseInfoCollectionForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ItemWarehouseInfoCollection';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ItemWarehouseInfoCollectionForm.init)  {
                ItemWarehouseInfoCollectionForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(ItemWarehouseInfoCollectionForm, [
                    'ItemCode', w0,
                    'WarehouseCode', w0,
                    'InStock', w0,
                    'Committed', w0,
                    'Ordered', w0,
                    'CountedQuantity', w0
                ]);
            }
        }
    }
}
