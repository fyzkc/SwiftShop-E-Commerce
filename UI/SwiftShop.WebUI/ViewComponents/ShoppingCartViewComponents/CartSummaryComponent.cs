using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class CartSummaryComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
