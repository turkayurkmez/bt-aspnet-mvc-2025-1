using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Domain.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchAsync(string name);
        //Kategoriye göre ürünleri getirir.

        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    }
}
