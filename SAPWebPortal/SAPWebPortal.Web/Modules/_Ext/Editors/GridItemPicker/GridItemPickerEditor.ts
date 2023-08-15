namespace _Ext {
    @Serenity.Decorators.registerClass([Serenity.ISetEditValue, Serenity.IGetEditValue, Serenity.IStringValue, Serenity.IReadOnly, Serenity.IValidateRequired])
    @Serenity.Decorators.editor()
    @Serenity.Decorators.element("<input type=\"text\" />")
    export class GridItemPickerEditor extends Serenity.Widget<GridItemPickerEditorOptions>
        implements Serenity.ISetEditValue, Serenity.IGetEditValue, Serenity.IStringValue, Serenity.IReadOnly, Serenity.IValidateRequired {

        containerDiv: JQuery;
        inplaceSearchButton: JQuery;
        inplaceViewButton: JQuery;
        clearSelectionButton: JQuery;

        constructor(container: JQuery, public options: GridItemPickerEditorOptions) {
            super(container, options);


            if (SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields.indexOf(options.propertyName) == -1)
            SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields.push(options.propertyName);
            this.element.addClass('select2-offscreen');

            this.containerDiv = $(`<div class="editor s-GridItemPickerEditor select2-container ${options.multiple ? 'select2-container-multi' : ''} has-inplace-button">
                        <div class="${options.multiple ? 'select2-choices' : 'select2-choice'}">
                            <div class="display-text" style="user-select: text; padding-right: 20px;${options.multiple ? 'padding-left: 5px;' : ''}"></div>
                            <a class="select2-search-choice-close btn-clear-selection" style="margin-top: 2px; cursor: pointer; left: unset;"></a>
                        </div>
                    </div>`).insertBefore(this.element);

            this.addInplaceButtons();

            this.setCascadeFrom(this.options.cascadeFrom);

        }

        protected addInplaceButtons(): void {
            var self = this;

            this.inplaceSearchButton = $('<a style="padding-top: 2px;"><i class="fa fa-search"></i></a>')
                .addClass('inplace-button inplace-search align-center').attr('title', 'search')
                .insertAfter(this.containerDiv)
                .click(function (e) {
                    self.inplaceSearchClick(e);
                });

            this.inplaceViewButton = $('<a style="padding-top: 2px;"><i class="fa fa-eye"></i></a>')
                .addClass('inplace-button inplace-view align-center').attr('title', 'view')
                .click(function (e) {
                    self.inplaceViewClick(e);
                })
                .hide();

            if (this.options.inplaceView != false && !this.options.multiple) {
                this.inplaceViewButton.insertAfter(this.containerDiv);
            }

            this.clearSelectionButton = this.containerDiv.find('.select2-search-choice-close')
                .click(e => {
                    this.value = '';
                    this.text = '';

                    this._selectedItem = null;
                    this.selectedItems = [];

                    $(e.target).hide();

                    this.element.trigger('change');
                    //this.element.triggerHandler('change');
                })
                .hide();

        }

        protected inplaceSearchClick(e: any): void {
            this.options.preSelectedKeys = this.values;
            var pickerDialog = new _Ext.GridItemPickerDialog(this.options);
           
            pickerDialog.onSuccess = (selectedItems: any[]) => {
                //this.value = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                //this.text = selectedItems.map(m => m[this.options.nameFieldInGridRow]).join(', ');
                if (Q.isEmptyOrNull(this.text)) {
                    console.warn('nameFieldInGridRow might be wrong in ' + this.widgetName);
                }
                if (this.options.rowType == "SAPWebPortal.Default.BusinessPartnerRow") {
                 
                    if (SAPWebPortal.Orders.DocumentDialog.Flag) {
                        var actionForm;
                        actionForm = SAPWebPortal.Orders.DocumentDialog.Form;
                        actionForm.CardCode.set_value(selectedItems.map(m => m["CardCode"]).join(', '));
                        actionForm.CardName.set_value(selectedItems.map(m => m["CardName"]).join(', '));
                         //actionForm.ContactPerson.set_value(selectedItems.map(m => m["ContactPerson"]).join(', '));
                        //data = JSON.stringify({
                        //    CardCode: selectedItems.map(m => m["CardCode"]).join(', '),
                        //     Name: selectedItems.map(m => m["ContactPerson"]).join(', '),
                        //});
                        //Q.serviceCall({
                        //    url: Q.resolveUrl('~/Services/Default/Ordr/getCntct'),
                        //    request: data,
                        //    onSuccess: response => {
                        //        console.log(response);
                        //        actionForm.CntctCode.set_value(response.key);
                        //        // orderForm.ContactPerson.set_value( response.value);
                        //    }
                        //});
                       
                        var cardcode = SAPWebPortal.Orders.DocumentDialog.Form.CardCode.value;
                        var editorSelectC1 = SAPWebPortal.Orders.Document.AddressListEditor.editorSelect;
                        var condition2 = editorSelectC1.items.length;
                        for (var ind = 0; ind < condition2; ind++) {
                            editorSelectC1.items.pop()
                        }
                        var data6 = { Code: cardcode, DBName: localStorage.getItem("DBName") };

                              Q.serviceCall({
                            url: Q.resolveUrl('~/Services/Orders/Document/getAddress'),
                                  request: data6, 
                                  async: false,
                                  onSuccess: response => {
                                      var count = Object.keys(response).length;
                                       for (var ind = 0; ind <= count; ind++) {
                                           try {
                                               editorSelectC1.addOption(response[ind]["Value"], response[ind]["Text"]);
                                           }
                                           catch{

                                           }
                                          
                                      }
                                      
                                      editorSelectC1.set_value("");
                                     
                                  }
                                 
                              });
                        var data = { Code: cardcode, DBName: localStorage.getItem("DBName") }

                        Q.serviceCall({
                            url: Q.resolveUrl('~/Services/Orders/Document/getDiscount'),
                            request: data,

                            onSuccess: response => {
                                console.log(response);
                                actionForm.DiscountPercent.set_value(response["Discount"]);
                            }

                        });
                        
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Services/Orders/Document/getPaymentGroup'),
                            request: data,

                            onSuccess: response => {
                                console.log(response);
                                actionForm.GroupNum.set_value(response["PymentGroup"]);
                            }

                        });
                        
                    }
                    if (SAPWebPortal.Quotations.DocumentDialog.Flag) {
                        var actionForm;
                        actionForm = SAPWebPortal.Quotations.DocumentDialog.Form;
                        actionForm.CardCode.set_value(selectedItems.map(m => m["CardCode"]).join(', '));
                        actionForm.CardName.set_value(selectedItems.map(m => m["CardName"]).join(', '));
                        //actionForm.ContactPerson.set_value(selectedItems.map(m => m["ContactPerson"]).join(', '));
                        //data = JSON.stringify({
                        //    CardCode: selectedItems.map(m => m["CardCode"]).join(', '),
                        //     Name: selectedItems.map(m => m["ContactPerson"]).join(', '),
                        //});
                        //Q.serviceCall({
                        //    url: Q.resolveUrl('~/Services/Default/Ordr/getCntct'),
                        //    request: data,
                        //    onSuccess: response => {
                        //        console.log(response);
                        //        actionForm.CntctCode.set_value(response.key);
                        //        // orderForm.ContactPerson.set_value( response.value);
                        //    }
                        //});
                        var cardcode = SAPWebPortal.Quotations.DocumentDialog.Form.CardCode.value;
                        var data = { Code: cardcode, DBName: localStorage.getItem("DBName") }

                        Q.serviceCall({
                            url: Q.resolveUrl('~/Services/Quotations/Document/getAddress'),
                            request: data,

                            onSuccess: response => {
                                console.log(response);
                                actionForm.U_Address.set_value(response["Address"]);
                            }

                        });
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Services/Quotations/Document/getDiscount'),
                            request: data,

                            onSuccess: response => {
                                console.log(response);
                                actionForm.DiscountPercent.set_value(response["Discount"]);
                            }

                        });
                    }
                    if (SAPWebPortal.Drafts.DocumentDialog.Flag) {
                        var actionForm;
                        actionForm = SAPWebPortal.Drafts.DocumentDialog.Form;
                        actionForm.CardCode.set_value(selectedItems.map(m => m["CardCode"]).join(', '));
                        actionForm.CardName.set_value(selectedItems.map(m => m["CardName"]).join(', '));
                        //actionForm.ContactPerson.set_value(selectedItems.map(m => m["ContactPerson"]).join(', '));
                        //data = JSON.stringify({
                        //    CardCode: selectedItems.map(m => m["CardCode"]).join(', '),
                        //     Name: selectedItems.map(m => m["ContactPerson"]).join(', '),
                        //});
                        //Q.serviceCall({
                        //    url: Q.resolveUrl('~/Services/Default/Ordr/getCntct'),
                        //    request: data,
                        //    onSuccess: response => {
                        //        console.log(response);
                        //        actionForm.CntctCode.set_value(response.key);
                        //        // orderForm.ContactPerson.set_value( response.value);
                        //    }
                        //});
                    }
                }
                else if (this.options.rowType == "SAPWebPortal.Default.ItemRow")
                {
                    if (SAPWebPortal.Orders.DocumentDialog.Flag)
                    {
                        if (this.element == null)
                        {
                            var Form = SAPWebPortal.Orders.DocumentDialog.Form;
                            var val = {
                                ItemCode: pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(','),
                                CardCode: Form.CardCode.value,
                                DBName: localStorage.getItem("DBName")
                            }
                            var ItemName = selectedItems.map(m => m["ItemName"]).join(', ');
                            var index = SAPWebPortal.OrdersLine.DocumentLineEditor.rnum;
                            Form.DocumentLines.getView().getItem(index).ItemCode = val.ItemCode;
                            Form.DocumentLines.getView().getItem(index).ItemDescription = ItemName;
                            Q.serviceCall({
                                url: Q.resolveUrl('~/Services/OrdersLine/DocumentLine/getItemDetail'),
                                request: val,
                                onSuccess: response => {
                                    Form.DocumentLines.getView().getItem(index).Quantity = 1;
                                    Form.DocumentLines.getView().getItem(index).UnitPrice = response["Price"];
                                    Form.DocumentLines.getView().getItem(index).WarehouseCode = response["WhsCode"];
                                    Form.DocumentLines.getView().getItem(index).UoMCode = response["UOM"];
                                    Form.DocumentLines.getView().getItem(index).LineTotal = response["LineTotal"];
                                    Form.DocumentLines.getView().getItem(index).GrossTotal = response["GrossTotal"];
                                    Form.DocumentLines.getView().getItem(index).VatGroup = response["Taxcode"];
                                    Form.DocumentLines.getView().getItem(index).UnitsOfMeasurment = response["UnitsOfMeasurment"];
                                    Form.DocumentLines.getView().getItem(index).InventoryQuantity = response["InventoryQuantity"];
                                    Form.DocumentLines.getView().getItem(index).DiscountPercent = response["Discount"];
                                    Form.DocumentLines.getGrid().invalidateRow(index);
                                    Form.DocumentLines.getGrid().render();
                                }
                            });
                            Form.DocumentLines.getGrid().invalidateRow(index);
                            Form.DocumentLines.getGrid().render();
                        }
                    }
                    if (SAPWebPortal.Quotations.DocumentDialog.Flag)
                    {
                        if (this.element == null)
                        {
                            var Form1 = SAPWebPortal.Quotations.DocumentDialog.Form;
                            var val = {
                                ItemCode: pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(','),
                                CardCode: Form1.CardCode.value,
                                DBName: localStorage.getItem("DBName")

                            }
                            var ItemName=selectedItems.map(m => m["ItemName"]).join(', ');
                            var index = SAPWebPortal.QuotationsLine.DocumentLineEditor.rnum;
                            Form1.DocumentLines.getView().getItem(index).ItemCode = val.ItemCode;
                            
                            Form1.DocumentLines.getView().getItem(index).ItemDescription = ItemName;
                            Q.serviceCall({
                                url: Q.resolveUrl('~/Services/QuotationsLine/DocumentLine/getItemDetail'),
                                request: val,
                                onSuccess: response => {
                                    Form1.DocumentLines.getView().getItem(index).Quantity = 1;
                                    Form1.DocumentLines.getView().getItem(index).UnitPrice = response["Price"];
                                    Form1.DocumentLines.getView().getItem(index).WarehouseCode = response["WhsCode"];
                                    Form1.DocumentLines.getView().getItem(index).UoMCode = response["UOM"];
                                    Form1.DocumentLines.getView().getItem(index).LineTotal = response["LineTotal"];
                                    Form1.DocumentLines.getView().getItem(index).GrossTotal = response["GrossTotal"];
                                    Form1.DocumentLines.getView().getItem(index).VatGroup = response["Taxcode"];
                                    Form1.DocumentLines.getView().getItem(index).UnitsOfMeasurment = response["UnitsOfMeasurment"];
                                    Form1.DocumentLines.getView().getItem(index).DiscountPercent = response["Discount"];

                                     Form1.DocumentLines.getGrid().invalidateRow(index);
                                    Form1.DocumentLines.getGrid().render();
                                }
                            });
                            Form1.DocumentLines.getGrid().invalidateRow(index);
                            Form1.DocumentLines.getGrid().render();
                        }
                    }
                    if (SAPWebPortal.Drafts.DocumentDialog.Flag) {
                        if (this.element == null) {
                            var Form2 = SAPWebPortal.Drafts.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var ItemName = selectedItems.map(m => m["ItemName"]).join(', ');
                            var index = SAPWebPortal.DraftsLine.DocumentLineEditor.rnum;
                            Form2.DocumentLines.getView().getItem(index).ItemCode = val;
                            Form2.DocumentLines.getView().getItem(index).ItemDescription = ItemName;
                            var data5 = { Code: val, DBName: localStorage.getItem("DBName") };
                            Q.serviceCall({
                                url: Q.resolveUrl('~/Services/DraftsLine/DocumentLine/getItemDetail'),
                                request: data5,
                                onSuccess: response => {
                                    Form2.DocumentLines.getView().getItem(index).Quantity = 1;
                                    Form2.DocumentLines.getView().getItem(index).UnitPrice = response["Price"];
                                     Form2.DocumentLines.getView().getItem(index).WarehouseCode = response["WhsCode"];
                                    Form2.DocumentLines.getView().getItem(index).UoMCode = response["UOM"];
                                    Form2.DocumentLines.getView().getItem(index).LineTotal = response["LineTotal"];
                                    Form2.DocumentLines.getView().getItem(index).GrossTotal = response["GrossTotal"];
                                    Form2.DocumentLines.getView().getItem(index).VatGroup = response["Taxcode"];
                                    Form2.DocumentLines.getView().getItem(index).UnitsOfMeasurment = response["UnitsOfMeasurment"];
                                    Form2.DocumentLines.getView().getItem(index).DiscountPercent = response["Discount"];
                                    Form2.DocumentLines.getGrid().invalidateRow(index);
                                    Form2.DocumentLines.getGrid().render();
                                }
                            });
                            Form2.DocumentLines.getGrid().invalidateRow(index);
                            Form2.DocumentLines.getGrid().render();
                        }
                    }
                }
                else if (this.options.rowType == "SAPWebPortal.VatGroups.VatGroupRow") {
                    if (SAPWebPortal.Orders.DocumentDialog.Flag) {
                        if (this.element == null && SAPWebPortal.Orders.DocumentDialog.DocumentLineFlag) {
                            var Form = SAPWebPortal.Orders.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.OrdersLine.DocumentLineEditor.rnum;
                            Form.DocumentLines.getView().getItem(index).VatGroup = val;
                            var data2 = { Code: val, DBName: localStorage.getItem("DBName") };

                            Q.serviceCall({
                                url: Q.resolveUrl("~/Services/Orders/Document/getTaxDetail"),
                                request: data2,
                                onSuccess: response => {
                                    var Rate = response["Rate"];
                                    Form.DocumentLines.getView().getItem(index).TaxTotal = (Form.DocumentLines.getView().getItem(index).UnitPrice * Form.DocumentLines.getView().getItem(index).Quantity) * (Rate / 100);
                                    Form.DocumentLines.getView().getItem(index).LineTotal = (Form.DocumentLines.getView().getItem(index).UnitPrice * Form.DocumentLines.getView().getItem(index).Quantity) + (Form.DocumentLines.getView().getItem(index).UnitPrice * Form.DocumentLines.getView().getItem(index).Quantity)* (Rate / 100);
                                    Form.DocumentLines.getGrid().invalidateRow(index);
                                    Form.DocumentLines.getGrid().render();
                                }
                            });
                            Form.DocumentLines.getGrid().invalidateRow(index);
                            Form.DocumentLines.getGrid().render();
                            SAPWebPortal.Orders.DocumentDialog.DocumentLineFlag = false;
                        }
                    }
                    if (SAPWebPortal.Quotations.DocumentDialog.Flag) {
                        if (this.element == null && SAPWebPortal.Quotations.DocumentDialog.DocumentLineFlag) {
                            var Form1 = SAPWebPortal.Quotations.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.QuotationsLine.DocumentLineEditor.rnum;
                            Form1.DocumentLines.getView().getItem(index).VatGroup = val;
                            var data1 = { Code: val, DBName: localStorage.getItem("DBName") };

                            Q.serviceCall({
                                url: Q.resolveUrl("~/Services/Quotations/Document/getTaxDetail"),
                                request: data1,
                                onSuccess: response => {
                                    var Rate = response["Rate"];
                                    Form1.DocumentLines.getView().getItem(index).TaxTotal = (Form1.DocumentLines.getView().getItem(index).UnitPrice * Form1.DocumentLines.getView().getItem(index).Quantity) * (Rate / 100);
                                    Form1.DocumentLines.getView().getItem(index).LineTotal = (Form1.DocumentLines.getView().getItem(index).UnitPrice * Form1.DocumentLines.getView().getItem(index).Quantity) + (Form1.DocumentLines.getView().getItem(index).UnitPrice * Form1.DocumentLines.getView().getItem(index).Quantity) * (Rate / 100);
                                    Form1.DocumentLines.getGrid().invalidateRow(index);
                                    Form1.DocumentLines.getGrid().render();
                                }
                            });
                            Form1.DocumentLines.getGrid().invalidateRow(index);
                            Form1.DocumentLines.getGrid().render();
                            SAPWebPortal.Quotations.DocumentDialog.DocumentLineFlag = false;
                        }
                    }
                    if (SAPWebPortal.Drafts.DocumentDialog.Flag) {
                        if (this.element == null && SAPWebPortal.Drafts.DocumentDialog.DocumentLineFlag) {
                            var Form2 = SAPWebPortal.Drafts.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.DraftsLine.DocumentLineEditor.rnum;
                            Form2.DocumentLines.getView().getItem(index).VatGroup = val;
                            Form2.DocumentLines.getGrid().invalidateRow(index);
                            Form2.DocumentLines.getGrid().render();
                            SAPWebPortal.Drafts.DocumentDialog.DocumentLineFlag = false;
                        }
                    }
                }
                else if (this.options.rowType == "SAPWebPortal.Default.WarehouseRow") {
                    if (SAPWebPortal.Orders.DocumentDialog.Flag) {
                        if (this.element == null) {
                            var Form = SAPWebPortal.Orders.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.OrdersLine.DocumentLineEditor.rnum;
                            Form.DocumentLines.getView().getItem(index).WarehouseCode = val;
                            Form.DocumentLines.getGrid().invalidateRow(index);
                            Form.DocumentLines.getGrid().render();
                        }
                    }
                    if (SAPWebPortal.Quotations.DocumentDialog.Flag) {
                        if (this.element == null) {
                            var Form1 = SAPWebPortal.Quotations.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.QuotationsLine.DocumentLineEditor.rnum;
                            Form1.DocumentLines.getView().getItem(index).WarehouseCode = val;
                            Form1.DocumentLines.getGrid().invalidateRow(index);
                            Form1.DocumentLines.getGrid().render();
                        }
                    }
                    if (SAPWebPortal.Drafts.DocumentDialog.Flag) {
                        if (this.element == null) {
                            var Form2 = SAPWebPortal.Drafts.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.DraftsLine.DocumentLineEditor.rnum;
                            Form2.DocumentLines.getView().getItem(index).WarehouseCode = val;
                            Form2.DocumentLines.getGrid().invalidateRow(index);
                            Form2.DocumentLines.getGrid().render();
                        }
                    }
                }
                else if (this.options.rowType == "SAPWebPortal.Default.ChartOfAccountRow") {
                    if (SAPWebPortal.Orders.DocumentDialog.Flag) {
                        if (this.element == null) {
                            var Form = SAPWebPortal.Orders.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.OrdersLine.DocumentLineEditor.rnum;
                            Form.DocumentLines.getView().getItem(index).AccountCode = val;
                            Form.DocumentLines.getGrid().invalidateRow(index);
                            Form.DocumentLines.getGrid().render();
                        }
                    }
                    if (SAPWebPortal.Quotations.DocumentDialog.Flag) {
                        if (this.element == null) {
                            var Form1 = SAPWebPortal.Quotations.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.QuotationsLine.DocumentLineEditor.rnum;
                            Form1.DocumentLines.getView().getItem(index).AccountCode = val;
                            Form1.DocumentLines.getGrid().invalidateRow(index);
                            Form1.DocumentLines.getGrid().render();
                        }
                    }
                    if (SAPWebPortal.Drafts.DocumentDialog.Flag) {
                        if (this.element == null) {
                            var Form2 = SAPWebPortal.Drafts.DocumentDialog.Form;
                            var val = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(',');
                            var index = SAPWebPortal.DraftsLine.DocumentLineEditor.rnum;
                            Form2.DocumentLines.getView().getItem(index).AccountCode = val;
                            Form2.DocumentLines.getGrid().invalidateRow(index);
                            Form2.DocumentLines.getGrid().render();
                        }
                    }
                }
                try { this.value = pickerDialog.checkGrid.rowSelection.getSelectedKeys().join(','); } catch { }
                if (this.element != null)
                {
                    this.text = selectedItems.map(m => m[this.options.nameFieldInGridRow]).join(', ');
                }
                this._selectedItem = selectedItems[0];
                this.selectedItems = selectedItems;
                if (this.element != null) {
                    this.element.trigger('change');
                }
            }
            pickerDialog.dialogOpen();
        }

        protected inplaceViewClick(e: any): void {
            var val = this.value;

            if (!Q.isEmptyOrNull(val)) {
                var dlg = this.getDialogInstance();
                dlg.isReadOnly = true;
                dlg.loadByIdAndOpenDialog(val, false);
            }
        }

        private getDialogInstance(): DialogBase<any, any> {
            var dialogType = this.options.dialogType;

            if (!dialogType.prototype)
                dialogType = Q.getType(this.options.dialogType);

            try {
                var dlg = new dialogType() as DialogBase<any, any>;
                return dlg;
            } catch (ex) {
                console.warn('Could not intialize ' + this.options.dialogType);
            }
        }

        public get value(): string {
            let editVal = this.element.val();
            return editVal;
        }

        public set value(val: string) {
            console.log(this.element.val());


            console.log(this.element.val(val));
            

            if (Q.isEmptyOrNull(val)) {
                this.text = '';
                this.inplaceViewButton.hide()
                this.clearSelectionButton.hide()
            } else {
                this.element.val(val);
                this.inplaceViewButton.show()
                if (this.get_readOnly() == false)
                    this.clearSelectionButton.show()
            }

        }

        public get values(): string[] {
            let valCVS = this.value;
            if (Q.isEmptyOrNull(valCVS))
                return [];
            else
                return valCVS.split(',');
        }

        public set values(val: string[]) {
            this.value = val.join(',');
        }

        public get text(): string {
            let editVal = this.containerDiv.find('.display-text').text();
            return editVal;
        }

        public set text(val: string) {
            this.containerDiv.find('.display-text').text(val);
        }

        public getEditValue(property, target) {
            if (this.options.multiple == true) {
                target[property.name] = this.values;
            } else {
                target[property.name] = this.value;
            }
        }
        public setEditValue(source, property) {
            this.value = source[property.name];

            let text = source[this.options.nameFieldInThisRow] || source[this.options.nameFieldInGridRow]
            this.text = text;

            if (source[property.name]) {
                this._selectedItem = {};
                this._selectedItem[this.options.idFieldInGridRow] = source[property.name];
                this._selectedItem[this.options.nameFieldInGridRow] = text;
            }
        }

        get_value() {
            return this.value;
        }

        set_value(value: string) {
            this.value = value;
        }

        get_readOnly(): boolean {
            return this.element.hasClass('readonly');
        }
        set_readOnly(value: boolean): void {
            if (value) {
                this.element.addClass('readonly');
                this.containerDiv.addClass('select2-container-disabled');
                this.inplaceSearchButton.addClass('disabled').hide();
                this.clearSelectionButton.addClass('disabled').hide();
            } else {
                this.element.removeClass('readonly')
                this.containerDiv.removeClass('select2-container-disabled');
                this.inplaceSearchButton.removeClass('disabled').show();
                this.clearSelectionButton.removeClass('disabled').show();
            }
        }

        get_required(): boolean {
            return this.element.hasClass('required');
        }
        set_required(value: boolean): void {
            if (value) {
                this.element.addClass('required');
                this.containerDiv.addClass('required');
                this.containerDiv.find('.select2-choice, display-text').addClass('required');
            } else {
                this.element.removeClass('required');
                this.containerDiv.removeClass('required');
                this.containerDiv.find('.select2-choice, display-text').removeClass('required');
            }
        }


        private _selectedItem;
        public selectedItemIncludeColumns: string[] = [];

        public get selectedItem() {
            if (this._selectedItem
                && this._selectedItem[this.options.nameFieldInGridRow]
                && this.selectedItemIncludeColumns.every(e => this._selectedItem[e])
            )
                return this._selectedItem;
            else if (!Q.isEmptyOrNull(this.value)) {

                Q.serviceCall<Serenity.RetrieveResponse<any>>({
                    service: this.serviceUrl + '/Retrieve',
                    request: {
                        EntityId: this.value,
                        ColumnSelection: Serenity.RetrieveColumnSelection.list,
                        IncludeColumns: this.selectedItemIncludeColumns
                    } as Serenity.RetrieveRequest,
                    async: false,
                    onSuccess: (response) => {
                        this._selectedItem = response.Entity;
                    }
                });

                return this._selectedItem;
            }
        }

        public selectedItems: any[];

        private _serviceUrl: string;
        get serviceUrl(): string {
            if (Q.isEmptyOrNull(this._serviceUrl)) {
                var dlg = this.getDialogInstance();
                this._serviceUrl = dlg['getService']();
            }
            return this._serviceUrl;
        }

        setValueAndText(value, text) {
            this.value = value;
            this.text = text;
        }

        //-------------------------------cascading and filtering -----------------------------------
        protected getCascadeFromValue(parent: Serenity.Widget<any>) {
            return Serenity.EditorUtils.getValue(parent);
        }

        protected cascadeLink: Serenity.CascadedWidgetLink<Serenity.Widget<any>>;

        protected setCascadeFrom(value: string) {

            if (Q.isEmptyOrNull(value)) {
                if (this.cascadeLink != null) {
                    this.cascadeLink.set_parentID(null);
                    this.cascadeLink = null;
                }
                (this.options as Serenity.Select2EditorOptions).cascadeFrom = null;
                return;
            }

            this.cascadeLink = new Serenity.CascadedWidgetLink<Serenity.Widget<any>>(Serenity.Widget, this, p => {
                this.set_cascadeValue(this.getCascadeFromValue(p));
            });

            this.cascadeLink.set_parentID(value);
            (this.options as Serenity.Select2EditorOptions).cascadeFrom = value;
        }

        protected get_cascadeFrom(): string {
            return (this.options as Serenity.Select2EditorOptions).cascadeFrom;
        }

        get cascadeFrom(): string {
            return this.get_cascadeFrom();
        }

        protected set_cascadeFrom(value: string) {
            if (value !== (this.options as Serenity.Select2EditorOptions).cascadeFrom) {
                this.setCascadeFrom(value);
                this.updateItems();
            }
        }

        set cascadeFrom(value: string) {
            this.set_cascadeFrom(value);
        }

        protected get_cascadeField() {
            return Q.coalesce((this.options as Serenity.Select2EditorOptions).cascadeField, (this.options as Serenity.Select2EditorOptions).cascadeFrom);
        }

        get cascadeField(): string {
            return this.get_cascadeField();
        }

        protected set_cascadeField(value: string) {
            (this.options as Serenity.Select2EditorOptions).cascadeField = value;
        }

        set cascadeField(value: string) {
            this.set_cascadeField(value);
        }

        protected get_cascadeValue(): any {
            return (this.options as Serenity.Select2EditorOptions).cascadeValue;
        }

        get cascadeValue(): any {
            return this.get_cascadeValue();
        }

        protected set_cascadeValue(value: any) {
            if ((this.options as Serenity.Select2EditorOptions).cascadeValue !== value) {
                (this.options as Serenity.Select2EditorOptions).cascadeValue = value;
                this.set_value(null);
                this.updateItems();

            }
        }

        set cascadeValue(value: any) {
            this.set_cascadeValue(value);
        }

        protected get_filterField() {
            return (this.options as Serenity.Select2EditorOptions).filterField;
        }

        get filterField(): string {
            return this.get_filterField();
        }

        protected set_filterField(value: string) {
            (this.options as Serenity.Select2EditorOptions).filterField = value;
        }

        set filterField(value: string) {
            this.set_filterField(value);
        }

        protected get_filterValue(): any {
            return (this.options as Serenity.Select2EditorOptions).filterValue;
        }

        get filterValue(): any {
            return this.get_filterValue();
        }

        protected set_filterValue(value: any) {
            if ((this.options as Serenity.Select2EditorOptions).filterValue !== value) {
                (this.options as Serenity.Select2EditorOptions).filterValue = value;
                this.set_value(null);
                this.updateItems();

            }
        }

        set filterValue(value: any) {
            this.set_filterValue(value);
        }

        protected updateItems() {
        }
       
    }

    export interface GridItemPickerEditorOptions extends Serenity.Select2FilterOptions {
        gridType: any;
        nameFieldInThisRow?: string;
        serviceUrl?: string;

        rowType?: string;
        idFieldInGridRow?: string;
        nameFieldInGridRow?: string;

        inplaceView?: boolean;

        multiple?: boolean;
        preSelectedKeys?: any[];

        filteringCriteria?: any;
        customPrams?: any;

        dialogType?: any;

        //from Serenity.Select2FilterOptions
        cascadeFrom?: string;
        cascadeField?: string;
        cascadeValue?: any;
        filterField?: string;
        propertyName?: string;
        filterValue?: any;

    }


}