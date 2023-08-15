

namespace SAPWebPortal.Default {

   
    @Serenity.Decorators.registerEditor()
    export class SelectCodeNameValueEditor extends Serenity.Select2Editor<any, any> {

        public static dropdownfields: Array<string> = new Array<string>();
        public static editorSelect: Serenity.Select2Editor<any, any>;
         constructor(container: JQuery, opt?: any) {
             super(container, opt);
             if (SelectCodeNameValueEditor.dropdownfields.indexOf(opt.propertyNameSAP)==-1)
             SelectCodeNameValueEditor.dropdownfields.push(opt.propertyNameSAP);

             SelectCodeNameValueEditor.editorSelect = this;

        }
      
        
    }
}