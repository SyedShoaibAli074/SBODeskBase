
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentCheckDialog extends _Ext.EditorDialogBase<PaymentCheckRow> {
        protected getFormKey() { return PaymentCheckForm.formKey; }
      //  protected getIdProperty() { return PaymentCheckRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentCheckRow.localTextPrefix; }
        //protected getService() { return PaymentCheckService.baseUrl; }
        //protected getDeletePermission() { return PaymentCheckRow.deletePermission; }
        //protected getInsertPermission() { return PaymentCheckRow.insertPermission; }
        //protected getUpdatePermission() { return PaymentCheckRow.updatePermission; }

        protected form = new PaymentCheckForm(this.idPrefix);

    }
}