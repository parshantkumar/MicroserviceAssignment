using System;
using System.Collections.Generic;
using System.Text;
using UserService.Shared.Model;

namespace UserService.Shared.Interface
{
   public interface IUserManager
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int productId);
        bool InsertUser(User User);
        bool DeleteUser(int userId);
    }
}
