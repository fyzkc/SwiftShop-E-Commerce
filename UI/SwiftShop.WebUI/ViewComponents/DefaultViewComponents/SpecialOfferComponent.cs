using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class SpecialOfferComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
