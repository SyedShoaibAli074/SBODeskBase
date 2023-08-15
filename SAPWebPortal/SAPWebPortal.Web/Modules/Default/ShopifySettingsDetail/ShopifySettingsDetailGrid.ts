
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()

    export class ShopifySettingsDetailGrid extends Serenity.EntityGrid<ShopifySettingsDetailRow, any> {
        protected getColumnsKey() { return ShopifySettingsDetailColumns.columnsKey; }
        protected getDialogType() { return ShopifySettingsDetailDialog; }
        protected getIdProperty() { return ShopifySettingsDetailRow.idProperty; }
        protected getInsertPermission() { return ShopifySettingsDetailRow.insertPermission; }
        protected getLocalTextPrefix() { return ShopifySettingsDetailRow.localTextPrefix; }
        protected getService() { return ShopifySettingsDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}