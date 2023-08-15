
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
   
	export class ShopifySettingsDetailEditor extends _Ext.GridEditorBase<ShopifySettingsDetailRow> {
		protected getColumnsKey() { return ShopifySettingsDetailColumns.columnsKey; }
		protected getDialogType() { return ShopifySettingsDetailDialog; }
		protected getLocalTextPrefix() { return ShopifySettingsDetailRow.localTextPrefix; }
      

        constructor(container: JQuery) {
			super(container);
			
			
		}
		
		
	}
}
