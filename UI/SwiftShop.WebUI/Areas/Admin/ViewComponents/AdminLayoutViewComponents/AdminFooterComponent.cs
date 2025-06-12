using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class AdminFooterComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
