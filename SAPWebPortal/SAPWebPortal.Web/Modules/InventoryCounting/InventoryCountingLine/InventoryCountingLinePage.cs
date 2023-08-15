using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.InventoryCounting.Pages
{

    [PageAuthorize(typeof(InventoryCountingLineRow))]
    public class InventoryCountingLineController : Controller
    {
        [Route("InventoryCounting/InventoryCountingLine")]
        public ActionResult Index()
        {
            return View("~/Modules/InventoryCounting/InventoryCountingLine/InventoryCountingLineIndex.cshtml");
        }
    }
}