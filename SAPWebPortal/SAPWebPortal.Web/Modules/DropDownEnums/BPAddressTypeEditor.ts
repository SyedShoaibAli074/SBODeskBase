namespace SAPWebPortal.Default {


    @Serenity.Decorators.registerEditor()
    export class BPAddressTypeEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            this.addOption("bo_ShipTo", "Ship To");
            this.addOption("bo_BillTo", "Bill To");
        }
    }
}