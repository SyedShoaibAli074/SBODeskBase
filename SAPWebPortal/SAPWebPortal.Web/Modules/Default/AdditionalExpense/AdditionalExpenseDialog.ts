
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class AdditionalExpenseDialog extends Serenity.EntityDialog<AdditionalExpenseRow, any> {
        protected getFormKey() { return AdditionalExpenseForm.formKey; }
        protected getIdProperty() { return AdditionalExpenseRow.idProperty; }
        protected getLocalTextPrefix() { return AdditionalExpenseRow.localTextPrefix; }
        protected getService() { return AdditionalExpenseService.baseUrl; }
        protected getDeletePermission() { return AdditionalExpenseRow.deletePermission; }
        protected getInsertPermission() { return AdditionalExpenseRow.insertPermission; }
        protected getUpdatePermission() { return AdditionalExpenseRow.updatePermission; }

        protected form = new AdditionalExpenseForm(this.idPrefix);

    }
}