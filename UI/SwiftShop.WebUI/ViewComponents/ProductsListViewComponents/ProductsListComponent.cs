using Microsoft.AspNetCore.Mvc;
using SwiftShop.WebUI.Areas.Admin.Models;

namespace SwiftShop.WebUI.ViewComponents.ProductsListViewComponents
{
    public class ProductsListComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<ProductWithCategoryViewModel> products)
        {
            return View(products);
        }
    }
}
