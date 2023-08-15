
namespace SAPWebPortal.Orders {
	import fld = Default.AddressExtensionRow.Fields;
    @Serenity.Decorators.registerClass()
    export class AddressExtensionEditor extends _Ext.GridEditorBase<AddressExtensionRow> {
        protected getColumnsKey() { return "Orders.AddressExtension"; }
        protected getDialogType() { return AddressExtensionDialog; }
        protected getLocalTextPrefix() { return AddressExtensionRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);

           

		}
		

    }
}