using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailReviewsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
