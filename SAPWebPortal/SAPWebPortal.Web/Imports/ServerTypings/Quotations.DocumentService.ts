namespace SAPWebPortal.Quotations {
    export namespace DocumentService {
        export const baseUrl = 'Quotations/Document';

        export declare function GetAllDataDictionary(request: Serenity.ServiceRequest, onSuccess?: (response: System.ValueTuple<string, string, string, number>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckStatus(request: DocumentRow, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetDownloadFile(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            GetAllDataDictionary = "Quotations/Document/GetAllDataDictionary",
            Create = "Quotations/Document/Create",
            Update = "Quotations/Document/Update",
            Delete = "Quotations/Document/Delete",
            Retrieve = "Quotations/Document/Retrieve",
            List = "Quotations/Document/List",
            CheckStatus = "Quotations/Document/CheckStatus",
            GetDownloadFile = "Quotations/Document/GetDownloadFile"
        }

        [
            'GetAllDataDictionary', 
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'CheckStatus', 
            'GetDownloadFile'
        ].forEach(x => {
            (<any>DocumentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
