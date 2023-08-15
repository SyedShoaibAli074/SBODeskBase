
namespace SAPWebPortal.IncomingPayment {
	import fld = IncomingPayment.PaymentCheckRow.Fields;
    @Serenity.Decorators.registerClass()
	export class PaymentCheckEditor extends _Ext.GridEditorBase<PaymentCheckRow> {
		protected getColumnsKey() { return "IncomingPayment.PaymentCheck"; }
		protected getDialogType() { return PaymentCheckDialog; }
		protected getLocalTextPrefix() { return PaymentCheckRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);

           

		}
		
    }
}