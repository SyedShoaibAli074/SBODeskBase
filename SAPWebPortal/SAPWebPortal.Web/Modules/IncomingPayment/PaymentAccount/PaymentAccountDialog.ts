
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentAccountDialog extends _Ext.EditorDialogBase<PaymentAccountRow> {
        protected getFormKey() { return PaymentAccountForm.formKey; }
     //   protected getIdProperty() { return PaymentAccountRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentAccountRow.localTextPrefix; }
        //protected getService() { return PaymentAccountService.baseUrl; }
        //protected getDeletePermission() { return PaymentAccountRow.deletePermission; }
        //protected getInsertPermission() { return PaymentAccountRow.insertPermission; }
        //protected getUpdatePermission() { return PaymentAccountRow.updatePermission; }

        protected form = new PaymentAccountForm(this.idPrefix);

    }
}