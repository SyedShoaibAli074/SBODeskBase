
namespace SAPWebPortal.APInvoice {
	import fld = APInvoice.DocumentRow.Fields;
    @Serenity.Decorators.registerClass()
    export class DocumentGrid extends _Ext.GridBase1<DocumentRow, any> {
        protected getColumnsKey() { return DocumentColumns.columnsKey; }
        protected getDialogType() { return DocumentDialog; }
        protected getIdProperty() { return DocumentRow.idProperty; }
        protected getInsertPermission() { return DocumentRow.insertPermission; }
        protected getLocalTextPrefix() { return DocumentRow.localTextPrefix; }
        protected getService() { return DocumentService.baseUrl; }


        constructor(container: JQuery, options?) {
            options.SomeProp = 15;
            super(container, options);
            var current = IncomingPayment.PaymentDialog.Form;
            var current1 = OutgoingPayment.PaymentDialog.Form;
            if (current1 || current != undefined) {
                $(".s-Serenity-QuickFilterBar").hide();
                $(".QuickFilterBar").hide();
            }
        }
		protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {

			// get quick filter list from base class
			let filters = super.getQuickFilters();

			//quick filter init method is a good place to set initial
            //value for a quick filter editor, just after it is created
            var current = IncomingPayment.PaymentDialog.Form;
            var current1 = OutgoingPayment.PaymentDialog.Form;
            if (current != undefined) {
                Q.first(filters, x => x.field == fld.CardCode).init = w => {

                    (w as _Ext.GridItemPickerEditor).value = current.CardCode.value.toString();

                };
            }
            if (current1 != undefined) {
                Q.first(filters, x => x.field == fld.CardCode).init = w => {

                    (w as _Ext.GridItemPickerEditor).value = current1.CardCode.value.toString();

                };
            }
		


			return filters;
		}
    }
}