using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class AdminHeadComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
