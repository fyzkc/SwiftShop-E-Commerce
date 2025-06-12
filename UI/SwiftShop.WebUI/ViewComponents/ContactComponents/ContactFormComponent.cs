using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ContactComponents
{
    public class ContactFormComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
