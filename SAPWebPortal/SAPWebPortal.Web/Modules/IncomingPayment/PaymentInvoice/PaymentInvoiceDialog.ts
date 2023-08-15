
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentInvoiceDialog extends _Ext.EditorDialogBase<PaymentInvoiceRow> {
        protected getFormKey() { return PaymentInvoiceForm.formKey; }
       // protected getIdProperty() { return PaymentInvoiceRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentInvoiceRow.localTextPrefix; }
        //protected getService() { return PaymentInvoiceService.baseUrl; }
        //protected getDeletePermission() { return PaymentInvoiceRow.deletePermission; }
        //protected getInsertPermission() { return PaymentInvoiceRow.insertPermission; }
        //protected getUpdatePermission() { return PaymentInvoiceRow.updatePermission; }

        protected form = new PaymentInvoiceForm(this.idPrefix);

    }
}