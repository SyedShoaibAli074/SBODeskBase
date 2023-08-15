
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifySettingsGrid extends _Ext.GridBase<ShopifySettingsRow, any> {
        protected getColumnsKey() { return ShopifySettingsColumns.columnsKey; }
        protected getDialogType() { return ShopifySettingsDialog; }
        protected getIdProperty() { return ShopifySettingsRow.idProperty; }
        protected getInsertPermission() { return ShopifySettingsRow.insertPermission; }
        protected getLocalTextPrefix() { return ShopifySettingsRow.localTextPrefix; }
        protected getService() { return ShopifySettingsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}