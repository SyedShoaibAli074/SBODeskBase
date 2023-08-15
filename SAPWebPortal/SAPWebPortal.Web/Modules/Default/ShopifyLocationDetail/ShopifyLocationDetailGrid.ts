
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifyLocationDetailGrid extends Serenity.EntityGrid<ShopifyLocationDetailRow, any> {
        protected getColumnsKey() { return ShopifyLocationDetailColumns.columnsKey; }
        protected getDialogType() { return ShopifyLocationDetailDialog; }
        protected getIdProperty() { return ShopifyLocationDetailRow.idProperty; }
        protected getInsertPermission() { return ShopifyLocationDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return ShopifyLocationDetailRow.localTextPrefix; }
        protected getService() { return ShopifyLocationDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}