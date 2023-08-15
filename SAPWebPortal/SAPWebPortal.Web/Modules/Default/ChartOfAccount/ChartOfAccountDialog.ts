
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ChartOfAccountDialog extends Serenity.EntityDialog<ChartOfAccountRow, any> {
        protected getFormKey() { return ChartOfAccountForm.formKey; }
        protected getIdProperty() { return ChartOfAccountRow.idProperty; }
        protected getLocalTextPrefix() { return ChartOfAccountRow.localTextPrefix; }
        protected getService() { return ChartOfAccountService.baseUrl; }
        protected getDeletePermission() { return ChartOfAccountRow.deletePermission; }
        protected getInsertPermission() { return ChartOfAccountRow.insertPermission; }
        protected getUpdatePermission() { return ChartOfAccountRow.updatePermission; }

        protected form = new ChartOfAccountForm(this.idPrefix);

    }
}