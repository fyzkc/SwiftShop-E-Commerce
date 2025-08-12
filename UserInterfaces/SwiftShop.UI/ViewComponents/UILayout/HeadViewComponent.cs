using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.UILayout
{
    public class HeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
