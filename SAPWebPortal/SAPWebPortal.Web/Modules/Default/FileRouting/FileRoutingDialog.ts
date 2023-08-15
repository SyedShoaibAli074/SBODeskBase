
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class FileRoutingDialog extends Serenity.EntityDialog<FileRoutingRow, any> {
        protected getFormKey() { return FileRoutingForm.formKey; }
        protected getIdProperty() { return FileRoutingRow.idProperty; }
        protected getLocalTextPrefix() { return FileRoutingRow.localTextPrefix; }
        protected getNameProperty() { return FileRoutingRow.nameProperty; }
        protected getService() { return FileRoutingService.baseUrl; }
        protected getDeletePermission() { return FileRoutingRow.deletePermission; }
        protected getInsertPermission() { return FileRoutingRow.insertPermission; }
        protected getUpdatePermission() { return FileRoutingRow.updatePermission; }

        protected form = new FileRoutingForm(this.idPrefix);

    }
}