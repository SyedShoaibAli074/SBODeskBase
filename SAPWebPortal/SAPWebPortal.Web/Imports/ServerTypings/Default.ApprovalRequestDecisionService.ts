namespace SAPWebPortal.Default {
    export namespace ApprovalRequestDecisionService {
        export const baseUrl = 'Default/ApprovalRequestDecision';

        export declare function Create(request: Serenity.SaveRequest<ApprovalRequestDecisionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<ApprovalRequestDecisionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ApprovalRequestDecisionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ApprovalRequestDecisionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/ApprovalRequestDecision/Create",
            Update = "Default/ApprovalRequestDecision/Update",
            Delete = "Default/ApprovalRequestDecision/Delete",
            Retrieve = "Default/ApprovalRequestDecision/Retrieve",
            List = "Default/ApprovalRequestDecision/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>ApprovalRequestDecisionService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
