
namespace SAPWebPortal.Default {
	import fld = Default.BPAddressesRow.Fields;
    @Serenity.Decorators.registerClass()
    export class BPAddressesEditor extends _Ext.GridEditorBase<BPAddressesRow> {
        protected getColumnsKey() { return "Default.BPAddresses"; }
        protected getDialogType() { return BPAddressesDialog; }
        protected getLocalTextPrefix() { return BPAddressesRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);

           

		}
		

    }
}