
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class UserDetail2Grid extends Serenity.EntityGrid<UserDetail2Row, any> {
        protected getColumnsKey() { return UserDetail2Columns.columnsKey; }
        protected getDialogType() { return UserDetail2Dialog; }
        protected getIdProperty() { return UserDetail2Row.idProperty; }
        protected getInsertPermission() { return UserDetail2Row.insertPermission; }
        protected getLocalTextPrefix() { return UserDetail2Row.localTextPrefix; }
        protected getService() { return UserDetail2Service.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}