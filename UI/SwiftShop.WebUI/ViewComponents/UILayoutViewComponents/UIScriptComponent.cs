using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UIScriptComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
