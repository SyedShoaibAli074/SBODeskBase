namespace SAPWebPortal.Administration {
    export interface UserFormAuthorizationsDetailsRow {
        Id?: number;
        UserFormAuthorizationId?: number;
        FieldName?: string;
        FieldDescription?: string;
        DataType?: string;
        DefaultValue?: string;
        DataSize?: string;
        Readonly?: boolean;
        Required?: boolean;
        Visible?: boolean;
        HtmlClass?: string;
        HtmlStyle?: string;
        HtmlAttributes?: string;
    }

    export namespace UserFormAuthorizationsDetailsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'FieldName';
        export const localTextPrefix = 'Administration.UserFormAuthorizationsDetails';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UserFormAuthorizationId = "UserFormAuthorizationId",
            FieldName = "FieldName",
            FieldDescription = "FieldDescription",
            DataType = "DataType",
            DefaultValue = "DefaultValue",
            DataSize = "DataSize",
            Readonly = "Readonly",
            Required = "Required",
            Visible = "Visible",
            HtmlClass = "HtmlClass",
            HtmlStyle = "HtmlStyle",
            HtmlAttributes = "HtmlAttributes"
        }
    }
}
