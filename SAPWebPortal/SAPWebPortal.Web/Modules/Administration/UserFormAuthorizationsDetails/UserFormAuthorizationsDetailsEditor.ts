namespace SAPWebPortal.Administration {
    @Serenity.Decorators.registerClass()
    export class UserFormAuthorizationsDetailsEditor extends _Ext.GridEditorBase<SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow> {
        protected getColumnsKey() { return "Administration.UserFormAuthorizationsDetails"; }
        protected getDialogType() { return SAPWebPortal.Administration.UserFormAuthorizationsDetailsDialog; }
        protected getLocalTextPrefix() { return SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow.localTextPrefix; }
        public static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery) {
            super(container);
        }
        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = true;
            return opt;
        }
     
    }
}