using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class CartCouponCodeComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
