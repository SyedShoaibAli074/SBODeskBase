
namespace SAPWebPortal.Default {
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    @Serenity.Decorators.panel()

    export class Report_UsersDialog extends _Ext.EditorDialogBase<Report_UsersRow> {
        protected getFormKey() { return Report_UsersForm.formKey; }
        //protected getIdProperty() { return Report_UsersRow.idProperty; }
        protected getLocalTextPrefix() { return Report_UsersRow.localTextPrefix; }
        // protected getNameProperty() { return Report_UsersRow.nameProperty; }
        //protected getService() { return Report_UsersService.baseUrl; }
        protected form: Report_UsersForm;
        constructor() {
            super();
            this.form = new Report_UsersForm(this.idPrefix);
        }
    }
}