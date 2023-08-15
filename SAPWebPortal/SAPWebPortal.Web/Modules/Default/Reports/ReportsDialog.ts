
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()

    export class ReportsDialog extends _Ext.DialogBase<ReportsRow, any> {
        protected getFormKey() { return ReportsForm.formKey; }
        protected getIdProperty() { return ReportsRow.idProperty; }
        protected getLocalTextPrefix() { return ReportsRow.localTextPrefix; }
        protected getNameProperty() { return ReportsRow.nameProperty; }
        protected getService() { return ReportsService.baseUrl; }
        protected getDeletePermission() { return ReportsRow.deletePermission; }
        protected getInsertPermission() { return ReportsRow.insertPermission; }
        protected getUpdatePermission() { return ReportsRow.updatePermission; }

        protected form = new ReportsForm(this.idPrefix);
        constructor(container: JQuery) {
            super(container);
        }
    }
}