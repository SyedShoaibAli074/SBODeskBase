
namespace SAPWebPortal.Quotations {

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
        public static Form: DocumentForm;
        static Flag: Boolean = false;
        static DocumentLineFlag: Boolean = false;
        static AdditionalExpenseFlag: Boolean = false;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery) {
            super(container);
            this.dialogTitle = "Quotations";
            DocumentDialog.Flag = true;
            DocumentDialog.Form = this.form;
            var service = this.getService();
            this.form.DocumentLines.slickGrid.onCellChange.subscribe((e, args) => {

                let row = args.row;
                let grid = args.grid as Slick.Grid;
                let item = args.item as SAPWebPortal.QuotationsLine.DocumentLineRow;
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
                        request:data,
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
            this.form.DocumentLines.slickGrid.onClick.subscribe((e, args) => {
                if (args.cell == 8) {
                    DocumentDialog.DocumentLineFlag = true;
                }
                SAPWebPortal.QuotationsLine.DocumentLineEditor.rnum = args.row as number;
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
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
            this.form.DocumentLines.view.onDataChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
            (this.form.DocumentLines.view as any).onRowCountChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
            this.form.DocumentLines.slickGrid.onActiveCellChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity(); 
            if (!this.isEditMode()) {
                this.toolbar.findButton("Preview-report-button").hide();
            }
            Serenity.EditorUtils.setReadonly(this.form.DocType.element, true);
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            var service = this.getService();
            this.getSaveEntity();
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
            this.form.DBName.value = localStorage.getItem("DBName");

            this.form.CardCode.change(e => {
                if (this.form.SalesPersonCode.items.length > 0) {
                    this.form.SalesPersonCode.value = this.form.SalesPersonCode.items[0].id;
                }

            });
            if (this.isNew()) {
                var TodayDate = new Date();
                var nextMonth = TodayDate.getMonth() + 1;

                var DocDate = TodayDate.getMonth() + 1 + '/' + TodayDate.getDate() + '/' + TodayDate.getFullYear();
                var NextDay = TodayDate.getDate() + 1;
                var DocDueDate = TodayDate.getMonth() + 1 + '/' + NextDay + '/' + TodayDate.getFullYear();
                //var DocDate = TodayDate.getDate() + '/' + nextMonth + '/' + TodayDate.getFullYear();
                //var NextDay = TodayDate.getDate() + 1;
                //var DocDueDate = NextDay + '/' + nextMonth + '/' + TodayDate.getFullYear();
                this.form.DocDate.value = DocDate;
                this.form.DocDueDate.value = DocDate;
                this.form.DiscountPercent.value = 0;
                this.form.TotalDiscount.value = 0;





                if (this.form.DocCurrency.items.length > 0) {
                    this.form.DocCurrency.value = "PKR";
                }

            }
            else {
                //set the document to readonly after 24 hours
                Q.serviceCall({
                    url: Q.resolveUrl('~/Services/' + service + '/CheckStatus'),
                    request: this.getSaveEntity(),
                    async: false,
                    onSuccess: response => {
                        var flag = response;
                        if (flag == true || flag == "true") {

                            //this.setReadOnly(true);

                        }

                    }
                });

            }
        }
        protected getToolbarButtons() {
            let buttons = super.getToolbarButtons();
            buttons.push({
                title: "Preview",
                cssClass: 'Preview-report-button',
                icon: 'fa fa-download text-green',
                onClick: () => {
                    var test: SAPWebPortal.Quotations.DocumentRow = this.getSaveEntity();
                    var payloadinfo: SAPWebPortal.Quotations.DocumentRow = { DBName: localStorage.getItem("DBName"),DocEntry: test.DocEntry, DocNum: test.DocNum };
                    SAPWebPortal.Quotations.DocumentService.GetDownloadFile({ Entity: payloadinfo }, response => {
                        var t = response;
                        const byteCharacters = atob(response.Entity.Comments);
                        const byteArrays = [];
                        for (let offset = 0; offset < byteCharacters.length; offset += 512) {
                            const slice = byteCharacters.slice(offset, offset + 512);
                            const byteNumbers = new Array(slice.length);
                            for (let i = 0; i < slice.length; i++) {
                                byteNumbers[i] = slice.charCodeAt(i);
                            }
                            const byteArray = new Uint8Array(byteNumbers);
                            byteArrays.push(byteArray);
                        }
                        const blob = new Blob(byteArrays, { type: 'application/pdf' });
                        const blobUrl = URL.createObjectURL(blob);
                        var anchor = document.createElement('a');
                        anchor.href = blobUrl;
                        anchor.target = '_blank';
                        anchor.click();
                        anchor.remove();
                    });
                }
            });
            return buttons;
        }
    }
}