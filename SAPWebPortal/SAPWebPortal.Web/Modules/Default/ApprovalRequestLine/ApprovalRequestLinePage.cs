using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ApprovalRequestLineRow))]
    public class ApprovalRequestLineController : Controller
    {
        [Route("Default/ApprovalRequestLine")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ApprovalRequestLine/ApprovalRequestLineIndex.cshtml");
        }
    }
}