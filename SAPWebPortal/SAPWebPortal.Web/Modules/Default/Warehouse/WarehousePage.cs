using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(WarehouseRow))]
    public class WarehouseController : Controller
    {
        [Route("Default/Warehouse")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Warehouse/WarehouseIndex.cshtml");
        }
    }
}