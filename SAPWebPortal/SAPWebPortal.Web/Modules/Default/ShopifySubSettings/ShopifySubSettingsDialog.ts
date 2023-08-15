
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifySubSettingsDialog extends Serenity.EntityDialog<ShopifySubSettingsRow, any> {
        protected getFormKey() { return ShopifySubSettingsForm.formKey; }
        protected getIdProperty() { return ShopifySubSettingsRow.idProperty; }
        protected getLocalTextPrefix() { return ShopifySubSettingsRow.localTextPrefix; }
        protected getNameProperty() { return ShopifySubSettingsRow.nameProperty; }
        protected getService() { return ShopifySubSettingsService.baseUrl; }
        protected getDeletePermission() { return ShopifySubSettingsRow.deletePermission; }
        protected getInsertPermission() { return ShopifySubSettingsRow.insertPermission; }
        protected getUpdatePermission() { return ShopifySubSettingsRow.updatePermission; }

        protected form = new ShopifySubSettingsForm(this.idPrefix);

    }
}