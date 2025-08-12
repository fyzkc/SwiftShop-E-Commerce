using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.UILayout
{
    public class FooterSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
