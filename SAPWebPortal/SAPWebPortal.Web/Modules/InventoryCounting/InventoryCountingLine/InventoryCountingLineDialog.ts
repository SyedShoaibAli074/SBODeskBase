
namespace SAPWebPortal.InventoryCounting {

    @Serenity.Decorators.registerClass()
    export class InventoryCountingLineDialog extends Serenity.EntityDialog<InventoryCountingLineRow, any> {
        protected getFormKey() { return InventoryCountingLineForm.formKey; }
        protected getIdProperty() { return InventoryCountingLineRow.idProperty; }
        protected getLocalTextPrefix() { return InventoryCountingLineRow.localTextPrefix; }
        protected getNameProperty() { return InventoryCountingLineRow.nameProperty; }
        protected getService() { return InventoryCountingLineService.baseUrl; }
        protected getDeletePermission() { return InventoryCountingLineRow.deletePermission; }
        protected getInsertPermission() { return InventoryCountingLineRow.insertPermission; }
        protected getUpdatePermission() { return InventoryCountingLineRow.updatePermission; }

        protected form = new InventoryCountingLineForm(this.idPrefix);

    }
}