namespace SAPWebPortal.Default {
    export interface FileRoutingRow {
        Id?: number;
        Name?: string;
        SlObjectType?: string;
        ReportPath?: string;
        RdocCode?: string;
        ExportExtension?: string;
        FileNameTemplate?: string;
        ExportPath?: string;
        CompanyDB?: string;
    }

    export namespace FileRoutingRow {
        export const idProperty = 'Id';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Default.FileRouting';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            Id = "Id",
            Name = "Name",
            SlObjectType = "SlObjectType",
            ReportPath = "ReportPath",
            RdocCode = "RdocCode",
            ExportExtension = "ExportExtension",
            FileNameTemplate = "FileNameTemplate",
            ExportPath = "ExportPath",
            CompanyDB = "CompanyDB"
        }
    }
}
