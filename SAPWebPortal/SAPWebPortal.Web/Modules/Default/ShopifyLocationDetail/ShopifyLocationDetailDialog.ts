
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifyLocationDetailDialog extends _Ext.EditorDialogBase<ShopifyLocationDetailRow> {
        protected getFormKey() { return ShopifyLocationDetailForm.formKey; }
        //protected getIdProperty() { return ShopifyLocationDetailRow.idProperty; }
        protected getLocalTextPrefix() { return ShopifyLocationDetailRow.localTextPrefix; }
        //protected getNameProperty() { return ShopifyLocationDetailRow.nameProperty; }
        protected getService() { return ShopifyLocationDetailService.baseUrl; }
        //protected getDeletePermission() { return ShopifyLocationDetailRow.deletePermission; }
        //protected getInsertPermission() { return ShopifyLocationDetailRow.insertPermission; }
        //protected getUpdatePermission() { return ShopifyLocationDetailRow.updatePermission; }

        protected form = new ShopifyLocationDetailForm(this.idPrefix);

    }
}