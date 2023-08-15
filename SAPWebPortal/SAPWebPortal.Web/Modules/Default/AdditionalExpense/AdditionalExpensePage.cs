using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(AdditionalExpenseRow))]
    public class AdditionalExpenseController : Controller
    {
        [Route("Default/AdditionalExpense")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/AdditionalExpense/AdditionalExpenseIndex.cshtml");
        }
    }
}