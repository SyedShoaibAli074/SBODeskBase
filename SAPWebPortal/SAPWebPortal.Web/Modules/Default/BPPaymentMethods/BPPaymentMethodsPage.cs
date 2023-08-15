using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(BPPaymentMethodsRow))]
    public class BPPaymentMethodsController : Controller
    {
        [Route("Default/BPPaymentMethods")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/BPPaymentMethods/BPPaymentMethodsIndex.cshtml");
        }
    }
}