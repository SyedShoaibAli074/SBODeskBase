
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ApprovalRequestLineDialog extends _Ext.EditorDialogBase<ApprovalRequestLineRow> {
        protected getFormKey() { return ApprovalRequestLineForm.formKey; }
        //protected getIdProperty() { return ApprovalRequestLineRow.idProperty; }
        protected getLocalTextPrefix() { return ApprovalRequestLineRow.localTextPrefix; }
        protected getService() { return ApprovalRequestLineService.baseUrl; }
        //protected getDeletePermission() { return ApprovalRequestLineRow.deletePermission; }
        //protected getInsertPermission() { return ApprovalRequestLineRow.insertPermission; }
        //protected getUpdatePermission() { return ApprovalRequestLineRow.updatePermission; }

        protected form = new ApprovalRequestLineForm(this.idPrefix);
        constructor(container: JQuery) {
            super(container);
        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity();
            this.toolbar.findButton('save-and-close-button').hide();
            this.toolbar.findButton('apply-changes-button').hide();
            this.toolbar.findButton('delete-button').hide();
            var service = this.getService();
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
        }
        //protected getToolbarButtons(): Serenity.ToolButton[] {
        //    let buttons = super.getToolbarButtons();
        //    buttons.splice(Q.indexOf(buttons, x => x.cssClass == "save-and-close-button"), 1);
        //    buttons.splice(Q.indexOf(buttons, x => x.cssClass == "apply-changes-button"), 1);
        //    buttons.splice(Q.indexOf(buttons, x => x.cssClass == "delete-button"), 1);
        //    return buttons;
        //}
    }
}