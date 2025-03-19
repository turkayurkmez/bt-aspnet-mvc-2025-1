using EShopLite.Application.DataTransferObjects;
using EShopLite.Domain;

namespace EShopLite.Application
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListDisplay>> GetProducts(int? page=null, int? pageSize=null);
        Task<IEnumerable<ProductListDisplay>> GetProductsByCategory(int categoryId, int? page = null, int? pageSize = null);
        Task<int> TotalProductsCount(int? categoryId);

        Task<ProductItemForBasket> GetProductById(int id);

    }
}