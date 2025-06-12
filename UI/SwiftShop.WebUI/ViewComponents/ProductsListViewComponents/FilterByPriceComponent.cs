using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ProductsListViewComponents
{
    public class FilterByPriceComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
