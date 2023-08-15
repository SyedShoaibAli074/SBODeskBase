namespace SAPWebPortal.Default {

    /**
     * Our select editor with hardcoded values.
     * 
     * When you define a new editor type, make sure you build
     * and transform templates for it to be available 
     * in server side forms, e.g. [HardCodedValuesEditor]
     */
    @Serenity.Decorators.registerEditor()
    export class DbServerTypeValuesEditor extends Serenity.Select2Editor<any, any> {

        constructor(container: JQuery) {
            super(container, null);

            // add option accepts a key (id) value and display text value
           
            this.addOption("dst_MSSQL", "dst_MSSQL");
            this.addOption("dst_DB_2", "dst_DB_2");
            this.addOption("dst_SYBASE", "dst_SYBASE");
            this.addOption("dst_MSSQL2005", "dst_MSSQL2005");
            this.addOption("dst_MAXDB", "dst_MAXDB");
            this.addOption("dst_MSSQL2008", "dst_MSSQL2008");
            this.addOption("dst_MSSQL2012", "dst_MSSQL2012");
            this.addOption("dst_MSSQL2014", "dst_MSSQL2014");
            this.addOption("dst_MSSQL2016", "dst_MSSQL2016");

            this.addOption("dst_MSSQL2017", "dst_MSSQL2017");

            this.addOption("dst_MSSQL2019", "dst_MSSQL2019");

            this.addOption("dst_HANADB", "dst_HANADB");
         
        }
    }
}