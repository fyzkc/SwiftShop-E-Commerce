using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class AdminScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
