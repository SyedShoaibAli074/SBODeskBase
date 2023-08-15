using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ShopifySettingsDetailRow))]
    public class ShopifySettingsDetailController : Controller
    {
        [Route("Default/ShopifySettingsDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ShopifySettingsDetail/ShopifySettingsDetailIndex.cshtml");
        }
    }
}