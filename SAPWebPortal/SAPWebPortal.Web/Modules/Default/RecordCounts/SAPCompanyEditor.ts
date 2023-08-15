
namespace SAPWebPortal.Default {
	@Serenity.Decorators.registerEditor()
	export class SAPCompanyEditor extends Serenity.Select2Editor<any, any> {

		constructor(container: JQuery) {
			super(container, null);
			// add option accepts a key (id) value and display text value

			Q.serviceCall({
				url: Q.resolveUrl('~/Services/Default/FileRouting/SAPCompanies'),
				request: localStorage.getItem("DBName"),
				onSuccess: response => {
					var count = Object.keys(response).length;
					for (var ind = 0; ind < count; ind++) {
						//console.log(response[ind]["Text"]);
						this.addOption(response[ind]["Value"], response[ind]["Text"]);
					}

				}
			});
		}
	}
}