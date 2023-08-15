
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ShopifyWebkookSettingsDialog extends Serenity.EntityDialog<ShopifyWebkookSettingsRow, any> {
        protected getFormKey() { return ShopifyWebkookSettingsForm.formKey; }
        protected getIdProperty() { return ShopifyWebkookSettingsRow.idProperty; }
        protected getLocalTextPrefix() { return ShopifyWebkookSettingsRow.localTextPrefix; }
        protected getNameProperty() { return ShopifyWebkookSettingsRow.nameProperty; }
        protected getService() { return ShopifyWebkookSettingsService.baseUrl; }
        protected getDeletePermission() { return ShopifyWebkookSettingsRow.deletePermission; }
        protected getInsertPermission() { return ShopifyWebkookSettingsRow.insertPermission; }
        protected getUpdatePermission() { return ShopifyWebkookSettingsRow.updatePermission; }

        protected form = new ShopifyWebkookSettingsForm(this.idPrefix);
        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push(
                {
                    title: Q.text("Remove"),	
                    cssClass: 'stampe',
                    icon: 'fa-trash',
                    onClick: () => {

                       

                    },
                }
            );



            return buttons;
        }
        afterLoadEntity() {
            super.afterLoadEntity();
            if (this.isEditMode()) {
                Serenity.EditorUtils.setReadonly(this.form.ShopifyWebhookTopic.element, true);
                Serenity.EditorUtils.setReadonly(this.form.ShopifyStore.element, true);
            }
            

        }
    }
}