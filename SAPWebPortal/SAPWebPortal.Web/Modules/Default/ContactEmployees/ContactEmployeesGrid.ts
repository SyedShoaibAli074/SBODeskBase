
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ContactEmployeesGrid extends Serenity.EntityGrid<ContactEmployeesRow, any> {
        protected getColumnsKey() { return ContactEmployeesColumns.columnsKey; }
        protected getDialogType() { return ContactEmployeesDialog; }
        protected getIdProperty() { return ContactEmployeesRow.idProperty; }
        protected getInsertPermission() { return ContactEmployeesRow.insertPermission; }
        protected getLocalTextPrefix() { return ContactEmployeesRow.localTextPrefix; }
        protected getService() { return ContactEmployeesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}