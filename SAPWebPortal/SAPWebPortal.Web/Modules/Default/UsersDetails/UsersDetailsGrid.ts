
namespace SAPWebPortal.Default {
	import fld = SAPWebPortal.Default.UsersDetailsRow.Fields
    @Serenity.Decorators.registerClass()
	export class UsersDetailsGrid extends _Ext.GridBase<UsersDetailsRow, any> {
        protected getColumnsKey() { return UsersDetailsColumns.columnsKey; }
        protected getDialogType() { return UsersDetailsDialog; }
        protected getIdProperty() { return UsersDetailsRow.idProperty; }
        protected getInsertPermission() { return UsersDetailsRow.insertPermission; }
        protected getLocalTextPrefix() { return UsersDetailsRow.localTextPrefix; }
        protected getService() { return UsersDetailsService.baseUrl; }
		constructor(container: JQuery) {
			super(container);
		}
		protected createSlickGrid() {
			var grid = super.createSlickGrid();

			grid.registerPlugin(new Slick.Data.GroupItemMetadataProvider());
			this.view.setGrouping
				([
					{
						getter: fld.UserId
					},
					{
						getter: fld.DbName

					},
					{
						getter: fld.Rodcid

					}
				])
			return grid;
		}
		protected getColumns() {
			var columns = super.getColumns();
			return columns;
		}
		protected getSlickOptions() {
			var opt = super.getSlickOptions();
			return opt;
		}

		protected usePager() {
			return false;
		}
		protected getButtons() {
			var buttons = super.getButtons();
			buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
			return buttons;
		}
    }
}