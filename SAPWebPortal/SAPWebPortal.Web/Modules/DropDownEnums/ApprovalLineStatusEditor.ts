namespace SAPWebPortal.Modules.DropDownEnums {
    @Serenity.Decorators.registerEditor()
    export class ApprovalLineStatusEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);

            this.addOption("ardPending", "Pending");
            this.addOption("ardApproved", "Approved");
            this.addOption("ardNotApproved", "Rejected");
        }

    }


}