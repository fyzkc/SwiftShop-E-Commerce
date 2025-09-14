using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.UI.ViewComponents.Context
{
    public class InstagramSectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
