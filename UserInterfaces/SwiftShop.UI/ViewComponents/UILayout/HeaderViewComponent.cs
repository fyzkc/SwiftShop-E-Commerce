using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.UILayout
{
    [ViewComponent(Name = "HeaderViewComponent")]
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
