
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifySubSettingsGrid extends Serenity.EntityGrid<ShopifySubSettingsRow, any> {
        protected getColumnsKey() { return ShopifySubSettingsColumns.columnsKey; }
        protected getDialogType() { return ShopifySubSettingsDialog; }
        protected getIdProperty() { return ShopifySubSettingsRow.idProperty; }
        protected getInsertPermission() { return ShopifySubSettingsRow.insertPermission; }
        protected getLocalTextPrefix() { return ShopifySubSettingsRow.localTextPrefix; }
        protected getService() { return ShopifySubSettingsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}