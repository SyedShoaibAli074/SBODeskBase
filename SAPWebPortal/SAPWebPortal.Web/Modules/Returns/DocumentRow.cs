using System;
using System.Collections.Generic;

namespace SAPWebPortal.Web.Modules.Returns
{
    [ServiceLayer("Returns")]
    public class DocumentRow
    {
        

        public int? DocEntry { get; set; }
        public int? Series { get; set; }
        public int? DocNum { get; set; }

        public string U_ReturnReason { get; set; }
        public string U_ApprovalGUID { get; set; }
        public string U_FullfilmentId { get; set; }
        public string DocType { get; set; }

        public DateTime? DocDate { get; set; }
        public DateTime? DocDueDate { get; set; }

        public string CardCode { get; set; }
        public string CardName { get; set; }

        public decimal? DocTotal { get; set; }

        public int? DocumentsOwner { get; set; }

        public string DocumentStatus { get; set; }

        public string AttachmentEntry { get; set; }

        public int? SalesPersonCode { get; set; }

        public decimal? TotalDiscount { get; set; }

        public decimal? DiscountPercent { get; set; }

        public string Comments { get; set; }

        public int? UserSign { get; set; }

        public decimal? VatSum { get; set; }

        public string DocCurrency { get; set; }

        public List<DocumentLineRow> DocumentLines { get; set; }

        public int? GroupNumber { get; set; }

        public string Project { get; set; }

        public string PayToCode { get; set; }

        public string ShipToCode { get; set; }

        public string NumAtCard { get; set; }

        public string U_CanceledAt { get; set; }
        public string U_PaymentMethod { get; set; }
        public string U_OrderNumber { get; set; }
        public string U_ShopifyOrderId { get; set; }
        public string U_RefundId { get; set; }
        public string DocObjectCode { get; set; }
    }
}
