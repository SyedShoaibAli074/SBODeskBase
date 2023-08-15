namespace SAPWebPortal.Drafts {
    export namespace DataDictionaryViewService {
        export const baseUrl = 'DevTools/DataDictionaryView';

        export declare function GetSessions(request: Serenity.ServiceRequest, onSuccess?: (response: Newtonsoft.Json.Linq.JArray) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetDataDictionaries(request: Serenity.ServiceRequest, onSuccess?: (response: any[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            GetSessions = "DevTools/DataDictionaryView/GetSessions",
            GetDataDictionaries = "DevTools/DataDictionaryView/GetDataDictionaries"
        }

        [
            'GetSessions', 
            'GetDataDictionaries'
        ].forEach(x => {
            (<any>DataDictionaryViewService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
