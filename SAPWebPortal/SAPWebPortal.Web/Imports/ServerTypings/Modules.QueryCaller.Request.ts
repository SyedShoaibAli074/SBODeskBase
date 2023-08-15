namespace SAPWebPortal.Modules.QueryCaller {
    export interface Request {
        TableName?: string;
        DBName?: string;
        Username?: string;
        Columns?: string;
        Payload?: string;
        Query?: string;
    }
}
