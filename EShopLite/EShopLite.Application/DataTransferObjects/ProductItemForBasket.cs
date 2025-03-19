using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application.DataTransferObjects
{
    public record ProductItemForBasket(int ProductId, string ProductName, decimal Price, string? ImageUrl);

}
