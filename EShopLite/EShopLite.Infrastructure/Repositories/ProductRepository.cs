using EShopLite.Domain;
using EShopLite.Domain.Contracts;
using EShopLite.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Infrastructure.Repositories
{
    public class ProductRepository(EshopLiteDbContext dbContext) : IProductRepository
    {
        public async Task AddAsync(Product entity)
        {

            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();

        }

        public async Task<int> Count(int? categoryId)
        {
            return categoryId.HasValue ? await dbContext.Products.CountAsync(x=>x.CategoryId==categoryId)
                                       : await dbContext.Products.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
           return await dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await dbContext.Products.Where(x => x.CategoryId == categoryId).ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetByCategoryWithPaging(int categoryId, int pageNo, int pageSize)
        {
            var startIndex = (pageNo - 1) * pageSize;
            var endIndex = startIndex + pageSize;
            return await dbContext.Products
                .Where(x => x.CategoryId == categoryId)
                .OrderBy(x => x.Id)
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync();
               
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<bool> IsExistsAync(int id)
        {
           return await dbContext.Products.AnyAsync(x => x.Id == id);
        }

        public async  Task<IEnumerable<Product>> Paginated(int pageNo, int pageSize)
        {
            var startIndex = (pageNo - 1) * pageSize;
            var endIndex = startIndex + pageSize;

            var result = await dbContext.Products.OrderBy(p=>p.Id).Skip(startIndex).Take(pageSize).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string name)
        {
           return await dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public Task UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}
