namespace SAPWebPortal.Drafts {
    export namespace DocumentService {
        export const baseUrl = 'Drafts/Document';

        export declare function GetAllDataDictionary(request: Serenity.ServiceRequest, onSuccess?: (response: System.ValueTuple<string, string, string, number>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Create(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Create_GRN(request: Serenity.SaveRequest<DocumentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            GetAllDataDictionary = "Drafts/Document/GetAllDataDictionary",
            Create = "Drafts/Document/Create",
            Update = "Drafts/Document/Update",
            Delete = "Drafts/Document/Delete",
            Retrieve = "Drafts/Document/Retrieve",
            List = "Drafts/Document/List",
            Create_GRN = "Drafts/Document/Create_GRN"
        }

        [
            'GetAllDataDictionary', 
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'Create_GRN'
        ].forEach(x => {
            (<any>DocumentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
