namespace SAPWebPortal.Default {


    @Serenity.Decorators.registerEditor()
    export class StatusValuesEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null); 
            this.addOption("Open", "Open");
            this.addOption("Close", "Close");



        }
    }
}