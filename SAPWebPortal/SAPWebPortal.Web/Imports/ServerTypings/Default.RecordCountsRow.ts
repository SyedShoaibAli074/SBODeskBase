namespace SAPWebPortal.Default {
    export interface RecordCountsRow {
        Id?: number;
        ModuleName?: string;
        ObjectType?: number;
        Company?: string;
        Counts?: number;
        DateTimeStamp?: string;
    }

    export namespace RecordCountsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ModuleName';
        export const localTextPrefix = 'Default.RecordCounts';
        export const deletePermission = 'MasterData:RecordCounts:Delete';
        export const insertPermission = 'MasterData:RecordCounts:Insert';
        export const readPermission = 'MasterData:RecordCounts:View';
        export const updatePermission = 'MasterData:RecordCounts:Modify';

        export declare const enum Fields {
            Id = "Id",
            ModuleName = "ModuleName",
            ObjectType = "ObjectType",
            Company = "Company",
            Counts = "Counts",
            DateTimeStamp = "DateTimeStamp"
        }
    }
}
