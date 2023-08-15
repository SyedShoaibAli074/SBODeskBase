namespace SAPWebPortal.Modules.DropDownEnums {


    @Serenity.Decorators.registerEditor()
    export class DocTypeEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
             
            this.addOption("dDocument_Items", "Items");
            this.addOption("dDocument_Service", "Service");
        }
    }
}