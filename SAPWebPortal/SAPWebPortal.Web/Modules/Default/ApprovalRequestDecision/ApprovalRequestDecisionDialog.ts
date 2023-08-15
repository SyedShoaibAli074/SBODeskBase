
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ApprovalRequestDecisionDialog extends _Ext.EditorDialogBase<ApprovalRequestDecisionRow> {
        protected getFormKey() { return ApprovalRequestDecisionForm.formKey; }
        //protected getIdProperty() { return ApprovalRequestDecisionRow.idProperty; }
        protected getLocalTextPrefix() { return ApprovalRequestDecisionRow.localTextPrefix; }
        protected getService() { return ApprovalRequestDecisionService.baseUrl; }
        //protected getDeletePermission() { return ApprovalRequestDecisionRow.deletePermission; }
        //protected getInsertPermission() { return ApprovalRequestDecisionRow.insertPermission; }
        //protected getUpdatePermission() { return ApprovalRequestDecisionRow.updatePermission; }

        protected form = new ApprovalRequestDecisionForm(this.idPrefix);

    }
}