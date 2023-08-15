
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class WarehouseDialog extends Serenity.EntityDialog<WarehouseRow, any> {
        protected getFormKey() { return WarehouseForm.formKey; }
        protected getIdProperty() { return WarehouseRow.idProperty; }
        protected getLocalTextPrefix() { return WarehouseRow.localTextPrefix; }
        protected getService() { return WarehouseService.baseUrl; }
        protected getDeletePermission() { return WarehouseRow.deletePermission; }
        protected getInsertPermission() { return WarehouseRow.insertPermission; }
        protected getUpdatePermission() { return WarehouseRow.updatePermission; }

        protected form = new WarehouseForm(this.idPrefix);

    }
}