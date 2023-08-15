
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentCheckGrid extends Serenity.EntityGrid<PaymentCheckRow, any> {
        protected getColumnsKey() { return PaymentCheckColumns.columnsKey; }
        protected getDialogType() { return PaymentCheckDialog; }
        protected getIdProperty() { return PaymentCheckRow.idProperty; }
        protected getInsertPermission() { return PaymentCheckRow.insertPermission; }
        protected getLocalTextPrefix() { return PaymentCheckRow.localTextPrefix; }
        protected getService() { return PaymentCheckService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}