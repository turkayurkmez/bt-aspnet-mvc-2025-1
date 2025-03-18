using EShopLite.Domain;
using EShopLite.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await categoryRepository.GetAllAsync();
        }
    }
}
