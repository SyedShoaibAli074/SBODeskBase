
namespace SAPWebPortal.InventoryTransferRequest {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class StockTransferDialog extends Serenity.EntityDialog<StockTransferRow, any> {
        protected getFormKey() { return StockTransferForm.formKey; }
        protected getIdProperty() { return StockTransferRow.idProperty; }
        protected getLocalTextPrefix() { return StockTransferRow.localTextPrefix; }
        protected getNameProperty() { return StockTransferRow.nameProperty; }
        protected getService() { return StockTransferService.baseUrl; }
        protected getDeletePermission() { return StockTransferRow.deletePermission; }
        protected getInsertPermission() { return StockTransferRow.insertPermission; }
        protected getUpdatePermission() { return StockTransferRow.updatePermission; }

        protected form = new StockTransferForm(this.idPrefix);
        //after load entry
        protected afterLoadEntity() {

            this.form.DBName.value = localStorage.getItem("DBName");
        }

    }
}