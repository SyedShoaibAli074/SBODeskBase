using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ContactEmployeesRow))]
    public class ContactEmployeesController : Controller
    {
        [Route("Default/ContactEmployees")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ContactEmployees/ContactEmployeesIndex.cshtml");
        }
    }
}