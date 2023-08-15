
//// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace SAPWebPortal.Default {

	@Serenity.Decorators.registerClass()
	export class UsersDetails extends _Ext.GridEditorBase<UsersDetailsRow> {
		protected getColumnsKey() { return 'Default.UsersDetails'; }

		protected getDialogType() { return UsersDetailsDialog; }
		protected getLocalTextPrefix() { return UsersDetailsRow.localTextPrefix; }

		constructor(container: JQuery) {
			super(container);

		}
		public depID: number;
		protected getAddButtonCaption() {
			return "Add";
		}
		
	}
}

