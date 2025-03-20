using EShopLite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopLite.Application
{
    public class UserService : IUserService
    {
        private List<User> _users;
        public UserService()
        {
            _users = new()
             {
                  new User {Id = 1, UserName="ecey", FullName="Ece Yağcı", Email="e.y@test.com", Password="123", Role="admin"},
                  new User {Id = 2, UserName="zeynep", FullName="Zeynep Yalçın", Email="zey@test.com" , Password="123", Role="user"},
                  new User { Id = 3, UserName="turkay", FullName="Türkay Ürkmez", Email="tu@test.com", Password="123", Role="editor" }
             };

        }

       public User? ValidateUser(string userName, string password)
        {
            return _users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

        }
    }
}
