namespace SAPWebPortal.Modules.QueryCaller {
    export namespace QueryService {
        export const baseUrl = 'Queries/List';

        export declare function OWHS(request: Request, onSuccess?: (response: OWHS[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function OITW(request: Request, onSuccess?: (response: OITW[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetDefaultWhsCode(request: Request, onSuccess?: (response: string) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GET_STOCK_STATUS(request: Request, onSuccess?: (response: STOCK_STATUS[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Get_Table_OSCN(request: Request, onSuccess?: (response: OSCN[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Getitems(request: Request, onSuccess?: (response: Default.ItemRow[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetObjects(request: Request, onSuccess?: (response: Newtonsoft.Json.Linq.JArray) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function PostObject(request: Request, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            OWHS = "Queries/List/OWHS",
            OITW = "Queries/List/OITW",
            GetDefaultWhsCode = "Queries/List/GetDefaultWhsCode",
            GET_STOCK_STATUS = "Queries/List/GET_STOCK_STATUS",
            Get_Table_OSCN = "Queries/List/Get_Table_OSCN",
            Getitems = "Queries/List/Getitems",
            GetObjects = "Queries/List/GetObjects",
            PostObject = "Queries/List/PostObject"
        }

        [
            'OWHS', 
            'OITW', 
            'GetDefaultWhsCode', 
            'GET_STOCK_STATUS', 
            'Get_Table_OSCN', 
            'Getitems', 
            'GetObjects', 
            'PostObject'
        ].forEach(x => {
            (<any>QueryService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
