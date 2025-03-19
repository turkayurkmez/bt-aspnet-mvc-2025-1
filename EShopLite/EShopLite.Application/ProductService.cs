using EShopLite.Application.DataTransferObjects;
using EShopLite.Domain;
using EShopLite.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<ProductItemForBasket> GetProductById(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return new ProductItemForBasket(product.Id, product.Name, product.Price, product.ImageUrl);
        }

        public async Task<IEnumerable<ProductListDisplay>> GetProducts(int? page=null, int? pageSize=null)
        {

            IEnumerable<Product> response;

            if (page != null && pageSize != null)
            {
                response = await productRepository.Paginated(page!.Value, pageSize!.Value);
              
            }
            else
            {
                response = await productRepository.GetAllAsync();
            }


            var dtoResponse = response.Select(x => new ProductListDisplay
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Rating = x.Rating
            });

            return dtoResponse;
        }

        public async Task<IEnumerable<ProductListDisplay>> GetProductsByCategory(int categoryId, int? page = null, int? pageSize = null)
        {
            var products = page!=null && pageSize!=null ? await productRepository.GetByCategoryWithPaging(categoryId,page.Value,pageSize.Value)
                : await productRepository.GetByCategoryAsync(categoryId);

            var dtoResponse = products.Select(x => new ProductListDisplay
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Rating = x.Rating
            });

            return dtoResponse;
        }

        public async Task<int> TotalProductsCount(int? categoryId)
        {
            return  await productRepository.Count(categoryId);
        }
    }
}
