using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.VatGroups.Pages
{

    [PageAuthorize(typeof(VatGroupRow))]
    public class VatGroupController : Controller
    {
        [Route("VatGroups/VatGroup")]
        public ActionResult Index()
        {
            return View("~/Modules/VatGroups/VatGroup/VatGroupIndex.cshtml");
        }
    }
}