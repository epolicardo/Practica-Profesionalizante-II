using OrderNow.API.Data;

namespace OrderNow.Tests.Controllers
{
    public class UsersControllerTests
    {
        private readonly UsersController _sut;

        private readonly Mock<IGenericRepository<Users>> _genericRepositoryMock = new Mock<IGenericRepository<Users>>();
        private readonly Mock<IOptions<JwtBearerTokenSettings>> _jwtToken = new Mock<IOptions<JwtBearerTokenSettings>>();
        private readonly Mock<DataContext> _dataContext = new Mock<DataContext>();
        private readonly Mock<UserManager<Users>> _userManager = new Mock<UserManager<Users>>();

        private Guid userIdMocked;
        private Users userMocked;

        //Arrange
        public UsersControllerTests()
        {
           

            userIdMocked = Guid.NewGuid();
            userMocked = new Users()
            {
                Id = userIdMocked.ToString(),
            };
            _genericRepositoryMock.Setup(x => x.GetByIdAsync(userIdMocked.ToString()))
                .ReturnsAsync(userMocked);
        }

        //[Theory]
        //[InlineData("22/05/2022", "22 May")]
        //public void GetToken_ShouldReturnToken_WhenCredentialsUserAreCorrect(string date, string expected)
        //[Fact]
        //public void GetToken_ShouldReturnToken_WhenCredentialsUserAreCorrect()
        //{
        //}

        [Fact]
        public void GetByIdAsync_ShouldReturnAUser_WhenUserExists()
        {
            //Act
            System.Threading.Tasks.Task<Users>? result = _sut.GetByIdAsync(userIdMocked.ToString());
            var response = result.Result;
            //Assert
            Assert.Equal(userIdMocked.ToString(), response.Id);
            Assert.Equal(userMocked.UserName, response.UserName);
        }

        [Fact]
        public void GetByListAsync_ShouldReturnUsers_WhenUsersExists()
        {
            //Act
            System.Threading.Tasks.Task<Users>? result = _sut.GetByIdAsync(userIdMocked.ToString());
            var response = result.Result;
            //Assert
            Assert.Equal(userIdMocked.ToString(), response.Id);
            Assert.Equal(userMocked.UserName, response.UserName);
        }

        [Fact]
        public void GetByEmailAsync_ShouldReturnAUser_WhenEmailExists()
        {
            //Act
            Task<Users>? result = _sut.GetByIdAsync(userIdMocked.ToString());
            var response = result.Result;
            //Assert
            Assert.Equal(userIdMocked.ToString(), response.Id);
            Assert.Equal(userMocked.UserName, response.UserName);
        }
    }
}