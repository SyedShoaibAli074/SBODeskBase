namespace SAPWebPortal.Modules.DropDownEnums {
    @Serenity.Decorators.registerEditor()
    export class IsYOrNEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
            this.addOption("Y", "Yes");
            this.addOption("N", "No");
        }
    }
}