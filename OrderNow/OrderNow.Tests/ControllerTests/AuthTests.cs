//using OrderNow.API.Controllers.V1;
//using OrderNow.API.Services.Auth;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OrderNow.Tests.ControllerTests
//{
  
//    public class AuthTests
//    {


//        private readonly Mock<IUsersServices>  _usersServices = new();
//        private readonly AuthController _sut;
//        private readonly Mock<IJwtTokenGenerator> _jwtGenerator = new Mock<IJwtTokenGenerator>();


//        public AuthTests()
//        {
//            _sut = new AuthController(_jwtGenerator.Object, _usersServices.Object);
//        }

//        [Theory]
//        [InlineData("epolicardo", "Em1Li4N*", "")]
//        public void GetToken_ShouldReturnToken_WhenCredentialsUserAreCorrect(string user, string password, string expected)
//        {
//         //   _sut.Login()

//        }
//    }
//}
