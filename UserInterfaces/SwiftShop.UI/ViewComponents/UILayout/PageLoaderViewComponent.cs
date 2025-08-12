using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.UILayout
{
    public class PageLoaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
