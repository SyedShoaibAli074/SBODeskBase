
namespace SAPWebPortal.IncomingPayment {
	import fld = IncomingPayment.PaymentInvoiceRow.Fields;
    @Serenity.Decorators.registerClass()
	export class PaymentInvoiceEditor extends _Ext.GridEditorBase<PaymentInvoiceRow> {
		protected getColumnsKey() { return "IncomingPayment.PaymentInvoice"; }
		protected getDialogType() { return PaymentInvoiceDialog; }
		protected getLocalTextPrefix() { return PaymentInvoiceRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);

           

		}
		
    }
}