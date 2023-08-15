using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ShopifyWebkookSettingsRow))]
    public class ShopifyWebkookSettingsController : Controller
    {
        [Route("Default/ShopifyWebkookSettings")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ShopifyWebkookSettings/ShopifyWebkookSettingsIndex.cshtml");
        }
    }
}