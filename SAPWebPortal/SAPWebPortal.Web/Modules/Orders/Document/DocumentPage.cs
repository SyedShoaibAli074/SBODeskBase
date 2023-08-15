using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Orders.Pages
{

    [PageAuthorize(typeof(DocumentRow))]
    public class DocumentController : Controller
    {
        [Route("Orders/Document")]
        public ActionResult Index()
        {
            return View("~/Modules/Orders/Document/DocumentIndex.cshtml");
        }
    }
}