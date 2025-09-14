using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.Context
{
    public class BannerSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
