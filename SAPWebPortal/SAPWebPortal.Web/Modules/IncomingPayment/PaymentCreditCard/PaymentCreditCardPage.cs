using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.IncomingPayment.Pages
{

    [PageAuthorize(typeof(PaymentCreditCardRow))]
    public class PaymentCreditCardController : Controller
    {
        [Route("IncomingPayment/PaymentCreditCard")]
        public ActionResult Index()
        {
            return View("~/Modules/IncomingPayment/PaymentCreditCard/PaymentCreditCardIndex.cshtml");
        }
    }
}