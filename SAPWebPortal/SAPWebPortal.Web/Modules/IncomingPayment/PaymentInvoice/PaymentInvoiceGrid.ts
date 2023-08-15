
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentInvoiceGrid extends Serenity.EntityGrid<PaymentInvoiceRow, any> {
        protected getColumnsKey() { return PaymentInvoiceColumns.columnsKey; }
        protected getDialogType() { return PaymentInvoiceDialog; }
        protected getIdProperty() { return PaymentInvoiceRow.idProperty; }
        protected getInsertPermission() { return PaymentInvoiceRow.insertPermission; }
        protected getLocalTextPrefix() { return PaymentInvoiceRow.localTextPrefix; }
        protected getService() { return PaymentInvoiceService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}