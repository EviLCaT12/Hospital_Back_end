using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class User
    {
        int Id { get; set; }
        public string Login { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
        string FullName { get; set; }
        Role Role { get; set; }

        public User(int id, string login, string password, string phoneNumber, string fullName, Role role)
        {
            Id = id;
            Login = login;
            Password = password;
            PhoneNumber = phoneNumber;
            FullName = fullName;
            Role = role;
        }
        public Result IsValid()
        {
            if (string.IsNullOrEmpty(Login))
            {
                return Result.Fail("Invalid login");
            }
            if (string.IsNullOrEmpty(Password))
            {
                return Result.Fail("Invalid password");
            }
            else if (string.IsNullOrEmpty(PhoneNumber))
            {
                return Result.Fail("Invalid phone number");
            }
            else if (string.IsNullOrEmpty(FullName))
            {
                return Result.Fail("Invalid full name");
            }
            else if (string.IsNullOrEmpty(FullName))
            {
                return Result.Fail("Invalid full name");
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}
