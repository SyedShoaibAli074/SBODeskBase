
namespace SAPWebPortal.InventoryCounting {

    @Serenity.Decorators.registerClass()
    export class InventoryCountingDialog extends Serenity.EntityDialog<InventoryCountingRow, any> {
        protected getFormKey() { return InventoryCountingForm.formKey; }
        protected getIdProperty() { return InventoryCountingRow.idProperty; }
        protected getLocalTextPrefix() { return InventoryCountingRow.localTextPrefix; }
        protected getNameProperty() { return InventoryCountingRow.nameProperty; }
        protected getService() { return InventoryCountingService.baseUrl; }
        protected getDeletePermission() { return InventoryCountingRow.deletePermission; }
        protected getInsertPermission() { return InventoryCountingRow.insertPermission; }
        protected getUpdatePermission() { return InventoryCountingRow.updatePermission; }
        protected form = new InventoryCountingForm(this.idPrefix);
        protected afterLoadEntity() {

            this.form.DBName.value = localStorage.getItem("DBName");
        }

    }  
}