using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.IncomingPayment.Pages
{

    [PageAuthorize(typeof(PaymentRow))]
    public class PaymentController : Controller
    {
        [Route("IncomingPayment/Payment")]
        public ActionResult Index()
        {
            return View("~/Modules/IncomingPayment/Payment/PaymentIndex.cshtml");
        }
    }
}