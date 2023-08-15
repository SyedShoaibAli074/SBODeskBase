using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.IncomingPayment.Pages
{

    [PageAuthorize(typeof(PaymentAccountRow))]
    public class PaymentAccountController : Controller
    {
        [Route("IncomingPayment/PaymentAccount")]
        public ActionResult Index()
        {
            return View("~/Modules/IncomingPayment/PaymentAccount/PaymentAccountIndex.cshtml");
        }
    }
}