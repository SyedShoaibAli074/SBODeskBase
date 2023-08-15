
///// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace SAPWebPortal.Default {

	@Serenity.Decorators.registerClass()
	export class Report_UsersEditor extends _Ext.GridEditorBase<Report_UsersRow> {
		protected getColumnsKey() { return 'Default.Report_Users'; }

		protected getDialogType() { return Report_UsersDialog; }
		protected getLocalTextPrefix() { return Report_UsersRow.localTextPrefix; }

		constructor(container: JQuery) {
			super(container);
		
			this.slickGrid.onCellChange.subscribe((e, args) => {
				let cell = args.cell;
				let row = args.row;
				let grid = args.grid as Slick.Grid;
				let item = args.item as Report_UsersRow;

				var productID = Q.toId(item.Rodcid);
				if (productID != null) {
					item.RptName = ReportsRow.getLookup().itemById[productID].RptName;
					//item.DB_Name = RdocRow.getLookup().itemById[productID].DB_Name;
					//item.OtItemCode = OitmRow.getLookup().itemById[productID].ItemCode;
				}

				if (this.validateEntity(item, item[this.getIdProperty()])) {
					grid.updateRow(row);
				}
				else {
					//e.stopPropagation();
					//e.stopImmediatePropagation();
				}
			});
		}
		public depID: number;
		//protected getAddButtonCaption() {
		//	return "Add";
		//}
		validateEntity(row: Report_UsersRow, id: number) {


			var sameProduct = Q.tryFirst(this.view.getItems(), x => x.Rodcid === row.Rodcid);
			if (sameProduct && this.id(sameProduct) !== id) {
				Q.alert('This Report is already in details!');
				return false;
			}


			row.RptName = ReportsRow.getLookup().itemById[row.Rodcid].RptName;
			
			return true;

		}
		
		protected getSlickOptions() {
			$('[id^="slickgrid_"][id$="RowNum"]').hide();
			let opt = super.getSlickOptions();
			opt.editable = false;
			return opt;
			
		}
		protected ShowRowNumberColumn() {
			return false;
		}
	
		protected getButtons() {
			let buttons = super.getButtons();
			buttons.push({
				title: "Pick Reports",
				cssClass: "edit-permissions-button",
				icon: 'fa-plus text-green',
				
				onClick: () => {
					var pickerDialog = new _Ext.GridItemPickerDialog({
						gridType: ReportsGrid, multiple: true,
						preSelectedKeys: this.value.map(k => k.Rodcid)
					});

					pickerDialog.onSuccess = (selectedItems: any[]) => {
						let selectedItems2 = selectedItems.filter(t => { return !Q.any(this.view.getItems(), n => n.Rodcid == t.Rdocid) });

						var orderDetails = selectedItems2.map<Report_UsersRow>(r => {
							return {
								Rodcid: r.Rdocid,
								RptName: r.RptName,
								DB_Name: r.DB_Name,
							}
						});

						for (let orderDetail of orderDetails) {
							orderDetail[this.getIdProperty()] = "`" + this.nextId++;
							this.view.addItem(orderDetail);
						}

					}
					
					pickerDialog.dialogOpen();
				}
			});

			return buttons;
		}

	}
}
