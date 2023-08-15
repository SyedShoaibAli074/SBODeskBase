/// <reference path="BulkAction.ts" />
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class OipbatchGrid extends _Ext.GridBase<OipbatchRow, any> {
        protected getColumnsKey() { return OipbatchColumns.columnsKey; }
        protected getDialogType() { return OipbatchDialog; }
        protected getIdProperty() { return OipbatchRow.idProperty; }
        protected getInsertPermission() { return OipbatchRow.insertPermission; }
        protected getLocalTextPrefix() { return OipbatchRow.localTextPrefix; }
        protected getService() { return OipbatchService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected createToolbarExtensions() {
            super.createToolbarExtensions();
            //this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        }

        protected getButtons() {
            return [{
                title: 'Close Payment Batch',
                cssClass: 'send-button',
                onClick: () => {
                    if (!this.onViewSubmit()) {
                        return;
                    }

                    var action = new BulkAction();
                    action.done = () => this.rowSelection.resetCheckedAndRefresh();
                    action.execute(this.rowSelection.getSelectedKeys());
                }
            }];
        }

        protected getColumns() {
            var columns = super.getColumns();
            columns.splice(0, 0, Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection));
		//set column of checbox to 20px;
			
			
			columns[0].width = 20;
		
		
            return columns;
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 2500;
            return opt;
        }
    }
}