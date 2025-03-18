using EShopLite.Application.DataTransferObjects;

namespace EShopLite.MVC.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductListDisplay>   Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public int? CategoryId { get; set; }

    }
}
