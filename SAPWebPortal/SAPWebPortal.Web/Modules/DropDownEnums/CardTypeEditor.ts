namespace SAPWebPortal.Modules.DropDownEnums {


    @Serenity.Decorators.registerEditor()
    export class CardTypeEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
             
            this.addOption("cCustomer", "Customer");
            this.addOption("cSupplier", "Supplier");
            this.addOption("cLid", "Lead");
        }
    }
}