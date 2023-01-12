using domain.Logic;
using domain.Models;
using DataBase.Converts;

namespace DataBase.Repository
{
    public class UserRepo : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(User item)
        {
           _context.Users.Add(item.ToModel());
            return true; 
        }

        public bool Delete(User item)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == item.Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            return false;
        }

        public IEnumerable<User?> GetAllItem()
        {
            var _users = _context.Users.ToList();
            var users = _users.Select(x => x.ToDomain()).ToList();
            return users;
        }

        public User? GetItemById(int id)
        {
            var user = _context.Users.FirstOrDefault(_x => _x.Id == id);
            return user?.ToDomain();
        }

        public User? GetUserByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            return user?.ToDomain();
        }

        public bool IsUserExist(string login)
        {
            var res = _context.Users.FirstOrDefault(u =>u.Login == login);
            return res != null; 
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(User item)
        {
           _context.Users.Update(item.ToModel());
            return true;
        }
    }
}
