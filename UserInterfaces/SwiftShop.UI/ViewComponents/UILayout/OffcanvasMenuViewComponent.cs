using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.UILayout
{
    public class OffcanvasMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
