
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class SapToShopifySyncLogGrid extends Serenity.EntityGrid<SapToShopifySyncLogRow, any> {
        protected getColumnsKey() { return SapToShopifySyncLogColumns.columnsKey; }
        protected getDialogType() { return SapToShopifySyncLogDialog; }
        protected getIdProperty() { return SapToShopifySyncLogRow.idProperty; }
        protected getInsertPermission() { return SapToShopifySyncLogRow.insertPermission; }
        protected getLocalTextPrefix() { return SapToShopifySyncLogRow.localTextPrefix; }
        protected getService() { return SapToShopifySyncLogService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}