
namespace SAPWebPortal.InventoryTransferRequest {

    @Serenity.Decorators.registerClass()  
    export class StockTransferGrid extends _Ext.GridBase1<StockTransferRow, any> {
        protected getColumnsKey() { return StockTransferColumns.columnsKey; }
        protected getDialogType() { return StockTransferDialog; }
        protected getIdProperty() { return StockTransferRow.idProperty; }
        protected getInsertPermission() { return StockTransferRow.insertPermission; }
        protected getLocalTextPrefix() { return StockTransferRow.localTextPrefix; }
        protected getService() { return StockTransferService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected onViewSubmit(): boolean {
            if (!super.onViewSubmit()) { return false; }
            let request = this.view.params as Serenity.ListRequest;
            var DB = localStorage.getItem("DBName");
            request.CompanyDB = DB;
            return true;
        }

    }
}