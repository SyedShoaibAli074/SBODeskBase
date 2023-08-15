using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.InventoryCounting.Pages
{

    [PageAuthorize(typeof(InventoryCountingRow))]
    public class InventoryCountingController : Controller
    {
        [Route("InventoryCounting/InventoryCounting")]
        public ActionResult Index()
        {
            return View("~/Modules/InventoryCounting/InventoryCounting/InventoryCountingIndex.cshtml");
        }
    }
}