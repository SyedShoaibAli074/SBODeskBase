namespace SAPWebPortal.Membership {
    export interface LoginRequest extends Serenity.ServiceRequest {
        Username?: string;
        Password?: string;
        CompanyDatabase?: string;
        CompanyDatabaseName?: string;
    }
}
