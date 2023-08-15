using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ApprovalRequestDecisionRow))]
    public class ApprovalRequestDecisionController : Controller
    {
        [Route("Default/ApprovalRequestDecision")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ApprovalRequestDecision/ApprovalRequestDecisionIndex.cshtml");
        }
    }
}