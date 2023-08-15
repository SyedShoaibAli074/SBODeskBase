
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentCreditCardDialog extends _Ext.EditorDialogBase<PaymentCreditCardRow> {
        protected getFormKey() { return PaymentCreditCardForm.formKey; }
       // protected getIdProperty() { return PaymentCreditCardRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentCreditCardRow.localTextPrefix; }
        //protected getService() { return PaymentCreditCardService.baseUrl; }
        //protected getDeletePermission() { return PaymentCreditCardRow.deletePermission; }
        //protected getInsertPermission() { return PaymentCreditCardRow.insertPermission; }
        //protected getUpdatePermission() { return PaymentCreditCardRow.updatePermission; }

        protected form = new PaymentCreditCardForm(this.idPrefix);

    }
}