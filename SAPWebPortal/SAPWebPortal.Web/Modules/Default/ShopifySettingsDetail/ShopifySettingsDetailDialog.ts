
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifySettingsDetailDialog extends _Ext.EditorDialogBase<ShopifySettingsDetailRow> {
        protected getFormKey() { return ShopifySettingsDetailForm.formKey; }
        //protected getIdProperty() { return ShopifySettingsDetailRow.idProperty; }
        protected getLocalTextPrefix() { return ShopifySettingsDetailRow.localTextPrefix; }
        //protected getNameProperty() { return ShopifySettingsDetailRow.nameProperty; }
        protected getService() { return ShopifySettingsDetailService.baseUrl; }
        //protected getDeletePermission() { return ShopifySettingsDetailRow.deletePermission; }
        //protected getInsertPermission() { return ShopifySettingsDetailRow.insertPermission; }
        //protected getUpdatePermission() { return ShopifySettingsDetailRow.updatePermission; }

        protected form = new ShopifySettingsDetailForm(this.idPrefix);

    }
}