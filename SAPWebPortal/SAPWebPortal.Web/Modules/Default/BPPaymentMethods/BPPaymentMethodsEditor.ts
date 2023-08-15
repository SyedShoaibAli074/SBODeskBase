
namespace SAPWebPortal.Default {
    import fld = Default.BPAddressesRow.Fields;
    @Serenity.Decorators.registerClass()
    export class BPPaymentMethodsEditor extends _Ext.GridEditorBase<BPPaymentMethodsRow> {
        protected getColumnsKey() { return "Default.BPPaymentMethods"; }

        protected getIdProperty() { return BPPaymentMethodsRow.idProperty; }
        protected getDialogType() { return BPPaymentMethodsDialog; }
        protected getLocalTextPrefix() { return BPPaymentMethodsRow.localTextPrefix; }
      
        constructor(container: JQuery) {
            super(container);
           
        }
        //helper: SAPWebPortal.Helpers.BusinessFormHelper
        //afterLoadEntity() {
        //    var service = this.getService();
        //    var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
        //    this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(BPPaymentMethodsDialog.Form, dropdownfields, service, this);
        //}

    }
}