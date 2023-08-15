
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class UsersGrid extends _Ext.GridBase<UsersRow, any> {
        protected getColumnsKey() { return UsersColumns.columnsKey; }
        protected getDialogType() { return UsersDialog; }
        protected getIdProperty() { return UsersRow.idProperty; }
        protected getInsertPermission() { return UsersRow.insertPermission; }
        protected getLocalTextPrefix() { return UsersRow.localTextPrefix; }
        protected getService() { return UsersService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        //For Removing the Add Button
        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }

    }
}