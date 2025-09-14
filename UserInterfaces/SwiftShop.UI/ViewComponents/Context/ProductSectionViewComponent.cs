using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.Context
{
    public class ProductSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
