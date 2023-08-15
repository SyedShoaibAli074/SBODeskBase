
namespace SAPWebPortal.Orders {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class DocumentDialog extends _Ext.DialogBase<DocumentRow, any> {
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
        constructor(container: JQuery) {
            super(container);
            this.dialogTitle = "Orders";
            DocumentDialog.Flag = true;
            DocumentDialog.Form = this.form;
            var service = this.getService();
            this.form.DocumentLines.slickGrid.onCellChange.subscribe((e, args) => {
                let row = args.row;
                let index = args.cell;
                
                let grid = args.grid as Slick.Grid;
                let item = args.item as SAPWebPortal.OrdersLine.DocumentLineRow;
                
                if (index == 4) {
                    
                    if (item.DiscountPercent == null || item.DiscountPercent == undefined)
                    {
                         
                            item.DiscountPercent = 0
                             item.LineTotal = item.UnitPrice * item.Quantity;
                            item.GrossTotal = (item.UnitPrice * item.Quantity);
                            item.InventoryQuantity = item.UnitsOfMeasurment * item.Quantity;
                        
                    }
                    else
                    {

                        item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                        item.LineTotal = (item.UnitPrice * item.Quantity - ((item.UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                        item.GrossTotal = (item.UnitPrice * item.Quantity);
                        item.InventoryQuantity = item.UnitsOfMeasurment * item.Quantity;
 
                    }
                }
                if (index == 5)
                {
                       
                        if (item.DiscountPercent == null || item.DiscountPercent == undefined)
                        {
                            item.DiscountPercent = 0                          
                            item.Quantity = item.InventoryQuantity / item.UnitsOfMeasurment;
                            item.LineTotal = item.UnitPrice * item.Quantity;
                            item.GrossTotal = (item.UnitPrice * item.Quantity);
 
                        }
                        else
                        {
                            item.DiscountPercent = parseFloat(item.DiscountPercent.toString());
                            item.Quantity = item.InventoryQuantity / item.UnitsOfMeasurment;
                            item.LineTotal = (item.UnitPrice * item.Quantity - ((item.UnitPrice * item.Quantity) * (item.DiscountPercent / 100)));
                            item.GrossTotal = (item.UnitPrice * item.Quantity); 
 

                        }

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
                            //todo: press tab key programatically

                            //grid.navigateNext();

                            //press tab key from keyboard
                            grid.navigateNext();

                        }
                    });
                }
                else
                {
                    item.GrossTotal = item.GrossTotal - ((item.GrossTotal) * (item.DiscountPercent / 100));
                }
              
                grid.updateRow(row);
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
            this.form.DocumentLines.getGrid().onClick.subscribe((e, args) => {
                if (args.cell == 8) {
                    DocumentDialog.DocumentLineFlag = true;
                }
                SAPWebPortal.OrdersLine.DocumentLineEditor.rnum = args.row as number;
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
            this.form.DocumentLines.slickGrid.onActiveCellChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
            });
            (this.form.DocumentLines.view as any).onRowCountChanged.subscribe(() => {
                this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(this.form, service);
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
            this.form.DocDate.changeSelect2(e => {
                var nextDay = new Date();
                nextDay.setDate(this.form.DocDate.valueAsDate.getDate() + 1);
                this.form.DocDueDate.value = nextDay.toDateString();
            });
            $('.categories').each(function () {
                $(this).attr('class', "");

            })
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

                var tomorrow = new Date();
                tomorrow.setDate(tomorrow.getDate() + 1);
                 var TodayDate = new Date();
				//get next day from todaydate
                var nextDay = new Date();
                nextDay.setDate(nextDay.getDate() + 1);
                this.form.DocDueDate.value = nextDay.toDateString();
				
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

                            this.setReadOnly(true);

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
                    var test: SAPWebPortal.Orders.DocumentRow = this.getSaveEntity();
                    var payloadinfo: SAPWebPortal.Orders.DocumentRow = { DBName: localStorage.getItem("DBName"), DocEntry: test.DocEntry, DocNum: test.DocNum };
                    SAPWebPortal.Orders.DocumentService.GetDownloadFile({ Entity: payloadinfo }, response => {
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