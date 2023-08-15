using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.IncomingPayment.Pages
{

    [PageAuthorize(typeof(PaymentCheckRow))]
    public class PaymentCheckController : Controller
    {
        [Route("IncomingPayment/PaymentCheck")]
        public ActionResult Index()
        {
            return View("~/Modules/IncomingPayment/PaymentCheck/PaymentCheckIndex.cshtml");
        }
    }
}