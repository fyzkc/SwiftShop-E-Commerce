using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.UILayoutViewComponents
{
    //[ViewComponent(Name = "UIHeader")]
    public class UIHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
