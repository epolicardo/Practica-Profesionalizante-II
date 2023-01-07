//using OrderNow.API.Data;

//namespace OrderNow.Tests.Controllers
//{
//    public class UsersControllerTests
//    {
//        private readonly UsersController _sut;



//        private Guid userIdMocked;
//        private Users userMocked;

//        //Arrange
//        public UsersControllerTests()
//        {
           

//            userIdMocked = Guid.NewGuid();
//            userMocked = new Users()
//            {
//                Id = userIdMocked.ToString(),
//            };
          
//        }

      

        

//        [Fact]
//        public void GetByIdAsync_ShouldReturnAUser_WhenUserExists()
//        {
//            //Act
//            System.Threading.Tasks.Task<Users>? result = _sut.GetByIdAsync(userIdMocked);
//            var response = result.Result;
//            //Assert
//            Assert.Equal(userIdMocked.ToString(), response.Id);
//            Assert.Equal(userMocked.UserName, response.UserName);
//        }

//        [Fact]
//        public void GetByListAsync_ShouldReturnUsers_WhenUsersExists()
//        {
//            //Act
//            System.Threading.Tasks.Task<Users>? result = _sut.GetByIdAsync(userIdMocked);
//            var response = result.Result;
//            //Assert
//            Assert.Equal(userIdMocked.ToString(), response.Id);
//            Assert.Equal(userMocked.UserName, response.UserName);
//        }

//        [Fact]
//        public void GetByEmailAsync_ShouldReturnAUser_WhenEmailExists()
//        {
//            //Act
//            Task<Users>? result = _sut.GetByIdAsync(userIdMocked);
//            var response = result.Result;
//            //Assert
//            Assert.Equal(userIdMocked.ToString(), response.Id);
//            Assert.Equal(userMocked.UserName, response.UserName);
//        }
//    }
//}