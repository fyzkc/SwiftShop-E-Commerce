using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class FeaturesComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
