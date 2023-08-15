
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class BPAddressesGrid extends Serenity.EntityGrid<BPAddressesRow, any> {
        protected getColumnsKey() { return BPAddressesColumns.columnsKey; }
        protected getDialogType() { return BPAddressesDialog; }
        protected getIdProperty() { return BPAddressesRow.idProperty; }
        protected getInsertPermission() { return BPAddressesRow.insertPermission; }
        protected getLocalTextPrefix() { return BPAddressesRow.localTextPrefix; }
        protected getService() { return BPAddressesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}