namespace SAPWebPortal.Modules.DropDownEnums {
    @Serenity.Decorators.registerEditor()
    export class DirectionEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
            this.addOption("SAPToShopify", "SAPToShopify");
            this.addOption("ShopifyToSAP", "ShopifyToSAP");
        }
    }
}