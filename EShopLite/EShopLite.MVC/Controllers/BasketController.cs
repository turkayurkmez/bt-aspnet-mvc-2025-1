using EShopLite.Application;
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
              var serialized = HttpContext.Session.GetString("basket");
            if (serialized == null)
            {
                return new ShoppingCardCollection();
            }
            return JsonConvert.DeserializeObject<ShoppingCardCollection>(serialized);
        }

        private void saveToSession(ShoppingCardCollection shoppingCardCollection)
        {
            //önce json 'a çevir
            var serialized = JsonConvert.SerializeObject(shoppingCardCollection);
            //session'a kaydet
            HttpContext.Session.SetString("basket", serialized);

        }

        public IActionResult Index()
        {
            var shoppingCardCollection = getCollectionFromSession();
            return View(shoppingCardCollection);
        }
    }
}
