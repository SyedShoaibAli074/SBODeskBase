
namespace SAPWebPortal.IncomingPayment {
	import fld = IncomingPayment.PaymentAccountRow.Fields;
    @Serenity.Decorators.registerClass()
	export class PaymentAccountEditor extends _Ext.GridEditorBase<PaymentAccountRow> {
		protected getColumnsKey() { return "IncomingPayment.PaymentAccount"; }
		protected getDialogType() { return PaymentAccountDialog; }
		protected getLocalTextPrefix() { return PaymentAccountRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);

           

		}
		
    }
}