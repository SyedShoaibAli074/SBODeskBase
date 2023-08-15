namespace SAPWebPortal.Delivery {
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class DocumentDialog extends Serenity.EntityDialog<DocumentRow, any> {
        protected getFormKey() { return DocumentForm.formKey; }
        protected getIdProperty() { return DocumentRow.idProperty; }
        protected getLocalTextPrefix() { return DocumentRow.localTextPrefix; }
        protected getService() { return DocumentService.baseUrl; }
        protected getDeletePermission() { return DocumentRow.deletePermission; }
        protected getInsertPermission() { return DocumentRow.insertPermission; }
        protected getUpdatePermission() { return DocumentRow.updatePermission; }
        protected form = new DocumentForm(this.idPrefix);
        static Form: DocumentForm;
        static Flag: Boolean = false;
        static DocumentLineFlag: Boolean = false;
        static AdditionalExpenseFlag: Boolean = false;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery) {
            super(container);
            this.dialogTitle = "Delivery";
            DocumentDialog.Flag = true;
            DocumentDialog.Form = this.form;
            var service = this.getService();
            SAPWebPortal.Delivery.DocumentDialog.Form.DocumentLines.slickGrid.onCellChange.subscribe((e, args) => {

                let row = args.row;
                let grid = args.grid as Slick.Grid;
                let item = args.item as SAPWebPortal.DeliveryLine.DocumentLineRow;
                item.GrossTotal = (item.UnitPrice * item.Quantity);
                if (item.DiscountPercent == null || item.DiscountPercent == undefined) {
                    item.DiscountPercent = 0
                    item.LineTotal = item.UnitPrice * item.Quantity;
                }
                else {
                    item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                    item.LineTotal = (item.UnitPrice * item.Quantity - ((item.UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                }
                if (item.VatGroup != "" && item.VatGroup != undefined) {
                    var data = { Code: item.VatGroup, DBName: localStorage.getItem("DBName") };

                    Q.serviceCall({
                        url: Q.resolveUrl("~/Services/" + service + "/getTaxDetail"),
                        request: data,
                        onSuccess: response => {
                            var Rate = response["Rate"];
                            item.TaxTotal = item.GrossTotal * (Rate / 100);
                            item.GrossTotal = item.GrossTotal + item.GrossTotal * (Rate / 100);

                            item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                            item.GrossTotal = item.GrossTotal - ((item.GrossTotal) * (item.DiscountPercent / 100));
                            grid.updateRow(row);
                        }
                    });
                }
                else {
                    item.GrossTotal = item.GrossTotal - ((item.GrossTotal) * (item.DiscountPercent / 100));
                }

                grid.updateRow(row);
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
         
            SAPWebPortal.Delivery.DocumentDialog.Form.DocumentLines.getGrid().onClick.subscribe((e, args) => {
                if (args.cell == 8) {
                    DocumentDialog.DocumentLineFlag = true;
                }
                SAPWebPortal.DeliveryLine.DocumentLineEditor.rnum = args.row as number;
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity();
            this.toolbar.findButton("delete-button").hide();
            this.toolbar.findButton("add-button").hide();
            this.toolbar.findButton("apply-changes-button").hide();
            this.toolbar.findButton("save-and-close-button").hide();
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            var service = this.getService();
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
            this.form.DBName.value = localStorage.getItem("DBName");

        }


    

    }
}