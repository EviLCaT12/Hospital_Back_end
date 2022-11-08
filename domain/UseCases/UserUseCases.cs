using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Logic;
using domain.Models;

namespace domain.UseCases
{
    public class UserUseCases
    {
        private readonly IUserRepository _db;

        public UserUseCases(IUserRepository db)
        {
            _db = db;
        }

        public Result<User>GetUserByLogin(string login)
        {
            if(string.IsNullOrEmpty(login))
            {
                return Result.Fail<User>("Invalid login");
            }

            var user = _db.GetUserByLogin(login);
            return user != null ? Result.Ok(user) : Result.Fail<User>("No users with such login");
        }

        public Result<bool>IsUserExists(string login)
        {
            if (!_db.IsUserExist(login))
            {
                return Result.Fail<bool>("User does not exist");
            }
            else
            {
                return Result.Ok(_db.IsUserExist(login));
            }
        }

        public Result<User> Register(User user)
        {
            var isValid = user.IsValid();
            if (isValid.IsFailure)
            {
                return Result.Fail<User>("Invalid input data:" + isValid.Error);
            }
            else if (!_db.IsUserExist(user.Login))
            {
                return Result.Fail<User>("User is already exist");
            }
            else
            {
                return _db.CreateUser(user) ? Result.Ok(user) : Result.Fail<User>("Error while creating. Try again later");
            }
        }

    }
}
