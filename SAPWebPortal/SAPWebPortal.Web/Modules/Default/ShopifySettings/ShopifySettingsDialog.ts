
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()

    export class ShopifySettingsDialog extends Serenity.EntityDialog<ShopifySettingsRow, any> {
        protected getFormKey() { return ShopifySettingsForm.formKey; }
        protected getIdProperty() { return ShopifySettingsRow.idProperty; }
        protected getLocalTextPrefix() { return ShopifySettingsRow.localTextPrefix; }
        protected getNameProperty() { return ShopifySettingsRow.nameProperty; }
        protected getService() { return ShopifySettingsService.baseUrl; }
        protected getDeletePermission() { return ShopifySettingsRow.deletePermission; }
        protected getInsertPermission() { return ShopifySettingsRow.insertPermission; }
        protected getUpdatePermission() { return ShopifySettingsRow.updatePermission; }

        protected form = new ShopifySettingsForm(this.idPrefix);

    }
}