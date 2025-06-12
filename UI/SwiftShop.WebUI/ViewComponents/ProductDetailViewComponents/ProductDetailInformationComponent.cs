using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailInformationComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
