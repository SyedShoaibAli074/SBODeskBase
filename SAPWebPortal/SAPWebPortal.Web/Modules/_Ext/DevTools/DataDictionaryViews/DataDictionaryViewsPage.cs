
namespace _Ext.DevTools.Pages
{
    using Serenity;
    using Serenity.Web;
    using Microsoft.AspNetCore.Mvc;

    [PageAuthorize("DevTools:DataDictionaryViews")]
    public class DataDictionaryViewsController : Controller
    {
        [Route("DataDictionaryViews")]
        public ActionResult Index()
        {
            return View("~/Modules/_Ext/DevTools/DataDictionaryViews/DataDictionaryViewsIndex.cshtml");
        }
        
    }
}