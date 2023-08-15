
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class ItemDialog extends _Ext.DialogBase<ItemRow, any> {
        protected getFormKey() { return ItemForm.formKey; }
        protected getIdProperty() { return ItemRow.idProperty; }
        protected getLocalTextPrefix() { return ItemRow.localTextPrefix; }
        protected getNameProperty() { return ItemRow.nameProperty; }
        protected getService() { return ItemService.baseUrl; }
        protected getDeletePermission() { return ItemRow.deletePermission; }
        protected getInsertPermission() { return ItemRow.insertPermission; }
        protected getUpdatePermission() { return ItemRow.updatePermission; }

        protected form = new ItemForm(this.idPrefix);
        constructor(container: JQuery) {
            super(container);
        }
        protected afterLoadEntity() {
            super.afterLoadEntity();
            if (!this.isEditMode()) {
                q.hideEditorTab(this.form.ItemWarehouseInfoCollection);
			}
        }
    }
}