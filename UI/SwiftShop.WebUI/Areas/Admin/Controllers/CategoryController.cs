using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
