using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
