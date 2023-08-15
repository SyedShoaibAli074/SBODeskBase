
namespace SAPWebPortal.Default {
    @Serenity.Decorators.panel()
    @Serenity.Decorators.registerClass()
    export class LogDialog extends Serenity.EntityDialog<LogRow, any> {
        protected getFormKey() { return LogForm.formKey; }
        protected getIdProperty() { return LogRow.idProperty; }
        protected getLocalTextPrefix() { return LogRow.localTextPrefix; }
        protected getNameProperty() { return LogRow.nameProperty; }
        protected getService() { return LogService.baseUrl; }
        protected getDeletePermission() { return LogRow.deletePermission; }
        protected getInsertPermission() { return LogRow.insertPermission; }
        protected getUpdatePermission() { return LogRow.updatePermission; }

        protected form = new LogForm(this.idPrefix);

    }
}