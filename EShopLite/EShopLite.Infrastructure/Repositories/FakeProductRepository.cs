using EShopLite.Domain;
using EShopLite.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Infrastructure.Repositories
{
    //public class FakeProductRepository : IProductRepository
    //{
    //    private List<Product> _fakeCollection;
    //    public FakeProductRepository()
    //    {
    //        _fakeCollection = new List<Product>()
    //        {
    //            new()
    //            {
    //                Id = 1,
    //                Name = "Product 1",
    //                Description = "Description 1",
    //                Price = 100,
    //                Rating = 4.5,
    //                Stock = 10,
    //                CreatedDate = DateTime.Now,
    //                CategoryId = 1

    //            },
    //            new()
    //            {
    //                Id = 2,
    //                Name = "Product 2",
    //                Description = "Description 2",
    //                Price = 200,

    //                Rating = 4.0,
    //                Stock = 20,
    //                CreatedDate = DateTime.Now,
    //                CategoryId = 1

    //            },
    //            new()
    //            {
    //                Id = 3,
    //                Name = "Product 3",
    //                Description = "Description 3",
    //                Price = 300,

    //                Rating = 3.5,
    //                Stock = 30,
    //                CreatedDate = DateTime.Now,
    //                CategoryId = 2

    //            },
    //             new()
    //            {
    //                Id = 4,
    //                Name = "Product 1",
    //                Description = "Description 1",
    //                Price = 100,
    //                Rating = 4.5,
    //                Stock = 10,
    //                CreatedDate = DateTime.Now,
    //                CategoryId = 3

    //            },
    //            new()
    //            {
    //                Id = 5,
    //                Name = "Product 2",
    //                Description = "Description 2",
    //                Price = 200,

    //                Rating = 4.0,
    //                Stock = 20,
    //                CreatedDate = DateTime.Now,
    //                CategoryId = 1

    //            },
    //            new()
    //            {
    //                Id = 6,
    //                Name = "Product 3",
    //                Description = "Description 3",
    //                Price = 300,

    //                Rating = 3.5,
    //                Stock = 30,
    //                CreatedDate = DateTime.Now,
    //                CategoryId = 2
    //            },
    //                new()
    //                {
    //                    Id = 7,
    //                    Name = "Product 1",
    //                    Description = "Description 1",
    //                    Price = 100,
    //                    Rating = 4.5,
    //                    Stock = 10,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 3

    //                },
    //                new()
    //                {
    //                    Id = 8,
    //                    Name = "Product 2",
    //                    Description = "Description 2",
    //                    Price = 200,
    //                    Rating = 4.0,
    //                    Stock = 20,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 1
    //                },

    //                new()
    //                {
    //                    Id = 9,
    //                    Name = "Product 3",
    //                    Description = "Description 3",
    //                    Price = 300,
    //                    Rating = 3.5,
    //                    Stock = 30,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 2

    //                },

    //                new()
    //                {
    //                    Id = 10,
    //                    Name = "Product 1",
    //                    Description = "Description 1",
    //                    Price = 100,
    //                    Rating = 4.5,
    //                    Stock = 10,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 3
    //                },

    //                new()
    //                {
    //                    Id = 11,
    //                    Name = "Product 2",
    //                    Description = "Description 2",
    //                    Price = 200,
    //                    Rating = 4.0,
    //                    Stock = 20,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 2

    //                },

    //                new()
    //                {
    //                    Id = 12,
    //                    Name = "Product 3",
    //                    Description = "Description 3",
    //                    Price = 300,
    //                    Rating = 3.5,
    //                    Stock = 30,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 1

    //                },

    //                new()
    //                {
    //                    Id = 13,
    //                    Name = "Product 1",
    //                    Description = "Description 1",
    //                    Price = 100,
    //                    Rating = 4.5,
    //                    Stock = 10,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 3

    //                },


    //                new()
    //                {
    //                    Id = 14,
    //                    Name = "Product 2",
    //                    Description = "Description 2",
    //                    Price = 200,
    //                    Rating = 4.0,
    //                    Stock = 20,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 2

    //                },


    //                new()
    //                {
    //                    Id = 15,
    //                    Name = "Product 3",
    //                    Description = "Description 3",
    //                    Price = 300,
    //                    Rating = 3.5,
    //                    Stock = 30,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 1
    //                },

    //                new()
    //                {
    //                    Id = 16,
    //                    Name = "Product 1",
    //                    Description = "Description 1",
    //                    Price = 100,
    //                    Rating = 4.5,
    //                    Stock = 10,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 3
    //                },

    //                new()
    //                {
    //                    Id = 17,
    //                    Name = "Product 2",
    //                    Description = "Description 2",
    //                    Price = 200,
    //                    Rating = 4.0,
    //                    Stock = 20,
    //                    CreatedDate = DateTime.Now,
    //                    CategoryId = 2
    //                },















    //        };

    //    }
    //    public Task AddAsync(Product entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task DeleteAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public  Task<IEnumerable<Product>> GetAllAsync()
    //    {
            

    //        return Task.FromResult(_fakeCollection.AsEnumerable());
    //    }

    //    public Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
    //    {
    //      return Task.FromResult(_fakeCollection.Where(x => x.CategoryId == categoryId).AsEnumerable());
    //    }

    //    public Task<Product> GetByIdAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> IsExistsAync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Product>> Paginated(int pageNo, int pageSize)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Product>> SearchAsync(string name)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task UpdateAsync(Product entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
