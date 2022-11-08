using System.Xml.Linq;
using Xunit;
using domain.UseCases;
using domain.Logic;
using domain.Models;
using Moq;

namespace Tests
{
    public class UserTest
    {
        private readonly UserUseCases _userUseCases;
        private readonly Mock<IUserRepository> _userRepositoryMock;


        public UserTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userUseCases = new UserUseCases(_userRepositoryMock.Object);
        }

        [Fact]
        public void LoginIsEmptyOrNull_ShouldFail()
        {
            var res = _userUseCases.GetUserByLogin(string.Empty);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid login", res.Error); 
        }

        [Fact]
        public void UserNotFound_ShouldFail()
        {
            
            _userRepositoryMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                .Returns(() => null);

            var res = _userUseCases.GetUserByLogin("qwertyuiop"); 

            Assert.True(res.IsFailure);
            Assert.Equal("No users with such login", res.Error); 
        }

        [Fact]
        public void UserIsExist_shouldFail()
        {
            _userRepositoryMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                .Returns(() => null);

            var res = _userUseCases.IsUserExists("ecrynqwe8crynqwcyr");

            Assert.True(res.IsFailure);
            Assert.Equal("User does not exist", res.Error);
        }

        [Fact]

        public void IsNotValidRegister_shouldFail()
        {
            User user = new User(1, "", "123123", "1", "TIM", Role.Patient);

            var res = _userUseCases.Register(user);
            Assert.True(res.IsFailure);
            Assert.Equal("Invalid input data:Invalid login", res.Error);
        }
    }
}
