
namespace SAPWebPortal.InventoryTransferRequest {

    @Serenity.Decorators.registerClass()
    export class StockTransferLineGrid extends Serenity.EntityGrid<StockTransferLineRow, any> {
        protected getColumnsKey() { return StockTransferLineColumns.columnsKey; }
        protected getDialogType() { return StockTransferLineDialog; }
        protected getIdProperty() { return StockTransferLineRow.idProperty; }
        protected getInsertPermission() { return StockTransferLineRow.insertPermission; }
        protected getLocalTextPrefix() { return StockTransferLineRow.localTextPrefix; }
        protected getService() { return StockTransferLineService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}