using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(BusinessPartnerRow))]
    public class BusinessPartnerController : Controller
    {
        [Route("Default/BusinessPartner")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/BusinessPartner/BusinessPartnerIndex.cshtml");
        }
    }
}