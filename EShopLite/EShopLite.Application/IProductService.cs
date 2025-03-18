using EShopLite.Application.DataTransferObjects;
using EShopLite.Domain;

namespace EShopLite.Application
{
    public interface IProductService
    {
        IEnumerable<ProductListDisplay> GetProducts();
    }
}