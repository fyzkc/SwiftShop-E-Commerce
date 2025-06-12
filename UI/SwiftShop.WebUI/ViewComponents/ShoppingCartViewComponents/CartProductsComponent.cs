using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class CartProductsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
