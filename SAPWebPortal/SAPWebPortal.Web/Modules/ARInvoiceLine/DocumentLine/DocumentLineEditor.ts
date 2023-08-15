namespace SAPWebPortal.ARInvoiceLine {
    @Serenity.Decorators.registerClass()
    export class DocumentLineEditor extends _Ext.GridEditorBase<SAPWebPortal.ARInvoiceLine.DocumentLineRow> {
        protected getColumnsKey() { return "ARInvoiceLine.DocumentLine"; }
        protected getDialogType() { return SAPWebPortal.ARInvoiceLine.DocumentLineDialog; }
        protected getLocalTextPrefix() { return SAPWebPortal.ARInvoiceLine.DocumentLineRow.localTextPrefix; }
        public static rnum: number;
        DocTotalHelper: SAPWebPortal.Helpers.DocTotalHelper;
        constructor(container: JQuery) {
            super(container);
           
        }
        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = true;
            return opt;
        }
        deleteEntity(id) {
            var ans = super.deleteEntity(id);
            this.DocTotalHelper = new SAPWebPortal.Helpers.DocTotalHelper(SAPWebPortal.ARInvoice.DocumentDialog.Form, "");
            return ans;
        }
        protected getButtons() {
            let buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            buttons.push({
                title: "Pick Products",
                cssClass: "Pick-Products-button",
                icon: 'fa fa-plus text-green',
                onClick: () => {

                    var HeaderForm = SAPWebPortal.ARInvoice.DocumentDialog.Form;
                    //on change of DocType


                    if (HeaderForm.CardCode != null && HeaderForm.CardCode.value != undefined && HeaderForm.CardCode.value != "") {
                        if (HeaderForm.DocType.value == "dDocument_Items") {
                            var columns = this.slickGrid.getColumns();
                            var columnsToHide = ['AccountCode', 'AccountName'];
                            columns = columns.filter(column => !columnsToHide.includes(column.field));
                            columns = columns.map(column1 => {
                                if (column1.field === 'ItemDescription') {
                                    column1.editor = null; // Remove the editor for the column
                                    column1.cssClass = 'read-only'; // Apply a CSS class to visually indicate it's read-only
                                }
                                return column1;
                            });
                            this.slickGrid.setColumns(columns);
                             var pickerDialog = new _Ext.GridItemPickerDialog({
                                 gridType: SAPWebPortal.Default.ItemGrid, multiple: true,
                            //preSelectedKeys: this.value.map(k => k.ItemCode)
                             });
                             pickerDialog.onSuccess = (selectedItems: any[]) => {
                             let selectedItems2 = selectedItems.filter(t => {
                            console.log(t);
                            console.log(this.view.getItems());

                            var test: SAPWebPortal.Default.ItemRow = t;

                            return /*!Q.any(*/this.view.getItems();/*, n => n.ItemCode == test.ItemCode)*/
                             });
                            var orderDetails = selectedItems2.map<SAPWebPortal.ARInvoiceLine.DocumentLineRow>(r => {
                            var itemname = "";
                            var data = { Code: r.ItemCode, DBName: localStorage.getItem("DBName") };
                            Q.serviceCall({
                                url: Q.resolveUrl('~/Services/ARInvoice/Document/getItemNameFromItemCode'),
                                request: data,
                                async: false,
                                onSuccess: response => {
                                    itemname = response.toString();
                                }
                            });

                            var v = {
                                ItemCode: r.ItemCode,
                                ItemDescription: itemname,
                                Quantity: 1,
                                UnitPrice: '',
                                WarehouseCode: '',
                                UoMCode: '',
                                LineTotal: 0.0,
                                VatGroup: 'S2',
                                DiscountPercent: 0.0,
                                GrossTotal: 0.0,
                                U_WRNT: '',
                                U_STCK: 0.0
                            }
                            var cardcode = SAPWebPortal.ARInvoice.DocumentDialog.Form.CardCode.value;

                            var data = {
                                ItemCode: r.ItemCode, CardCode: cardcode
                            }
                            Q.serviceCall({
                                url: Q.resolveUrl('~/Services/ARInvoiceLine/DocumentLine/getItemDetail'),
                                request: data,
                                async: false,
                                onSuccess: response => {
                                    v.Quantity = 1
                                    v.UnitPrice = response["Price"];    
                                    v.WarehouseCode = response["WhsCode"];
                                    v.UoMCode = response["UOM"];
                                    v.LineTotal = response["LineTotal"];
                                    v.GrossTotal = response["GrossTotal"];
                                    v.DiscountPercent = response["Discount"];
                                    v.U_WRNT = response["WtyItem"];
                                    v.U_STCK = response["instock"];
                                      
                                }
                            });
                            return v;
                          });
                          for (let orderDetail of orderDetails) {
                            orderDetail[this.getIdProperty()] = "`" + this.nextId++;
                            this.view.addItem(orderDetail);
                        }
                    }
                            pickerDialog.dialogOpen();
                        }
                        else {
                            var columns = this.slickGrid.getColumns();
                            columns = columns.filter(column => column.field !== 'ItemCode');                          
                            this.slickGrid.setColumns(columns);
                            var v = {
                                ItemDescription: '',
                                Quantity: 1,
                                UnitPrice: '',
                                WarehouseCode: '',
                                UoMCode: '',
                                LineTotal: 0.0,
                                VatGroup: 'S2',
                                DiscountPercent: 0.0,
                                GrossTotal: 0.0,
                                U_WRNT: '',
                                U_STCK: 0.0
                            }
                            v[this.getIdProperty()] = "`" + this.nextId++;
                            this.view.addItem(v);


                        }
                    }
                    else
                    {
                        Q.notifyError("Please select a customer first!")
                    }
                }
            });
            return buttons;
        }

    }
}