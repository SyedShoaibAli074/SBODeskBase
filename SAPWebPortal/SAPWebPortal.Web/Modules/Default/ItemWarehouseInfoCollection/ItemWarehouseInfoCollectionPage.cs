using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ItemWarehouseInfoCollectionRow))]
    public class ItemWarehouseInfoCollectionController : Controller
    {
        [Route("Default/ItemWarehouseInfoCollection")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ItemWarehouseInfoCollection/ItemWarehouseInfoCollectionIndex.cshtml");
        }
    }
}