using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UINavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
