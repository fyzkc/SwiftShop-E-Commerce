using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.UILayoutViewComponents
{
    //[ViewComponent(Name = "UITopbar")]
    public class UITopbarComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
