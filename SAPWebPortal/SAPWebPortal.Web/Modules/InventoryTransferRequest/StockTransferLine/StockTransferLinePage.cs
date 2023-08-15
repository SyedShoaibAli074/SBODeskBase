using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.InventoryTransferRequest.Pages
{

    [PageAuthorize(typeof(StockTransferLineRow))]
    public class StockTransferLineController : Controller
    {
        [Route("InventoryTransferRequest/StockTransferLine")]
        public ActionResult Index()
        {
            return View("~/Modules/InventoryTransferRequest/StockTransferLine/StockTransferLineIndex.cshtml");
        }
    }
}