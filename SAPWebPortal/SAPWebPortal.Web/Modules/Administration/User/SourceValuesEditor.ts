namespace SAPWebPortal.Administration {


    @Serenity.Decorators.registerEditor()
    export class SourceValuesEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);
            this.addOption("site", "site");
            this.addOption("SBO", "SBO");
			



        }
    }
}