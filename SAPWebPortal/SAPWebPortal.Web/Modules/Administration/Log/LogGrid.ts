
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class LogGrid extends Serenity.EntityGrid<LogRow, any> {
        protected getColumnsKey() { return LogColumns.columnsKey; }
        protected getDialogType() { return LogDialog; }
        protected getIdProperty() { return LogRow.idProperty; }
        protected getInsertPermission() { return LogRow.insertPermission; }
        protected getLocalTextPrefix() { return LogRow.localTextPrefix; }
        protected getService() { return LogService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getButtons() {
            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }
    }
}