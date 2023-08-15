using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ShopifyLocationDetailRow))]
    public class ShopifyLocationDetailController : Controller
    {
        [Route("Default/ShopifyLocationDetail")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ShopifyLocationDetail/ShopifyLocationDetailIndex.cshtml");
        }
    }
}