
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class SapToShopifySyncLogDialog extends Serenity.EntityDialog<SapToShopifySyncLogRow, any> {
        protected getFormKey() { return SapToShopifySyncLogForm.formKey; }
        protected getIdProperty() { return SapToShopifySyncLogRow.idProperty; }
        protected getLocalTextPrefix() { return SapToShopifySyncLogRow.localTextPrefix; }
        protected getNameProperty() { return SapToShopifySyncLogRow.nameProperty; }
        protected getService() { return SapToShopifySyncLogService.baseUrl; }
        protected getDeletePermission() { return SapToShopifySyncLogRow.deletePermission; }
        protected getInsertPermission() { return SapToShopifySyncLogRow.insertPermission; }
        protected getUpdatePermission() { return SapToShopifySyncLogRow.updatePermission; }

        protected form = new SapToShopifySyncLogForm(this.idPrefix);

    }
}