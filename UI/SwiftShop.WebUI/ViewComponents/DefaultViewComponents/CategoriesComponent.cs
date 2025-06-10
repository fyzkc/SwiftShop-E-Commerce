using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class CategoriesComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
