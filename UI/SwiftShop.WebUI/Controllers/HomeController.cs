using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
