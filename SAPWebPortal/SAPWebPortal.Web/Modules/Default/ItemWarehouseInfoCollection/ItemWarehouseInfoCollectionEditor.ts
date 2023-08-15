
namespace SAPWebPortal.Default {
    import fld = Default.BPAddressesRow.Fields;
    @Serenity.Decorators.registerClass()
    export class ItemWarehouseInfoCollectionEditor extends _Ext.GridEditorBase<ItemWarehouseInfoCollectionRow> {
        protected getColumnsKey() { return "Default.ItemWarehouseInfoCollection"; }
        protected getDialogType() { return ItemWarehouseInfoCollectionDialog; }
        protected getLocalTextPrefix() { return ItemWarehouseInfoCollectionRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);



        }


    }
}