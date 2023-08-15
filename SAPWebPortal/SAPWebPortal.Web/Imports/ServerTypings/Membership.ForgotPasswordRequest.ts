namespace SAPWebPortal.Membership {
    export interface ForgotPasswordRequest extends Serenity.ServiceRequest {
        Email?: string;
    }
}
