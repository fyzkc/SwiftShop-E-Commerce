using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UIFooterComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
