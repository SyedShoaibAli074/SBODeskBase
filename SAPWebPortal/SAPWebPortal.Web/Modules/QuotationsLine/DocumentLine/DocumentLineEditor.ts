namespace SAPWebPortal.QuotationsLine {
    @Serenity.Decorators.registerClass()
    export class DocumentLineEditor extends _Ext.GridEditorBase<SAPWebPortal.QuotationsLine.DocumentLineRow> {
        protected getColumnsKey() { return "QuotationsLine.DocumentLine"; }
        protected getDialogType() { return SAPWebPortal.QuotationsLine.DocumentLineDialog; }
        protected getLocalTextPrefix() { return SAPWebPortal.QuotationsLine.DocumentLineRow.localTextPrefix; }
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
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            buttons.push({
                title: "Pick Products",
                cssClass: "Pick-Products-button",
                icon: 'fa fa-plus text-green',
                onClick: () => {

                    var HeaderForm = SAPWebPortal.Quotations.DocumentDialog.Form;
                    if (HeaderForm.CardCode != null && HeaderForm.CardCode.value != undefined && HeaderForm.CardCode.value != "") {
                        var pickerDialog = new _Ext.GridItemPickerDialog({
                            gridType: SAPWebPortal.Default.ItemGrid, multiple: true,
                            preSelectedKeys: this.value.map(k => k.ItemCode)
                        });
                        pickerDialog.onSuccess = (selectedItems: any[]) => {
                            let selectedItems2 = selectedItems.filter(t => {
                                console.log(t);
                                console.log(this.view.getItems());

                                var test: SAPWebPortal.Default.ItemRow = t;

                                return !Q.any(this.view.getItems(), n => n.ItemCode == test.ItemCode)
                            });
                            var orderDetails = selectedItems2.map<SAPWebPortal.QuotationsLine.DocumentLineRow>(r => {
                                var v =  {
                                    ItemCode: r.ItemCode,
                                    ItemDescription: r.ItemName,
                                    Quantity: 1,
                                    UnitPrice: 0.0,
                                    WarehouseCode: '',
                                    UoMCode: '',
                                    LineTotal: 0.0,
                                    GrossTotal: 0.0,
                                    VatGroup: '',
                                    UnitsOfMeasurment: 0.0,
                                    DiscountPercent: 0.0  
                                    
                                }
                                var cardcode = SAPWebPortal.Quotations.DocumentDialog.Form.CardCode.value;

                                var data = {
                                    ItemCode: r.ItemCode, CardCode: cardcode, DBName: localStorage.getItem("DBName")

                                }
                                Q.serviceCall({
                                    url: Q.resolveUrl('~/Services/QuotationsLine/DocumentLine/getItemDetail'),
                                    request: data,
                                    async:false,
                                    onSuccess: response => {
                                        v.Quantity=1 
                                        v.UnitPrice = response["Price"];
                                        v.WarehouseCode = response["WhsCode"];
                                        v.UoMCode = response["UOM"];
                                        v.LineTotal = response["LineTotal"];
                                        v.VatGroup = response["TaxCode"];
                                        v.UnitsOfMeasurment = response["UnitsOfMeasurment"]
                                        v.DiscountPercent = response["Discount"]
                                        v.GrossTotal = response["GrossTotal"]
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
                        Q.notifyError("Please select a customer first!")
                    }
                }
            });
            return buttons;
        }
        
    }
}