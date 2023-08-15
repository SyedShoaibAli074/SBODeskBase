
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentAccountGrid extends Serenity.EntityGrid<PaymentAccountRow, any> {
        protected getColumnsKey() { return PaymentAccountColumns.columnsKey; }
        protected getDialogType() { return PaymentAccountDialog; }
        protected getIdProperty() { return PaymentAccountRow.idProperty; }
        protected getInsertPermission() { return PaymentAccountRow.insertPermission; }
        protected getLocalTextPrefix() { return PaymentAccountRow.localTextPrefix; }
        protected getService() { return PaymentAccountService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}