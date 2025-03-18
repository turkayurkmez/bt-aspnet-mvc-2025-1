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
        
        public IEnumerable<ProductListDisplay> GetProducts()
        {

            var response = productRepository.GetAllAsync().Result;           

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
    }
}
