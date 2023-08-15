namespace SAPWebPortal.DraftsExpense {
   /* import fld = Default.BPAddressesRow.Fields;*/
    @Serenity.Decorators.registerClass()
    export class DocumentAdditionalExpenseEditor extends _Ext.GridEditorBase<SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow> {
        protected getColumnsKey() { return "DraftsExpense.DocumentAdditionalExpense"; }
        protected getDialogType() { return SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseDialog; }
        protected getLocalTextPrefix() { return SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow.localTextPrefix; }
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
                title: "Add Expenses",
                cssClass: "add-button",
                onClick: () => {
                    var HeaderForm = SAPWebPortal.Drafts.DocumentDialog.Form;
                    if (HeaderForm.CardCode != null && HeaderForm.CardCode.value != undefined && HeaderForm.CardCode.value != "") {
                        let ExpenseDetails = this.value;
                        ExpenseDetails.push({
                            U_Amount: 0.0,
                            TaxPercent: 0.0,
                            TaxSum: 0.0,
                            LineTotal: 0.0,
                        });
                        this.value = ExpenseDetails;
                    }
                    else {
                        Q.notifyWarning("Please select a customer first!")
                    }
                }
            });
            return buttons;
        }
    }
}