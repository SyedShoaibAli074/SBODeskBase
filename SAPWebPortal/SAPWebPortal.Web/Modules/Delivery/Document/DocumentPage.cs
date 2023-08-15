using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Delivery.Pages
{

    [PageAuthorize(typeof(DocumentRow))]
    public class DocumentController : Controller
    {
        [Route("Delivery/Document")]
        public ActionResult Index()
        {
            return View("~/Modules/Delivery/Document/DocumentIndex.cshtml");
        }
    }
}