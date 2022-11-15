using domain.Models;

namespace DataBase.Models
{
    class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
    }
}
