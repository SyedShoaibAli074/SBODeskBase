
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    export class PaymentCreditCardGrid extends Serenity.EntityGrid<PaymentCreditCardRow, any> {
        protected getColumnsKey() { return PaymentCreditCardColumns.columnsKey; }
        protected getDialogType() { return PaymentCreditCardDialog; }
        protected getIdProperty() { return PaymentCreditCardRow.idProperty; }
        protected getInsertPermission() { return PaymentCreditCardRow.insertPermission; }
        protected getLocalTextPrefix() { return PaymentCreditCardRow.localTextPrefix; }
        protected getService() { return PaymentCreditCardService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}