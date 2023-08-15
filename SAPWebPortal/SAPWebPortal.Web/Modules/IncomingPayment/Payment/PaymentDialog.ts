
namespace SAPWebPortal.IncomingPayment {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class PaymentDialog extends Serenity.EntityDialog<PaymentRow, any> {
        protected getFormKey() { return PaymentForm.formKey; }
        protected getIdProperty() { return PaymentRow.idProperty; }
        protected getLocalTextPrefix() { return PaymentRow.localTextPrefix; }
        protected getService() { return PaymentService.baseUrl; }
        protected getDeletePermission() { return PaymentRow.deletePermission; }
        protected getInsertPermission() { return PaymentRow.insertPermission; }
        protected getUpdatePermission() { return PaymentRow.updatePermission; }

        protected form = new PaymentForm(this.idPrefix);
        public static Form: PaymentForm;
        static Flag: Boolean = false;
        constructor(container: JQuery) {
            super(container);
            PaymentDialog.Flag = true;
            PaymentDialog.Form = this.form;
            var service = this.getService();
            this.form.Series.change(e => {
                var DocNum = "";
                try {
                    if ((e as any).added.source == false && this.form.Series.value != null) {
                        Serenity.EditorUtils.setReadOnly(this.form.DocNum, true);
                        var data = { Code: this.form.Series.value.toString(), DBName: localStorage.getItem("DBName") };

                        Q.serviceCall({
                            url: Q.resolveUrl('~/Services/' + service + '/GetNextNumber'),
                            request: data,
                            async: false,
                            onSuccess: response => {
                                DocNum = response as string;
                            }
                        });
                        this.form.DocNum.value = Number(DocNum);
                    }
                }
                catch
                { }
            });
            this.form.DocType.changeSelect2(e => {
                var id = this.form.DocType.value;
                if (id == "C") {
                    //this.form.CardCode.getGridField().toggle(false);
                }
                else if (id == "S") {

                }
                else if (id == "A") {

				}
			})
        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity();
            $('.categories').each(function () {
                $(this).attr('class', "");
            })
            Serenity.EditorUtils.setReadonly(this.form.DocType.element, true);
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            var service = this.getService();
            this.getSaveEntity();
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
            $('.btn-history').hide();
            $('.add-button').each(function (e) {
                var text = $(this).text();
                if (text == "Payment Invoice") {
                    $(this).hide();
                }
            });

        }
    }
}