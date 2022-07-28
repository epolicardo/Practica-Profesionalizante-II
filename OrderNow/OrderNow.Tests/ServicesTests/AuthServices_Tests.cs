using OrderNow.API.Services.Auth;

namespace OrderNow.Tests.Services
{
    public class AuthServices_Tests
    {
        private readonly AuthServices _sut;
        private readonly Mock<IUsersServices> _usersServicesMock = new Mock<IUsersServices>();
        private readonly Mock<IJwtTokenGenerator> _jwtGenerator = new Mock<IJwtTokenGenerator>();


        public AuthServices_Tests()
        {
            _sut = new AuthServices(
                _usersServicesMock.Object,
                _jwtGenerator.Object);
        }

        [Fact]
        public void Register_ShouldRegisterANewUser_WhenDataIsValid()
        {
            


        }

        [Theory]
        [InlineData("pizzeria-popular-rc", true)]
        [InlineData("pizzeria-popular-ric", false)]
        public void LoginShouldGiveATokenWhenUserAlreadyExists(string URL, bool expected) { }

        [Fact]
        public void LogoutShouldClearTokenWhenIsCalled() { }


    }
}