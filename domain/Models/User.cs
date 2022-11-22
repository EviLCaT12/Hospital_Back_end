using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }

        public User() : this(0, "", "", "", "", new Role()) { }
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
