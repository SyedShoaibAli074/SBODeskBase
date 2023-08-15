namespace SAPWebPortal.Administration {
    export interface ExceptionsRow {
        Id?: number;
        Guid?: string;
        ApplicationName?: string;
        MachineName?: string;
        CreationDate?: string;
        Type?: string;
        IsProtected?: boolean;
        Host?: string;
        Url?: string;
        HttpMethod?: string;
        IpAddress?: string;
        Source?: string;
        Message?: string;
        Detail?: string;
        StatusCode?: number;
        Sql?: string;
        DeletionDate?: string;
        FullJson?: string;
        ErrorHash?: number;
        DuplicateCount?: number;
        DBName?: string;
    }

    export namespace ExceptionsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ApplicationName';
        export const localTextPrefix = 'Administration.Exceptions';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            Guid = "Guid",
            ApplicationName = "ApplicationName",
            MachineName = "MachineName",
            CreationDate = "CreationDate",
            Type = "Type",
            IsProtected = "IsProtected",
            Host = "Host",
            Url = "Url",
            HttpMethod = "HttpMethod",
            IpAddress = "IpAddress",
            Source = "Source",
            Message = "Message",
            Detail = "Detail",
            StatusCode = "StatusCode",
            Sql = "Sql",
            DeletionDate = "DeletionDate",
            FullJson = "FullJson",
            ErrorHash = "ErrorHash",
            DuplicateCount = "DuplicateCount",
            DBName = "DBName"
        }
    }
}
