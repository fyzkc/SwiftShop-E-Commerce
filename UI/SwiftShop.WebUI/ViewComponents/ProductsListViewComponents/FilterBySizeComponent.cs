using Microsoft.AspNetCore.Mvc;

namespace SwiftShop.WebUI.ViewComponents.ProductsListViewComponents
{
    public class FilterBySizeComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
