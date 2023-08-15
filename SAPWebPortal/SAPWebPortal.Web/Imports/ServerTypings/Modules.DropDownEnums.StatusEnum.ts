namespace SAPWebPortal.Modules.DropDownEnums {
    export enum StatusEnum {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }
    Serenity.Decorators.registerEnumType(StatusEnum, 'SAPWebPortal.Modules.DropDownEnums.StatusEnum');
}
