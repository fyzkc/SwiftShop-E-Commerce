using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class BrandsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
