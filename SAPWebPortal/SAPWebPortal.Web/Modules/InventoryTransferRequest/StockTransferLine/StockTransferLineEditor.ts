namespace SAPWebPortal.InventoryTransferRequest {
    @Serenity.Decorators.registerClass()
    export class StockTransferLineEditor extends _Ext.GridEditorBase<SAPWebPortal.InventoryTransferRequest.StockTransferLineRow> {
        protected getColumnsKey() { return "InventoryTransferRequest.StockTransferLine"; }
        protected getDialogType() { return SAPWebPortal.InventoryTransferRequest.StockTransferLineDialog; }
        protected getLocalTextPrefix() { return SAPWebPortal.InventoryTransferRequest.StockTransferLineRow.localTextPrefix; }
        public static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery) {
            super(container);
        }
       
    }
}