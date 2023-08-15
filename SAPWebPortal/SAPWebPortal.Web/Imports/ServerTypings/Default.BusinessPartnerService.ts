namespace SAPWebPortal.Default {
    export namespace BusinessPartnerService {
        export const baseUrl = 'Default/BusinessPartner';

        export declare function Create(request: Serenity.SaveRequest<BusinessPartnerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetCardCodeCardNameForAuth(request: any, onSuccess?: (response: System.ValueTuple<string, string>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<BusinessPartnerRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BusinessPartnerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function RetrieveSeries(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BusinessPartnerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BusinessPartnerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetAll(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<BusinessPartnerRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetAllDataDictionary(request: Serenity.ServiceRequest, onSuccess?: (response: System.ValueTuple<string, string, string, number>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/BusinessPartner/Create",
            GetCardCodeCardNameForAuth = "Default/BusinessPartner/GetCardCodeCardNameForAuth",
            Update = "Default/BusinessPartner/Update",
            Delete = "Default/BusinessPartner/Delete",
            Retrieve = "Default/BusinessPartner/Retrieve",
            RetrieveSeries = "Default/BusinessPartner/RetrieveSeries",
            List = "Default/BusinessPartner/List",
            GetAll = "Default/BusinessPartner/GetAll",
            GetAllDataDictionary = "Default/BusinessPartner/GetAllDataDictionary"
        }

        [
            'Create', 
            'GetCardCodeCardNameForAuth', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'RetrieveSeries', 
            'List', 
            'GetAll', 
            'GetAllDataDictionary'
        ].forEach(x => {
            (<any>BusinessPartnerService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
