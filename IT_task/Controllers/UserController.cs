using domain.UseCases;
using domain.Models;
using Microsoft.AspNetCore.Mvc;
using IT_task.Views;

namespace IT_task.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserUseCases _usecases;
        public UserController(UserUseCases usecases)
        {
            _usecases = usecases;
        }

        [HttpGet("login")]
        public ActionResult<UserSearchView> GetUserByLogin(string login)
        {
            if (login == string.Empty)
            {
                return Problem(statusCode: 404, detail: "Пустой логин");
            }

            var userRes = _usecases.GetUserByLogin(login);
            if (userRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: userRes.Error);
            }

            return Ok(new UserSearchView
            {
                Id = userRes.Value.Id,
                Login = userRes.Value.Login,
                Password = userRes.Value.Password,
                PhoneNumber = userRes.Value.PhoneNumber,
                FullName = userRes.Value.FullName,
                Role = userRes.Value.Role
            });
        }

        [HttpGet("is_user")]
        public ActionResult IsUserExists (string login)
        {
            var userRes = _usecases.IsUserExists(login);

            if(userRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: userRes.Error);
            }

            return Ok(userRes.Value);
        }

        [HttpPost("register")]
        public ActionResult UserRegister(string login, string password, string phoneNumber, string fullName, Role role) 
        { 
            User user = new User(0, login, password, phoneNumber, fullName, role);
            var userRes = _usecases.Register(user);
            if (userRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: userRes.Error);
            }
            return Ok(userRes.Value);
        }
    }
}
