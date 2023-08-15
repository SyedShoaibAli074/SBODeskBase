
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class ExceptionsDialog extends Serenity.EntityDialog<ExceptionsRow, any> {
        protected getFormKey() { return ExceptionsForm.formKey; }
        protected getIdProperty() { return ExceptionsRow.idProperty; }
        protected getLocalTextPrefix() { return ExceptionsRow.localTextPrefix; }
        protected getNameProperty() { return ExceptionsRow.nameProperty; }
        protected getService() { return ExceptionsService.baseUrl; }
        protected getDeletePermission() { return ExceptionsRow.deletePermission; }
        protected getInsertPermission() { return ExceptionsRow.insertPermission; }
        protected getUpdatePermission() { return ExceptionsRow.updatePermission; }

        protected form = new ExceptionsForm(this.idPrefix);

    }
}