using EShopLite.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EshopLite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }
    }
}
