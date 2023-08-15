
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class SessionsGrid extends Serenity.EntityGrid<SessionsRow, any> {
        protected getColumnsKey() { return SessionsColumns.columnsKey; }
        protected getDialogType() { return SessionsDialog; }
        protected getIdProperty() { return SessionsRow.idProperty; }
        protected getInsertPermission() { return SessionsRow.insertPermission; }
        protected getLocalTextPrefix() { return SessionsRow.localTextPrefix; }
        protected getService() { return SessionsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}