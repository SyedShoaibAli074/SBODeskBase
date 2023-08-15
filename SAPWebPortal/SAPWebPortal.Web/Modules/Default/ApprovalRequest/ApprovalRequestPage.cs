using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ApprovalRequestRow))]
    public class ApprovalRequestController : Controller
    {
        [Route("Default/ApprovalRequest")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ApprovalRequest/ApprovalRequestIndex.cshtml");
        }
    }
}