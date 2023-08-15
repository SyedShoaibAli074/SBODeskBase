namespace SAPWebPortal.Membership {

    /**
     * Our select editor with hardcoded values.
     * 
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available 
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    @Serenity.Decorators.registerEditor()
    export class CompanyDatabaseValuesEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

            // add option accepts a key (id) value and display text value

            SAPWebPortal.Default.SapDatabasesService.List({}, (response) => {
                var entities = response.Entities;
                for (var i = 0; i < entities.length; i++) {
                    this.addOption(entities[i].CompanyDb, entities[i].CompanyDb);
                }
            })
         
        }
    }
}