namespace SAPWebPortal.Default {
    export interface FileRoutingForm {
        Name: Serenity.StringEditor;
        CompanyDB: SAPCompanyEditor;
        SlObjectType: SAPObectsValuesEditor;
        ReportPath: Serenity.ImageUploadEditor;
        RdocCode: Serenity.StringEditor;
        ExportExtension: ExtensionsValuesEditor;
        FileNameTemplate: Serenity.StringEditor;
        ExportPath: Serenity.StringEditor;
    }

    export class FileRoutingForm extends Serenity.PrefixedContext {
        static formKey = 'Default.FileRouting';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!FileRoutingForm.init)  {
                FileRoutingForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = SAPCompanyEditor;
                var w2 = SAPObectsValuesEditor;
                var w3 = s.ImageUploadEditor;
                var w4 = ExtensionsValuesEditor;

                Q.initFormType(FileRoutingForm, [
                    'Name', w0,
                    'CompanyDB', w1,
                    'SlObjectType', w2,
                    'ReportPath', w3,
                    'RdocCode', w0,
                    'ExportExtension', w4,
                    'FileNameTemplate', w0,
                    'ExportPath', w0
                ]);
            }
        }
    }
}
