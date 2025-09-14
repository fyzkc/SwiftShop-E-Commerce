using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.Context
{
    public class HeroSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
