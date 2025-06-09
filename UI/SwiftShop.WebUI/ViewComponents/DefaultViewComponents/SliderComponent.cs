using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class SliderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
