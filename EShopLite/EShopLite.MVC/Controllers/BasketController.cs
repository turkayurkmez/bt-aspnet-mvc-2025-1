using EShopLite.Application;
using EShopLite.MVC.Extensions;
using EShopLite.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopLite.MVC.Controllers
{
    public class BasketController(IProductService productService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AddToBasket(int productId)
        {
            //1. db'den ürünü çek
            var productForBasket = await productService.GetProductById(productId);

            //2. Sepete eklenecek ürün nesnesine çevir.
            //3. Sepet koleksiyonuna ekle
            ShoppingCardCollection shoppingCardCollection = getCollectionFromSession();
            shoppingCardCollection.Add(new ShoppingCardItem { ProductItem = productForBasket, Quantity = 1 });
            saveToSession(shoppingCardCollection);
            return Json($"{productForBasket.ProductName} ürünü başarıyla sepete eklendi");
        }

     

        private ShoppingCardCollection getCollectionFromSession()
        {
            //lazy initialization
            return HttpContext.Session.GetJson<ShoppingCardCollection>("basket") ?? new ShoppingCardCollection();
        }

        private void saveToSession(ShoppingCardCollection shoppingCardCollection)
        {
           HttpContext.Session.SetJson("basket", shoppingCardCollection);

        }

        public IActionResult Index()
        {
            var shoppingCardCollection = getCollectionFromSession();
            return View(shoppingCardCollection);
        }
    }
}
