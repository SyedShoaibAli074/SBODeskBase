
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class ApprovalRequestDialog extends Serenity.EntityDialog<ApprovalRequestRow, any> {
        protected getFormKey() { return ApprovalRequestForm.formKey; }
        protected getIdProperty() { return ApprovalRequestRow.idProperty; }
        protected getLocalTextPrefix() { return ApprovalRequestRow.localTextPrefix; }
        protected getService() { return ApprovalRequestService.baseUrl; }
        protected getDeletePermission() { return ApprovalRequestRow.deletePermission; }
        protected getInsertPermission() { return ApprovalRequestRow.insertPermission; }
        protected getUpdatePermission() { return ApprovalRequestRow.updatePermission; }

        protected form = new ApprovalRequestForm(this.idPrefix);
        public static Form: ApprovalRequestForm;
        constructor(opt?: any) {
            super(opt);
            //this.form.ApprovalRequestDecisions.view.onDataChanged.subscribe(() => {

            //    var st = this.form.ApprovalRequestDecisions.

            //});
        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity();
            this.toolbar.findButton('delete-button').hide();
            var c = this.form.ApprovalRequestLines.getGrid().getColumns();
            c = c.filter(f => f.field != "inline-actions");
            this.form.ApprovalRequestLines.getGrid().setColumns(c);
            var service = this.getService();
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
            this.form.DBName.value = localStorage.getItem("DBName");

        }
    }
}