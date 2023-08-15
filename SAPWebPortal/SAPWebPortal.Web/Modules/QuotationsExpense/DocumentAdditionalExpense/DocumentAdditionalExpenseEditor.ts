namespace SAPWebPortal.QuotationsExpense {
    @Serenity.Decorators.registerClass()
    export class DocumentAdditionalExpenseEditor extends _Ext.GridEditorBase<SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseRow> {
        protected getColumnsKey() { return "QuotationsExpense.DocumentAdditionalExpense"; }
        protected getDialogType() { return SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseDialog; }
        protected getLocalTextPrefix() { return SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseRow.localTextPrefix; }
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
            this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(SAPWebPortal.Quotations.DocumentDialog.Form, "");
            return ans;
        }
        protected getButtons() {
            let buttons = super.getButtons();
            buttons = [];
            buttons.push({
                title: "Add Expenses",
                cssClass: "add-button",
                onClick: () => {
                    var HeaderForm = SAPWebPortal.Quotations.DocumentDialog.Form;
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