using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Orders.Pages
{

    [PageAuthorize(typeof(AddressExtensionRow))]
    public class AddressExtensionController : Controller
    {
        [Route("Default/AddressExtension")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/AddressExtension/AddressExtensionIndex.cshtml");
        }
    }
}