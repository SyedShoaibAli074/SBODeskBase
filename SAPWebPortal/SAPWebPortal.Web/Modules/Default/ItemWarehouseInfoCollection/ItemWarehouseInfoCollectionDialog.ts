
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ItemWarehouseInfoCollectionDialog extends Serenity.EntityDialog<ItemWarehouseInfoCollectionRow, any> {
        protected getFormKey() { return ItemWarehouseInfoCollectionForm.formKey; }
        protected getIdProperty() { return ItemWarehouseInfoCollectionRow.idProperty; }
        protected getLocalTextPrefix() { return ItemWarehouseInfoCollectionRow.localTextPrefix; }
        protected getNameProperty() { return ItemWarehouseInfoCollectionRow.nameProperty; }
        protected getService() { return ItemWarehouseInfoCollectionService.baseUrl; }
        protected getDeletePermission() { return ItemWarehouseInfoCollectionRow.deletePermission; }
        protected getInsertPermission() { return ItemWarehouseInfoCollectionRow.insertPermission; }
        protected getUpdatePermission() { return ItemWarehouseInfoCollectionRow.updatePermission; }

        protected form = new ItemWarehouseInfoCollectionForm(this.idPrefix);

    }
}