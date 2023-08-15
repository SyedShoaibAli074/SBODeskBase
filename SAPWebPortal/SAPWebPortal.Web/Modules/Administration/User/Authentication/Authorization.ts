namespace SAPWebPortal.Authorization {
    export declare let userDefinition: ScriptUserDefinition;

    Object.defineProperty(Authorization, 'userDefinition', {
        get: function () {
            return Q.getRemoteData('UserData');
        }
    });

    export function hasPermission(permissionKey: string) {
        return Q.Authorization.hasPermission(permissionKey);
    }
     
    //export function getSapUserid(UserName: string) {
    //    var UserId = "";
       
    //    Q.serviceCall({
    //        url: Q.resolveUrl('~/Services/QuotationsLine/DocumentLine/getSapId'),
    //        request: UserName,
           
    //        async: false,
    //        onSuccess: response => {

    //            UserId = response.toString();

    //        }

    //    });
    //    return UserId;
    //}
}
