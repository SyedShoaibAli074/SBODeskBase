namespace SAPWebPortal.Modules.DropDownEnums {
    @Serenity.Decorators.registerEditor()
    export class ApprovalStatusEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);

            this.addOption("arsPending", "Pending");
            this.addOption("arsApproved", "Approved");
            this.addOption("arsNotApproved", "Rejected");
        }
    }
}