
namespace SAPWebPortal.APInvoice {

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
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        
        constructor() {
            super();
            
            this.dialogTitle = "APInvoice";
            DocumentDialog.Flag = true;
            DocumentDialog.Form = this.form;
            var service = this.getService();
            //this.form.DocumentLines.slickGrid.onActiveCellChanged.subscribe((e, args) => {

                
            //})
            this.form.DocumentLines.slickGrid.onCellChange.subscribe((e, args) => {
                let row = args.row;
                let index = args.cell;

                let grid = args.grid as Slick.Grid;
                let item = args.item as SAPWebPortal.APInvoiceLine.DocumentLineRow;

                let columnDefinitions = grid.getColumns();
                let fieldName = columnDefinitions[index].field;
                var UnitPrice = parseFloat(item.UnitPrice.toString());

                if (fieldName == "Quantity") {

                    if (item.DiscountPercent == null || item.DiscountPercent == undefined) {

                        item.DiscountPercent = 0
                        item.LineTotal = UnitPrice * item.Quantity;
                        item.GrossTotal = (UnitPrice * item.Quantity);

                    }
                    else {

                        item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                        item.LineTotal = (UnitPrice * item.Quantity - ((UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                        item.GrossTotal = (UnitPrice * item.Quantity - ((UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));

                    }
                    if (item.VatGroup != "" && item.VatGroup != undefined) {
                        Q.serviceCall({
                            url: Q.resolveUrl("~/Services/" + service + "/getTaxDetail"),
                            request: item.VatGroup,
                            onSuccess: response => {
                                var Rate = response["Rate"];
                                item.TaxTotal = item.LineTotal * (Rate / 100);
                                item.GrossTotal = item.LineTotal + item.TaxTotal;
                                grid.updateRow(row);
                            }
                        });
                    }


                }
                if (fieldName == "UnitPrice") {

                    if (item.DiscountPercent == null || item.DiscountPercent == undefined) {
                        item.DiscountPercent = 0
                        item.LineTotal = UnitPrice * item.Quantity;
                        item.GrossTotal = (UnitPrice * item.Quantity);

                    }
                    else {
                        item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                        item.LineTotal = (UnitPrice * item.Quantity - ((UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                        item.GrossTotal = (UnitPrice * item.Quantity - ((UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                    }
                    if (item.VatGroup != "" && item.VatGroup != undefined) {
                        Q.serviceCall({
                            url: Q.resolveUrl("~/Services/" + service + "/getTaxDetail"),
                            request: item.VatGroup,
                            onSuccess: response => {
                                var Rate = response["Rate"];
                                item.TaxTotal = item.LineTotal * (Rate / 100);
                                item.GrossTotal = item.LineTotal + item.TaxTotal;
                                grid.updateRow(row);

                            }
                        });
                    }


                }
                if (fieldName == "DiscountPercent") {
                    item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                    item.LineTotal = (UnitPrice * item.Quantity - ((UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                    item.GrossTotal = (UnitPrice * item.Quantity - ((UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                    if (item.VatGroup != "" && item.VatGroup != undefined) {
                        Q.serviceCall({
                            url: Q.resolveUrl("~/Services/" + service + "/getTaxDetail"),
                            request: item.VatGroup,
                            onSuccess: response => {
                                var Rate = response["Rate"];
                                item.TaxTotal = item.LineTotal * (Rate / 100);
                                item.GrossTotal = item.LineTotal + item.TaxTotal;
                                grid.updateRow(row);
                            }
                        });
                    }
                }
                if (fieldName == "WarehouseCode") {
                    //execute query 67
                    var data = {
                        ItemCode: item.ItemCode, WhsCode: item.WarehouseCode
                    }
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Services/APInvoiceLine/DocumentLine/getInStockValue'),
                        request: data,
                        onSuccess: response => {
                            var instock = response["instock"];
                            item.U_STCK = instock
                            grid.updateRow(row);

                        }
                    });

                }
                if (fieldName == "VatGroup") {
                    if (item.DiscountPercent == null || item.DiscountPercent == undefined) {
                        item.DiscountPercent = 0
                    }
                    item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                    item.LineTotal = (UnitPrice * item.Quantity - ((UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                    Q.serviceCall({
                        url: Q.resolveUrl("~/Services/" + service + "/getTaxDetail"),
                        request: item.VatGroup,
                        onSuccess: response => {
                            var Rate = response["Rate"];
                            item.TaxTotal = item.LineTotal * (Rate / 100);
                            item.GrossTotal = item.LineTotal + item.TaxTotal;
                            grid.updateRow(row);
                            grid.navigateNext();


                        }
                    });

                }
                

                //if (item.VatGroup != "" && item.VatGroup != undefined) {
                //    Q.serviceCall({
                //        url: Q.resolveUrl("~/Services/" + service + "/getTaxDetail"),
                //        request: item.VatGroup,
                //        onSuccess: response => {
                //            var Rate = response["Rate"];
                //            item.TaxTotal = item.LineTotal * (Rate / 100);
                //            item.GrossTotal = item.LineTotal + item.TaxTotal;
                //            item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                //            item.GrossTotal = item.GrossTotal - ((item.GrossTotal) * (item.DiscountPercent / 100));
                //            grid.updateRow(row);
                //            grid.navigateNext();

                //        }
                //    });
                //}
                //else
                //{
                //    item.GrossTotal = item.LineTotal - ((item.LineTotal) * (item.DiscountPercent / 100));
                //}

                grid.updateRow(row);
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
            
            //this.form.DocumentLines.getGrid().onClick.subscribe((e, args) => {
            //    if (args.cell == 9) {
            //        DocumentDialog.DocumentLineFlag = true;
            //    }
            //    if (args.cell == 10) {
            //        DocumentDialog.DocumentLineFlag = true;
            //    }
            //    SAPWebPortal.APInvoiceLine.DocumentLineEditor.rnum = args.row as number;
            //});
            this.form.DocumentLines.getGrid().onClick.subscribe((e, args) => {
                let grid = this.form.DocumentLines.getGrid();
                let columnDefinitions = grid.getColumns();
                let clickedColumn = columnDefinitions[args.cell];

                if (clickedColumn.field === "WarehouseCode" || clickedColumn.field === "VatGroup") {
                    DocumentDialog.DocumentLineFlag = true;
                }

                SAPWebPortal.APInvoiceLine.DocumentLineEditor.rnum = args.row as number;
            });
            
             

            this.form.Series.change(e => {
                var DocNum = "";
                try {
                    if ((e as any).added.source == false && this.form.Series.value != null) {
                        Serenity.EditorUtils.setReadOnly(this.form.DocNum, true);
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Services/' + service + '/GetNextNumber'),
                            request: this.form.Series.value.toString(),
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
            this.form.DiscountPercent.change(e => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
                
            });
            this.form.TotalDiscount.change(e => {
                this.form.DiscountPercent.value = "0";
                var totalDiscount = this.form.TotalDiscount.value;
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);

                var doctotal = this.form.DocTotal.value;
                //this.form.DocTotal.value = doctotal - totalDiscount;


                
            });

            this.form.DocumentLines.view.onDataChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
            this.form.DocumentLines.slickGrid.onActiveCellChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
            (this.form.DocumentLines.view as any).onRowCountChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });

            Q.serviceCall({
                url: Q.resolveUrl('~/Services/Administration/User/getdetaillist'),
                request: "APInvoice",
                async: false,
                onSuccess: response => {
                    var count = Object.keys(response).length;
                    for (var ind = 0; ind < count; ind++) {
                        this.form[response[ind]].getGridField().toggle(false)
                    }
                }
            });
        }


        protected updateInterface(): void {
            super.updateInterface();
            if (this.isEditMode()) {
                this.toolbar.findButton('save-and-close-button').find('.button-inner').text('Update');
            }

        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity();

            //this.form.DocumentLines.change(e => {

            //    DocumentDialog.Form = this.form;


            //});
            $('.categories').each(function () {
                $(this).attr('class', "");

            })
           
           
            if (!this.isEditMode()) {
                this.toolbar.findButton("Preview-report-button").hide();
            }
            //Serenity.EditorUtils.setReadonly(this.form.DocType.element, true);
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            var service = this.getService();
            this.getSaveEntity();
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
            //this.form.CardCode.change(e => {
            //    if (this.form.SalesPersonCode.items.length > 0) {
            //        this.form.SalesPersonCode.value = this.form.SalesPersonCode.items[0].id;
            //    }

            //});
            if (this.isNew()) {

                var tomorrow = new Date();
                tomorrow.setDate(tomorrow.getDate() + 1);
                var TodayDate = new Date();
                //get next day from todaydate
                var nextDay = new Date();
                nextDay.setDate(nextDay.getDate() + 1);
                //this.form.DocDueDate.value = nextDay.toDateString();

                // var nextMonth = TodayDate.getMonth() + 1;
                // var today = new Date(); // Or Date.today()
                // var tomorrow = today.getDay()+1;

                //var DocDate = TodayDate.getDate() + '/' + nextMonth + '/' + TodayDate.getFullYear();
                //var NextDay = TodayDate.getDate() + 1;
                //var DocDueDate = NextDay + '/' + nextMonth + '/' + TodayDate.getFullYear();
                // //var DocDate = TodayDate.getDate() + '/' + nextMonth + '/' + TodayDate.getFullYear();
                //var NextDay = TodayDate.getDate() + 1;
                //var DocDueDate = NextDay + '/' + nextMonth + '/' + TodayDate.getFullYear();
                //this.form.DocDate.value = tm;
                var d = tomorrow.toLocaleString();
                d = d.split(' ')[0].split(',')[0];


                //this.form.DiscountPercent.value ="0";
                //this.form.TotalDiscount.value = "0";





                if (this.form.DocCurrency.items.length > 0) {
                    this.form.DocCurrency.value = "PKR";
                }
                
            }
            else {
                Serenity.EditorUtils.setReadonly(this.form.U_Cartons.element, false);
                Serenity.EditorUtils.setReadonly(this.form.U_Total_Weight.element, false);
                

            }
           
        }
        protected getToolbarButtons() {
            let buttons = super.getToolbarButtons();
            buttons.push({

                title: "Preview",
                cssClass: 'Preview-report-button',
                icon: 'fa fa-download text-green',

                onClick: () => {
                    //show "Report 2" button
                    this.toolbar.findButton("Preview-report1-button").show();
                    this.toolbar.findButton("Preview-report2-button").show();
                    this.toolbar.findButton("Preview-report3-button").show();
                    //var test: SAPWebPortal.APInvoice.DocumentRow = this.getSaveEntity();
                    //var payloadinfo: SAPWebPortal.APInvoice.DocumentRow = { DocEntry: test.DocEntry, DocNum: test.DocNum };
                    //SAPWebPortal.APInvoice.DocumentService.GetDownloadFile({ Entity: payloadinfo }, response => {
                    //    var t = response;
                    //    const byteCharacters = atob(response.Entity.Comments);
                    //    const byteArrays = [];
                    //    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
                    //        const slice = byteCharacters.slice(offset, offset + 512);
                    //        const byteNumbers = new Array(slice.length);
                    //        for (let i = 0; i < slice.length; i++) {
                    //            byteNumbers[i] = slice.charCodeAt(i);
                    //        }
                    //        const byteArray = new Uint8Array(byteNumbers);
                    //        byteArrays.push(byteArray);
                    //    }
                    //    const blob = new Blob(byteArrays, { type: 'application/pdf' });
                    //    const blobUrl = URL.createObjectURL(blob);
                    //    var anchor = document.createElement('a');
                    //    anchor.href = blobUrl;
                    //    anchor.target = '_blank';
                    //    anchor.click();
                    //    anchor.remove();
                    // });
                }
            });
            buttons.push({
                //button for multiple reports
                title: "Sales Invoice",
                cssClass: 'Preview-report1-button',
                icon: 'fa fa-download text-green',
                onClick: () => {
                    //q.showField(this.form.SelectOption);
                    var name: string = "Sales Invoice";
                    this.form.FederalTaxId.value = name;
                    var test: SAPWebPortal.APInvoice.DocumentRow = this.getSaveEntity();

                    var payloadinfo: SAPWebPortal.APInvoice.DocumentRow = { DocEntry: test.DocEntry, DocNum: test.DocNum, FederalTaxId: test.FederalTaxId };
                    SAPWebPortal.APInvoice.DocumentService.GetDownloadFile({ Entity: payloadinfo }, response => {
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
                },
                visible: false



            });
            buttons.push({
                //button for multiple reports
                title: "Sales Tax",
                cssClass: 'Preview-report2-button',
                icon: 'fa fa-download text-green',
                //hide button

                onClick: () => {
                    //q.showField(this.form.SelectOption);
                    var name: string = "Sales Tax";
                    this.form.FederalTaxId.value = name;

                    var test: SAPWebPortal.APInvoice.DocumentRow = this.getSaveEntity();
                    var payloadinfo: SAPWebPortal.APInvoice.DocumentRow = { DocEntry: test.DocEntry, DocNum: test.DocNum, FederalTaxId: test.FederalTaxId };
                    SAPWebPortal.APInvoice.DocumentService.GetDownloadFile({ Entity: payloadinfo }, response => {
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
                },
                visible: false



            });
            buttons.push({
                //button for multiple reports
                title: "Delivery Challan",
                cssClass: 'Preview-report3-button',
                icon: 'fa fa-download text-green',
                //hide button

                onClick: () => {
                    //q.showField(this.form.SelectOption);
                    var name: string = "Delivery Challan";
                    this.form.FederalTaxId.value = name;
                    var test: SAPWebPortal.APInvoice.DocumentRow = this.getSaveEntity();
                    var payloadinfo: SAPWebPortal.APInvoice.DocumentRow = { DocEntry: test.DocEntry, DocNum: test.DocNum, FederalTaxId: test.FederalTaxId };
                    SAPWebPortal.APInvoice.DocumentService.GetDownloadFile({ Entity: payloadinfo }, response => {
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
                },
                visible: false



            });
            //buttons.push(
            //    {
            //        title: Q.text("MultiReports"),	// *** Get button text from translation
            //        cssClass: 'stampe',
            //        icon: 'fa-print',
            //        onClick: () => {

            //            // *** do something on click if you want **

            //        },
            //    }
            //);

            return buttons;
        }
    }
}