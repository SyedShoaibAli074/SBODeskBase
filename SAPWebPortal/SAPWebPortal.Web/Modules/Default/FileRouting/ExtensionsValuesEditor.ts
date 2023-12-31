﻿
namespace SAPWebPortal.Default {

    /**
     * Our select editor with hardcoded values.
     * 
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available 
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    @Serenity.Decorators.registerEditor()
    export class ExtensionsValuesEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

                 ////this.addOption(".txt", "TXT");
            this.addOption(".pdf", "PDF");
            //this.addOption(".csv", "CSV");
         
        }
    }
}