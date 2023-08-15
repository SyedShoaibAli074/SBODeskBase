namespace SAPWebPortal.Default {


    @Serenity.Decorators.registerEditor()
    export class BatchTypeValuesEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
			this.addOption("Cash", "Cash");
			this.addOption("Bank", "Bank");
            this.addOption("Cheque", "Cheque");



        }
    }
}