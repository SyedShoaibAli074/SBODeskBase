namespace SAPWebPortal.Default {


    @Serenity.Decorators.registerEditor()
    export class CardTypeValuesEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            this.addOption("cLid", "Lead");
            this.addOption("cCustomer", "Customer");
            this.addOption("cSupplier", "Supplier");



        }
    }
}