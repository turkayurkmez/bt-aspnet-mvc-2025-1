using EShopLite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetCategories();
    }
}
