using EShopLite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application
{
    public class ProductService
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new()
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description 1",
                    Price = 100,
                    ImageUrl = "https://via.placeholder.com/150",
                    Rating = 4.5,
                    Stock = 10,
                    CreatedDate = DateTime.Now

                },
                new()
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description 2",
                    Price = 200,
                    ImageUrl = "https://via.placeholder.com/150",
                    Rating = 4.0,
                    Stock = 20,
                    CreatedDate = DateTime.Now

                },
                new()
                {
                    Id = 3,
                    Name = "Product 3",
                    Description = "Description 3",
                    Price = 300,
                    ImageUrl = "https://via.placeholder.com/150",
                    Rating = 3.5,
                    Stock = 30,
                    CreatedDate = DateTime.Now
                }





            };

            return products;
        }
    }
}
