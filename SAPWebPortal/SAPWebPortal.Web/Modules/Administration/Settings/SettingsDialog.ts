
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class SettingsDialog extends Serenity.EntityDialog<SettingsRow, any> {
        protected getFormKey() { return SettingsForm.formKey; }
        protected getIdProperty() { return SettingsRow.idProperty; }
        protected getLocalTextPrefix() { return SettingsRow.localTextPrefix; }
        protected getNameProperty() { return SettingsRow.nameProperty; }
        protected getService() { return SettingsService.baseUrl; }
        protected getDeletePermission() { return SettingsRow.deletePermission; }
        protected getInsertPermission() { return SettingsRow.insertPermission; }
        protected getUpdatePermission() { return SettingsRow.updatePermission; }

        protected form = new SettingsForm(this.idPrefix);

    }
}