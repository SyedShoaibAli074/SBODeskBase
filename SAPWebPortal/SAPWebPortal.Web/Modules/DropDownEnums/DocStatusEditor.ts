namespace SAPWebPortal.Modules.DropDownEnums {


    @Serenity.Decorators.registerEditor()
    export class DocStatusEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
             
            this.addOption("bost_Open", "Open");
            this.addOption("bost_Close", "Close");
            this.addOption("bost_Paid", "Paid");
            this.addOption("bost_Delivered", "Delivered");
        }
    }
}