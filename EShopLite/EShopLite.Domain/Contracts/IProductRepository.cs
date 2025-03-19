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

        Task<IEnumerable<Product>> Paginated(int pageNo, int pageSize);
        Task<IEnumerable<Product>> GetByCategoryWithPaging(int categoryId, int pageNo, int pageSize);

        Task<int> Count(int? categoryId);
    }
}
