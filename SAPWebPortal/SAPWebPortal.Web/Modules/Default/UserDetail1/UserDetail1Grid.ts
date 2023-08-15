
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class UserDetail1Grid extends Serenity.EntityGrid<UserDetail1Row, any> {
        protected getColumnsKey() { return UserDetail1Columns.columnsKey; }
        protected getDialogType() { return UserDetail1Dialog; }
        protected getIdProperty() { return UserDetail1Row.idProperty; }
        protected getInsertPermission() { return UserDetail1Row.insertPermission; }
        protected getLocalTextPrefix() { return UserDetail1Row.localTextPrefix; }
        protected getService() { return UserDetail1Service.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}