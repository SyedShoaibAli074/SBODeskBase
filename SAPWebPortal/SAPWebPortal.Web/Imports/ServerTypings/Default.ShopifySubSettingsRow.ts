namespace SAPWebPortal.Default {
    export interface ShopifySubSettingsRow {
        Id?: number;
        Name?: string;
        Description?: string;
    }

    export namespace ShopifySubSettingsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Default.ShopifySubSettings';
        export const lookupKey = 'Default.ShopifySubSettings';

        export function getLookup(): Q.Lookup<ShopifySubSettingsRow> {
            return Q.getLookup<ShopifySubSettingsRow>('Default.ShopifySubSettings');
        }
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            Description = "Description"
        }
    }
}
