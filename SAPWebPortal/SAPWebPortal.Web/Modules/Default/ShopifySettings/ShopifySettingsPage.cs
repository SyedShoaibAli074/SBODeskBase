using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ShopifySettingsRow))]
    public class ShopifySettingsController : Controller
    {
        [Route("Default/ShopifySettings")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ShopifySettings/ShopifySettingsIndex.cshtml");
        }
    }
}