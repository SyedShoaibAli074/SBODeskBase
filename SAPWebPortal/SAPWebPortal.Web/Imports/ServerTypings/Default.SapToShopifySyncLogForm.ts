namespace SAPWebPortal.Default {
    export interface SapToShopifySyncLogForm {
        DocEntry: Serenity.StringEditor;
        SyncStatus: Serenity.StringEditor;
        TargetStoreId: Serenity.StringEditor;
        SourceObjType: Serenity.StringEditor;
        SyncTime: Serenity.StringEditor;
    }

    export class SapToShopifySyncLogForm extends Serenity.PrefixedContext {
        static formKey = 'Default.SapToShopifySyncLog';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SapToShopifySyncLogForm.init)  {
                SapToShopifySyncLogForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(SapToShopifySyncLogForm, [
                    'DocEntry', w0,
                    'SyncStatus', w0,
                    'TargetStoreId', w0,
                    'SourceObjType', w0,
                    'SyncTime', w0
                ]);
            }
        }
    }
}
