using domain.Models;
using DataBase.Models;
using System.Runtime.CompilerServices;

namespace DataBase.Converts
{
    public static class UserConverter
    {
        public static User? ToDomain(this UserModel model)
        {
            return new User
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName,
                Role = model.Role
            };
        }

        public static UserModel? ToModel(this User model)
        {
            return new UserModel
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName,
                Role = model.Role
            };
        }
    }
}
