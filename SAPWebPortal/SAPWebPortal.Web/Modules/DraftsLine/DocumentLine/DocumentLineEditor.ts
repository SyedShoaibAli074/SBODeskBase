namespace SAPWebPortal.DraftsLine {
    @Serenity.Decorators.registerClass()
    export class DocumentLineEditor extends _Ext.GridEditorBase<SAPWebPortal.DraftsLine.DocumentLineRow> {
        protected getColumnsKey() { return "DraftsLine.DocumentLine"; }
        protected getDialogType() { return SAPWebPortal.DraftsLine.DocumentLineDialog; }
        protected getLocalTextPrefix() { return SAPWebPortal.DraftsLine.DocumentLineRow.localTextPrefix; }
        public static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery) {
            super(container);
        }
        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = true;
            /*opt.autoEdit = true;*/
            return opt;
        }
        deleteEntity(id) {
            var ans = super.deleteEntity(id);
            this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(SAPWebPortal.Drafts.DocumentDialog.Form, "");
            return ans;
        }
        protected getButtons() {
            let buttons = super.getButtons();
            buttons = [];
            buttons.push({
                title: "Add Products",
                cssClass: "add-button",
                onClick: () => {
                    var HeaderForm = SAPWebPortal.Drafts.DocumentDialog.Form;
                    if (HeaderForm.CardCode != null && HeaderForm.CardCode.value != undefined && HeaderForm.CardCode.value != "") {
                        let orderDetails = this.value;
                        orderDetails.push({
                            Quantity: 0.0,
                            UnitPrice: 0.0,
                            LineTotal: 0.0,
                        });
                        this.value = orderDetails;

                    } else {
                        Q.notifyWarning("Please select a customer first!")
                    }
                }
            });
            return buttons;
        }
    }
}