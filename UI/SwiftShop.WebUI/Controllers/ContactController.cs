using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
