using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.InventoryTransferRequest.Pages
{

    [PageAuthorize(typeof(StockTransferRow))]
    public class StockTransferController : Controller
    {
        [Route("InventoryTransferRequest/StockTransfer")]
        public ActionResult Index()
        {
            return View("~/Modules/InventoryTransferRequest/StockTransfer/StockTransferIndex.cshtml");
        }
    }
}