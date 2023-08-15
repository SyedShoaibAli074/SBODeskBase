namespace SAPWebPortal.Default {
    export interface ItemForm {
        ItemCode: Serenity.StringEditor;
        ItemName: Serenity.StringEditor;
        ForeignName: Serenity.StringEditor;
        BarCode: Serenity.StringEditor;
        PurchaseItem: Modules.DropDownEnums.YesOrNoEditor;
        SalesItem: Modules.DropDownEnums.YesOrNoEditor;
        InventoryItem: Modules.DropDownEnums.YesOrNoEditor;
        ItemWarehouseInfoCollection: ItemWarehouseInfoCollectionEditor;
    }

    export class ItemForm extends Serenity.PrefixedContext {
        static formKey = 'Default.Item';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ItemForm.init)  {
                ItemForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = Modules.DropDownEnums.YesOrNoEditor;
                var w2 = ItemWarehouseInfoCollectionEditor;

                Q.initFormType(ItemForm, [
                    'ItemCode', w0,
                    'ItemName', w0,
                    'ForeignName', w0,
                    'BarCode', w0,
                    'PurchaseItem', w1,
                    'SalesItem', w1,
                    'InventoryItem', w1,
                    'ItemWarehouseInfoCollection', w2
                ]);
            }
        }
    }
}
