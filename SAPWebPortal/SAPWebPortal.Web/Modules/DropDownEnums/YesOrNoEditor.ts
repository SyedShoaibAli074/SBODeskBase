namespace SAPWebPortal.Modules.DropDownEnums {
    @Serenity.Decorators.registerEditor()
    export class YesOrNoEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
             
            this.addOption("tYES", "Yes");
            this.addOption("tNO", "No");
        }
    }
}