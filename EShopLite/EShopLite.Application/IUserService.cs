using EShopLite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
