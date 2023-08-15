namespace SAPWebPortal.Orders {
    export namespace DocumentService {
        export const baseUrl = 'Orders/Document';

        export declare function GetAllDataDictionary(request: Serenity.ServiceRequest, onSuccess?: (response: System.ValueTuple<string, string, string, number>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckStatus(request: DocumentRow, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetDownloadFile(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            GetAllDataDictionary = "Orders/Document/GetAllDataDictionary",
            Create = "Orders/Document/Create",
            Update = "Orders/Document/Update",
            Delete = "Orders/Document/Delete",
            CheckStatus = "Orders/Document/CheckStatus",
            Retrieve = "Orders/Document/Retrieve",
            List = "Orders/Document/List",
            GetDownloadFile = "Orders/Document/GetDownloadFile"
        }

        [
            'GetAllDataDictionary', 
            'Create', 
            'Update', 
            'Delete', 
            'CheckStatus', 
            'Retrieve', 
            'List', 
            'GetDownloadFile'
        ].forEach(x => {
            (<any>DocumentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
