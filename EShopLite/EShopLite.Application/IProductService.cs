using EShopLite.Domain;

namespace EShopLite.Application
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}