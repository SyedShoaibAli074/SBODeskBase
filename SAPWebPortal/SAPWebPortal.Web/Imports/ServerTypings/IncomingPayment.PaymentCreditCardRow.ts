namespace SAPWebPortal.IncomingPayment {
    export interface PaymentCreditCardRow {
        LineNum?: number;
        CreditCard?: number;
        CreditAcct?: string;
        CreditCardNumber?: string;
        CardValidUntil?: string;
        VoucherNum?: string;
        OwnerIdNum?: string;
        OwnerPhone?: string;
        PaymentMethodCode?: number;
        NumOfPayments?: number;
        FirstPaymentDue?: string;
        FirstPaymentSum?: number;
        AdditionalPaymentSum?: number;
        CreditSum?: number;
        CreditCur?: string;
        CreditRate?: number;
        ConfirmationNum?: string;
        NumOfCreditPayments?: number;
        CreditType?: string;
        SplitPayments?: string;
    }

    export namespace PaymentCreditCardRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'IncomingPayment.PaymentCreditCard';
        export const deletePermission = 'IncomingPayment';
        export const insertPermission = 'IncomingPayment';
        export const readPermission = 'IncomingPayment';
        export const updatePermission = 'IncomingPayment';

        export declare const enum Fields {
            LineNum = "LineNum",
            CreditCard = "CreditCard",
            CreditAcct = "CreditAcct",
            CreditCardNumber = "CreditCardNumber",
            CardValidUntil = "CardValidUntil",
            VoucherNum = "VoucherNum",
            OwnerIdNum = "OwnerIdNum",
            OwnerPhone = "OwnerPhone",
            PaymentMethodCode = "PaymentMethodCode",
            NumOfPayments = "NumOfPayments",
            FirstPaymentDue = "FirstPaymentDue",
            FirstPaymentSum = "FirstPaymentSum",
            AdditionalPaymentSum = "AdditionalPaymentSum",
            CreditSum = "CreditSum",
            CreditCur = "CreditCur",
            CreditRate = "CreditRate",
            ConfirmationNum = "ConfirmationNum",
            NumOfCreditPayments = "NumOfCreditPayments",
            CreditType = "CreditType",
            SplitPayments = "SplitPayments"
        }
    }
}
