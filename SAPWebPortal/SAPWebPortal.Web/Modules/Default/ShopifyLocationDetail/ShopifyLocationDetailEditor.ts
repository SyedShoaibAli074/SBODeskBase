
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
   
	export class ShopifyLocationDetailEditor extends _Ext.GridEditorBase<ShopifyLocationDetailRow> {
		protected getColumnsKey() { return ShopifyLocationDetailColumns.columnsKey; }
		protected getDialogType() { return ShopifyLocationDetailDialog; }
		protected getLocalTextPrefix() { return ShopifyLocationDetailRow.localTextPrefix; }
      

        constructor(container: JQuery) {
			super(container);
			
			
		}
		
		
	}
}
