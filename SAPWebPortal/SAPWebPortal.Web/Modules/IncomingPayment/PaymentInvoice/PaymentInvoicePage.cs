using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.IncomingPayment.Pages
{

    [PageAuthorize(typeof(PaymentInvoiceRow))]
    public class PaymentInvoiceController : Controller
    {
        [Route("IncomingPayment/PaymentInvoice")]
        public ActionResult Index()
        {
            return View("~/Modules/IncomingPayment/PaymentInvoice/PaymentInvoiceIndex.cshtml");
        }
    }
}