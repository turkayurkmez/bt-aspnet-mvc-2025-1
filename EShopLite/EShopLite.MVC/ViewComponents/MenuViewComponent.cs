using EShopLite.Application;
using Microsoft.AspNetCore.Mvc;

namespace EShopLite.MVC.ViewComponents
{
    public class MenuViewComponent(ICategoryService categoryService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories().Result;

            return View(categories);
        }
    }
}
