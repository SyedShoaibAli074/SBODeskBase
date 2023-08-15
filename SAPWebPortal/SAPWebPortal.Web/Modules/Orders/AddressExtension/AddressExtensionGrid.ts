
namespace SAPWebPortal.Orders {

    @Serenity.Decorators.registerClass()
    export class AddressExtensionGrid extends Serenity.EntityGrid<AddressExtensionRow, any> {
        protected getColumnsKey() { return AddressExtensionColumns.columnsKey; }
        protected getDialogType() { return AddressExtensionDialog; }
        protected getIdProperty() { return AddressExtensionRow.idProperty; }
        protected getInsertPermission() { return AddressExtensionRow.insertPermission; }
        protected getLocalTextPrefix() { return AddressExtensionRow.localTextPrefix; }
        protected getService() { return AddressExtensionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}