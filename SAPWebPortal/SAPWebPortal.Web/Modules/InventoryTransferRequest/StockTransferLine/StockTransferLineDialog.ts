
namespace SAPWebPortal.InventoryTransferRequest {

    @Serenity.Decorators.registerClass()
    export class StockTransferLineDialog extends _Ext.EditorDialogBase<StockTransferLineRow> {
        protected getFormKey() { return StockTransferLineForm.formKey; }
        protected getLocalTextPrefix() { return StockTransferLineRow.localTextPrefix; }
       
        

        protected form = new StockTransferLineForm(this.idPrefix);

    }
}