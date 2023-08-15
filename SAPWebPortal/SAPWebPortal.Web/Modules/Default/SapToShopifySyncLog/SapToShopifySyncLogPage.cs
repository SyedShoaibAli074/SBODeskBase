using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(SapToShopifySyncLogRow))]
    public class SapToShopifySyncLogController : Controller
    {
        [Route("Default/SapToShopifySyncLog")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/SapToShopifySyncLog/SapToShopifySyncLogIndex.cshtml");
        }
    }
}