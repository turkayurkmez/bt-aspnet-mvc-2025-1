using EshopLite.API.Filters;
using EShopLite.Application;
using EShopLite.Application.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Attributes;
using System.ComponentModel;

namespace EshopLite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [EndpointDescription("Tüm ürünleri getirir")]
        [Performance]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Get(int id)
        {
            var product = await productService.GetProductById(id);          
            return Ok(product);
        }

        [HttpGet("[action]/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await productService.GetProductsByCategory(categoryId);
            return Ok(products);
        }

        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string name)
        {
            var products = await productService.Search(name);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles ="admin,editor")]
        public async Task<IActionResult> Create(CreateNewProductRequest createNewProduct)
        {
            if (ModelState.IsValid)
            {
                var lastProductId = await productService.CreateNewProduct(createNewProduct);
                return CreatedAtAction(nameof(Get), new { id = lastProductId }, value: null);
            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Update(int id, UpdateProductRequest updateProduct)
        {


            if (ModelState.IsValid)
            {
                await productService.UpdateProduct(updateProduct);
                return NoContent();
            }
            return BadRequest(ModelState);



        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {


            await productService.DeleteProduct(id);
            return NoContent();

        }
    }
}
