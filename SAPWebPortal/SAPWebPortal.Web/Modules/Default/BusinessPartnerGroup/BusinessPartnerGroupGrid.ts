
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class BusinessPartnerGroupGrid extends Serenity.EntityGrid<BusinessPartnerGroupRow, any> {
        protected getColumnsKey() { return BusinessPartnerGroupColumns.columnsKey; }
        protected getDialogType() { return BusinessPartnerGroupDialog; }
        protected getIdProperty() { return BusinessPartnerGroupRow.idProperty; }
        protected getInsertPermission() { return BusinessPartnerGroupRow.insertPermission; }
        protected getLocalTextPrefix() { return BusinessPartnerGroupRow.localTextPrefix; }
        protected getService() { return BusinessPartnerGroupService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}