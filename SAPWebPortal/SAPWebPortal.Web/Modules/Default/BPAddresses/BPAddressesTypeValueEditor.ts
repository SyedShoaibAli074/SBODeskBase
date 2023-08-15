namespace SAPWebPortal.Default {


    @Serenity.Decorators.registerEditor()
    export class BPAddressesTypeValueEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            this.addOption("S", "Ship To");
            this.addOption("B", "Bill To");



        }
    }
}