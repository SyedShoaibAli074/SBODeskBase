namespace SAPWebPortal.IncomingPayment {
    export namespace PaymentService {
        export const baseUrl = 'IncomingPayment/Payment';

        export declare function Create(request: Serenity.SaveRequest<PaymentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function PostPayment(request: HelperWebSL.Models.IncomingPaymentPosting, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<PaymentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PaymentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PaymentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetAll(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<PaymentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetBanks(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<System.ValueTuple<string, string>>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetAllDataDictionary(request: Serenity.ServiceRequest, onSuccess?: (response: System.ValueTuple<string, string, string, number>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "IncomingPayment/Payment/Create",
            PostPayment = "IncomingPayment/Payment/PostPayment",
            Update = "IncomingPayment/Payment/Update",
            Delete = "IncomingPayment/Payment/Delete",
            Retrieve = "IncomingPayment/Payment/Retrieve",
            List = "IncomingPayment/Payment/List",
            GetAll = "IncomingPayment/Payment/GetAll",
            GetBanks = "IncomingPayment/Payment/GetBanks",
            GetAllDataDictionary = "IncomingPayment/Payment/GetAllDataDictionary"
        }

        [
            'Create', 
            'PostPayment', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetAll', 
            'GetBanks', 
            'GetAllDataDictionary'
        ].forEach(x => {
            (<any>PaymentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
