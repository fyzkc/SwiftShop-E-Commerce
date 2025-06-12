using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Controllers
{
    public class ProductsListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetails() 
        {
            return View();
        }
    }
}
