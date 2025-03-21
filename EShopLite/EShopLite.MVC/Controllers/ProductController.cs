using EShopLite.Application;
using EShopLite.Application.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EShopLite.MVC.Controllers
{
    [Authorize(Roles = "admin,editor")]
    public class ProductController(IProductService productService, ICategoryService categoryService) : Controller
    {

        
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();

            return View(products);
        }

     
        public async Task<IActionResult> Create()
        {

            ViewBag.Categories = await GetCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProductRequest model)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateNewProduct(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await GetCategories();
            return View(model);
        }

        private async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            var categories = await categoryService.GetCategories();
            return categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductForUpdate(id);
          
            ViewBag.Categories = await GetCategories();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductRequest model)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProduct(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await GetCategories();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) { 
            //id'ye göre ürünü çek:
            
            var product = await productService.GetProductById(id);    
            return View(product);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //serviste olduğunu varsayın.
            return View();
        }
    }
}
