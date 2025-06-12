using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
