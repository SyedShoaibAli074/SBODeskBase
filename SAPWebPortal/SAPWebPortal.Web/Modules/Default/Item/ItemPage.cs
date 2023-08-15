using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ItemRow))]
    public class ItemController : Controller
    {
        [Route("Default/Item")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Item/ItemIndex.cshtml");
        }
    }
}