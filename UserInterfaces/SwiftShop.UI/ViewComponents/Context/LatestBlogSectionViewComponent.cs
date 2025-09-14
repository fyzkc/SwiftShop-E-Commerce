using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.Context
{
    public class LatestBlogSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
