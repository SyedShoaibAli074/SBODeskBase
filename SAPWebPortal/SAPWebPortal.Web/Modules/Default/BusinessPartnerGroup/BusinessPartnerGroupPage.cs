using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(BusinessPartnerGroupRow))]
    public class BusinessPartnerGroupController : Controller
    {
        [Route("Default/BusinessPartnerGroup")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/BusinessPartnerGroup/BusinessPartnerGroupIndex.cshtml");
        }
    }
}