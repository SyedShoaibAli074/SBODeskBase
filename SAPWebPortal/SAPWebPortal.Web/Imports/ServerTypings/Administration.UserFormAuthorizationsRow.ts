namespace SAPWebPortal.Administration {
    export interface UserFormAuthorizationsRow {
        Id?: number;
        UserId?: number;
        ModuleName?: number;
        CompanyDb?: string;
        FormName?: string;
        FormTitle?: string;
        FormDescription?: string;
        DetailList?: UserFormAuthorizationsDetailsRow[];
    }

    export namespace UserFormAuthorizationsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'CompanyDb';
        export const localTextPrefix = 'Administration.UserFormAuthorizations';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UserId = "UserId",
            ModuleName = "ModuleName",
            CompanyDb = "CompanyDb",
            FormName = "FormName",
            FormTitle = "FormTitle",
            FormDescription = "FormDescription",
            DetailList = "DetailList"
        }
    }
}
