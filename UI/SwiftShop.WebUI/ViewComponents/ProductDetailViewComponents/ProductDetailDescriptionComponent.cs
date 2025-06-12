using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailDescriptionComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
