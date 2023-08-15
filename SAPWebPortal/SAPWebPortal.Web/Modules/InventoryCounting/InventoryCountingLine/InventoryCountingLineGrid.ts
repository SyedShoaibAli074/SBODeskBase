
namespace SAPWebPortal.InventoryCounting {

    @Serenity.Decorators.registerClass()
    export class InventoryCountingLineGrid extends Serenity.EntityGrid<InventoryCountingLineRow, any> {
        protected getColumnsKey() { return InventoryCountingLineColumns.columnsKey; }
        protected getDialogType() { return InventoryCountingLineDialog; }
        protected getIdProperty() { return InventoryCountingLineRow.idProperty; }
        protected getInsertPermission() { return InventoryCountingLineRow.insertPermission; }
        protected getLocalTextPrefix() { return InventoryCountingLineRow.localTextPrefix; }
        protected getService() { return InventoryCountingLineService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}