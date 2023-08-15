
namespace SAPWebPortal.InventoryCounting {

    @Serenity.Decorators.registerClass()
    export class InventoryCountingGrid extends _Ext.GridBase1<InventoryCountingRow, any>  {
        protected getColumnsKey() { return InventoryCountingColumns.columnsKey; }
        protected getDialogType() { return InventoryCountingDialog; }
        protected getIdProperty() { return InventoryCountingRow.idProperty; }
        protected getInsertPermission() { return InventoryCountingRow.insertPermission; }
        protected getLocalTextPrefix() { return InventoryCountingRow.localTextPrefix; }
        protected getService() { return InventoryCountingService.baseUrl; }

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