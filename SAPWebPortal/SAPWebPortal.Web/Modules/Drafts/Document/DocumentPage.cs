using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Drafts.Pages
{

    [PageAuthorize(typeof(DocumentRow))]
    public class DocumentController : Controller
    {
        [Route("Drafts/Document")]
        public ActionResult Index()
        {
            return View("~/Modules/Drafts/Document/DocumentIndex.cshtml");
        }
    }
}