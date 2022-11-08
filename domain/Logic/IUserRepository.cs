using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Models;

namespace domain.Logic
{
     public interface IUserRepository : IRepository<User>
    {
        bool IsUserExist(string login);
        bool CreateUser(User user);
        User? GetUserByLogin(string login);
    }
}
