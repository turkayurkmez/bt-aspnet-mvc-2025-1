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

      

      
        public IActionResult Index(int page=1)
        {
            //ProductService productService = new ProductService();

            //veritabanından ürünleri çekerken sayfalama yapmayı unutma!!!
            var products = _productService.GetProducts();
            var totalProducts = products.Count();
            var itemPerPage = 8;
            var totalPages = Math.Ceiling((double)totalProducts / itemPerPage);
            var startIndex = (page - 1) * itemPerPage;
            var endIndex = startIndex + itemPerPage;
            var paginatedProducts = products.OrderBy(x=>x.Id).Take(startIndex..endIndex);

            var viewModel = new HomeIndexViewModel
            {
                Products = paginatedProducts,
                CurrentPage = page,
                TotalPages = (int)totalPages
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
