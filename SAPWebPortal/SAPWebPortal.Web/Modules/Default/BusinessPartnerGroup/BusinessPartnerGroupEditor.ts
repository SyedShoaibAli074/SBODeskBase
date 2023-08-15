
namespace SAPWebPortal.Default {

	
	
    @Serenity.Decorators.registerEditor()
	export class BusinessPartnerGroupEditor extends Serenity.Select2Editor<any, any> {

		static editorSelect: Serenity.Select2Editor<any, any>;
		constructor(container: JQuery) {
			super(container, null);

			
			BusinessPartnerGroupEditor.editorSelect = this;

		}
    }
}