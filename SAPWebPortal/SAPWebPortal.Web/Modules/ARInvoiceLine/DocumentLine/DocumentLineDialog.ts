
namespace SAPWebPortal.ARInvoiceLine {
    @Serenity.Decorators.registerClass()
    export class DocumentLineDialog extends _Ext.EditorDialogBase<DocumentLineRow> {
        protected getFormKey() { return DocumentLineForm.formKey; }
        protected getLocalTextPrefix() { return DocumentLineRow.localTextPrefix; }
        protected form = new DocumentLineForm(this.idPrefix);
        static Form: DocumentLineForm;
        constructor(container: JQuery) {
            super(container);
            DocumentLineDialog.Form = this.form;
        }
        protected afterLoadEntity() {

            var editorSelect = _Ext.GLAccountEditor.editorSelect;
            try {
                //Q service call to get the value of the selected item in the GLAccountEditor
                Q.serviceCall({
                    url: Q.resolveUrl('~/Services/ARInvoiceLine/DocumentLine/GetGLAccounts'),
                    async: false,
                    onSuccess: response => {
                        var count = Object.keys(response).length;
                        for (var ind = 0; ind < count; ind++) {
                            editorSelect.addOption(response[ind].Item1, response[ind].Item1 + "-" + response[ind].Item2);
                        }
                    }
                });
            }
            catch (e) { console.log(e) }

        }
    }
}