
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class ExceptionsGrid extends Serenity.EntityGrid<ExceptionsRow, any> {
        protected getColumnsKey() { return ExceptionsColumns.columnsKey; }
        protected getDialogType() { return ExceptionsDialog; }
        protected getIdProperty() { return ExceptionsRow.idProperty; }
        protected getInsertPermission() { return ExceptionsRow.insertPermission; }
        protected getLocalTextPrefix() { return ExceptionsRow.localTextPrefix; }
        protected getService() { return ExceptionsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }
    }
}