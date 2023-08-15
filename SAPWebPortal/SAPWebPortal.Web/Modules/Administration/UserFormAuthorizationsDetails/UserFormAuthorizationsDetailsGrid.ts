
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class UserFormAuthorizationsDetailsGrid extends Serenity.EntityGrid<UserFormAuthorizationsDetailsRow, any> {
        protected getColumnsKey() { return UserFormAuthorizationsDetailsColumns.columnsKey; }
        protected getDialogType() { return UserFormAuthorizationsDetailsDialog; }
        protected getIdProperty() { return UserFormAuthorizationsDetailsRow.idProperty; }
        protected getInsertPermission() { return UserFormAuthorizationsDetailsRow.insertPermission; }
        protected getLocalTextPrefix() { return UserFormAuthorizationsDetailsRow.localTextPrefix; }
        protected getService() { return UserFormAuthorizationsDetailsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}