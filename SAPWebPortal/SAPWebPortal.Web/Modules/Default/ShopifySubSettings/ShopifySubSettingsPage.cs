using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ShopifySubSettingsRow))]
    public class ShopifySubSettingsController : Controller
    {
        [Route("Default/ShopifySubSettings")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ShopifySubSettings/ShopifySubSettingsIndex.cshtml");
        }
    }
}