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

      

      
        public IActionResult Index()
        {
            //ProductService productService = new ProductService();
            var products = _productService.GetProducts();
            return View(products);
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
