namespace SAPWebPortal.Default {
    export interface ShopifyLocationDetailForm {
        SapWarhouseCode: Serenity.StringEditor;
        ShopifyLocationCode: Serenity.StringEditor;
    }

    export class ShopifyLocationDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ShopifyLocationDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ShopifyLocationDetailForm.init)  {
                ShopifyLocationDetailForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(ShopifyLocationDetailForm, [
                    'SapWarhouseCode', w0,
                    'ShopifyLocationCode', w0
                ]);
            }
        }
    }
}
