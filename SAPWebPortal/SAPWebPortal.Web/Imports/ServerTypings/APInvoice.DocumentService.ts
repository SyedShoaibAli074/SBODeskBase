namespace SAPWebPortal.APInvoice {
    export namespace DocumentService {
        export const baseUrl = 'APInvoice/Document';

        export declare function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckStatus(request: DocumentRow, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetDownloadFile(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "APInvoice/Document/Create",
            Update = "APInvoice/Document/Update",
            Delete = "APInvoice/Document/Delete",
            CheckStatus = "APInvoice/Document/CheckStatus",
            Retrieve = "APInvoice/Document/Retrieve",
            List = "APInvoice/Document/List",
            GetDownloadFile = "APInvoice/Document/GetDownloadFile"
        }

        [
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
