using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(BPAddressesRow))]
    public class BPAddressesController : Controller
    {
        [Route("Default/BPAddresses")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/BPAddresses/BPAddressesIndex.cshtml");
        }
    }
}