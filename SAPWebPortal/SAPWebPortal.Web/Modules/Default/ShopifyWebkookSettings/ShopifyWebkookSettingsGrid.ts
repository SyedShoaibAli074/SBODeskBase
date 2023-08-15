
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifyWebkookSettingsGrid extends _Ext.GridBase<ShopifyWebkookSettingsRow, any> {
        protected getColumnsKey() { return ShopifyWebkookSettingsColumns.columnsKey; }
        protected getDialogType() { return ShopifyWebkookSettingsDialog; }
        protected getIdProperty() { return ShopifyWebkookSettingsRow.idProperty; }
        protected getInsertPermission() { return ShopifyWebkookSettingsRow.insertPermission; }
        protected getLocalTextPrefix() { return ShopifyWebkookSettingsRow.localTextPrefix; }
        protected getService() { return ShopifyWebkookSettingsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}