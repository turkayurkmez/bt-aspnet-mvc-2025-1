using System.Diagnostics;
using EShopLite.Application;
using EShopLite.Domain;
using EShopLite.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopLite.MVC.Controllers
{
    public class HomeController : Controller
    {
        //ProductService productService;

        //1. Sadece Index() bu nesneye ihtiyaç duyuyorsa, bu metod parametre alabilir.
        //2. Eğer controller'ın ProductService bağımlılığı runtime'da değişecekse, property injection kullanılabilir.
        //3. Eğer controller'ın ProductService bağımlılığı değişmeyecekse, constructor injection kullanılabilir.

        //public ProductService productService { get; set; }
        private readonly IProductService _productService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductService productService )
        {
            _logger = logger;
            _productService = productService;
        }

      

      
        public async Task<IActionResult> Index(int page=1, int? categoryId=null)
        {
            //ProductService productService = new ProductService();

            //veritabanından ürünleri çekerken sayfalama yapmayı unutma!!!
            var itemPerPage = 8;
            var products = categoryId.HasValue ? await _productService.GetProductsByCategory(categoryId.Value, page, itemPerPage)
                                               : await _productService.GetProducts(page, itemPerPage);
            var totalProducts = await _productService.TotalProductsCount(categoryId);
         
            var totalPages = Math.Ceiling((double)totalProducts / itemPerPage);
          

            var viewModel = new HomeIndexViewModel
            {
                Products = products,
                CurrentPage = page,
                TotalPages = (int)totalPages,
                CategoryId = categoryId
            };

            //ViewBag.CurrentPage = page;
            //ViewBag.TotalPages = totalPages;

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
