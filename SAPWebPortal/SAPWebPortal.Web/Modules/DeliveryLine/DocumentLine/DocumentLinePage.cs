using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.DeliveryLine.Pages
{

    [PageAuthorize(typeof(DocumentLineRow))]
    public class DocumentLineController : Controller
    {
        [Route("DeliveryLine/DocumentLine")]
        public ActionResult Index()
        {
            return View("~/Modules/DeliveryLine/DocumentLine/DocumentLineIndex.cshtml");
        }
    }
}