
namespace SAPWebPortal.IncomingPayment {
	import fld = IncomingPayment.PaymentCreditCardRow.Fields;
    @Serenity.Decorators.registerClass()
	export class PaymentCreditCardEditor extends _Ext.GridEditorBase<PaymentCreditCardRow> {
		protected getColumnsKey() { return "IncomingPayment.PaymentCreditCard"; }
		protected getDialogType() { return PaymentCreditCardDialog; }
		protected getLocalTextPrefix() { return PaymentCreditCardRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);

           

		}
		
    }
}