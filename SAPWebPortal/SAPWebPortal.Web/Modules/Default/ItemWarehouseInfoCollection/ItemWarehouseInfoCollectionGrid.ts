
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ItemWarehouseInfoCollectionGrid extends Serenity.EntityGrid<ItemWarehouseInfoCollectionRow, any> {
        protected getColumnsKey() { return ItemWarehouseInfoCollectionColumns.columnsKey; }
        protected getDialogType() { return ItemWarehouseInfoCollectionDialog; }
        protected getIdProperty() { return ItemWarehouseInfoCollectionRow.idProperty; }
        protected getInsertPermission() { return ItemWarehouseInfoCollectionRow.insertPermission; }
        protected getLocalTextPrefix() { return ItemWarehouseInfoCollectionRow.localTextPrefix; }
        protected getService() { return ItemWarehouseInfoCollectionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}