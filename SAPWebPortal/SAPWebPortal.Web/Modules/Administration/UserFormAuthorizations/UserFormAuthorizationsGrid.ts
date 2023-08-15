
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class UserFormAuthorizationsGrid extends Serenity.EntityGrid<UserFormAuthorizationsRow, any> {
        protected getColumnsKey() { return UserFormAuthorizationsColumns.columnsKey; }
        protected getDialogType() { return UserFormAuthorizationsDialog; }
        protected getIdProperty() { return UserFormAuthorizationsRow.idProperty; }
        protected getInsertPermission() { return UserFormAuthorizationsRow.insertPermission; }
        protected getLocalTextPrefix() { return UserFormAuthorizationsRow.localTextPrefix; }
        protected getService() { return UserFormAuthorizationsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}