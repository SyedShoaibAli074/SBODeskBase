namespace SAPWebPortal.Default {
    export interface BusinessPartnerGroupRow {
        Code?: number;
        Name?: string;
        Type?: string;
    }

    export namespace BusinessPartnerGroupRow {
        export const idProperty = 'Code';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Default.BusinessPartnerGroup';
        export const lookupKey = 'Default.BusinessPartnerGroup';

        export function getLookup(): Q.Lookup<BusinessPartnerGroupRow> {
            return Q.getLookup<BusinessPartnerGroupRow>('Default.BusinessPartnerGroup');
        }
        export const deletePermission = 'Administration:BusinessPartnerGroup';
        export const insertPermission = 'Administration:BusinessPartnerGroup';
        export const readPermission = 'Administration:BusinessPartnerGroup';
        export const updatePermission = 'Administration:BusinessPartnerGroup';

        export declare const enum Fields {
            Code = "Code",
            Name = "Name",
            Type = "Type"
        }
    }
}
