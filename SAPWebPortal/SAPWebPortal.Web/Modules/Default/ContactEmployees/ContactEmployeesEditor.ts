
namespace SAPWebPortal.Default {
    import fld = Default.BPAddressesRow.Fields;
    @Serenity.Decorators.registerClass()
    export class ContactEmployeesEditor extends _Ext.GridEditorBase<ContactEmployeesRow> {
        protected getColumnsKey() { return "Default.ContactEmployees"; }
        protected getDialogType() { return ContactEmployeesDialog; }
        protected getLocalTextPrefix() { return ContactEmployeesRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);



        }


    }
}