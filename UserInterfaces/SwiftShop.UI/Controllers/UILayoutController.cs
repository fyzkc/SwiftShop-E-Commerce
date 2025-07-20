using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
