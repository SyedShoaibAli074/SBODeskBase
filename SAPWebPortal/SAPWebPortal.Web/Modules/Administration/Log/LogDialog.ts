
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel() 
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
        protected getToolbarButtons(): Serenity.ToolButton[] {
            let buttons = super.getToolbarButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "save-and-close-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "apply-changes-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "delete-button"), 1);
            return buttons;
        }
    }
}